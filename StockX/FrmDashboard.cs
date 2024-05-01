using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockX.Master;
using StockX.Reports;
using StockX.Transaction;
using StockX.Utility;
using StockXBEntity;
using StockXCore;
using StokXBLL;
using StokXBLL.Repository;

namespace StockX
{
    public partial class FrmDashboard : Form
    {
        int _totalWidth = 0;
        int _totalHeight = 0;
        frmLogin _frmLogin;
        int LocationX = 0;
        int LocationYForNotification = 0;
        int NewscreenLocationX = 0;
        int NewscreenLocationY = 0;

        LoginBLL _loginBLL = new LoginBLL();
        BillingBLL billingBLL = new BillingBLL();
        ShopeeDetailsBLL shopeeDetailsBLL=new ShopeeDetailsBLL();
        StockMasterBLL stockMasterBLL = new StockMasterBLL();
        OutstandingBLL outstandingBLL = new OutstandingBLL();

        frmMessageBox frmMessageBox;
        FrmSplashScreen frmSplashScreen;
        public FrmDashboard()
        {
            InitializeComponent();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);  

            if(e.KeyCode == Keys.Escape)
            {
                Close();
            }
            if (e.KeyCode == Keys.F1)
            {
                LoadBillingScreen();
            }
            if (e.KeyCode == Keys.F2)
            {
                LoadItemMasterScreen();
            }
            if (e.KeyCode == Keys.F3)
            {
                LoadCustomerMasterScreen();
            }
            if (e.KeyCode == Keys.F4)
            {
                LoadStockMasterScreen();
            }
            if (e.KeyCode == Keys.F5)
            {
                LoadBillDetailsScreen();
            }
            if (e.KeyCode == Keys.F6)
            {
                LoadReportScreen();
            }
            if (e.KeyCode == Keys.F7)
            {
                LoadSettingScreen();
            }
        }

        private void LoadBillDetailsScreen()
        {
            frmBillDetails frmBillDetails = new frmBillDetails(NewscreenLocationX, NewscreenLocationY,_totalWidth - pnlMenuBar.Width, pnlSummaryDetails.Height);
            frmBillDetails.ShowDialog();
        }

        private void LoadStockMasterScreen()
        {
            frmStockMaster frmStockMaster = new frmStockMaster(NewscreenLocationX, NewscreenLocationY);
            frmStockMaster.ShowDialog();
        }

        private void LoadCustomerMasterScreen()
        {
            frmCustomerMaster frmCustomerMaster = new frmCustomerMaster(NewscreenLocationX, NewscreenLocationY);
            frmCustomerMaster.ShowDialog();
        }

        private void LoadItemMasterScreen()
        {
            frmItemMaster _frmitem = new frmItemMaster(NewscreenLocationX, NewscreenLocationY, _totalWidth - pnlMenuBar.Width, pnlSummaryDetails.Height);
            _frmitem.ShowDialog();
        }
        private void LoadBillingScreen()
        {
            if (Application.OpenForms.OfType<frmBilling>().Any())
            {
                Application.OpenForms.OfType<frmBilling>().First().BringToFront();
            }
            else
            {
                frmBilling _frmBilling = new frmBilling(NewscreenLocationX, NewscreenLocationY,
                    _totalWidth - pnlMenuBar.Width, pnlSummaryDetails.Height);
                _frmBilling.Show();
            }           
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            Hide();
            _frmLogin = new frmLogin();
            _frmLogin.ShowDialog();

            if (_frmLogin._isLoginSuccess)
            {
                _frmLogin.Close();
                if (GlobalCollection.dsCurrentLoginUserDetails.Tables[0].Rows.Count > 0)
                {
                    if (GlobalCollection.dsCurrentLoginUserDetails.Tables[0].Rows[0].ItemArray[5].ToString() == "1")
                    {
                        LoadUserMaster();
                    }
                }
            }
            else
            {
                Close();
            }

            SimulateMasterLoad();
        }

        private void SimulateMasterLoad()
        {
            ResizeScreen();            
            ClearAllControls();
            GetTenantDetails();
            SetDefaultValues();
            LoadTodaysSummary();
            LoadOutstanding();
            LoadItemStock();
        }

