namespace KrohndesignsStore
{
	partial class ViewOldOrderGUI
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
			this.ordersListView = new System.Windows.Forms.ListView();
			this.selectLabel = new System.Windows.Forms.Label();
			this.orderNumberColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.priceColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.shippingColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.totalColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.itemCountColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.closeButton = new System.Windows.Forms.Button();
			this.viewOrderButton = new System.Windows.Forms.Button();
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
			this.bannerPhotoBox.TabIndex = 16;
			this.bannerPhotoBox.TabStop = false;
			// 
			// ordersListView
			// 
			this.ordersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.orderNumberColumn,
            this.priceColumn,
            this.shippingColumn,
            this.itemCountColumn,
            this.totalColumn});
			this.ordersListView.FullRowSelect = true;
			this.ordersListView.GridLines = true;
			this.ordersListView.Location = new System.Drawing.Point(12, 148);
			this.ordersListView.Name = "ordersListView";
			this.ordersListView.Size = new System.Drawing.Size(760, 309);
			this.ordersListView.TabIndex = 17;
			this.ordersListView.UseCompatibleStateImageBehavior = false;
			this.ordersListView.View = System.Windows.Forms.View.Details;
			// 
			// selectLabel
			// 
			this.selectLabel.AutoSize = true;
			this.selectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.selectLabel.Location = new System.Drawing.Point(274, 125);
			this.selectLabel.Name = "selectLabel";
			this.selectLabel.Size = new System.Drawing.Size(253, 20);
			this.selectLabel.TabIndex = 18;
			this.selectLabel.Text = "Please select an order to view.";
			// 
			// orderNumberColumn
			// 
			this.orderNumberColumn.Text = "Order Number";
			this.orderNumberColumn.Width = 124;
			// 
			// priceColumn
			// 
			this.priceColumn.Text = "Price";
			this.priceColumn.Width = 101;
			// 
			// shippingColumn
			// 
			this.shippingColumn.Text = "Shipping";
			this.shippingColumn.Width = 116;
			// 
			// totalColumn
			// 
			this.totalColumn.DisplayIndex = 4;
			this.totalColumn.Text = "Total Cost";
			this.totalColumn.Width = 281;
			// 
			// itemCountColumn
			// 
			this.itemCountColumn.DisplayIndex = 3;
			this.itemCountColumn.Text = "Items";
			this.itemCountColumn.Width = 133;
			// 
			// closeButton
			// 
			this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.closeButton.Location = new System.Drawing.Point(410, 520);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(100, 30);
			this.closeButton.TabIndex = 19;
			this.closeButton.Text = "Close";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// viewOrderButton
			// 
			this.viewOrderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.viewOrderButton.Location = new System.Drawing.Point(290, 520);
			this.viewOrderButton.Name = "viewOrderButton";
			this.viewOrderButton.Size = new System.Drawing.Size(100, 30);
			this.viewOrderButton.TabIndex = 20;
			this.viewOrderButton.Text = "View Order";
			this.viewOrderButton.UseVisualStyleBackColor = true;
			// 
			// ViewOldOrderGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Controls.Add(this.viewOrderButton);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.selectLabel);
			this.Controls.Add(this.ordersListView);
			this.Controls.Add(this.bannerPhotoBox);
			this.Name = "ViewOldOrderGUI";
			this.Text = "ViewOldOrderGUI";
			this.Load += new System.EventHandler(this.ViewOldOrderGUI_Load);
			((System.ComponentModel.ISupportInitialize)(this.bannerPhotoBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox bannerPhotoBox;
		private System.Windows.Forms.ListView ordersListView;
		private System.Windows.Forms.Label selectLabel;
		private System.Windows.Forms.ColumnHeader orderNumberColumn;
		private System.Windows.Forms.ColumnHeader priceColumn;
		private System.Windows.Forms.ColumnHeader shippingColumn;
		private System.Windows.Forms.ColumnHeader totalColumn;
		private System.Windows.Forms.ColumnHeader itemCountColumn;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.Button viewOrderButton;
	}
}