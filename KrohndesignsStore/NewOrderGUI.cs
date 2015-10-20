using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KrohndesignsStore
{
    public partial class NewOrderGUI : Form
    {
        private Form previousForm;
        private ShoppingCart.Cart cart;

		// Static sconce values
		const double STANDARD_SCONCE_HEIGHT = 18;
		const double STANDARD_BOX_LENGTH = 30;

        public NewOrderGUI(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm;
            cart = new ShoppingCart.Cart();
        }

        // Close the New Order dialog.
        private void cancelButton_Click(object sender, EventArgs e)
        {
            // Check if the cart is empty and display a confirmation dialog to delete the cart if it's not empty.
            if(cart.itemCount() > 0){
                string messageText = "Are you sure you want to cancel this order and delete the shopping cart?";
                string buttonText = "Confirm Delete Cart";
                DialogResult confirmDialog = MessageBox.Show(messageText, buttonText, MessageBoxButtons.YesNo);
                if(confirmDialog == DialogResult.Yes){
                    this.Close();
                    previousForm.Visible = true;
                }
                // return to the New Order dialog if the user doesn't want to delete the cart.
                return;
            }
            // Close the New Order dialog if the cart is empty.
            this.Close();
            previousForm.Visible = true;
        }

        private void NewOrderGUI_Load(object sender, EventArgs e)
        {
            chalkboard_standardRadio.Checked = true;
            sconce_standardRadio.Checked = true;
			box_standardRadio.Checked = true;
			updateStandardBoxPrice();
			updateStandardSconcePrice();
        }

        private void addToCartButton_Click(object sender, EventArgs e)
        {
            try{
                if(tabContol.SelectedTab == chalkboardTab){
                    ShoppingCart.Chalkboard board = getChalkboardOrder();
                    for(int i = 0; i < chalkboard_countNumeric.Value; i++){
                        cart.addItem(board);
                    }
                    clearAllChalkboardFields();
                }
                else if(tabContol.SelectedTab == sconceTab){
					ShoppingCart.Sconce sconce = getSconceOrder();
					for(int i = 0; i < sconce_countNumeric.Value; i++){
						cart.addItem(sconce);
					}
					clearAllSconceFields();
                }
                else if(tabContol.SelectedTab == boxTab){
					ShoppingCart.Box weddingBox = getBoxOrder();
					for(int i = 0; i < box_countNumeric.Value; i++){
						cart.addItem(weddingBox);
					}
					clearAllBoxFields();
                }
                else if(tabContol.SelectedTab == organizerTab){

                }
                else if(tabContol.SelectedTab == masonSconceTab){

                }
                else{
                    throw new Exception("You must select a type of item to add to the cart");
                }
				MyMessageBox box = new MyMessageBox("Item added to cart");
				box.StartPosition = FormStartPosition.CenterParent;
				box.ShowDialog();
            }
            catch(Exception ex){
                MyMessageBox box = new MyMessageBox(ex.Message);
                box.StartPosition = FormStartPosition.CenterParent;
                box.ShowDialog();
            }
        }

        /**************************** GENERAL ADD TO CART FUNCTIONS ****************************/
        /***************************************************************************************/

        private void viewCartButton_Click(object sender, EventArgs e)
        {
            ViewCartDialog viewCart = new ViewCartDialog(cart);
            viewCart.StartPosition = FormStartPosition.CenterParent;
            viewCart.ShowDialog();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            clearAllChalkboardFields();
			clearAllSconceFields();
        }


        // Add the order to the database of completed orders, then clear the shopping cart.
        public void checkout(){
            if(cart.itemCount() > 0){
                string orderData = "";
                // Check for multiples of the same item to add to orderData string.
                for(int i = 0; i < cart.itemCount(); i++){
                    for(int count = 0; count < cart.getItem(i).itemTwo;  count++){
                        orderData += cart.getItem(i).itemOne.toDataString(); 
                    }
                }

                // Create the MySql query using the orderData string.
                string queryString = string.Format("INSERT INTO skrohn_kddb.orders (orderdata) VALUES (\"{0}\")", orderData);
                // Submit the query to the database, clear the cart if successful. Display success message.
                if(DatabaseAccess.insertDB(queryString)){
                    cart.emptyCart();
                    MyMessageBox box = new MyMessageBox("Order successfully submitted.");
                    box.StartPosition = FormStartPosition.CenterParent;
                    box.ShowDialog();
                }
            }
            else{
                MyMessageBox box = new MyMessageBox("Your cart is empty.");
                box.StartPosition = FormStartPosition.CenterParent;
                box.ShowDialog();
            }
        }

		// Prevents alpha chars and more than one . in the custom price boxes.
        private void customPriceBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar)){
                e.Handled = true;
            }

            if((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)){
                e.Handled = true;
            }
        }

        /***************************************************************************************/
        /***************************************************************************************/


        /****************************** CHALKBOARD ORDER FUNCTIONS ******************************/
        /***************************************************************************************/

        // Check to make sure a selection has been made for all necessary combo boxes.
        private bool validateChalkboardData(){
            if(chalkboard_stainCombo.Text == "" || chalkboard_frameCombo.Text == "" ||
                chalkboard_magneticCombo.Text == ""|| chalkboard_hangingCombo.Text == ""){
				return false;
            }
            if(chalkboard_customRadio.Checked == true && (chalkboard_customPriceBox.Text == "" || chalkboard_customShippingBox.Text =="")){
				return false; 
            }
            return true;
        }

        // Return a pait of the length/width of the size selection based on SizeComboBox.
        private Pair<double, double> getSizeSelection(){
            if(chalkboard_standardRadio.Checked == true){
                string sizeString = chalkboard_sizeComboBox.Text;
                switch(sizeString){
                    case("12\" x 24\""):
                        return new Pair<double,double>(12, 24);
                    case("18\" x 24\""):
                        return new Pair<double,double>(18, 24);
                    case("18\" x 36\""):
                        return new Pair<double,double>(18, 36);
                    case("24\" x 24\""):
                        return new Pair<double,double>(24, 24);
                    case("20\" x 30\""):
                        return new Pair<double,double>(20, 30);
                    case("24\" x 36\""):
                        return new Pair<double,double>(24, 36);
                    case("24\" x 48\""):
                        return new Pair<double,double>(24, 48);
                    case("30\" x 48\""):
                        return new Pair<double,double>(30, 48);
                    case("36\" x 48\""):
                        return new Pair<double,double>(36, 48);
                    default:
                        throw new Exception("No size was selected");
                }
            }
            else {
                if(((double)chalkboard_lengthNumeric.Value > 36 && (double)chalkboard_widthNumeric.Value > 36) ||
                    ((double)chalkboard_lengthNumeric.Value <= 6 || (double)chalkboard_widthNumeric.Value <=6 )){
                    throw new Exception("Invalid chalkboard dimensions");
                }
                return new Pair<double,double>((double)chalkboard_lengthNumeric.Value, (double)chalkboard_widthNumeric.Value);
            }
        }

        

        // Checked if input is valid, then returns a chalkboard object if it is.
        private ShoppingCart.Chalkboard getChalkboardOrder(){
			// Throws exception if input is invalid.
            if(!validateChalkboardData()){
				throw new Exception("Invalid/incomplete for a Chalkboard order");
			}
            ShoppingCart.Item.Stain_Color stain = OrderDataGatherer.getStainColor(chalkboard_stainCombo.Text);
            ShoppingCart.Chalkboard.Frame_Style frame = OrderDataGatherer.getFrameStyle(chalkboard_frameCombo.Text);
            ShoppingCart.Chalkboard.Hanging_Direction dir = OrderDataGatherer.getHangingDirection(chalkboard_hangingCombo.Text);
            ShoppingCart.Chalkboard.Magnetic_Type mag = OrderDataGatherer.getMagneticType(chalkboard_magneticCombo.Text);
            double length = getSizeSelection().itemOne;
            double width = getSizeSelection().itemTwo;
            Pair<double,double> pricing;
            if(chalkboard_standardRadio.Checked == true){
                pricing = getPricing(length, width, mag);
            }
            else{
                pricing = new Pair<double,double>(Double.Parse(chalkboard_customPriceBox.Text), Double.Parse(chalkboard_customShippingBox.Text));
            }
            return new ShoppingCart.Chalkboard(pricing.itemOne, pricing.itemTwo, ShoppingCart.Item.Item_Type.Board, stain, length, width, mag, frame, dir);
        }

        // Pricing for the standard sizes are stored in the database. This fuctions gets those prices based on the size.
        private Pair<double,double> getPricing(double length, double width, ShoppingCart.Chalkboard.Magnetic_Type mag){
            try{
                bool isMagnetic = (mag == ShoppingCart.Chalkboard.Magnetic_Type.Magnetic) ? true:false;
                string queryString = string.Format("SELECT * FROM skrohn_kddb.pricing_chalkboard WHERE length=\"{0}\" AND width=\"{1}\" AND magnetic={2}", length, width, isMagnetic);
                DataTable data = DatabaseAccess.selectDB(queryString);
                return new Pair<double,double>(Convert.ToDouble(data.Rows[0][4]), Convert.ToDouble(data.Rows[0][5]));
            }
            catch(Exception ex){
                MyMessageBox box = new MyMessageBox(ex.Message);
                box.StartPosition = FormStartPosition.CenterParent;
                box.ShowDialog();
            }
            throw new Exception("Unable to locate pricing data.");
        }

        private void chalkboard_standardRadio_CheckedChanged(object sender, EventArgs e)
        {
            chalkboard_standardPanel.Visible = true;
            chalkboard_standardCostPanel.Visible = true;
            chalkboard_customCostPanel.Visible = false;
            chalkboard_customSizePanel.Visible = false;
        }

        private void chalkboard_customRadio_CheckedChanged(object sender, EventArgs e)
        {
            chalkboard_customSizePanel.Visible = true;
            chalkboard_customCostPanel.Visible = true;
            chalkboard_standardPanel.Visible = false;
            chalkboard_standardCostPanel.Visible = false;
        }

        private void checkoutButton_Click(object sender, EventArgs e)
        {
            checkout();
        }

        private void chalkboard_sizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateStandardChalkboardPricing();
        }

        private void chalkboard_magneticCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateStandardChalkboardPricing();
        }

        // Update the labels for standard sized chalkboards if the size and the magnetic type have been selected.
        private void updateStandardChalkboardPricing(){
            if(chalkboard_sizeComboBox.SelectedIndex != -1 && chalkboard_magneticCombo.SelectedIndex != -1){
                Pair<double,double> cost = getSizeSelection();
                ShoppingCart.Chalkboard.Magnetic_Type mag = OrderDataGatherer.getMagneticType(chalkboard_magneticCombo.Text);
                Pair<double,double> pricing = getPricing(cost.itemOne, cost.itemTwo, mag);
                chalkboard_standardPriceDisplay.Text = string.Format("${0:#.00}", pricing.itemOne);
                chalkboard_standardShippingDisplay.Text = string.Format("${0:#.00}", pricing.itemTwo);
            }
        }

		// Clear all of the fields on the chalkboard order page.
		private void clearAllChalkboardFields(){
            chalkboard_sizeComboBox.SelectedIndex = -1;
            chalkboard_stainCombo.SelectedIndex = -1;
            chalkboard_widthNumeric.Value = 6;
            chalkboard_lengthNumeric.Value = 6;
            chalkboard_countNumeric.Value = 1;
            chalkboard_magneticCombo.SelectedIndex = -1;
            chalkboard_hangingCombo.SelectedIndex = -1;
            chalkboard_frameCombo.SelectedIndex = -1;
            chalkboard_customPriceBox.Clear();
            chalkboard_customShippingBox.Clear();
            chalkboard_standardPriceDisplay.Text = "";
            chalkboard_standardShippingDisplay.Text = "";
        }


        /***************************************************************************************/
        /***************************************************************************************/

        /******************************** SCONCE ORDER FUNCTIONS *******************************/
        /***************************************************************************************/

        private void sconce_standardRadio_CheckedChanged(object sender, EventArgs e)
        {
            sconce_customOrderPanel.Visible = false; 
            sconce_standardCostPanel.Visible = true;
			if(sconce_standardRadio.Checked){
				updateStandardSconcePrice();
			}
        }

		private void updateStandardSconcePrice(){
			Pair<double,double> pricing = getSconcePrice();
			sconce_standardPriceDisplay.Text = string.Format("${0:#.00}", pricing.itemOne);
			sconce_standardShippingDisplay.Text = string.Format("${0:#.00}", pricing.itemTwo);
		}

        private void sconce_customRadio_CheckedChanged(object sender, EventArgs e)
        {
            sconce_customOrderPanel.Visible = true;
            sconce_standardCostPanel.Visible = false;
        }

        private ShoppingCart.Sconce getSconceOrder(){
			if(!validateSconceOrder()){
				throw new Exception("Invalid/incomplete order data for a Sconce order.");
			}
            ShoppingCart.Item.Stain_Color stain = OrderDataGatherer.getStainColor(sconce_stainCombo.Text);
			Pair<double,double> cost = getSconcePrice();
            return new ShoppingCart.Sconce(cost.itemOne, cost.itemTwo, ShoppingCart.Item.Item_Type.Sconce, stain, getSconceHeight());
        }

		private double getSconceHeight(){
			if(sconce_standardRadio.Checked){
				return STANDARD_SCONCE_HEIGHT;
			}
			return Convert.ToDouble(sconce_numeric.Value);
		}

        private bool validateSconceOrder(){
			if(sconce_stainCombo.Text == "" || (sconce_customRadio.Checked && sconce_customPriceBox.Text == "" || sconce_customShippingBox.Text == "")){
				return false;
            }	
            return true;
        }

        private Pair<double,double> getSconcePrice(){
            if(sconce_customRadio.Checked){
				return new Pair<double,double>(Double.Parse(sconce_customPriceBox.Text), Double.Parse(sconce_customShippingBox.Text));
            }

            // If this isn't a custom order, get the current cost of the standard sized sconce from the database.
            DataTable dt = DatabaseAccess.selectDB(string.Format("SELECT * FROM skrohn_kddb.pricing_sconce WHERE length={0};", STANDARD_SCONCE_HEIGHT));
            return new Pair<double,double>(Convert.ToDouble(dt.Rows[0][2]), Convert.ToDouble(dt.Rows[0][3]));
		}

		private void clearAllSconceFields(){
			sconce_stainCombo.SelectedIndex = -1;
			sconce_customPriceBox.Text = "";
			sconce_customShippingBox.Text = "";
		}

        /***************************************************************************************/
        /***************************************************************************************/

		/********************************** BOX ORDER FUNCTIONS ********************************/
        /***************************************************************************************/

		private ShoppingCart.Box getBoxOrder(){
			ShoppingCart.Item.Stain_Color stain = OrderDataGatherer.getStainColor(box_stainCombo.Text);
			double length = getBoxLength();
			Pair<double,double> pricing = getBoxPrice();
			return new ShoppingCart.Box(pricing.itemOne, pricing.itemOne, ShoppingCart.Item.Item_Type.Box, stain, length);
		}

		// Check if the input for a Wedding Box order is valid. 
		private bool validateBoxOrder(){
			if(box_stainCombo.Text == "" || (box_customRadio.Checked && box_customPriceBox.Text == "" || box_customShippingBox.Text == "")){
				return false;
			}	
			return true;
		}

		private double getBoxLength(){
			if(box_standardRadio.Checked){
				return STANDARD_BOX_LENGTH;
			}
			return Convert.ToDouble(box_customNumeric.Value);
		}

		private Pair<double,double> getBoxPrice(){
			if(box_customRadio.Checked){
				return new Pair<double,double>(Double.Parse(box_customPriceBox.Text), Double.Parse(box_customShippingBox.Text));
			}
			DataTable dt = DatabaseAccess.selectDB(string.Format("SELECT * FROM skrohn_kddb.pricing_box WHERE length={0}", STANDARD_BOX_LENGTH));
			return new Pair<double,double>(Convert.ToDouble(dt.Rows[0][2]), Convert.ToDouble(dt.Rows[0][3]));
		}

		private void clearAllBoxFields(){
			box_stainCombo.SelectedIndex = -1;
			box_customPriceBox.Text = "";
			box_customShippingBox.Text = "";
		}

		private void updateStandardBoxPrice(){
			Pair<double,double> pricing = getBoxPrice();
			box_standardPriceDisplay.Text = string.Format("${0:#.00}", pricing.itemOne);
			box_standardShippingDisplay.Text = string.Format("${0:#.00}", pricing.itemTwo);
		}

		private void box_standardRadio_CheckedChanged(object sender, EventArgs e)
		{
			box_customPricePanel.Visible = false;
			box_standardCostPanel.Visible = true;
			if(box_standardRadio.Checked){
				updateStandardBoxPrice();
			}
		}

		private void box_customRadio_CheckedChanged(object sender, EventArgs e)
		{
			box_customPricePanel.Visible = true;
			box_standardCostPanel.Visible = false;
		}


        /***************************************************************************************/
        /***************************************************************************************/
    }
}