        private async void LoadItemStock()
        {
            GlobalCollection.dsStockDetails = await stockMasterBLL.GetStockDetails();

            if (GlobalCollection.dsStockDetails != null)
            {
                if(GlobalCollection.dsStockDetails.Tables.Count >0)
                {
                    gdvStockDetails.Size=new Size(pnlDetails1.Width,pnlDetails1.Height);
                    gdvStockDetails.AutoGenerateColumns = false;
                    gdvStockDetails.DataSource = GlobalCollection.dsStockDetails.Tables[0];
                }
            }
        }

        public async void LoadOutstanding()
        {
            GlobalCollection.dsPendingResult = await outstandingBLL.GetOutstandingCustomers();

            StringBuilder sb = new StringBuilder();
            if (GlobalCollection.dsPendingResult != null)
            {
                lblTotalOutstanding.Text = "₹ " + GlobalCollection.dsPendingResult.Tables[0]
                    .AsEnumerable().Sum(c => c.Field<decimal>("Total Pending")).ToString();


                    foreach (DataRow item in GlobalCollection.dsPendingResult.Tables[0].Rows)
                    {
                        if (item.ItemArray.Length > 0)
                        {
                            sb.Append(" | " + item.ItemArray[2].ToString() + ", " + item.ItemArray[3] + ", " + item.ItemArray[4] + " ₹ "
                                + item.ItemArray[5]);
                        }
                    }                    
                
                lblMarquee.Text = lblMarquee.Text + "***" + sb.ToString();
                
            }
            else { }
        }

        private void LoadTodaysSummary()
        {
            DataSet dsSummary = billingBLL.GetTodaysSummaryDetails(DateTime.UtcNow.ToString("yyyyMMdd"));

            if (dsSummary.Tables.Count > 1)
            {
                lblTotalItemSold.Text = dsSummary.Tables[1].Rows[0][0].ToString();
                lblTotalBills.Text = dsSummary.Tables[0].Rows[0][0].ToString();
                lblTotalCustomer.Text = "₹ " + dsSummary.Tables[2].Rows[0][0].ToString();
                if (dsSummary.Tables.Count > 3)
                {

                }
            }
            else
            {
                lblTotalBills.Text = "0";
                lblTotalItemSold.Text = "0";
            }
        }

        private async void GetTenantDetails()
        {
            var result=await shopeeDetailsBLL.GetShopeeDetails();
            lblProductInfo.Text = "::: " + result.ShopeeName + " :::";
        }

        private void SetDefaultValues()
        {
            LocationX = _totalWidth;
            LocationYForNotification = pnlShortcuts.Location.Y;
        }

