using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace KrohndesignsStore
{
    /************************************************************
     *  The Pair class is used as a container to store two related objects.
     *  The way in which they're related is up to the user. The main use
     *  of the Pair class for this application is as an entry in the Cart class.
     *  It represents an Item for sale and the quantity of that item in the cart.
     ************************************************************/
    public class Pair<TypeOne, TypeTwo>{
        public TypeOne itemOne; 
        public TypeTwo itemTwo;

        public Pair(TypeOne one, TypeTwo two){
            itemOne = one;
            itemTwo = two;
        }
    }

    /*
     * 
    */
    public class OrderDataGatherer{
        // Returns an enumeration based on a string that matches a stain type.
        public static ShoppingCart.Item.Stain_Color getStainColor(string stain){
            switch(stain){
                case "Ebony":
                    return ShoppingCart.Item.Stain_Color.Ebony;
                case "Red Mahogany":
                    return ShoppingCart.Item.Stain_Color.Red;
                case "Dark Red Mahogany":
                    return ShoppingCart.Item.Stain_Color.DarkRed;
                case "Classic Gray":
                    return ShoppingCart.Item.Stain_Color.Gray;
                case "Walnut":
                    return ShoppingCart.Item.Stain_Color.Walnut;
                case "Distressed White":
                    return ShoppingCart.Item.Stain_Color.White;
                default:
                    throw new Exception("Invalid stain selection.");
            }
        }

        public static ShoppingCart.Chalkboard.Frame_Style getFrameStyle(string frameStyle){
            switch(frameStyle){
                case "Mitered":
                    return ShoppingCart.Chalkboard.Frame_Style.Mitered;
                case "Straight":
                    return ShoppingCart.Chalkboard.Frame_Style.Straight;
                default:
                    throw new Exception("Invalid frame style selection.");
            }
        }

        public static ShoppingCart.Chalkboard.Magnetic_Type getMagneticType(string magneticType){
            switch(magneticType){
                case "Magnetic":
                    return ShoppingCart.Chalkboard.Magnetic_Type.Magnetic;
                case "Non-Magnetic":
                    return ShoppingCart.Chalkboard.Magnetic_Type.NonMagnetic;
                default:
                    throw new Exception("Invalid magnetic type selection.");
            }
        }

        public static ShoppingCart.Chalkboard.Hanging_Direction getHangingDirection(string hangingDirection){
            switch(hangingDirection){
                case "Horizontal":
                    return ShoppingCart.Chalkboard.Hanging_Direction.Horizontal;
                case "Vertical":
                    return ShoppingCart.Chalkboard.Hanging_Direction.Vertical;
                case "Both":
                    return ShoppingCart.Chalkboard.Hanging_Direction.Both;
                default:
                    throw new Exception("Invalid hanging direction selection.");
            }
        }
    }

    // The DatabaseAccess class provides different functions to access the kddb database.
    public class DatabaseAccess{

        // Returns an order based on an order number.
        public static ShoppingCart.Cart getOrder(int orderNumber){
            string queryString = string.Format("SELECT * FROM skrohn_kddb.orders WHERE ordernumber={0}", orderNumber);
            DataTable dt = DatabaseAccess.selectDB(queryString);

            if(dt.Rows.Count == 0){
                throw new Exception("No results found for order query.");
            }
            else if(dt.Rows.Count > 1){
                throw new Exception("Too many results returns from query for order.");
            }

            string orderData = (string)dt.Rows[0][1];
            return parseOrderData(orderData);
        }

        /* 
         * Parses a string of order information in the form of item numbers and price/shipping. Returns a 
         * ShoppingCart.Cart object full of the Items that were parsed.
         */
        private static ShoppingCart.Cart parseOrderData(string orderData){
            ShoppingCart.Cart cart = new ShoppingCart.Cart();
            // Split the orderData into parts, each representing 1 item. 
            string[] items = orderData.Split('/');
            foreach(string item in items){
                if(item != ""){
                    string[] parts = item.Split(',');
                    int orderNumber = Convert.ToInt32(parts[0]);
                    double orderPrice = Convert.ToDouble(parts[1]);
                    double orderShippingPrice = Convert.ToDouble(parts[2]);
                    ShoppingCart.Item nextItem = ItemNumberGenerator.getItemFromNumber(orderNumber);
                    nextItem.setCost(orderPrice, orderShippingPrice);
                    cart.addItem(nextItem);
                }
            }
            return cart;
        }

        // Perform an insert command into the kddb database using the command in 'insertCommand'
        public static bool insertDB(string insertCommand){
            try{
                string connectionInfo = "datasource=scottkrohn.com;port=3306;username=skrohn_root;password=refinnej8!";
                MySqlConnection myConnection = new MySqlConnection(connectionInfo);
                MySqlDataAdapter myData = new MySqlDataAdapter();
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myData);
                myConnection.Open();

                myData.InsertCommand = new MySqlCommand(insertCommand, myConnection);
                myData.InsertCommand.ExecuteReader();
                myConnection.Close();
                return true;
            }
            catch(Exception ex){
                MyMessageBox msgBox = new MyMessageBox(ex.Message);
                msgBox.StartPosition = FormStartPosition.CenterParent;
                msgBox.ShowDialog();
                return false;
            }
        }

        // Perform a select command on the kddb database using the command in 'selectCommand'
        public static DataTable selectDB(string selectCommand){
            DataTable dt = new DataTable();
            try{
                string connectionInfo = "server=sheep.arvixe.com;port=3306;username=skrohn_root;password=refinnej8!";
                MySqlConnection myConnection = new MySqlConnection(connectionInfo);
                MySqlDataAdapter myData = new MySqlDataAdapter();
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myData);
                myConnection.Open();

                myData.SelectCommand= new MySqlCommand(selectCommand, myConnection);
                myData.Fill(dt);
                myConnection.Close();
            }
            catch(Exception ex){
                MyMessageBox msgBox = new MyMessageBox(ex.Message);
                msgBox.StartPosition = FormStartPosition.CenterParent;
                msgBox.ShowDialog();
            }
            return dt;
        }
    }
}
