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
    public partial class LoginDialog: Form
    {
        public LoginDialog()
        {
            InitializeComponent();
        }

        private void loginButton_click(object sender, EventArgs e)
        {
            try{
                // Check for empty username or password
                if(usernameTextbox.Text == "" || passwordTextbox.Text == ""){
                    throw new Exception("You must enter a username and password.");
                }
                
                // Query the kddb database to check if the username/password combination are valid.
                string queryString = string.Format("SELECT * FROM skrohn_kddb.login WHERE username=\"{0}\" AND pw=\"{1}\"", usernameTextbox.Text, passwordTextbox.Text);
                DataTable dt = DatabaseAccess.selectDB(queryString);

                // Check if the query returned any rows with the specified username and password.
                if(dt.Rows.Count > 0){
                    // Valid username and password
                    MyMessageBox box = new MyMessageBox("Login successful.");
                    box.StartPosition = FormStartPosition.CenterParent;
                    box.ShowDialog();
                    this.Visible = false;
                    EmployeeScreen employeeGUI = new EmployeeScreen(this);
                    employeeGUI.StartPosition = FormStartPosition.CenterParent;
                    employeeGUI.ShowDialog();
                }
                else{
                    MyMessageBox box = new MyMessageBox("Invalid login information.");
                    box.StartPosition = FormStartPosition.CenterParent;
                    box.ShowDialog();
                }
            }
            catch(Exception ex){
                MyMessageBox box = new MyMessageBox(ex.Message);
                box.StartPosition = FormStartPosition.CenterParent;
                box.ShowDialog();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            RegisterGUI registrationGUI = new RegisterGUI(this);
            registrationGUI.StartPosition = FormStartPosition.CenterParent;
            registrationGUI.ShowDialog();
        }
    }
}

