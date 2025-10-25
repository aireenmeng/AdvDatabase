namespace AdvDatabase
{
    partial class NewTransactionForm
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
            this.btnCancelTransaction = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnAddtoCart = new System.Windows.Forms.Button();
            this.txtMoneyReceived = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbItemDiscount = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtItemQuantity = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTransactionType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblItemPrice = new System.Windows.Forms.Label();
            this.cmbProductSearch = new System.Windows.Forms.ComboBox();
            this.dgvCartItems = new System.Windows.Forms.DataGridView();
            this.lblGrandSubtotal = new System.Windows.Forms.Label();
            this.lblTaxAmount = new System.Windows.Forms.Label();
            this.lblTotalAmountDue = new System.Windows.Forms.Label();
            this.lblTotalDiscount = new System.Windows.Forms.Label();
            this.lblChangeDue = new System.Windows.Forms.Label();
            this.btnCompleteSale = new System.Windows.Forms.Button();
            this.btnHoldTransaction = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartItems)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelTransaction
            // 
            this.btnCancelTransaction.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelTransaction.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelTransaction.ForeColor = System.Drawing.Color.White;
            this.btnCancelTransaction.Location = new System.Drawing.Point(39, 502);
            this.btnCancelTransaction.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelTransaction.Name = "btnCancelTransaction";
            this.btnCancelTransaction.Size = new System.Drawing.Size(136, 80);
            this.btnCancelTransaction.TabIndex = 41;
            this.btnCancelTransaction.Text = "cancel transaction";
            this.btnCancelTransaction.UseVisualStyleBackColor = false;
            this.btnCancelTransaction.Click += new System.EventHandler(this.btnCancelTransaction_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnRemoveItem.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveItem.ForeColor = System.Drawing.Color.White;
            this.btnRemoveItem.Location = new System.Drawing.Point(237, 314);
            this.btnRemoveItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(112, 80);
            this.btnRemoveItem.TabIndex = 40;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.UseVisualStyleBackColor = false;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnAddtoCart
            // 
            this.btnAddtoCart.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAddtoCart.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddtoCart.ForeColor = System.Drawing.Color.White;
            this.btnAddtoCart.Location = new System.Drawing.Point(117, 314);
            this.btnAddtoCart.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddtoCart.Name = "btnAddtoCart";
            this.btnAddtoCart.Size = new System.Drawing.Size(112, 80);
            this.btnAddtoCart.TabIndex = 39;
            this.btnAddtoCart.Text = "Add to cart";
            this.btnAddtoCart.UseVisualStyleBackColor = false;
            this.btnAddtoCart.Click += new System.EventHandler(this.btnAddtoCart_Click);
            // 
            // txtMoneyReceived
            // 
            this.txtMoneyReceived.Location = new System.Drawing.Point(685, 462);
            this.txtMoneyReceived.Margin = new System.Windows.Forms.Padding(4);
            this.txtMoneyReceived.Multiline = true;
            this.txtMoneyReceived.Name = "txtMoneyReceived";
            this.txtMoneyReceived.Size = new System.Drawing.Size(204, 30);
            this.txtMoneyReceived.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(488, 467);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 25);
            this.label2.TabIndex = 36;
            this.label2.Text = "Money Recieved";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 278);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.TabIndex = 35;
            this.label1.Text = "Item Price";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(40, 139);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 25);
            this.label7.TabIndex = 29;
            this.label7.Text = "Product";
            // 
            // cmbItemDiscount
            // 
            this.cmbItemDiscount.FormattingEnabled = true;
            this.cmbItemDiscount.Items.AddRange(new object[] {
            "Senior Citizen",
            "PWD",
            "Seasonal/Promotional",
            "Employee "});
            this.cmbItemDiscount.Location = new System.Drawing.Point(237, 230);
            this.cmbItemDiscount.Margin = new System.Windows.Forms.Padding(4);
            this.cmbItemDiscount.Name = "cmbItemDiscount";
            this.cmbItemDiscount.Size = new System.Drawing.Size(204, 39);
            this.cmbItemDiscount.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(40, 187);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 25);
            this.label6.TabIndex = 31;
            this.label6.Text = "Quantity";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(40, 235);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 25);
            this.label8.TabIndex = 33;
            this.label8.Text = "Discount";
            // 
            // txtItemQuantity
            // 
            this.txtItemQuantity.Location = new System.Drawing.Point(237, 182);
            this.txtItemQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemQuantity.Multiline = true;
            this.txtItemQuantity.Name = "txtItemQuantity";
            this.txtItemQuantity.Size = new System.Drawing.Size(204, 30);
            this.txtItemQuantity.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(40, 89);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(158, 26);
            this.label10.TabIndex = 43;
            this.label10.Text = "Transaction Date";
            this.label10.UseMnemonic = false;
            // 
            // dtpTransactionDate
            // 
            this.dtpTransactionDate.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTransactionDate.Location = new System.Drawing.Point(237, 88);
            this.dtpTransactionDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpTransactionDate.Name = "dtpTransactionDate";
            this.dtpTransactionDate.Size = new System.Drawing.Size(204, 32);
            this.dtpTransactionDate.TabIndex = 42;
            this.dtpTransactionDate.UseWaitCursor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTransactionType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblItemPrice);
            this.groupBox1.Controls.Add(this.cmbProductSearch);
            this.groupBox1.Controls.Add(this.dtpTransactionDate);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtItemQuantity);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnRemoveItem);
            this.groupBox1.Controls.Add(this.cmbItemDiscount);
            this.groupBox1.Controls.Add(this.btnAddtoCart);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(476, 430);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Transaction";
            // 
            // cmbTransactionType
            // 
            this.cmbTransactionType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTransactionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbTransactionType.FormattingEnabled = true;
            this.cmbTransactionType.Items.AddRange(new object[] {
            "Sale (Default)",
            "Return"});
            this.cmbTransactionType.Location = new System.Drawing.Point(237, 28);
            this.cmbTransactionType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTransactionType.Name = "cmbTransactionType";
            this.cmbTransactionType.Size = new System.Drawing.Size(204, 39);
            this.cmbTransactionType.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 25);
            this.label3.TabIndex = 50;
            this.label3.Text = "transaction type";
            // 
            // lblItemPrice
            // 
            this.lblItemPrice.AutoSize = true;
            this.lblItemPrice.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemPrice.Location = new System.Drawing.Point(299, 278);
            this.lblItemPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.Size = new System.Drawing.Size(122, 25);
            this.lblItemPrice.TabIndex = 49;
            this.lblItemPrice.Text = "item rpice lbl";
            // 
            // cmbProductSearch
            // 
            this.cmbProductSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProductSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbProductSearch.FormattingEnabled = true;
            this.cmbProductSearch.Items.AddRange(new object[] {
            "Senior Citizen",
            "PWD",
            "Seasonal/Promotional",
            "Employee "});
            this.cmbProductSearch.Location = new System.Drawing.Point(237, 132);
            this.cmbProductSearch.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProductSearch.Name = "cmbProductSearch";
            this.cmbProductSearch.Size = new System.Drawing.Size(204, 39);
            this.cmbProductSearch.TabIndex = 48;
            // 
            // dgvCartItems
            // 
            this.dgvCartItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCartItems.Location = new System.Drawing.Point(513, 26);
            this.dgvCartItems.Name = "dgvCartItems";
            this.dgvCartItems.RowHeadersWidth = 51;
            this.dgvCartItems.RowTemplate.Height = 24;
            this.dgvCartItems.Size = new System.Drawing.Size(359, 288);
            this.dgvCartItems.TabIndex = 45;
            // 
            // lblGrandSubtotal
            // 
            this.lblGrandSubtotal.AutoSize = true;
            this.lblGrandSubtotal.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandSubtotal.Location = new System.Drawing.Point(694, 344);
            this.lblGrandSubtotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrandSubtotal.Name = "lblGrandSubtotal";
            this.lblGrandSubtotal.Size = new System.Drawing.Size(139, 25);
            this.lblGrandSubtotal.TabIndex = 44;
            this.lblGrandSubtotal.Text = "Grand Subtotal";
            // 
            // lblTaxAmount
            // 
            this.lblTaxAmount.AutoSize = true;
            this.lblTaxAmount.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxAmount.Location = new System.Drawing.Point(742, 408);
            this.lblTaxAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTaxAmount.Name = "lblTaxAmount";
            this.lblTaxAmount.Size = new System.Drawing.Size(91, 25);
            this.lblTaxAmount.TabIndex = 45;
            this.lblTaxAmount.Text = "Tax Label";
            // 
            // lblTotalAmountDue
            // 
            this.lblTotalAmountDue.AutoSize = true;
            this.lblTotalAmountDue.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmountDue.Location = new System.Drawing.Point(722, 433);
            this.lblTotalAmountDue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalAmountDue.Name = "lblTotalAmountDue";
            this.lblTotalAmountDue.Size = new System.Drawing.Size(111, 25);
            this.lblTotalAmountDue.TabIndex = 46;
            this.lblTotalAmountDue.Text = "Grand Total";
            // 
            // lblTotalDiscount
            // 
            this.lblTotalDiscount.AutoSize = true;
            this.lblTotalDiscount.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDiscount.Location = new System.Drawing.Point(739, 369);
            this.lblTotalDiscount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalDiscount.Name = "lblTotalDiscount";
            this.lblTotalDiscount.Size = new System.Drawing.Size(86, 25);
            this.lblTotalDiscount.TabIndex = 47;
            this.lblTotalDiscount.Text = "Discount";
            // 
            // lblChangeDue
            // 
            this.lblChangeDue.AutoSize = true;
            this.lblChangeDue.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeDue.Location = new System.Drawing.Point(742, 513);
            this.lblChangeDue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChangeDue.Name = "lblChangeDue";
            this.lblChangeDue.Size = new System.Drawing.Size(74, 25);
            this.lblChangeDue.TabIndex = 48;
            this.lblChangeDue.Text = "change";
            // 
            // btnCompleteSale
            // 
            this.btnCompleteSale.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnCompleteSale.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompleteSale.ForeColor = System.Drawing.Color.White;
            this.btnCompleteSale.Location = new System.Drawing.Point(493, 537);
            this.btnCompleteSale.Margin = new System.Windows.Forms.Padding(4);
            this.btnCompleteSale.Name = "btnCompleteSale";
            this.btnCompleteSale.Size = new System.Drawing.Size(379, 80);
            this.btnCompleteSale.TabIndex = 49;
            this.btnCompleteSale.Text = "compllete sale";
            this.btnCompleteSale.UseVisualStyleBackColor = false;
            this.btnCompleteSale.Click += new System.EventHandler(this.btnCompleteSale_Click);
            // 
            // btnHoldTransaction
            // 
            this.btnHoldTransaction.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnHoldTransaction.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoldTransaction.ForeColor = System.Drawing.Color.White;
            this.btnHoldTransaction.Location = new System.Drawing.Point(193, 502);
            this.btnHoldTransaction.Margin = new System.Windows.Forms.Padding(4);
            this.btnHoldTransaction.Name = "btnHoldTransaction";
            this.btnHoldTransaction.Size = new System.Drawing.Size(136, 80);
            this.btnHoldTransaction.TabIndex = 50;
            this.btnHoldTransaction.Text = "hold transaction";
            this.btnHoldTransaction.UseVisualStyleBackColor = false;
            this.btnHoldTransaction.Click += new System.EventHandler(this.btnHoldTransaction_Click);
            // 
            // NewTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(902, 661);
            this.Controls.Add(this.btnHoldTransaction);
            this.Controls.Add(this.btnCompleteSale);
            this.Controls.Add(this.lblChangeDue);
            this.Controls.Add(this.dgvCartItems);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTotalDiscount);
            this.Controls.Add(this.lblTaxAmount);
            this.Controls.Add(this.lblTotalAmountDue);
            this.Controls.Add(this.lblGrandSubtotal);
            this.Controls.Add(this.btnCancelTransaction);
            this.Controls.Add(this.txtMoneyReceived);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NewTransactionForm";
            this.Text = "New Transaction";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelTransaction;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnAddtoCart;
        private System.Windows.Forms.TextBox txtMoneyReceived;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbItemDiscount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtItemQuantity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpTransactionDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTotalDiscount;
        private System.Windows.Forms.Label lblTotalAmountDue;
        private System.Windows.Forms.Label lblTaxAmount;
        private System.Windows.Forms.Label lblGrandSubtotal;
        private System.Windows.Forms.DataGridView dgvCartItems;
        private System.Windows.Forms.ComboBox cmbProductSearch;
        private System.Windows.Forms.Label lblItemPrice;
        private System.Windows.Forms.Label lblChangeDue;
        private System.Windows.Forms.Button btnCompleteSale;
        private System.Windows.Forms.ComboBox cmbTransactionType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnHoldTransaction;
    }
}