        private void ResizeScreen()
        {
            _totalWidth = Screen.PrimaryScreen.WorkingArea.Width;
            _totalHeight = Screen.PrimaryScreen.WorkingArea.Height;
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            this.Height = _totalHeight;
            this.Width = _totalWidth;
            this.Location = new Point(0, 0);
            pnlBanner.Location = new Point(0, 0);
            pnlBanner.Size = new Size(_totalWidth, pnlBanner.Height);
            pnlMenuBar.Location = new Point(0, pnlBanner.Height);
            pnlMenuBar.Height = _totalHeight - pnlBanner.Height;
            //pnlTotalItemSold.Location = new Point(_totalWidth / 2 - pnlTotalItemSold.Width / 2, _totalHeight / 2 - pnlTotalItemSold.Height / 2);

            pnlShortcuts.Location = new Point(0, _totalHeight - pnlShortcuts.Height);
            pnlShortcuts.Size = new Size(_totalWidth, pnlShortcuts.Height);

            NewscreenLocationX = pnlMenuBar.Width;
            NewscreenLocationY = pnlBanner.Height + pnlHeaderMarquee.Height;

            pnlHeaderMarquee.Location = new Point(pnlMenuBar.Width, pnlBanner.Height+pnlBanner.Location.Y);
            pnlHeaderMarquee.Size = new Size((_totalWidth), pnlHeaderMarquee.Height);

            lblMarquee.Text = $"Todays Date -" + DateTime.UtcNow.ToLongDateString();

            lblNotification.Text = $"Days to renew " + GetValidity() + "\n Hurryup \nmake a call @\n+9850622535";

            btnClose.Location = new Point(_totalWidth - btnClose.Width, btnClose.Location.Y);
            btnMinimize.Location = new Point(_totalWidth - (btnClose.Width + btnMinimize.Width), btnClose.Location.Y);

            pnlSummaryDetails.Size=new Size(_totalWidth-pnlMenuBar.Width,(_totalHeight-((pnlShortcuts.Height)*3)));
            pnlSummaryDetails.Location = new Point(pnlMenuBar.Width, (pnlHeaderMarquee.Location.Y + pnlHeaderMarquee.Height));
            
            int cardwidth = (pnlSummaryDetails.Width / 4)-10;
           
            pnlCard1.Size = new Size(cardwidth, pnlCard1.Height);
            pnlCard1.Location = new Point(0, 0);//pnlHeaderMarquee.Location.Y + pnlHeaderMarquee.Height

            pnlCard2.Size = new Size(cardwidth, pnlCard1.Height);
            pnlCard2.Location = new Point(pnlCard1.Width, 0);

            pnlCard3.Size = new Size(cardwidth, pnlCard1.Height);
            pnlCard3.Location = new Point(pnlCard1.Width+pnlCard2.Width, 0);

            pnlCard4.Size = new Size(cardwidth, pnlCard1.Height);
            pnlCard4.Location = new Point(pnlCard1.Width+ pnlCard1.Width+pnlCard3.Width, 0);

            pnlDetails1.Size = new Size(pnlSummaryDetails.Width / 2, (pnlSummaryDetails.Height - (pnlCard1.Height-pnlShortcuts.Height)));
            //pnlDetails1.Location = new Point(0, pnlDetails1.Location.Y);
            pnlDetails1.Location = new Point(0, pnlCard1.Height);

            pnlDetails2.Size = new Size(pnlSummaryDetails.Width / 2, (pnlSummaryDetails.Height - (pnlCard1.Height)));
            pnlDetails2.Location = new Point(pnlDetails1.Width, pnlCard1.Height);          

            lblDate.Location = new Point(btnMinimize.Location.X - ((lblDate.Text.Length+btnClose.Width+btnClose.Width)*2), lblDate.Location.Y);
        }

        private string GetValidity()
        {
            if (GlobalCollection.dsAppSettings.Tables[0].AsEnumerable().Where(c => c.Field<string>("col1") == "davli").Any())
            {
                string ValidityDate = GlobalCollection.dsAppSettings.Tables[0]
                    .AsEnumerable()
                    .Where(c => c.Field<string>("col1") == "davli")
                    .Select(c => c.Field<string>("col2"))
                    .FirstOrDefault();
                DateTime ExpiryDate = Convert.ToDateTime(ValidityDate);

                string days = (ExpiryDate.Date - DateTime.UtcNow.Date).TotalDays.ToString();

                return days;
            }
            else
            {
                return "";
            }
        }

        private void ClearAllControls()
        {
            
        }

        private void smnuItemCategoryMAster_Click(object sender, EventArgs e)
        {
            
        }

        private void smnuTaxCategoryMaster_Click(object sender, EventArgs e)
        {
          
        }

        private void smnuUnitMaster_Click(object sender, EventArgs e)
        {
            frmUnitMaster _frmUnitMaster =new frmUnitMaster();
            _frmUnitMaster.ShowDialog();
        }

        private void smnuItemMaster_Click(object sender, EventArgs e)
        {
           
        }

        private void smnuBilling_Click(object sender, EventArgs e)
        {
            LoadBillingScreen();
        }

        private void smnuItemCategory_Click(object sender, EventArgs e)
        {
            frmItemCategoryMaster frmItemCategoryMaster = new frmItemCategoryMaster(NewscreenLocationX, NewscreenLocationY,
                 _totalWidth - pnlMenuBar.Width, pnlSummaryDetails.Height);
            frmItemCategoryMaster.ShowDialog();

        }

        private void smnuUserCategory_Click(object sender, EventArgs e)
        {
            frmUserCategoryMaster _frmUserCategoryMaster = new frmUserCategoryMaster(NewscreenLocationX, NewscreenLocationY,
                 _totalWidth - pnlMenuBar.Width, pnlSummaryDetails.Height);
            _frmUserCategoryMaster.ShowDialog();
        }

