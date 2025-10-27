namespace AdvDatabase
{
    partial class SuppliersUC
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
            this.txtSupplierSearch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSearchSupplier = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtContactEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClearSupplierFields = new System.Windows.Forms.Button();
            this.btnDeleteSupplier = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnUpdateSupplier = new System.Windows.Forms.Button();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.btnAddSupplier = new System.Windows.Forms.Button();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.dgvSuppliersList = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliersList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.txtSupplierSearch);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnSearchSupplier);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 71);
            this.panel1.TabIndex = 27;
            // 
            // txtSupplierSearch
            // 
            this.txtSupplierSearch.Location = new System.Drawing.Point(287, 14);
            this.txtSupplierSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSupplierSearch.Multiline = true;
            this.txtSupplierSearch.Name = "txtSupplierSearch";
            this.txtSupplierSearch.Size = new System.Drawing.Size(473, 34);
            this.txtSupplierSearch.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft New Tai Lue", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(20, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 45);
            this.label6.TabIndex = 25;
            this.label6.Text = "Suppliers";
            // 
            // btnSearchSupplier
            // 
            this.btnSearchSupplier.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchSupplier.Location = new System.Drawing.Point(770, 14);
            this.btnSearchSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchSupplier.Name = "btnSearchSupplier";
            this.btnSearchSupplier.Size = new System.Drawing.Size(113, 38);
            this.btnSearchSupplier.TabIndex = 5;
            this.btnSearchSupplier.Text = "Search";
            this.btnSearchSupplier.UseVisualStyleBackColor = true;
            this.btnSearchSupplier.Click += new System.EventHandler(this.btnSearchSupplier_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Snow;
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtContactEmail);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnClearSupplierFields);
            this.groupBox1.Controls.Add(this.btnDeleteSupplier);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.btnUpdateSupplier);
            this.groupBox1.Controls.Add(this.txtContactNo);
            this.groupBox1.Controls.Add(this.btnAddSupplier);
            this.groupBox1.Controls.Add(this.txtSupplierName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 88);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(373, 511);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add New Supplier";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 139);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 26);
            this.label9.TabIndex = 36;
            this.label9.Text = "Contact Email";
            this.label9.UseMnemonic = false;
            // 
            // txtContactEmail
            // 
            this.txtContactEmail.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactEmail.Location = new System.Drawing.Point(137, 138);
            this.txtContactEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtContactEmail.Multiline = true;
            this.txtContactEmail.Name = "txtContactEmail";
            this.txtContactEmail.Size = new System.Drawing.Size(208, 29);
            this.txtContactEmail.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "Supplier Name";
            this.label2.UseMnemonic = false;
            // 
            // btnClearSupplierFields
            // 
            this.btnClearSupplierFields.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnClearSupplierFields.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearSupplierFields.ForeColor = System.Drawing.Color.White;
            this.btnClearSupplierFields.Location = new System.Drawing.Point(110, 441);
            this.btnClearSupplierFields.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearSupplierFields.Name = "btnClearSupplierFields";
            this.btnClearSupplierFields.Size = new System.Drawing.Size(136, 38);
            this.btnClearSupplierFields.TabIndex = 17;
            this.btnClearSupplierFields.Text = "CLEAR ALL";
            this.btnClearSupplierFields.UseVisualStyleBackColor = false;
            this.btnClearSupplierFields.Click += new System.EventHandler(this.btnClearSupplierFields_Click);
            // 
            // btnDeleteSupplier
            // 
            this.btnDeleteSupplier.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnDeleteSupplier.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSupplier.ForeColor = System.Drawing.Color.White;
            this.btnDeleteSupplier.Location = new System.Drawing.Point(110, 384);
            this.btnDeleteSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteSupplier.Name = "btnDeleteSupplier";
            this.btnDeleteSupplier.Size = new System.Drawing.Size(136, 38);
            this.btnDeleteSupplier.TabIndex = 15;
            this.btnDeleteSupplier.Text = "DELETE";
            this.btnDeleteSupplier.UseVisualStyleBackColor = false;
            this.btnDeleteSupplier.Click += new System.EventHandler(this.btnDeleteSupplier_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(8, 90);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 26);
            this.label12.TabIndex = 28;
            this.label12.Text = "Contact No";
            this.label12.UseMnemonic = false;
            // 
            // btnUpdateSupplier
            // 
            this.btnUpdateSupplier.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnUpdateSupplier.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateSupplier.ForeColor = System.Drawing.Color.White;
            this.btnUpdateSupplier.Location = new System.Drawing.Point(110, 325);
            this.btnUpdateSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateSupplier.Name = "btnUpdateSupplier";
            this.btnUpdateSupplier.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnUpdateSupplier.Size = new System.Drawing.Size(136, 38);
            this.btnUpdateSupplier.TabIndex = 16;
            this.btnUpdateSupplier.Text = "UPDATE";
            this.btnUpdateSupplier.UseVisualStyleBackColor = false;
            this.btnUpdateSupplier.Click += new System.EventHandler(this.btnUpdateSupplier_Click);
            // 
            // txtContactNo
            // 
            this.txtContactNo.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactNo.Location = new System.Drawing.Point(137, 89);
            this.txtContactNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtContactNo.Multiline = true;
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(208, 29);
            this.txtContactNo.TabIndex = 27;
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAddSupplier.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSupplier.ForeColor = System.Drawing.Color.White;
            this.btnAddSupplier.Location = new System.Drawing.Point(110, 268);
            this.btnAddSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(136, 38);
            this.btnAddSupplier.TabIndex = 3;
            this.btnAddSupplier.Text = "ADD";
            this.btnAddSupplier.UseVisualStyleBackColor = false;
            this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierName.Location = new System.Drawing.Point(137, 40);
            this.txtSupplierName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSupplierName.Multiline = true;
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(208, 29);
            this.txtSupplierName.TabIndex = 7;
            // 
            // dgvSuppliersList
            // 
            this.dgvSuppliersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuppliersList.Location = new System.Drawing.Point(401, 88);
            this.dgvSuppliersList.Name = "dgvSuppliersList";
            this.dgvSuppliersList.RowHeadersWidth = 51;
            this.dgvSuppliersList.RowTemplate.Height = 24;
            this.dgvSuppliersList.Size = new System.Drawing.Size(499, 598);
            this.dgvSuppliersList.TabIndex = 46;
            this.dgvSuppliersList.SelectionChanged += new System.EventHandler(this.DgvSuppliersList_SelectionChanged);
            // 
            // SuppliersUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvSuppliersList);
            this.Name = "SuppliersUC";
            this.Size = new System.Drawing.Size(920, 708);
            this.Load += new System.EventHandler(this.SuppliersUC_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliersList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSupplierSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSearchSupplier;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClearSupplierFields;
        private System.Windows.Forms.Button btnDeleteSupplier;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnUpdateSupplier;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Button btnAddSupplier;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtContactEmail;
        private System.Windows.Forms.DataGridView dgvSuppliersList;
    }
}
