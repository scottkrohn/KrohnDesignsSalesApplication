namespace KrohndesignsStore
{
    partial class ViewCartDialog
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
            this.bannerPhotoBox = new System.Windows.Forms.PictureBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.cartListView = new System.Windows.Forms.ListView();
            this.columnItemNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnShipping = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDetails = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.totalTagLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.totalShippingLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bannerPhotoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // bannerPhotoBox
            // 
            this.bannerPhotoBox.ErrorImage = global::KrohndesignsStore.Properties.Resources.iusb_760x100_14040570_r4p5;
            this.bannerPhotoBox.Image = global::KrohndesignsStore.Properties.Resources.iusb_760x100_14040570_r4p5;
            this.bannerPhotoBox.InitialImage = global::KrohndesignsStore.Properties.Resources.iusb_760x100_14040570_r4p5;
            this.bannerPhotoBox.Location = new System.Drawing.Point(12, 12);
            this.bannerPhotoBox.Name = "bannerPhotoBox";
            this.bannerPhotoBox.Size = new System.Drawing.Size(760, 98);
            this.bannerPhotoBox.TabIndex = 15;
            this.bannerPhotoBox.TabStop = false;
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(350, 520);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(100, 30);
            this.closeButton.TabIndex = 16;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // cartListView
            // 
            this.cartListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnItemNumber,
            this.columnCount,
            this.columnPrice,
            this.columnShipping,
            this.columnDetails,
            this.columnTotal});
            this.cartListView.FullRowSelect = true;
            this.cartListView.GridLines = true;
            this.cartListView.Location = new System.Drawing.Point(12, 116);
            this.cartListView.Name = "cartListView";
            this.cartListView.Size = new System.Drawing.Size(760, 309);
            this.cartListView.TabIndex = 17;
            this.cartListView.UseCompatibleStateImageBehavior = false;
            this.cartListView.View = System.Windows.Forms.View.Details;
            // 
            // columnItemNumber
            // 
            this.columnItemNumber.Text = "Item #";
            // 
            // columnCount
            // 
            this.columnCount.Text = "Count";
            this.columnCount.Width = 42;
            // 
            // columnPrice
            // 
            this.columnPrice.Text = "Price";
            this.columnPrice.Width = 48;
            // 
            // columnShipping
            // 
            this.columnShipping.Text = "Shipping";
            this.columnShipping.Width = 53;
            // 
            // columnDetails
            // 
            this.columnDetails.Text = "Details";
            this.columnDetails.Width = 461;
            // 
            // columnTotal
            // 
            this.columnTotal.Text = "Total";
            // 
            // totalTagLabel
            // 
            this.totalTagLabel.AutoSize = true;
            this.totalTagLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTagLabel.Location = new System.Drawing.Point(288, 437);
            this.totalTagLabel.Name = "totalTagLabel";
            this.totalTagLabel.Size = new System.Drawing.Size(79, 25);
            this.totalTagLabel.TabIndex = 18;
            this.totalTagLabel.Text = "Total: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(256, 471);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "Shipping:";
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.Location = new System.Drawing.Point(373, 437);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(0, 25);
            this.totalLabel.TabIndex = 20;
            // 
            // totalShippingLabel
            // 
            this.totalShippingLabel.AutoSize = true;
            this.totalShippingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalShippingLabel.Location = new System.Drawing.Point(373, 471);
            this.totalShippingLabel.Name = "totalShippingLabel";
            this.totalShippingLabel.Size = new System.Drawing.Size(0, 25);
            this.totalShippingLabel.TabIndex = 21;
            // 
            // ViewCartDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.totalShippingLabel);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.totalTagLabel);
            this.Controls.Add(this.cartListView);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.bannerPhotoBox);
            this.Name = "ViewCartDialog";
            this.Text = "ViewCartDialog";
            this.Load += new System.EventHandler(this.ViewCartDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bannerPhotoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox bannerPhotoBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ListView cartListView;
        private System.Windows.Forms.ColumnHeader columnItemNumber;
        private System.Windows.Forms.ColumnHeader columnCount;
        private System.Windows.Forms.ColumnHeader columnPrice;
        private System.Windows.Forms.ColumnHeader columnShipping;
        private System.Windows.Forms.ColumnHeader columnDetails;
        private System.Windows.Forms.ColumnHeader columnTotal;
        private System.Windows.Forms.Label totalTagLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label totalShippingLabel;
    }
}