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
    public partial class RegisterGUI : Form
    {
        Form previousForm;
        public RegisterGUI(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            previousForm.Visible = true;
            this.Close();
        }

        // Validate username/password, check for existing username, then add new user to database if valid.
        private void createAccountButton_Click(object sender, EventArgs e)
        {
            try{
                // Validate username and password format.
                if(!validUsername(usernameTextbox.Text)){
                    throw new Exception("Invalid username.\nUsername must be alphanumeric.");
                }
                else if(!validPassword(passwordTextbox.Text)){
                    throw new Exception("Invalid password.\nPassword must be at least 6 characters long and contain at least 1 number.");
                }

                // Check if the username already exists in the database.
                string queryString = string.Format("Select * FROM skrohn_kddb.login WHERE username=\"{0}\"", usernameTextbox.Text);
                DataTable dt = DatabaseAccess.selectDB(queryString);
                if(dt.Rows.Count > 0){
                    // If the username exists, throw exception.
                    throw new Exception("Username already exists, please select a new username.");
                }
                else{
                    // If the username didn't exist, add it to the database.
                    string insertString = string.Format("INSERT INTO skrohn_kddb.login (username, pw) VALUES (\"{0}\", \"{1}\")", usernameTextbox.Text, passwordTextbox.Text);
                    DatabaseAccess.insertDB(insertString);
                }

                // Display message if registration was successful.
                MyMessageBox box = new MyMessageBox("Registration successful. Please login with your username and password.");
                box.StartPosition = FormStartPosition.CenterParent;
                box.ShowDialog();
                this.Close();
                previousForm.Visible = true;
            }
            catch(Exception ex){
                MyMessageBox box = new MyMessageBox(ex.Message);
                box.StartPosition = FormStartPosition.CenterParent;
                box.ShowDialog();
            }
        }

        //Check if the username is valid.
        bool validUsername(string name){
            // Check if any character in the username is NOT alphanumeric.
            foreach(char ch in name){
                if(!char.IsLetterOrDigit(ch)){
                    return false;
                }
            }
            if(name == ""){
                return false;
            }
            return true;
        }

        // Check if the password is valid. 
        bool validPassword(string pass){
            // If password length is less than 6, it's not valid.
            if(pass.Length < 6){
                return false;
            }
           
            // If the password doesn't contain a digit, it's not valid.
            if(!pass.Any(char.IsDigit)){
                return false;
            }
            return true;
        }

        private void RegisterGUI_Load(object sender, EventArgs e)
        {

        }
    }
}
