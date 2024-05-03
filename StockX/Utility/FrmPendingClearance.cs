using StockX.Transaction;
using StockXBEntity;
using StockXCore;
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
    public partial class FrmPendingClearance : Form
    {
        private int newscreenLocationX;
        private int newscreenLocationY;

        List<PaymentModeEntity> lstPaymentMode = new List<PaymentModeEntity>();

        CustomerMasterBLL customerMasterBLL = new CustomerMasterBLL();
        OutstandingBLL outstandingBLL = new OutstandingBLL();
        PaymentModeBLL paymentModeBLL = new PaymentModeBLL();
        BillingBLL billingBLL = new BillingBLL();

        frmBilling frmbilling = new frmBilling();
        public FrmPendingClearance()
        {
            InitializeComponent();
        }

        public FrmPendingClearance(int newscreenLocationX, int newscreenLocationY, int width, int height)
        {
            InitializeComponent();
            this.newscreenLocationX = newscreenLocationX;
            this.newscreenLocationY = newscreenLocationY;
            this.Width = width;
            this.Height = height;
        }

        private void FrmPayInOut_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(newscreenLocationX, newscreenLocationY);
            SimulateMasterLoad();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private async void SimulateMasterLoad()
        {
            SetDefaultValues();
            GetAllPendingCustomer();
            FillPaymentMode();
            ClearAllControls();
        }

        private async void FillPaymentMode()
        {
            if (lstPaymentMode.Count <= 0)
            {
                lstPaymentMode = await paymentModeBLL.GetAllPaymentModes();
                cboPaymentMode.DataSource = lstPaymentMode;
                cboPaymentMode.DisplayMember = "PaymentMode";
                cboPaymentMode.ValueMember = "ID";
            }
        }

        private void SetDefaultValues()
        {


        }
        private async void GetCustomerAllDetails()
        {
            await customerMasterBLL.GetAllCustomers();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void GetAllPendingCustomer()
        {
            DataSet dsOutstanding = await outstandingBLL.GetOutstandingCustomers();
            if (dsOutstanding != null)
            {
                if (dsOutstanding.Tables.Count > 0)
                {
                    //lblPendingAmt.Text = dsOutstanding.Tables[0].Rows[0].ItemArray[4].ToString();
                    gdvPendingDetails.AutoGenerateColumns = false;
                    gdvPendingDetails.DataSource = dsOutstanding.Tables[0];
                }
            }
            else
            {

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Text == "" || txtPayingAmt.Text == "")
            {
                await frmbilling.showMessage("Please select a Customer or add paying amount before save", "OK");
                txtPayingAmt.Focus();
                txtPayingAmt.SelectAll();
                return;
            }
            else { }


            if (Convert.ToDecimal(lblPendingAmt.Text) == Convert.ToDecimal(txtPayingAmt.Text))
            {
                await outstandingBLL.DeleteCustomerPending(Convert.ToInt64(lblBillNo.Text));
            }
            else
            {

                await outstandingBLL.InsertUpdatePendingAmount(Convert.ToInt64(lblBillNo.Text),
                    Convert.ToInt64(txtCustomerID.Text), Convert.ToDecimal(txtPayingAmt.Text),
                    dtpBillDate.Value.Date.ToString("yyyyMMdd"));

            }

            await billingBLL.UpdatePaymentDetails(Convert.ToInt64(lblBillNo.Text), dtpBillDate.Value.Date.ToString("yyyyMMdd"),
                Convert.ToInt32(cboPaymentMode.SelectedValue), Convert.ToDecimal(txtPayingAmt.Text));

            await frmbilling.showMessage("Payment Details Updated Successfully.....!", "OK");
            SimulateMasterLoad();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gdvPendingDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdvPendingDetails.CurrentRow != null)
            {
                if (gdvPendingDetails.CurrentRow.Cells["Name"].Value.ToString() != "")
                {
                    DateTime billDate =DateTime.Now;

                    lblBillNo.Text = gdvPendingDetails.CurrentRow.Cells["BillID"].Value.ToString();
                    txtCustomerID.Text = gdvPendingDetails.CurrentRow.Cells["CustomerID"].Value.ToString();
                    txtCustomerName.Text = gdvPendingDetails.CurrentRow.Cells["Name"].Value.ToString();
                    txtContact.Text = gdvPendingDetails.CurrentRow.Cells["MobileNo"].Value.ToString();
                    lblPendingAmt.Text = gdvPendingDetails.CurrentRow.Cells["TotalPending"].Value.ToString();
                    DateTime.TryParse(gdvPendingDetails.CurrentRow.Cells["BillDate"].Value.ToString(),out billDate);
                    dtpBillDate.Value = Convert.ToDateTime(billDate);
                }
                else
                {
                    ClearAllControls();
                }
            }
            else { }
        }

        private void ClearAllControls()
        {
            lblBillNo.Text = "0";
            txtCustomerID.Text = "0";
            txtCustomerName.Text = "";
            txtContact.Text = "";
            txtPayingAmt.Text = "0";
            lblPendingAmt.Text = "0";
        }

        private void txtPayingAmt_TextChanged(object sender, EventArgs e)
        {
            if (lblPendingAmt.Text != "")
            {
                if ((Convert.ToDecimal(lblPendingAmt.Text) - Convert.ToDecimal(txtPayingAmt.Text)) < 0)
                {
                    lblNewPending.Text = "0";
                }
                else
                {
                    lblNewPending.Text = (Convert.ToDecimal(lblPendingAmt.Text) - Convert.ToDecimal(txtPayingAmt.Text)).ToString();
                }
            }
            else { }
        }
    }
}
