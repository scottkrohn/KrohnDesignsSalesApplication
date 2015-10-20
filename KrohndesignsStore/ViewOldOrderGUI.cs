using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KrohndesignsStore
{
	public partial class ViewOldOrderGUI : Form
	{

		private Form previousForm;
		public ViewOldOrderGUI(Form previous) {
			InitializeComponent();
			previousForm = previous;
		}

		private void closeButton_Click(object sender, EventArgs e) {
			this.Close();
			previousForm.Visible = true;	
		}

		// Load the completed order information into the listview.
		private void ViewOldOrderGUI_Load(object sender, EventArgs e) {
			List<Pair<int, ShoppingCart.Cart>> orders = getOrders();
			for(int i = 0; i < orders.Count; i++) {
				ListViewItem item = new ListViewItem(Convert.ToString(orders[i].itemOne));
				item.SubItems.Add(orders[i].itemTwo.getTotalPrice().ToString());
				item.SubItems.Add(orders[i].itemTwo.getTotalShipping().ToString());
				item.SubItems.Add(orders[i].itemTwo.itemCount().ToString());
				double totalCost = orders[i].itemTwo.getTotalShipping() + orders[i].itemTwo.getTotalPrice();
				Console.WriteLine(totalCost);
				item.SubItems.Add(Convert.ToString(totalCost));
				ordersListView.Items.Add(item);
			}
		}

		/*
		 * Get all completed orders from the database and return them in a Pair where
		 * the first item is the order number and the second item is Cart object containing
		 * the order data.
		*/
		private List<Pair<int, ShoppingCart.Cart>> getOrders() {
			List<Pair<int, ShoppingCart.Cart>> orders = new List<Pair<int, ShoppingCart.Cart>>();
			string queryString = "SELECT * FROM skrohn_kddb.orders";
			DataTable dt = DatabaseAccess.selectDB(queryString);
			for(int i = 0; i < dt.Rows.Count; i++) {
				int orderNumber = Convert.ToInt32(dt.Rows[i][0]);
				ShoppingCart.Cart cart = DatabaseAccess.getOrder(orderNumber);
				orders.Add(new Pair<int,ShoppingCart.Cart>(orderNumber, cart));
			}
			return orders;
		}

	}
}