        private void smnuTaxCategory_Click(object sender, EventArgs e)
        {
            frmTaxCategoryMaster _frmTaxCategoryMaster = new frmTaxCategoryMaster(NewscreenLocationX, NewscreenLocationY);
            _frmTaxCategoryMaster.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblNotification.Hide();
            if (LocationX < -(lblMarquee.Width))
            {
                LocationX = _totalWidth;
            }

            LocationX = LocationX - 5;
            lblMarquee.Location = new Point(LocationX, lblMarquee.Location.Y);

            lblDate.Text = DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss");

            if (LocationYForNotification < (pnlMenuBar.Height / 2))
            {
                LocationYForNotification = pnlShortcuts.Location.Y;
            }
            LocationYForNotification = LocationYForNotification - 2;
            lblNotification.Location = new Point(-1, LocationYForNotification);
            lblNotification.Show();
        }

        private void smnuItemMaster_Click_1(object sender, EventArgs e)
        {
            LoadItemMasterScreen();
        }

        private void smnuUserMaster_Click(object sender, EventArgs e)
        {
            LoadUserMaster();
        }

        private void LoadUserMaster()
        {
            frmUserMaster _frmUserMaster = new frmUserMaster(NewscreenLocationX, NewscreenLocationY);
            _frmUserMaster.ShowDialog();
        }

        private void smnuShopeeDetails_Click(object sender, EventArgs e)
        {
            frmShopeeDetails _frmShopeeDetails = new frmShopeeDetails(NewscreenLocationX, NewscreenLocationY);
            _frmShopeeDetails.ShowDialog();
        }

        private void smnuStockMaster_Click(object sender, EventArgs e)
        {
            LoadStockMasterScreen();
        }

        private void smnuCustomerMaster_Click(object sender, EventArgs e)
        {
            LoadCustomerMasterScreen();
        }

        private void smnuUnitMaster_Click_1(object sender, EventArgs e)
        {
            frmUnitMaster _frmUnitMaster= new frmUnitMaster(NewscreenLocationX, NewscreenLocationY);
            _frmUnitMaster.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async Task<string> showMessage(string message, string button = "OK")
        {
            frmMessageBox = new frmMessageBox();
            frmMessageBox._Message = message;
            frmMessageBox._Button = button;
            frmMessageBox.ShowDialog();
            return frmMessageBox.result;
        }
        private async void FrmDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_frmLogin._isLoginSuccess)
            {
                string message = await showMessage("Are You Sure You Want To Close this application.....?", "YesNo");
                
                if (message == Constants.Message_Button_Type.YES)
                {
                    return;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                Dispose();
                return;
            }
        }

        private void smnuSupplierMaster_Click(object sender, EventArgs e)
        {
            frmSupplierMaster frmSupplierMaster = new frmSupplierMaster(NewscreenLocationX, NewscreenLocationY);
            frmSupplierMaster.ShowDialog();
        }

        private void smnuStockReports_Click(object sender, EventArgs e)
        {
            LoadReportScreen();

        }

        private void LoadReportScreen()
        {
            frmReports frmReports = new frmReports(NewscreenLocationX, NewscreenLocationY, _totalWidth - pnlMenuBar.Width, pnlSummaryDetails.Height);
            frmReports.ShowDialog();
        }

        private void pnlMenuBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void smnuPaymentModes_Click(object sender, EventArgs e)
        {
            frmPaymentModeMaster frmPaymentMode = new frmPaymentModeMaster(NewscreenLocationX, NewscreenLocationY);
            frmPaymentMode.ShowDialog();
        }

        private void smnuBillingDetails_Click(object sender, EventArgs e)
        {
            LoadBillDetailsScreen();
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            LoadTodaysSummary();
            LoadOutstanding();
            LoadItemStock();
        }
        
        private void smnuSettings_Click(object sender, EventArgs e)
        {
            LoadSettingScreen();
        }

        private void LoadSettingScreen()
        {
            FrmSettings frmSettings = new FrmSettings(NewscreenLocationX, NewscreenLocationY, _totalWidth - pnlMenuBar.Width, pnlSummaryDetails.Height);
            frmSettings.ShowDialog();
        }

        private void smnuPendingDetails_Click_1(object sender, EventArgs e)
        {
            FrmPendingClearance frmPayInOut = new FrmPendingClearance(NewscreenLocationX, NewscreenLocationY, _totalWidth - pnlMenuBar.Width, pnlSummaryDetails.Height);
            frmPayInOut.ShowDialog();
        }
    }
}
