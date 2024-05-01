namespace StockX.Utility
{
    partial class frmBillDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.gdvBillDetails = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnGetDetails = new System.Windows.Forms.Button();
            this.dtpBillDate = new System.Windows.Forms.DateTimePicker();
            this.lblTotalDiscount = new System.Windows.Forms.Label();
            this.lblTotalTax = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.lblTotalBill = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gdvBillItemDetails = new System.Windows.Forms.DataGridView();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gdvBillPaymentDetails = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalBillAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvBillDetails)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvBillItemDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvBillPaymentDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(65)))), ((int)(((byte)(115)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1049, 32);
            this.panel1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(460, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Billing Details";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Location = new System.Drawing.Point(999, 1);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(49, 29);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gdvBillDetails
            // 
            this.gdvBillDetails.AllowUserToAddRows = false;
            this.gdvBillDetails.AllowUserToDeleteRows = false;
            this.gdvBillDetails.AllowUserToResizeColumns = false;
            this.gdvBillDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(176)))), ((int)(((byte)(110)))));
            this.gdvBillDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gdvBillDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(56)))), ((int)(((byte)(64)))));
            this.gdvBillDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvBillDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BillID,
            this.BillDate,
            this.TotalTax,
            this.Discount,
            this.TotalBillAmount});
            this.gdvBillDetails.Location = new System.Drawing.Point(27, 102);
            this.gdvBillDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdvBillDetails.Name = "gdvBillDetails";
            this.gdvBillDetails.ReadOnly = true;
            this.gdvBillDetails.RowHeadersVisible = false;
            this.gdvBillDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gdvBillDetails.Size = new System.Drawing.Size(731, 496);
            this.gdvBillDetails.TabIndex = 12;
            this.gdvBillDetails.SelectionChanged += new System.EventHandler(this.gdvBillDetails_SelectionChanged);
            this.gdvBillDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gdvBillDetails_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(803, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total Amount ₹";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAmount.Font = new System.Drawing.Font("DaytonaPro-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Yellow;
            this.lblTotalAmount.Location = new System.Drawing.Point(953, 10);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(48, 22);
            this.lblTotalAmount.TabIndex = 14;
            this.lblTotalAmount.Text = "0.00";
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::StockX.Properties.Resources.bg10;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnGetDetails);
            this.panel3.Controls.Add(this.dtpBillDate);
            this.panel3.Controls.Add(this.lblTotalDiscount);
            this.panel3.Controls.Add(this.lblTotalTax);
            this.panel3.Controls.Add(this.label31);
            this.panel3.Controls.Add(this.label30);
            this.panel3.Controls.Add(this.lblTotalBill);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.lblTotalAmount);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(9, 45);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1037, 44);
            this.panel3.TabIndex = 15;
            // 
            // btnGetDetails
            // 
            this.btnGetDetails.BackColor = System.Drawing.Color.Transparent;
            this.btnGetDetails.BackgroundImage = global::StockX.Properties.Resources.messagebg21;
            this.btnGetDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGetDetails.FlatAppearance.BorderSize = 0;
            this.btnGetDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetDetails.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetDetails.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGetDetails.Location = new System.Drawing.Point(162, 6);
            this.btnGetDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGetDetails.Name = "btnGetDetails";
            this.btnGetDetails.Size = new System.Drawing.Size(122, 34);
            this.btnGetDetails.TabIndex = 50;
            this.btnGetDetails.Text = "Get Details";
            this.btnGetDetails.UseVisualStyleBackColor = false;
            this.btnGetDetails.Click += new System.EventHandler(this.btnGetDetails_Click);
            // 
            // dtpBillDate
            // 
            this.dtpBillDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBillDate.Location = new System.Drawing.Point(21, 9);
            this.dtpBillDate.MaxDate = new System.DateTime(2222, 1, 1, 0, 0, 0, 0);
            this.dtpBillDate.Name = "dtpBillDate";
            this.dtpBillDate.Size = new System.Drawing.Size(135, 27);
            this.dtpBillDate.TabIndex = 49;
            this.dtpBillDate.Value = new System.DateTime(2024, 4, 26, 0, 0, 0, 0);
            // 
            // lblTotalDiscount
            // 
            this.lblTotalDiscount.AutoSize = true;
            this.lblTotalDiscount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalDiscount.Font = new System.Drawing.Font("DaytonaPro-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDiscount.ForeColor = System.Drawing.Color.Yellow;
            this.lblTotalDiscount.Location = new System.Drawing.Point(724, 10);
            this.lblTotalDiscount.Name = "lblTotalDiscount";
            this.lblTotalDiscount.Size = new System.Drawing.Size(21, 22);
            this.lblTotalDiscount.TabIndex = 48;
            this.lblTotalDiscount.Text = "0";
            // 
            // lblTotalTax
            // 
            this.lblTotalTax.AutoSize = true;
            this.lblTotalTax.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalTax.Font = new System.Drawing.Font("DaytonaPro-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTax.ForeColor = System.Drawing.Color.Yellow;
            this.lblTotalTax.Location = new System.Drawing.Point(536, 12);
            this.lblTotalTax.Name = "lblTotalTax";
            this.lblTotalTax.Size = new System.Drawing.Size(21, 22);
            this.lblTotalTax.TabIndex = 47;
            this.lblTotalTax.Text = "0";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Font = new System.Drawing.Font("DaytonaPro-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.White;
            this.label31.Location = new System.Drawing.Point(618, 10);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(100, 22);
            this.label31.TabIndex = 46;
            this.label31.Text = "Discount  ₹";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Font = new System.Drawing.Font("DaytonaPro-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.White;
            this.label30.Location = new System.Drawing.Point(475, 12);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(55, 22);
            this.label30.TabIndex = 45;
            this.label30.Text = "Tax  ₹";
            // 
            // lblTotalBill
            // 
            this.lblTotalBill.AutoSize = true;
            this.lblTotalBill.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalBill.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBill.ForeColor = System.Drawing.Color.Yellow;
            this.lblTotalBill.Location = new System.Drawing.Point(390, 9);
            this.lblTotalBill.Name = "lblTotalBill";
            this.lblTotalBill.Size = new System.Drawing.Size(23, 25);
            this.lblTotalBill.TabIndex = 16;
            this.lblTotalBill.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(309, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Total Bill";
            // 
            // gdvBillItemDetails
            // 
            this.gdvBillItemDetails.AllowUserToAddRows = false;
            this.gdvBillItemDetails.AllowUserToDeleteRows = false;
            this.gdvBillItemDetails.AllowUserToResizeColumns = false;
            this.gdvBillItemDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(164)))), ((int)(((byte)(71)))));
            this.gdvBillItemDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.gdvBillItemDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(56)))), ((int)(((byte)(64)))));
            this.gdvBillItemDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvBillItemDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemID,
            this.ItemName,
            this.Total});
            this.gdvBillItemDetails.Location = new System.Drawing.Point(783, 102);
            this.gdvBillItemDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdvBillItemDetails.Name = "gdvBillItemDetails";
            this.gdvBillItemDetails.ReadOnly = true;
            this.gdvBillItemDetails.RowHeadersVisible = false;
            this.gdvBillItemDetails.Size = new System.Drawing.Size(263, 353);
            this.gdvBillItemDetails.TabIndex = 16;
            this.gdvBillItemDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gdvBillItemDetails_DataError);
            // 
            // ItemID
            // 
            this.ItemID.DataPropertyName = "ItemID";
            this.ItemID.HeaderText = "ID";
            this.ItemID.Name = "ItemID";
            this.ItemID.ReadOnly = true;
            this.ItemID.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Total.DataPropertyName = "Total";
            this.Total.HeaderText = "Amount";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // gdvBillPaymentDetails
            // 
            this.gdvBillPaymentDetails.AllowUserToAddRows = false;
            this.gdvBillPaymentDetails.AllowUserToDeleteRows = false;
            this.gdvBillPaymentDetails.AllowUserToResizeColumns = false;
            this.gdvBillPaymentDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.gdvBillPaymentDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.gdvBillPaymentDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(56)))), ((int)(((byte)(64)))));
            this.gdvBillPaymentDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvBillPaymentDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.PaymentMode,
            this.Amount});
            this.gdvBillPaymentDetails.Location = new System.Drawing.Point(783, 458);
            this.gdvBillPaymentDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdvBillPaymentDetails.Name = "gdvBillPaymentDetails";
            this.gdvBillPaymentDetails.ReadOnly = true;
            this.gdvBillPaymentDetails.RowHeadersVisible = false;
            this.gdvBillPaymentDetails.Size = new System.Drawing.Size(263, 142);
            this.gdvBillPaymentDetails.TabIndex = 17;
            this.gdvBillPaymentDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gdvBillPaymentDetails_DataError);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ID";
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(73)))), ((int)(((byte)(250)))));
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn4.HeaderText = "ID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // PaymentMode
            // 
            this.PaymentMode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PaymentMode.DataPropertyName = "PaymentMode";
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(73)))), ((int)(((byte)(250)))));
            this.PaymentMode.DefaultCellStyle = dataGridViewCellStyle10;
            this.PaymentMode.HeaderText = "Pay Mode";
            this.PaymentMode.Name = "PaymentMode";
            this.PaymentMode.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(73)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle11.Format = "C2";
            dataGridViewCellStyle11.NullValue = null;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle11;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // BillID
            // 
            this.BillID.DataPropertyName = "BillID";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(221)))), ((int)(((byte)(155)))));
            this.BillID.DefaultCellStyle = dataGridViewCellStyle2;
            this.BillID.HeaderText = "Bill No";
            this.BillID.Name = "BillID";
            this.BillID.ReadOnly = true;
            // 
            // BillDate
            // 
            this.BillDate.DataPropertyName = "Date";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(221)))), ((int)(((byte)(155)))));
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.BillDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.BillDate.HeaderText = "Date";
            this.BillDate.Name = "BillDate";
            this.BillDate.ReadOnly = true;
            this.BillDate.Width = 150;
            // 
            // TotalTax
            // 
            this.TotalTax.DataPropertyName = "TotalTax";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(221)))), ((int)(((byte)(155)))));
            this.TotalTax.DefaultCellStyle = dataGridViewCellStyle4;
            this.TotalTax.HeaderText = "TotalTax";
            this.TotalTax.Name = "TotalTax";
            this.TotalTax.ReadOnly = true;
            this.TotalTax.Width = 150;
            // 
            // Discount
            // 
            this.Discount.DataPropertyName = "TotalDiscount";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(221)))), ((int)(((byte)(155)))));
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.Discount.DefaultCellStyle = dataGridViewCellStyle5;
            this.Discount.HeaderText = "Total Discount";
            this.Discount.Name = "Discount";
            this.Discount.ReadOnly = true;
            this.Discount.Width = 150;
            // 
            // TotalBillAmount
            // 
            this.TotalBillAmount.DataPropertyName = "TotalBillAmount";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(221)))), ((int)(((byte)(155)))));
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.TotalBillAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.TotalBillAmount.HeaderText = "Amount";
            this.TotalBillAmount.Name = "TotalBillAmount";
            this.TotalBillAmount.ReadOnly = true;
            this.TotalBillAmount.Width = 150;
            // 
            // frmBillDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(56)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1052, 611);
            this.Controls.Add(this.gdvBillPaymentDetails);
            this.Controls.Add(this.gdvBillItemDetails);
            this.Controls.Add(this.gdvBillDetails);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("DaytonaPro-Semibold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmBillDetails";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmPaymentMode";
            this.Load += new System.EventHandler(this.frmPaymentMode_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvBillDetails)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvBillItemDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvBillPaymentDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView gdvBillDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTotalBill;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalDiscount;
        private System.Windows.Forms.Label lblTotalTax;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.DataGridView gdvBillItemDetails;
        private System.Windows.Forms.DataGridView gdvBillPaymentDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DateTimePicker dtpBillDate;
        private System.Windows.Forms.Button btnGetDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalBillAmount;
    }
}