namespace StockX
{
    partial class FrmDashboard
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDashboard));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlMenuBar = new System.Windows.Forms.Panel();
            this.lblNotification = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuDashboard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.smnuBilling = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.smnuShopeeDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.smnuItemCategoryMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.smnuItemCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.smnuUserCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.smnuTaxCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.smnuMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.smnuItemMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.smnuUnitMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.smnuUserMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.smnuCustomerMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.smnuSupplierMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.smnuStockMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.smnuPaymentModes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAccounting = new System.Windows.Forms.ToolStripMenuItem();
            this.smnuDailyExpenses = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.smnuPendingDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.smnuStockReports = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUtility = new System.Windows.Forms.ToolStripMenuItem();
            this.smnuBillingDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.smnuDatabaseBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.smnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlShortcuts = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlSummaryDetails = new System.Windows.Forms.Panel();
            this.pnlCard4 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalOutstanding = new System.Windows.Forms.Label();
            this.pnlDetails2 = new System.Windows.Forms.Panel();
            this.pnlDetails1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.gdvStockDetails = new System.Windows.Forms.DataGridView();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlCard3 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalCustomer = new System.Windows.Forms.Label();
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalBills = new System.Windows.Forms.Label();
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalItemSold = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBanner = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblProductInfo = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlHeaderMarquee = new System.Windows.Forms.Panel();
            this.lblMarquee = new System.Windows.Forms.Label();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.smnuExpenseCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.chtSales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlMenuBar.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnlShortcuts.SuspendLayout();
            this.pnlSummaryDetails.SuspendLayout();
            this.pnlCard4.SuspendLayout();
            this.pnlDetails2.SuspendLayout();
            this.pnlDetails1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvStockDetails)).BeginInit();
            this.pnlCard3.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard1.SuspendLayout();
            this.pnlBanner.SuspendLayout();
            this.pnlHeaderMarquee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtSales)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlMenuBar
            // 
            this.pnlMenuBar.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenuBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMenuBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMenuBar.Controls.Add(this.lblNotification);
            this.pnlMenuBar.Controls.Add(this.menuStrip1);
            this.pnlMenuBar.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMenuBar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlMenuBar.Location = new System.Drawing.Point(1, 35);
            this.pnlMenuBar.Name = "pnlMenuBar";
            this.pnlMenuBar.Size = new System.Drawing.Size(164, 439);
            this.pnlMenuBar.TabIndex = 0;
            this.pnlMenuBar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMenuBar_Paint);
            // 
            // lblNotification
            // 
            this.lblNotification.AutoSize = true;
            this.lblNotification.Font = new System.Drawing.Font("DaytonaPro-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotification.ForeColor = System.Drawing.Color.Yellow;
            this.lblNotification.Location = new System.Drawing.Point(10, 411);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(70, 22);
            this.lblNotification.TabIndex = 0;
            this.lblNotification.Text = "label10";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDashboard,
            this.mnuMaster,
            this.mnuAccounting,
            this.mnuUtility,
            this.mnuReports,
            this.mnuSettings,
            this.mnuRefresh});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(162, 316);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuDashboard
            // 
            this.mnuDashboard.BackColor = System.Drawing.Color.Transparent;
            this.mnuDashboard.BackgroundImage = global::StockX.Properties.Resources.bg10;
            this.mnuDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mnuDashboard.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator6,
            this.smnuBilling,
            this.toolStripSeparator7});
            this.mnuDashboard.Font = new System.Drawing.Font("DaytonaPro-Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuDashboard.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.mnuDashboard.Image = global::StockX.Properties.Resources.Monitor_icon;
            this.mnuDashboard.Name = "mnuDashboard";
            this.mnuDashboard.Padding = new System.Windows.Forms.Padding(10);
            this.mnuDashboard.Size = new System.Drawing.Size(155, 44);
            this.mnuDashboard.Text = "Dashboard";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(149, 6);
            // 
            // smnuBilling
            // 
            this.smnuBilling.BackgroundImage = global::StockX.Properties.Resources.marqueebg;
            this.smnuBilling.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smnuBilling.Name = "smnuBilling";
            this.smnuBilling.Size = new System.Drawing.Size(152, 24);
            this.smnuBilling.Text = "Billing F1";
            this.smnuBilling.Click += new System.EventHandler(this.smnuBilling_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(149, 6);
            // 
            // mnuMaster
            // 
            this.mnuMaster.BackColor = System.Drawing.Color.Transparent;
            this.mnuMaster.BackgroundImage = global::StockX.Properties.Resources.bg10;
            this.mnuMaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mnuMaster.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smnuShopeeDetails,
            this.toolStripSeparator12,
            this.smnuItemCategoryMaster,
            this.toolStripSeparator13,
            this.smnuMaster});
            this.mnuMaster.Font = new System.Drawing.Font("DaytonaPro-Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMaster.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.mnuMaster.Image = global::StockX.Properties.Resources.Admin_icon;
            this.mnuMaster.Name = "mnuMaster";
            this.mnuMaster.Padding = new System.Windows.Forms.Padding(10);
            this.mnuMaster.Size = new System.Drawing.Size(155, 44);
            this.mnuMaster.Text = "Master";
            // 
            // smnuShopeeDetails
            // 
            this.smnuShopeeDetails.BackgroundImage = global::StockX.Properties.Resources.marqueebg;
            this.smnuShopeeDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smnuShopeeDetails.Name = "smnuShopeeDetails";
            this.smnuShopeeDetails.Size = new System.Drawing.Size(185, 24);
            this.smnuShopeeDetails.Text = "Shopee Detail";
            this.smnuShopeeDetails.Click += new System.EventHandler(this.smnuShopeeDetails_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(182, 6);
            // 
            // smnuItemCategoryMaster
            // 
            this.smnuItemCategoryMaster.BackgroundImage = global::StockX.Properties.Resources.marqueebg;
            this.smnuItemCategoryMaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smnuItemCategoryMaster.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smnuItemCategory,
            this.toolStripSeparator15,
            this.smnuUserCategory,
            this.toolStripSeparator16,
            this.smnuTaxCategory,
            this.toolStripSeparator14,
            this.smnuExpenseCategory});
            this.smnuItemCategoryMaster.Name = "smnuItemCategoryMaster";
            this.smnuItemCategoryMaster.Size = new System.Drawing.Size(185, 24);
            this.smnuItemCategoryMaster.Text = "Category";
            this.smnuItemCategoryMaster.Click += new System.EventHandler(this.smnuItemCategoryMAster_Click);
            // 
            // smnuItemCategory
            // 
            this.smnuItemCategory.BackgroundImage = global::StockX.Properties.Resources.marqueebg1;
            this.smnuItemCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smnuItemCategory.Name = "smnuItemCategory";
            this.smnuItemCategory.Size = new System.Drawing.Size(214, 24);
            this.smnuItemCategory.Text = "Item Category";
            this.smnuItemCategory.Click += new System.EventHandler(this.smnuItemCategory_Click);
            // 
            // smnuUserCategory
            // 
            this.smnuUserCategory.BackgroundImage = global::StockX.Properties.Resources.marqueebg1;
            this.smnuUserCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smnuUserCategory.Name = "smnuUserCategory";
            this.smnuUserCategory.Size = new System.Drawing.Size(214, 24);
            this.smnuUserCategory.Text = "User Category";
            this.smnuUserCategory.Click += new System.EventHandler(this.smnuUserCategory_Click);
            // 
            // smnuTaxCategory
            // 
            this.smnuTaxCategory.BackgroundImage = global::StockX.Properties.Resources.marqueebg1;
            this.smnuTaxCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smnuTaxCategory.Name = "smnuTaxCategory";
            this.smnuTaxCategory.Size = new System.Drawing.Size(214, 24);
            this.smnuTaxCategory.Text = "Tax Category";
            this.smnuTaxCategory.Click += new System.EventHandler(this.smnuTaxCategory_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(182, 6);
            // 
            // smnuMaster
            // 
            this.smnuMaster.BackgroundImage = global::StockX.Properties.Resources.marqueebg;
            this.smnuMaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smnuMaster.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smnuItemMaster,
            this.toolStripSeparator1,
            this.smnuUnitMaster,
            this.toolStripSeparator2,
            this.smnuUserMaster,
            this.toolStripSeparator3,
            this.smnuCustomerMaster,
            this.toolStripSeparator4,
            this.smnuSupplierMaster,
            this.toolStripSeparator5,
            this.smnuStockMaster,
            this.toolStripSeparator9,
            this.smnuPaymentModes,
            this.toolStripSeparator11});
            this.smnuMaster.Name = "smnuMaster";
            this.smnuMaster.Size = new System.Drawing.Size(185, 24);
            this.smnuMaster.Text = "Master ";
            this.smnuMaster.Click += new System.EventHandler(this.smnuItemMaster_Click);
            // 
            // smnuItemMaster
            // 
            this.smnuItemMaster.BackgroundImage = global::StockX.Properties.Resources.marqueebg1;
            this.smnuItemMaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smnuItemMaster.Name = "smnuItemMaster";
            this.smnuItemMaster.Size = new System.Drawing.Size(233, 24);
            this.smnuItemMaster.Text = "Item Master";
            this.smnuItemMaster.Click += new System.EventHandler(this.smnuItemMaster_Click_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(230, 6);
            // 
            // smnuUnitMaster
            // 
            this.smnuUnitMaster.BackgroundImage = global::StockX.Properties.Resources.marqueebg1;
            this.smnuUnitMaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smnuUnitMaster.Name = "smnuUnitMaster";
            this.smnuUnitMaster.Size = new System.Drawing.Size(233, 24);
            this.smnuUnitMaster.Text = "Unit Master";
            this.smnuUnitMaster.Click += new System.EventHandler(this.smnuUnitMaster_Click_1);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(230, 6);
            // 
            // smnuUserMaster
            // 
            this.smnuUserMaster.BackgroundImage = global::StockX.Properties.Resources.marqueebg1;
            this.smnuUserMaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smnuUserMaster.Name = "smnuUserMaster";
            this.smnuUserMaster.Size = new System.Drawing.Size(233, 24);
            this.smnuUserMaster.Text = "User Master";
            this.smnuUserMaster.Click += new System.EventHandler(this.smnuUserMaster_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(230, 6);
            // 
            // smnuCustomerMaster
            // 
            this.smnuCustomerMaster.BackgroundImage = global::StockX.Properties.Resources.marqueebg1;
            this.smnuCustomerMaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smnuCustomerMaster.Name = "smnuCustomerMaster";
            this.smnuCustomerMaster.Size = new System.Drawing.Size(233, 24);
            this.smnuCustomerMaster.Text = "Customer Master F3";
            this.smnuCustomerMaster.Click += new System.EventHandler(this.smnuCustomerMaster_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(230, 6);
            // 
            // smnuSupplierMaster
            // 
            this.smnuSupplierMaster.BackgroundImage = global::StockX.Properties.Resources.marqueebg1;
            this.smnuSupplierMaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smnuSupplierMaster.Name = "smnuSupplierMaster";
            this.smnuSupplierMaster.Size = new System.Drawing.Size(233, 24);
            this.smnuSupplierMaster.Text = "Supplier Master";
            this.smnuSupplierMaster.Click += new System.EventHandler(this.smnuSupplierMaster_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(230, 6);
            // 
            // smnuStockMaster
            // 
            this.smnuStockMaster.BackgroundImage = global::StockX.Properties.Resources.marqueebg1;
            this.smnuStockMaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smnuStockMaster.Name = "smnuStockMaster";
            this.smnuStockMaster.Size = new System.Drawing.Size(233, 24);
            this.smnuStockMaster.Text = "Stock Master F4";
            this.smnuStockMaster.Click += new System.EventHandler(this.smnuStockMaster_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(230, 6);
            // 
            // smnuPaymentModes
            // 
            this.smnuPaymentModes.BackgroundImage = global::StockX.Properties.Resources.marqueebg1;
            this.smnuPaymentModes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smnuPaymentModes.Name = "smnuPaymentModes";
            this.smnuPaymentModes.Size = new System.Drawing.Size(233, 24);
            this.smnuPaymentModes.Text = "Payment Modes";
            this.smnuPaymentModes.Click += new System.EventHandler(this.smnuPaymentModes_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(230, 6);
            // 
            // mnuAccounting
            // 
            this.mnuAccounting.BackgroundImage = global::StockX.Properties.Resources.bg10;
            this.mnuAccounting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mnuAccounting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smnuDailyExpenses,
            this.toolStripSeparator10,
            this.smnuPendingDetails});
            this.mnuAccounting.Font = new System.Drawing.Font("DaytonaPro-Bold", 11.25F);
            this.mnuAccounting.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.mnuAccounting.Image = global::StockX.Properties.Resources.Accounting_Calculator_icon;
            this.mnuAccounting.Name = "mnuAccounting";
            this.mnuAccounting.Padding = new System.Windows.Forms.Padding(10);
            this.mnuAccounting.Size = new System.Drawing.Size(155, 44);
            this.mnuAccounting.Text = "Accounting";
            // 
            // smnuDailyExpenses
            // 
            this.smnuDailyExpenses.BackgroundImage = global::StockX.Properties.Resources.marqueebg;
            this.smnuDailyExpenses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smnuDailyExpenses.Name = "smnuDailyExpenses";
            this.smnuDailyExpenses.Size = new System.Drawing.Size(191, 24);
            this.smnuDailyExpenses.Text = "Daily Expenses";
            this.smnuDailyExpenses.Click += new System.EventHandler(this.smnuDailyExpenses_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(188, 6);
            // 
            // smnuPendingDetails
            // 
            this.smnuPendingDetails.BackgroundImage = global::StockX.Properties.Resources.marqueebg;
            this.smnuPendingDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smnuPendingDetails.Name = "smnuPendingDetails";
            this.smnuPendingDetails.Size = new System.Drawing.Size(191, 24);
            this.smnuPendingDetails.Text = "Clear Pending";
            this.smnuPendingDetails.Click += new System.EventHandler(this.smnuPendingDetails_Click_1);
            // 
            // mnuReports
            // 
            this.mnuReports.BackColor = System.Drawing.Color.Transparent;
            this.mnuReports.BackgroundImage = global::StockX.Properties.Resources.bg10;
            this.mnuReports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mnuReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smnuStockReports});
            this.mnuReports.Font = new System.Drawing.Font("DaytonaPro-Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuReports.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.mnuReports.Image = global::StockX.Properties.Resources.print_icon;
            this.mnuReports.Name = "mnuReports";
            this.mnuReports.Padding = new System.Windows.Forms.Padding(10);
            this.mnuReports.Size = new System.Drawing.Size(155, 44);
            this.mnuReports.Text = "Reports";
            // 
            // smnuStockReports
            // 
            this.smnuStockReports.BackgroundImage = global::StockX.Properties.Resources.marqueebg;
            this.smnuStockReports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smnuStockReports.Name = "smnuStockReports";
            this.smnuStockReports.Size = new System.Drawing.Size(186, 24);
            this.smnuStockReports.Text = "Stock Reports";
            this.smnuStockReports.Click += new System.EventHandler(this.smnuStockReports_Click);
            // 
            // mnuUtility
            // 
            this.mnuUtility.BackColor = System.Drawing.Color.Transparent;
            this.mnuUtility.BackgroundImage = global::StockX.Properties.Resources.bg10;
            this.mnuUtility.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mnuUtility.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smnuBillingDetails,
            this.toolStripSeparator8,
            this.smnuDatabaseBackup});
            this.mnuUtility.Font = new System.Drawing.Font("DaytonaPro-Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuUtility.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.mnuUtility.Image = global::StockX.Properties.Resources.RAID_Utility_icon;
            this.mnuUtility.Name = "mnuUtility";
            this.mnuUtility.Padding = new System.Windows.Forms.Padding(10);
            this.mnuUtility.Size = new System.Drawing.Size(155, 44);
            this.mnuUtility.Text = " Utility";
            // 
            // smnuBillingDetails
            // 
            this.smnuBillingDetails.BackgroundImage = global::StockX.Properties.Resources.marqueebg;
            this.smnuBillingDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smnuBillingDetails.Name = "smnuBillingDetails";
            this.smnuBillingDetails.Size = new System.Drawing.Size(211, 24);
            this.smnuBillingDetails.Text = "Billing Details";
            this.smnuBillingDetails.Click += new System.EventHandler(this.smnuBillingDetails_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(208, 6);
            // 
            // smnuDatabaseBackup
            // 
            this.smnuDatabaseBackup.BackgroundImage = global::StockX.Properties.Resources.marqueebg;
            this.smnuDatabaseBackup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smnuDatabaseBackup.Name = "smnuDatabaseBackup";
            this.smnuDatabaseBackup.Size = new System.Drawing.Size(211, 24);
            this.smnuDatabaseBackup.Text = "Database Backup";
            // 
            // mnuSettings
            // 
            this.mnuSettings.BackColor = System.Drawing.Color.Transparent;
            this.mnuSettings.BackgroundImage = global::StockX.Properties.Resources.bg10;
            this.mnuSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mnuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smnuSettings});
            this.mnuSettings.Font = new System.Drawing.Font("DaytonaPro-Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuSettings.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.mnuSettings.Image = global::StockX.Properties.Resources.Gear_icon;
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Padding = new System.Windows.Forms.Padding(10);
            this.mnuSettings.Size = new System.Drawing.Size(155, 44);
            this.mnuSettings.Text = "Settings";
            // 
            // smnuSettings
            // 
            this.smnuSettings.BackgroundImage = global::StockX.Properties.Resources.marqueebg;
            this.smnuSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smnuSettings.Name = "smnuSettings";
            this.smnuSettings.Size = new System.Drawing.Size(237, 24);
            this.smnuSettings.Text = "Application Settings";
            this.smnuSettings.Click += new System.EventHandler(this.smnuSettings_Click);
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.BackColor = System.Drawing.Color.Transparent;
            this.mnuRefresh.BackgroundImage = global::StockX.Properties.Resources.bg10;
            this.mnuRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mnuRefresh.Font = new System.Drawing.Font("DaytonaPro-Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuRefresh.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.mnuRefresh.Image = global::StockX.Properties.Resources.Actions_view_refresh_icon;
            this.mnuRefresh.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.Padding = new System.Windows.Forms.Padding(10);
            this.mnuRefresh.Size = new System.Drawing.Size(155, 46);
            this.mnuRefresh.Text = "Refresh";
            this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
            // 
            // pnlShortcuts
            // 
            this.pnlShortcuts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(176)))), ((int)(((byte)(110)))));
            this.pnlShortcuts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlShortcuts.Controls.Add(this.label2);
            this.pnlShortcuts.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlShortcuts.Location = new System.Drawing.Point(1, 587);
            this.pnlShortcuts.Name = "pnlShortcuts";
            this.pnlShortcuts.Size = new System.Drawing.Size(1008, 39);
            this.pnlShortcuts.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("DaytonaPro-Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(42, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(932, 60);
            this.label2.TabIndex = 0;
            this.label2.Text = "F1 - Billing | F2 - Item Master | F3 - Customer Master | F4 - Stock Master | F5 -" +
    " Bill Details | F6 - Reports | F7 - Settings\r\n\r\n\r\n";
            // 
            // pnlSummaryDetails
            // 
            this.pnlSummaryDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlSummaryDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSummaryDetails.Controls.Add(this.pnlCard4);
            this.pnlSummaryDetails.Controls.Add(this.pnlDetails2);
            this.pnlSummaryDetails.Controls.Add(this.pnlDetails1);
            this.pnlSummaryDetails.Controls.Add(this.pnlCard3);
            this.pnlSummaryDetails.Controls.Add(this.pnlCard2);
            this.pnlSummaryDetails.Controls.Add(this.pnlCard1);
            this.pnlSummaryDetails.Location = new System.Drawing.Point(169, 67);
            this.pnlSummaryDetails.Name = "pnlSummaryDetails";
            this.pnlSummaryDetails.Size = new System.Drawing.Size(925, 451);
            this.pnlSummaryDetails.TabIndex = 21;
            // 
            // pnlCard4
            // 
            this.pnlCard4.BackColor = System.Drawing.Color.Transparent;
            this.pnlCard4.BackgroundImage = global::StockX.Properties.Resources.card5;
            this.pnlCard4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlCard4.Controls.Add(this.panel4);
            this.pnlCard4.Controls.Add(this.label6);
            this.pnlCard4.Controls.Add(this.lblTotalOutstanding);
            this.pnlCard4.Location = new System.Drawing.Point(701, 16);
            this.pnlCard4.Name = "pnlCard4";
            this.pnlCard4.Size = new System.Drawing.Size(210, 127);
            this.pnlCard4.TabIndex = 24;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BackgroundImage = global::StockX.Properties.Resources.outstanding1;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(22, 57);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(55, 46);
            this.panel4.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("DaytonaPro-Regular", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(17, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 27);
            this.label6.TabIndex = 19;
            this.label6.Text = "OUTSTANDING";
            // 
            // lblTotalOutstanding
            // 
            this.lblTotalOutstanding.AutoSize = true;
            this.lblTotalOutstanding.Font = new System.Drawing.Font("DaytonaPro-Fat", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalOutstanding.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTotalOutstanding.Location = new System.Drawing.Point(91, 59);
            this.lblTotalOutstanding.Name = "lblTotalOutstanding";
            this.lblTotalOutstanding.Size = new System.Drawing.Size(46, 41);
            this.lblTotalOutstanding.TabIndex = 18;
            this.lblTotalOutstanding.Text = " 0";
            // 
            // pnlDetails2
            // 
            this.pnlDetails2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(54)))), ((int)(((byte)(70)))));
            this.pnlDetails2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlDetails2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetails2.Controls.Add(this.chtSales);
            this.pnlDetails2.Location = new System.Drawing.Point(461, 149);
            this.pnlDetails2.Name = "pnlDetails2";
            this.pnlDetails2.Size = new System.Drawing.Size(454, 250);
            this.pnlDetails2.TabIndex = 26;
            // 
            // pnlDetails1
            // 
            this.pnlDetails1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(54)))), ((int)(((byte)(70)))));
            this.pnlDetails1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlDetails1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetails1.Controls.Add(this.label4);
            this.pnlDetails1.Controls.Add(this.gdvStockDetails);
            this.pnlDetails1.Font = new System.Drawing.Font("DaytonaPro-Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlDetails1.Location = new System.Drawing.Point(9, 149);
            this.pnlDetails1.Name = "pnlDetails1";
            this.pnlDetails1.Size = new System.Drawing.Size(454, 250);
            this.pnlDetails1.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("DaytonaPro-Regular", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(96, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(287, 27);
            this.label4.TabIndex = 18;
            this.label4.Text = "Available stock at a Glance";
            // 
            // gdvStockDetails
            // 
            this.gdvStockDetails.AllowUserToAddRows = false;
            this.gdvStockDetails.AllowUserToDeleteRows = false;
            this.gdvStockDetails.AllowUserToResizeColumns = false;
            this.gdvStockDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(164)))), ((int)(((byte)(71)))));
            this.gdvStockDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gdvStockDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvStockDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName,
            this.StockQty,
            this.UnitName});
            this.gdvStockDetails.Location = new System.Drawing.Point(7, 39);
            this.gdvStockDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdvStockDetails.Name = "gdvStockDetails";
            this.gdvStockDetails.ReadOnly = true;
            this.gdvStockDetails.RowHeadersVisible = false;
            this.gdvStockDetails.Size = new System.Drawing.Size(433, 207);
            this.gdvStockDetails.TabIndex = 17;
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemName.DataPropertyName = "ItemName";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(238)))), ((int)(((byte)(187)))));
            this.ItemName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // StockQty
            // 
            this.StockQty.DataPropertyName = "StockQty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(238)))), ((int)(((byte)(187)))));
            this.StockQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.StockQty.HeaderText = "Qty";
            this.StockQty.Name = "StockQty";
            this.StockQty.ReadOnly = true;
            this.StockQty.Width = 90;
            // 
            // UnitName
            // 
            this.UnitName.DataPropertyName = "UnitName";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(238)))), ((int)(((byte)(187)))));
            this.UnitName.DefaultCellStyle = dataGridViewCellStyle4;
            this.UnitName.HeaderText = "UnitName";
            this.UnitName.Name = "UnitName";
            this.UnitName.ReadOnly = true;
            // 
            // pnlCard3
            // 
            this.pnlCard3.BackColor = System.Drawing.Color.Transparent;
            this.pnlCard3.BackgroundImage = global::StockX.Properties.Resources.card3;
            this.pnlCard3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlCard3.Controls.Add(this.panel3);
            this.pnlCard3.Controls.Add(this.label8);
            this.pnlCard3.Controls.Add(this.lblTotalCustomer);
            this.pnlCard3.Location = new System.Drawing.Point(471, 16);
            this.pnlCard3.Name = "pnlCard3";
            this.pnlCard3.Size = new System.Drawing.Size(210, 127);
            this.pnlCard3.TabIndex = 23;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::StockX.Properties.Resources.rupee;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(12, 57);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(55, 46);
            this.panel3.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("DaytonaPro-Regular", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(17, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(211, 27);
            this.label8.TabIndex = 19;
            this.label8.Text = "TOTAL COLLECTION";
            // 
            // lblTotalCustomer
            // 
            this.lblTotalCustomer.AutoSize = true;
            this.lblTotalCustomer.Font = new System.Drawing.Font("DaytonaPro-Fat", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCustomer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTotalCustomer.Location = new System.Drawing.Point(74, 59);
            this.lblTotalCustomer.Name = "lblTotalCustomer";
            this.lblTotalCustomer.Size = new System.Drawing.Size(46, 41);
            this.lblTotalCustomer.TabIndex = 18;
            this.lblTotalCustomer.Text = " 0";
            // 
            // pnlCard2
            // 
            this.pnlCard2.BackColor = System.Drawing.Color.Transparent;
            this.pnlCard2.BackgroundImage = global::StockX.Properties.Resources.card2;
            this.pnlCard2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlCard2.Controls.Add(this.panel2);
            this.pnlCard2.Controls.Add(this.label7);
            this.pnlCard2.Controls.Add(this.lblTotalBills);
            this.pnlCard2.Location = new System.Drawing.Point(243, 16);
            this.pnlCard2.Name = "pnlCard2";
            this.pnlCard2.Size = new System.Drawing.Size(210, 127);
            this.pnlCard2.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::StockX.Properties.Resources.receipts;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Location = new System.Drawing.Point(17, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(55, 46);
            this.panel2.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("DaytonaPro-Regular", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(15, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 27);
            this.label7.TabIndex = 17;
            this.label7.Text = "TOTAL BILL\'S";
            // 
            // lblTotalBills
            // 
            this.lblTotalBills.AutoSize = true;
            this.lblTotalBills.Font = new System.Drawing.Font("DaytonaPro-Fat", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBills.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTotalBills.Location = new System.Drawing.Point(123, 60);
            this.lblTotalBills.Name = "lblTotalBills";
            this.lblTotalBills.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalBills.Size = new System.Drawing.Size(46, 41);
            this.lblTotalBills.TabIndex = 16;
            this.lblTotalBills.Text = " 0";
            // 
            // pnlCard1
            // 
            this.pnlCard1.BackColor = System.Drawing.Color.Transparent;
            this.pnlCard1.BackgroundImage = global::StockX.Properties.Resources.messagebg21;
            this.pnlCard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlCard1.Controls.Add(this.panel1);
            this.pnlCard1.Controls.Add(this.lblTotalItemSold);
            this.pnlCard1.Controls.Add(this.label1);
            this.pnlCard1.Location = new System.Drawing.Point(14, 16);
            this.pnlCard1.Name = "pnlCard1";
            this.pnlCard1.Size = new System.Drawing.Size(210, 127);
            this.pnlCard1.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::StockX.Properties.Resources.sales;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(17, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(55, 46);
            this.panel1.TabIndex = 19;
            // 
            // lblTotalItemSold
            // 
            this.lblTotalItemSold.AutoSize = true;
            this.lblTotalItemSold.Font = new System.Drawing.Font("DaytonaPro-Fat", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalItemSold.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTotalItemSold.Location = new System.Drawing.Point(96, 65);
            this.lblTotalItemSold.Name = "lblTotalItemSold";
            this.lblTotalItemSold.Size = new System.Drawing.Size(46, 41);
            this.lblTotalItemSold.TabIndex = 14;
            this.lblTotalItemSold.Text = " 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("DaytonaPro-Regular", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "TOTAL ITEM SOLD";
            // 
            // pnlBanner
            // 
            this.pnlBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlBanner.BackgroundImage = global::StockX.Properties.Resources.marqueebg1;
            this.pnlBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBanner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBanner.Controls.Add(this.panel5);
            this.pnlBanner.Controls.Add(this.lblDate);
            this.pnlBanner.Controls.Add(this.lblProductInfo);
            this.pnlBanner.Controls.Add(this.btnMinimize);
            this.pnlBanner.Controls.Add(this.btnClose);
            this.pnlBanner.Location = new System.Drawing.Point(1, -1);
            this.pnlBanner.Name = "pnlBanner";
            this.pnlBanner.Size = new System.Drawing.Size(1098, 36);
            this.pnlBanner.TabIndex = 19;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BackgroundImage = global::StockX.Properties.Resources.logo;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Location = new System.Drawing.Point(500, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(121, 35);
            this.panel5.TabIndex = 18;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("DaytonaPro-Fat", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblDate.Location = new System.Drawing.Point(768, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(80, 37);
            this.lblDate.TabIndex = 17;
            this.lblDate.Text = "Stok";
            // 
            // lblProductInfo
            // 
            this.lblProductInfo.AutoSize = true;
            this.lblProductInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblProductInfo.Font = new System.Drawing.Font("BankGothic Md BT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(65)))), ((int)(((byte)(115)))));
            this.lblProductInfo.Location = new System.Drawing.Point(12, 7);
            this.lblProductInfo.Name = "lblProductInfo";
            this.lblProductInfo.Size = new System.Drawing.Size(110, 25);
            this.lblProductInfo.TabIndex = 0;
            this.lblProductInfo.Text = "label1";
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMinimize.Location = new System.Drawing.Point(975, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(55, 28);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.Text = "_";
            this.btnMinimize.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClose.Location = new System.Drawing.Point(1036, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlHeaderMarquee
            // 
            this.pnlHeaderMarquee.BackgroundImage = global::StockX.Properties.Resources.bg10;
            this.pnlHeaderMarquee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlHeaderMarquee.Controls.Add(this.lblMarquee);
            this.pnlHeaderMarquee.Location = new System.Drawing.Point(166, 35);
            this.pnlHeaderMarquee.Name = "pnlHeaderMarquee";
            this.pnlHeaderMarquee.Size = new System.Drawing.Size(933, 26);
            this.pnlHeaderMarquee.TabIndex = 18;
            // 
            // lblMarquee
            // 
            this.lblMarquee.AutoSize = true;
            this.lblMarquee.BackColor = System.Drawing.Color.Transparent;
            this.lblMarquee.Font = new System.Drawing.Font("DaytonaPro-Cond", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarquee.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMarquee.Location = new System.Drawing.Point(276, 4);
            this.lblMarquee.Name = "lblMarquee";
            this.lblMarquee.Size = new System.Drawing.Size(62, 25);
            this.lblMarquee.TabIndex = 0;
            this.lblMarquee.Text = "label3";
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(211, 6);
            // 
            // smnuExpenseCategory
            // 
            this.smnuExpenseCategory.BackgroundImage = global::StockX.Properties.Resources.marqueebg1;
            this.smnuExpenseCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.smnuExpenseCategory.Name = "smnuExpenseCategory";
            this.smnuExpenseCategory.Size = new System.Drawing.Size(214, 24);
            this.smnuExpenseCategory.Text = "Expense Category";
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(211, 6);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(211, 6);
            // 
            // chtSales
            // 
            chartArea1.Name = "ChartArea1";
            this.chtSales.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chtSales.Legends.Add(legend1);
            this.chtSales.Location = new System.Drawing.Point(21, 8);
            this.chtSales.Name = "chtSales";
            this.chtSales.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "Date";
            this.chtSales.Series.Add(series1);
            this.chtSales.Size = new System.Drawing.Size(415, 227);
            this.chtSales.TabIndex = 0;
            this.chtSales.Text = "Daily Sales";
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(54)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(1100, 729);
            this.Controls.Add(this.pnlSummaryDetails);
            this.Controls.Add(this.pnlBanner);
            this.Controls.Add(this.pnlHeaderMarquee);
            this.Controls.Add(this.pnlShortcuts);
            this.Controls.Add(this.pnlMenuBar);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDashboard_FormClosing);
            this.Load += new System.EventHandler(this.FrmDashboard_Load);
            this.pnlMenuBar.ResumeLayout(false);
            this.pnlMenuBar.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlShortcuts.ResumeLayout(false);
            this.pnlShortcuts.PerformLayout();
            this.pnlSummaryDetails.ResumeLayout(false);
            this.pnlCard4.ResumeLayout(false);
            this.pnlCard4.PerformLayout();
            this.pnlDetails2.ResumeLayout(false);
            this.pnlDetails1.ResumeLayout(false);
            this.pnlDetails1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvStockDetails)).EndInit();
            this.pnlCard3.ResumeLayout(false);
            this.pnlCard3.PerformLayout();
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard2.PerformLayout();
            this.pnlCard1.ResumeLayout(false);
            this.pnlCard1.PerformLayout();
            this.pnlBanner.ResumeLayout(false);
            this.pnlBanner.PerformLayout();
            this.pnlHeaderMarquee.ResumeLayout(false);
            this.pnlHeaderMarquee.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtSales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenuBar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuDashboard;
        private System.Windows.Forms.ToolStripMenuItem mnuMaster;
        private System.Windows.Forms.ToolStripMenuItem mnuReports;
        private System.Windows.Forms.ToolStripMenuItem mnuUtility;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem smnuItemCategoryMaster;
        private System.Windows.Forms.ToolStripMenuItem smnuMaster;
        private System.Windows.Forms.ToolStripMenuItem smnuBilling;
        private System.Windows.Forms.Panel pnlShortcuts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem smnuShopeeDetails;
        private System.Windows.Forms.ToolStripMenuItem smnuItemCategory;
        private System.Windows.Forms.ToolStripMenuItem smnuUserCategory;
        private System.Windows.Forms.ToolStripMenuItem smnuTaxCategory;
        private System.Windows.Forms.ToolStripMenuItem smnuUnitMaster;
        private System.Windows.Forms.ToolStripMenuItem smnuUserMaster;
        private System.Windows.Forms.ToolStripMenuItem smnuCustomerMaster;
        private System.Windows.Forms.ToolStripMenuItem smnuSupplierMaster;
        private System.Windows.Forms.Panel pnlHeaderMarquee;
        private System.Windows.Forms.Label lblMarquee;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem smnuItemMaster;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem smnuStockMaster;
        private System.Windows.Forms.Panel pnlBanner;
        private System.Windows.Forms.Label lblProductInfo;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem smnuStockReports;
        private System.Windows.Forms.ToolStripMenuItem smnuPaymentModes;
        private System.Windows.Forms.Panel pnlSummaryDetails;
        private System.Windows.Forms.Panel pnlDetails2;
        private System.Windows.Forms.Panel pnlDetails1;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Label lblTotalItemSold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalBills;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem smnuBillingDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem smnuDatabaseBackup;
        private System.Windows.Forms.ToolStripMenuItem smnuSettings;
        private System.Windows.Forms.DataGridView gdvStockDetails;
        private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel pnlCard4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalOutstanding;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalCustomer;
        private System.Windows.Forms.Label lblNotification;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private System.Windows.Forms.ToolStripMenuItem mnuAccounting;
        private System.Windows.Forms.ToolStripMenuItem smnuDailyExpenses;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem smnuPendingDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripMenuItem smnuExpenseCategory;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtSales;
    }
}

