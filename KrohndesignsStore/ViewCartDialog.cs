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
    public partial class ViewCartDialog : Form
    {
        ShoppingCart.Cart cart;
        public ViewCartDialog(ShoppingCart.Cart cart)
        {
            InitializeComponent();
            this.cart = cart;
            totalLabel.Text = string.Format("${0:#.00}", cart.getTotalPrice());
            totalShippingLabel.Text = string.Format("${0:#.00}", cart.getTotalShipping());
            
        }

        private void ViewCartDialog_Load(object sender, EventArgs e)
        {
            if(cart.itemCount() > 0){
                for(int i = 0; i < cart.itemCount(); i++){
                    ListViewItem item = new ListViewItem(Convert.ToString(cart.getItem(i).itemOne.getItemNumber()));
                    item.SubItems.Add(Convert.ToString(cart.getItem(i).itemTwo));
                    item.SubItems.Add(Convert.ToString(cart.getItem(i).itemOne.getPrice()));
                    item.SubItems.Add(Convert.ToString(cart.getItem(i).itemOne.getShipping()));
                    item.SubItems.Add(Convert.ToString(cart.getItem(i).itemOne.ToString()));
                    item.SubItems.Add(Convert.ToString((cart.getItem(i).itemOne.getPrice() + cart.getItem(i).itemOne.getShipping()) * cart.getItem(i).itemTwo));
                    cartListView.Items.Add(item);
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
