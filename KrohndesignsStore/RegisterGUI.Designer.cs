namespace KrohndesignsStore
{
    partial class RegisterGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.createAccountButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.directionsLabel = new System.Windows.Forms.Label();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.usernameReqLabel = new System.Windows.Forms.Label();
            this.passwordReqLabel = new System.Windows.Forms.Label();
            this.bannerPhotoBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bannerPhotoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // createAccountButton
            // 
            this.createAccountButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createAccountButton.Location = new System.Drawing.Point(300, 354);
            this.createAccountButton.Name = "createAccountButton";
            this.createAccountButton.Size = new System.Drawing.Size(200, 60);
            this.createAccountButton.TabIndex = 3;
            this.createAccountButton.Text = "Create Account";
            this.createAccountButton.UseVisualStyleBackColor = true;
            this.createAccountButton.Click += new System.EventHandler(this.createAccountButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(300, 420);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(200, 60);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // directionsLabel
            // 
            this.directionsLabel.AutoSize = true;
            this.directionsLabel.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directionsLabel.Location = new System.Drawing.Point(231, 193);
            this.directionsLabel.Name = "directionsLabel";
            this.directionsLabel.Size = new System.Drawing.Size(338, 24);
            this.directionsLabel.TabIndex = 5;
            this.directionsLabel.Text = "Please select a username and password:";
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextbox.Location = new System.Drawing.Point(300, 247);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(200, 26);
            this.usernameTextbox.TabIndex = 6;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(211, 247);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(83, 20);
            this.usernameLabel.TabIndex = 7;
            this.usernameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(216, 279);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(78, 20);
            this.passwordLabel.TabIndex = 9;
            this.passwordLabel.Text = "Password";
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextbox.Location = new System.Drawing.Point(300, 279);
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.Size = new System.Drawing.Size(200, 26);
            this.passwordTextbox.TabIndex = 8;
            // 
            // usernameReqLabel
            // 
            this.usernameReqLabel.AutoSize = true;
            this.usernameReqLabel.Location = new System.Drawing.Point(506, 255);
            this.usernameReqLabel.Name = "usernameReqLabel";
            this.usernameReqLabel.Size = new System.Drawing.Size(98, 13);
            this.usernameReqLabel.TabIndex = 10;
            this.usernameReqLabel.Text = "(alphanumeric only)";
            // 
            // passwordReqLabel
            // 
            this.passwordReqLabel.AutoSize = true;
            this.passwordReqLabel.Location = new System.Drawing.Point(506, 287);
            this.passwordReqLabel.Name = "passwordReqLabel";
            this.passwordReqLabel.Size = new System.Drawing.Size(211, 13);
            this.passwordReqLabel.TabIndex = 11;
            this.passwordReqLabel.Text = "(at least 6 chars long, must include number)";
            // 
            // bannerPhotoBox
            // 
            this.bannerPhotoBox.ErrorImage = global::KrohndesignsStore.Properties.Resources.iusb_760x100_14040570_r4p5;
            this.bannerPhotoBox.Image = global::KrohndesignsStore.Properties.Resources.iusb_760x100_14040570_r4p5;
            this.bannerPhotoBox.InitialImage = global::KrohndesignsStore.Properties.Resources.iusb_760x100_14040570_r4p5;
            this.bannerPhotoBox.Location = new System.Drawing.Point(12, 30);
            this.bannerPhotoBox.Name = "bannerPhotoBox";
            this.bannerPhotoBox.Size = new System.Drawing.Size(760, 98);
            this.bannerPhotoBox.TabIndex = 15;
            this.bannerPhotoBox.TabStop = false;
            // 
            // RegisterGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.bannerPhotoBox);
            this.Controls.Add(this.passwordReqLabel);
            this.Controls.Add(this.usernameReqLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordTextbox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.directionsLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createAccountButton);
            this.Name = "RegisterGUI";
            this.Text = "Employee Registration";
            this.Load += new System.EventHandler(this.RegisterGUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bannerPhotoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createAccountButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label directionsLabel;
        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.Label usernameReqLabel;
        private System.Windows.Forms.Label passwordReqLabel;
        private System.Windows.Forms.PictureBox bannerPhotoBox;

    }
}