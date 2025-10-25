namespace AdvDatabase
{
    partial class TransactionsUC
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
            this.txtTransactionSearch = new System.Windows.Forms.TextBox();
            this.btnSearchTransaction = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvTransactionHistory = new System.Windows.Forms.DataGridView();
            this.btnNewTransaction = new System.Windows.Forms.Button();
            this.cmbTimeFilter = new System.Windows.Forms.ComboBox();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.btnVoidTransaction = new System.Windows.Forms.Button();
            this.btnResumeTransaction = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.txtTransactionSearch);
            this.panel1.Controls.Add(this.btnSearchTransaction);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 71);
            this.panel1.TabIndex = 0;
            // 
            // txtTransactionSearch
            // 
            this.txtTransactionSearch.Location = new System.Drawing.Point(399, 21);
            this.txtTransactionSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtTransactionSearch.Multiline = true;
            this.txtTransactionSearch.Name = "txtTransactionSearch";
            this.txtTransactionSearch.Size = new System.Drawing.Size(473, 34);
            this.txtTransactionSearch.TabIndex = 30;
            // 
            // btnSearchTransaction
            // 
            this.btnSearchTransaction.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchTransaction.Location = new System.Drawing.Point(881, 21);
            this.btnSearchTransaction.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchTransaction.Name = "btnSearchTransaction";
            this.btnSearchTransaction.Size = new System.Drawing.Size(113, 38);
            this.btnSearchTransaction.TabIndex = 31;
            this.btnSearchTransaction.Text = "Search";
            this.btnSearchTransaction.UseVisualStyleBackColor = true;
            this.btnSearchTransaction.Click += new System.EventHandler(this.btnSearchTransaction_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft New Tai Lue", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(11, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 45);
            this.label3.TabIndex = 29;
            this.label3.Text = "Transaction";
            // 
            // dgvTransactionHistory
            // 
            this.dgvTransactionHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactionHistory.Location = new System.Drawing.Point(0, 150);
            this.dgvTransactionHistory.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTransactionHistory.Name = "dgvTransactionHistory";
            this.dgvTransactionHistory.RowHeadersWidth = 51;
            this.dgvTransactionHistory.Size = new System.Drawing.Size(1009, 449);
            this.dgvTransactionHistory.TabIndex = 1;
            // 
            // btnNewTransaction
            // 
            this.btnNewTransaction.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnNewTransaction.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewTransaction.ForeColor = System.Drawing.Color.Transparent;
            this.btnNewTransaction.Location = new System.Drawing.Point(19, 87);
            this.btnNewTransaction.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewTransaction.Name = "btnNewTransaction";
            this.btnNewTransaction.Size = new System.Drawing.Size(188, 42);
            this.btnNewTransaction.TabIndex = 29;
            this.btnNewTransaction.Text = "New Transaction";
            this.btnNewTransaction.UseVisualStyleBackColor = false;
            this.btnNewTransaction.Click += new System.EventHandler(this.btnNewTransaction_Click);
            // 
            // cmbTimeFilter
            // 
            this.cmbTimeFilter.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTimeFilter.FormattingEnabled = true;
            this.cmbTimeFilter.Items.AddRange(new object[] {
            "Today",
            "Last 7 Days",
            "By Cashier"});
            this.cmbTimeFilter.Location = new System.Drawing.Point(850, 87);
            this.cmbTimeFilter.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTimeFilter.Name = "cmbTimeFilter";
            this.cmbTimeFilter.Size = new System.Drawing.Size(144, 33);
            this.cmbTimeFilter.TabIndex = 31;
            this.cmbTimeFilter.Text = "Filter By";
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Items.AddRange(new object[] {
            "Completed",
            "Voided",
            "Pending",
            "Return/Refund"});
            this.cmbStatusFilter.Location = new System.Drawing.Point(686, 87);
            this.cmbStatusFilter.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(144, 33);
            this.cmbStatusFilter.TabIndex = 30;
            this.cmbStatusFilter.Text = "Status Filter";
            // 
            // btnVoidTransaction
            // 
            this.btnVoidTransaction.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnVoidTransaction.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoidTransaction.ForeColor = System.Drawing.Color.Transparent;
            this.btnVoidTransaction.Location = new System.Drawing.Point(443, 87);
            this.btnVoidTransaction.Margin = new System.Windows.Forms.Padding(4);
            this.btnVoidTransaction.Name = "btnVoidTransaction";
            this.btnVoidTransaction.Size = new System.Drawing.Size(98, 42);
            this.btnVoidTransaction.TabIndex = 32;
            this.btnVoidTransaction.Text = "Void";
            this.btnVoidTransaction.UseVisualStyleBackColor = false;
            this.btnVoidTransaction.Click += new System.EventHandler(this.btnVoidTransaction_Click);
            // 
            // btnResumeTransaction
            // 
            this.btnResumeTransaction.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnResumeTransaction.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResumeTransaction.ForeColor = System.Drawing.Color.Transparent;
            this.btnResumeTransaction.Location = new System.Drawing.Point(227, 87);
            this.btnResumeTransaction.Margin = new System.Windows.Forms.Padding(4);
            this.btnResumeTransaction.Name = "btnResumeTransaction";
            this.btnResumeTransaction.Size = new System.Drawing.Size(188, 42);
            this.btnResumeTransaction.TabIndex = 33;
            this.btnResumeTransaction.Text = "resume transaction";
            this.btnResumeTransaction.UseVisualStyleBackColor = false;
            this.btnResumeTransaction.Click += new System.EventHandler(this.btnResumeTransaction_Click);
            // 
            // TransactionsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.btnResumeTransaction);
            this.Controls.Add(this.btnVoidTransaction);
            this.Controls.Add(this.cmbTimeFilter);
            this.Controls.Add(this.cmbStatusFilter);
            this.Controls.Add(this.btnNewTransaction);
            this.Controls.Add(this.dgvTransactionHistory);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TransactionsUC";
            this.Size = new System.Drawing.Size(1007, 599);
            this.Load += new System.EventHandler(this.TransactionsUC_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvTransactionHistory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNewTransaction;
        private System.Windows.Forms.TextBox txtTransactionSearch;
        private System.Windows.Forms.Button btnSearchTransaction;
        private System.Windows.Forms.ComboBox cmbTimeFilter;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Button btnVoidTransaction;
        private System.Windows.Forms.Button btnResumeTransaction;
    }
}
