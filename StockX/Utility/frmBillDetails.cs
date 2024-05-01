using StockXBEntity;
using StockXExceptionLogger;
using StokXBLL.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockX.Utility
{
    public partial class frmBillDetails : Form
    {
        private int newscreenLocationX;
        private int newscreenLocationY;
        int _height = 0;
        int _width = 0;
        BillingBLL billingBLL;

        DataSet dsAllBills=new DataSet();
        public frmBillDetails()
        {
            InitializeComponent();
        }

        public frmBillDetails(int newscreenLocationX, int newscreenLocationY, int width, int height)
        {
            InitializeComponent();
            this.newscreenLocationX = newscreenLocationX;
            this.newscreenLocationY = newscreenLocationY;
            _height = height;
            _width = width;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            
        }

        private void frmPaymentMode_Load(object sender, EventArgs e)
        {
            this.Height = _height;
            this.Width = _width;
            Location = new Point(newscreenLocationX, newscreenLocationY);
            gdvBillDetails.SelectionChanged -= gdvBillDetails_SelectionChanged;
            LoadBillDetails(DateTime.UtcNow.ToString("yyyyMMdd"));
            SetDefaultValues();
        }

        private void SetDefaultValues()
        {
            dtpBillDate.MaxDate = DateTime.UtcNow.Date;
            dtpBillDate.Value = DateTime.UtcNow.Date;
        }

        private async void LoadBillDetails(string BillDate)
        {
            billingBLL = new BillingBLL();
            dsAllBills = await billingBLL.GetAllBillDetailsForDate(BillDate);

            if(dsAllBills!=null)
            {
                if(dsAllBills.Tables.Count>0) 
                {
                    gdvBillDetails.DataSource = null;
                    gdvBillDetails.AutoGenerateColumns = false;

                    gdvBillDetails.SelectionChanged -= gdvBillDetails_SelectionChanged;
                    gdvBillDetails.DataSource = dsAllBills.Tables[0];
                    

                    if (gdvBillDetails.Rows.Count > 0)
                    {
                        lblTotalAmount.Text = dsAllBills.Tables[0]
                            .AsEnumerable().Sum(c => c.Field<decimal>("TotalBillAmount")).ToString();
                        
                        lblTotalDiscount.Text = dsAllBills.Tables[0]
                            .AsEnumerable().Sum(c => c.Field<decimal>("TotalDiscount")).ToString();

                        lblTotalTax.Text = dsAllBills.Tables[0]
                            .AsEnumerable().Sum(c => c.Field<decimal>("TotalTax")).ToString();

                        GetAllItemsForSelectedBill();
                        GetAllPaymentDetailsForSelecedBil();
                        gdvBillDetails.Rows[0].Selected = true;
                    }
                    else
                    {
                        lblTotalAmount.Text = "0";
                        gdvBillItemDetails.DataSource = null;
                        gdvBillPaymentDetails.DataSource = null;
                    }
                    gdvBillDetails.SelectionChanged += gdvBillDetails_SelectionChanged;
                }
                else { }
            }
        }

        private void GetAllPaymentDetailsForSelecedBil()
        {
            if (gdvBillDetails.CurrentRow.Index > -1)
            {
                gdvBillPaymentDetails.AutoGenerateColumns = false;
                gdvBillPaymentDetails.DataSource = null;
                if (dsAllBills.Tables[3].AsEnumerable()
                    .Where(c => c.Field<long>("BillID") == Convert.ToInt64(gdvBillDetails.CurrentRow.Cells[0].Value)).Any())
                {
                    var result = dsAllBills.Tables[3].AsEnumerable()
                        .Where(c => c.Field<long>("BillID") == Convert.ToInt64(gdvBillDetails.CurrentRow.Cells[0].Value)).CopyToDataTable();
                    gdvBillPaymentDetails.DataSource = result;
                    gdvBillPaymentDetails.Refresh();
                    gdvBillPaymentDetails.ClearSelection();
                }
                else { }
            }
            else { }
        }

        private void GetAllItemsForSelectedBill()
        {
            if (gdvBillDetails.CurrentRow.Index > -1)
            {
                gdvBillItemDetails.AutoGenerateColumns = false;
                gdvBillItemDetails.DataSource = null;
                if (dsAllBills.Tables[1].AsEnumerable()
                    .Where(c => c.Field<long>("BillID") == Convert.ToInt64(gdvBillDetails.CurrentRow.Cells[0].Value)).Any())
                {
                    var result = dsAllBills.Tables[1].AsEnumerable()
                        .Where(c => c.Field<long>("BillID") == Convert.ToInt64(gdvBillDetails.CurrentRow.Cells[0].Value)).CopyToDataTable();
                    gdvBillItemDetails.DataSource = result;
                    gdvBillItemDetails.Refresh();
                    gdvBillItemDetails.ClearSelection();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        }

        private async void gdvBillDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            {
                //gdvBillDetails.SelectionChanged += gdvBillDetails_SelectionChanged;
                //LoadBillDetailsAndPayments();
            }
            if (e.KeyCode==Keys.Enter)
            {
                await PrintBill(gdvBillDetails.CurrentRow.Cells["BillID"].Value.ToString());
            }
        }

        private void LoadBillDetailsAndPayments()
        {
            if (gdvBillDetails.Rows.Count > 0)
            {
                //gdvBillItemDetails.DataSource = null;
                //gdvBillItemDetails.Refresh();
                //gdvBillPaymentDetails.DataSource = null;
                //gdvBillPaymentDetails.Refresh();
                gdvBillDetails.CurrentRow.Selected = true;
                GetAllItemsForSelectedBill();
                GetAllPaymentDetailsForSelecedBil();
            }
            else { }
        }

        public async Task PrintBill(string BillId) {
            try
            {                
                frmReports frmReports = new frmReports();
                frmReports.BillNo = BillId;
                frmReports.PrintReport = true;
                frmReports.ReportName = "Bill";
                await frmReports.GenerateReport();
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionLog(ex);
            }
            
        }

        private void gdvBillDetails_SelectionChanged(object sender, EventArgs e)
        {
            LoadBillDetailsAndPayments();
        }

        private void gdvBillItemDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException=false;
            e.Cancel = false;
        }

        private void gdvBillPaymentDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = false;
        }

        private void btnGetDetails_Click(object sender, EventArgs e)
        {
            LoadBillDetails(dtpBillDate.Value.Date.ToString("yyyyMMdd"));
        }
    }
}
