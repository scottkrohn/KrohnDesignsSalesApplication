namespace KrohndesignsStore
{
    partial class EmployeeScreen
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
			this.createOrderButton = new System.Windows.Forms.Button();
			this.viewOrdersButton = new System.Windows.Forms.Button();
			this.logoutButton = new System.Windows.Forms.Button();
			this.directionsLabel = new System.Windows.Forms.Label();
			this.bannerPhotoBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.bannerPhotoBox)).BeginInit();
			this.SuspendLayout();
			// 
			// createOrderButton
			// 
			this.createOrderButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.createOrderButton.Location = new System.Drawing.Point(280, 274);
			this.createOrderButton.Name = "createOrderButton";
			this.createOrderButton.Size = new System.Drawing.Size(240, 60);
			this.createOrderButton.TabIndex = 2;
			this.createOrderButton.Text = "Create New Order";
			this.createOrderButton.UseVisualStyleBackColor = true;
			this.createOrderButton.Click += new System.EventHandler(this.createOrderButton_Click);
			// 
			// viewOrdersButton
			// 
			this.viewOrdersButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.viewOrdersButton.Location = new System.Drawing.Point(280, 340);
			this.viewOrdersButton.Name = "viewOrdersButton";
			this.viewOrdersButton.Size = new System.Drawing.Size(240, 60);
			this.viewOrdersButton.TabIndex = 3;
			this.viewOrdersButton.Text = "View Orders";
			this.viewOrdersButton.UseVisualStyleBackColor = true;
			this.viewOrdersButton.Click += new System.EventHandler(this.viewOrdersButton_Click);
			// 
			// logoutButton
			// 
			this.logoutButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.logoutButton.Location = new System.Drawing.Point(280, 406);
			this.logoutButton.Name = "logoutButton";
			this.logoutButton.Size = new System.Drawing.Size(240, 60);
			this.logoutButton.TabIndex = 4;
			this.logoutButton.Text = "Logout";
			this.logoutButton.UseVisualStyleBackColor = true;
			this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
			// 
			// directionsLabel
			// 
			this.directionsLabel.AutoSize = true;
			this.directionsLabel.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.directionsLabel.Location = new System.Drawing.Point(299, 191);
			this.directionsLabel.Name = "directionsLabel";
			this.directionsLabel.Size = new System.Drawing.Size(204, 24);
			this.directionsLabel.TabIndex = 6;
			this.directionsLabel.Text = "Please select an option.";
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
			// EmployeeScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Controls.Add(this.bannerPhotoBox);
			this.Controls.Add(this.directionsLabel);
			this.Controls.Add(this.logoutButton);
			this.Controls.Add(this.viewOrdersButton);
			this.Controls.Add(this.createOrderButton);
			this.Name = "EmployeeScreen";
			this.Text = "EmployeeScreen";
			this.Load += new System.EventHandler(this.EmployeeScreen_Load);
			((System.ComponentModel.ISupportInitialize)(this.bannerPhotoBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createOrderButton;
        private System.Windows.Forms.Button viewOrdersButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label directionsLabel;
        private System.Windows.Forms.PictureBox bannerPhotoBox;
    }
}