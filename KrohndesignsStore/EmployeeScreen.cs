using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KrohndesignsStore
{
    public partial class EmployeeScreen : Form
    {
        Form previousForm;
        public EmployeeScreen(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm;
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
            MyMessageBox box = new MyMessageBox("You're now logged out.");
            box.StartPosition = FormStartPosition.CenterParent;
            box.ShowDialog();
            previousForm.Visible = true;
        }

        private void createOrderButton_Click(object sender, EventArgs e)
        {
            NewOrderGUI newOrder = new NewOrderGUI(this);
            newOrder.StartPosition = FormStartPosition.CenterParent;
            this.Visible = false;
            newOrder.ShowDialog();
        }

        private void viewOrdersButton_Click(object sender, EventArgs e)
        {
			ViewOldOrderGUI oldOrderGUI = new ViewOldOrderGUI(this);
			oldOrderGUI.StartPosition = FormStartPosition.CenterParent;
			oldOrderGUI.ShowDialog();
            // TEMPORARY, NEED TO CREATE GUI TO VIEW OLD ORDERS

            string queryString = "SELECT * FROM skrohn_kddb.orders";
            DataTable dt = DatabaseAccess.selectDB(queryString);

            List<ShoppingCart.Cart> orders = new List<ShoppingCart.Cart>();
            for(int row = 0; row < dt.Rows.Count; row++){
                orders.Add(DatabaseAccess.getOrder((int)dt.Rows[row][0]));
            }
            
            foreach(ShoppingCart.Cart order in orders){
                Console.WriteLine(order.ToString());
            }
        }

		private void EmployeeScreen_Load(object sender, EventArgs e)
		{

		}
    }
}
