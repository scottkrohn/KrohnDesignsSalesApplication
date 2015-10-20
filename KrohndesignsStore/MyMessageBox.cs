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
    public partial class MyMessageBox : Form
    {
        public MyMessageBox(string message)
        {
            InitializeComponent();
            this.message.Text = message;
            this.message.ReadOnly = true;
            this.message.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void setMessage(string message){
            this.message.Text = message;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MyMessageBox_Load(object sender, EventArgs e)
        {

        }

    }
}
