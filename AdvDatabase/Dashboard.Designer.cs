namespace AdvDatabase
{
    partial class DashboardUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDashboardSearch = new System.Windows.Forms.TextBox();
            this.btnDashboardSearch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.DashboardP = new System.Windows.Forms.GroupBox();
            this.panelLowStockItems = new System.Windows.Forms.Panel();
            this.lblLowStockCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelExpiredItems = new System.Windows.Forms.Panel();
            this.lblExpiredItemsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelTotalProducts = new System.Windows.Forms.Panel();
            this.lblTotalProductsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelTodaySale = new System.Windows.Forms.Panel();
            this.lblTodaySaleValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvRecentTransactions = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvProactiveAlerts = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.DashboardP.SuspendLayout();
            this.panelLowStockItems.SuspendLayout();
            this.panelExpiredItems.SuspendLayout();
            this.panelTotalProducts.SuspendLayout();
            this.panelTodaySale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProactiveAlerts)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.txtDashboardSearch);
            this.panel1.Controls.Add(this.btnDashboardSearch);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 71);
            this.panel1.TabIndex = 0;
            // 
            // txtDashboardSearch
            // 
            this.txtDashboardSearch.Location = new System.Drawing.Point(392, 20);
            this.txtDashboardSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtDashboardSearch.Multiline = true;
            this.txtDashboardSearch.Name = "txtDashboardSearch";
            this.txtDashboardSearch.Size = new System.Drawing.Size(473, 34);
            this.txtDashboardSearch.TabIndex = 32;
            // 
            // btnDashboardSearch
            // 
            this.btnDashboardSearch.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboardSearch.Location = new System.Drawing.Point(875, 20);
            this.btnDashboardSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnDashboardSearch.Name = "btnDashboardSearch";
            this.btnDashboardSearch.Size = new System.Drawing.Size(113, 38);
            this.btnDashboardSearch.TabIndex = 33;
            this.btnDashboardSearch.Text = "Search";
            this.btnDashboardSearch.UseVisualStyleBackColor = true;
            this.btnDashboardSearch.Click += new System.EventHandler(this.btnDashboardSearch_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Agency FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(25, 16);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 41);
            this.label7.TabIndex = 7;
            this.label7.Text = "Dashboard";
            // 
            // DashboardP
            // 
            this.DashboardP.BackColor = System.Drawing.Color.Snow;
            this.DashboardP.Controls.Add(this.panelLowStockItems);
            this.DashboardP.Controls.Add(this.panelExpiredItems);
            this.DashboardP.Controls.Add(this.panelTotalProducts);
            this.DashboardP.Controls.Add(this.panelTodaySale);
            this.DashboardP.Font = new System.Drawing.Font("Microsoft New Tai Lue", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DashboardP.Location = new System.Drawing.Point(20, 94);
            this.DashboardP.Margin = new System.Windows.Forms.Padding(4);
            this.DashboardP.Name = "DashboardP";
            this.DashboardP.Padding = new System.Windows.Forms.Padding(4);
            this.DashboardP.Size = new System.Drawing.Size(949, 192);
            this.DashboardP.TabIndex = 0;
            this.DashboardP.TabStop = false;
            this.DashboardP.Text = "OverView";
            // 
            // panelLowStockItems
            // 
            this.panelLowStockItems.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panelLowStockItems.Controls.Add(this.lblLowStockCount);
            this.panelLowStockItems.Controls.Add(this.label4);
            this.panelLowStockItems.Location = new System.Drawing.Point(721, 36);
            this.panelLowStockItems.Margin = new System.Windows.Forms.Padding(4);
            this.panelLowStockItems.Name = "panelLowStockItems";
            this.panelLowStockItems.Size = new System.Drawing.Size(197, 133);
            this.panelLowStockItems.TabIndex = 3;
            // 
            // lblLowStockCount
            // 
            this.lblLowStockCount.AutoSize = true;
            this.lblLowStockCount.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowStockCount.Location = new System.Drawing.Point(88, 72);
            this.lblLowStockCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLowStockCount.Name = "lblLowStockCount";
            this.lblLowStockCount.Size = new System.Drawing.Size(24, 27);
            this.lblLowStockCount.TabIndex = 5;
            this.lblLowStockCount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 27);
            this.label4.TabIndex = 4;
            this.label4.Text = "Low Stock Items";
            // 
            // panelExpiredItems
            // 
            this.panelExpiredItems.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panelExpiredItems.Controls.Add(this.lblExpiredItemsCount);
            this.panelExpiredItems.Controls.Add(this.label2);
            this.panelExpiredItems.Location = new System.Drawing.Point(489, 36);
            this.panelExpiredItems.Margin = new System.Windows.Forms.Padding(4);
            this.panelExpiredItems.Name = "panelExpiredItems";
            this.panelExpiredItems.Size = new System.Drawing.Size(197, 133);
            this.panelExpiredItems.TabIndex = 3;
            // 
            // lblExpiredItemsCount
            // 
            this.lblExpiredItemsCount.AutoSize = true;
            this.lblExpiredItemsCount.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpiredItemsCount.Location = new System.Drawing.Point(87, 72);
            this.lblExpiredItemsCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExpiredItemsCount.Name = "lblExpiredItemsCount";
            this.lblExpiredItemsCount.Size = new System.Drawing.Size(24, 27);
            this.lblExpiredItemsCount.TabIndex = 4;
            this.lblExpiredItemsCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Expired Items";
            // 
            // panelTotalProducts
            // 
            this.panelTotalProducts.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panelTotalProducts.Controls.Add(this.lblTotalProductsCount);
            this.panelTotalProducts.Controls.Add(this.label3);
            this.panelTotalProducts.Location = new System.Drawing.Point(257, 36);
            this.panelTotalProducts.Margin = new System.Windows.Forms.Padding(4);
            this.panelTotalProducts.Name = "panelTotalProducts";
            this.panelTotalProducts.Size = new System.Drawing.Size(197, 133);
            this.panelTotalProducts.TabIndex = 2;
            // 
            // lblTotalProductsCount
            // 
            this.lblTotalProductsCount.AutoSize = true;
            this.lblTotalProductsCount.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProductsCount.Location = new System.Drawing.Point(89, 72);
            this.lblTotalProductsCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalProductsCount.Name = "lblTotalProductsCount";
            this.lblTotalProductsCount.Size = new System.Drawing.Size(24, 27);
            this.lblTotalProductsCount.TabIndex = 3;
            this.lblTotalProductsCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total Products";
            // 
            // panelTodaySale
            // 
            this.panelTodaySale.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panelTodaySale.Controls.Add(this.lblTodaySaleValue);
            this.panelTodaySale.Controls.Add(this.label1);
            this.panelTodaySale.Location = new System.Drawing.Point(25, 36);
            this.panelTodaySale.Margin = new System.Windows.Forms.Padding(4);
            this.panelTodaySale.Name = "panelTodaySale";
            this.panelTodaySale.Size = new System.Drawing.Size(197, 133);
            this.panelTodaySale.TabIndex = 1;
            // 
            // lblTodaySaleValue
            // 
            this.lblTodaySaleValue.AutoSize = true;
            this.lblTodaySaleValue.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodaySaleValue.Location = new System.Drawing.Point(93, 72);
            this.lblTodaySaleValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTodaySaleValue.Name = "lblTodaySaleValue";
            this.lblTodaySaleValue.Size = new System.Drawing.Size(24, 27);
            this.lblTodaySaleValue.TabIndex = 2;
            this.lblTodaySaleValue.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Today\'s Sale";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 305);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(160, 31);
            this.label5.TabIndex = 0;
            this.label5.Text = "Recent Transaction";
            // 
            // dgvRecentTransactions
            // 
            this.dgvRecentTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentTransactions.Location = new System.Drawing.Point(20, 345);
            this.dgvRecentTransactions.Margin = new System.Windows.Forms.Padding(4);
            this.dgvRecentTransactions.Name = "dgvRecentTransactions";
            this.dgvRecentTransactions.RowHeadersWidth = 51;
            this.dgvRecentTransactions.Size = new System.Drawing.Size(560, 250);
            this.dgvRecentTransactions.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(596, 305);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(202, 27);
            this.label6.TabIndex = 5;
            this.label6.Text = "Proactive Alerts List";
            // 
            // dgvProactiveAlerts
            // 
            this.dgvProactiveAlerts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProactiveAlerts.Location = new System.Drawing.Point(602, 345);
            this.dgvProactiveAlerts.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProactiveAlerts.Name = "dgvProactiveAlerts";
            this.dgvProactiveAlerts.RowHeadersWidth = 51;
            this.dgvProactiveAlerts.Size = new System.Drawing.Size(368, 250);
            this.dgvProactiveAlerts.TabIndex = 7;
            // 
            // DashboardUC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.dgvProactiveAlerts);
            this.Controls.Add(this.dgvRecentTransactions);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DashboardP);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DashboardUC";
            this.Size = new System.Drawing.Size(1007, 624);
            this.Load += new System.EventHandler(this.DashboardUC_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.DashboardP.ResumeLayout(false);
            this.panelLowStockItems.ResumeLayout(false);
            this.panelLowStockItems.PerformLayout();
            this.panelExpiredItems.ResumeLayout(false);
            this.panelExpiredItems.PerformLayout();
            this.panelTotalProducts.ResumeLayout(false);
            this.panelTotalProducts.PerformLayout();
            this.panelTodaySale.ResumeLayout(false);
            this.panelTodaySale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProactiveAlerts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox DashboardP;
        private System.Windows.Forms.Panel panelLowStockItems;
        private System.Windows.Forms.Panel panelExpiredItems;
        private System.Windows.Forms.Panel panelTotalProducts;
        private System.Windows.Forms.Panel panelTodaySale;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvRecentTransactions;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvProactiveAlerts;
        private System.Windows.Forms.TextBox txtDashboardSearch;
        private System.Windows.Forms.Button btnDashboardSearch;
        private System.Windows.Forms.Label lblTodaySaleValue;
        private System.Windows.Forms.Label lblLowStockCount;
        private System.Windows.Forms.Label lblExpiredItemsCount;
        private System.Windows.Forms.Label lblTotalProductsCount;
    }
}
