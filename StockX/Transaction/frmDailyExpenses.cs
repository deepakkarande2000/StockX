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

namespace StockX.Transaction
{
    public partial class frmDailyExpenses : Form
    {
        private int newscreenLocationX;
        private int newscreenLocationY;
        private int v;
        PaymentModeBLL paymentModeBLL = new PaymentModeBLL();
        DailyExpenseBLL dailyExpenseBLL = new DailyExpenseBLL();
        frmBilling frmBilling = new frmBilling();
        List<PaymentModeEntity> lstPaymentMode = new List<PaymentModeEntity>();
        List<ExpenseTitleMasterEntity> lstExpensetitle = new List<ExpenseTitleMasterEntity>();
        public frmDailyExpenses()
        {
            InitializeComponent();
        }

        public frmDailyExpenses(int newscreenLocationX, int newscreenLocationY, int v, int height)
        {
            InitializeComponent();
            this.newscreenLocationX = newscreenLocationX;
            this.newscreenLocationY = newscreenLocationY;
            this.v = v;
            Height = height;
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

        }
        private void frmDailyExpenses_Load(object sender, EventArgs e)
        {
            this.Location = new Point(this.newscreenLocationX, this.newscreenLocationY);
            this.Size = new Size(this.v, Height);
            SimulateMasterLoad();
        }

        private void SimulateMasterLoad()
        {
            FillPaymentModes();
            FillDailyExpenseTitle();
            SetDefaultValues();
            GetDailyExpenses();
            ClearAllControls();
        }

        private async void GetDailyExpenses()
        {
            DataSet dsDailyExpense = await dailyExpenseBLL.GetDailyExpenses(dtpBillDate.Value.Date.ToString("yyyyMMdd"));

            if (dsDailyExpense != null)
            {
                if (dsDailyExpense.Tables.Count > 0)
                {
                    gdvItemDetails.AutoGenerateColumns = false;
                    gdvItemDetails.DataSource = dsDailyExpense.Tables[0];
                }
                else { }
            }
            else { }
        }

        private void SetDefaultValues()
        {
            dtpBillDate.MaxDate = DateTime.Now.Date;
            dtpBillDate.Value = DateTime.Now.Date;
        }

        private async void FillPaymentModes()
        {
            lstPaymentMode = await paymentModeBLL.GetAllPaymentModes();
            if (lstPaymentMode != null)
            {
                cboPaymentModes.DataSource = lstPaymentMode;
                cboPaymentModes.DisplayMember = "PaymentMode";
                cboPaymentModes.ValueMember = "ID";
            }
            else
            {
                cboPaymentModes.DataSource = null;
            }
        }

        private async void FillDailyExpenseTitle()
        {
            lstExpensetitle = await dailyExpenseBLL.GetAllExpenseTitle();
         
            if (lstExpensetitle != null)
            {
                cboExpenseTitle.DataSource = lstExpensetitle;
                cboExpenseTitle.DisplayMember = "ExpenseTitle";
                cboExpenseTitle.ValueMember = "ExpenseID";
                cboExpenseTitle.SelectedValue = -1;
            }
            else
            {
                cboExpenseTitle.DataSource = null;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
          bool result =  await dailyExpenseBLL.InsertUpdateDailyExpenses(Convert.ToInt64(cboExpenseTitle.SelectedValue), dtpBillDate.Value.Date.ToString("yyyyMMdd"),
                Convert.ToDecimal(txtAmount.Text), Convert.ToInt32(cboPaymentModes.SelectedValue), txtDescription.Text.Trim(),
                Convert.ToInt64(cboPaymentModes.SelectedValue), txtPayee.Text.Trim());

            if(result)
            {                
                await frmBilling.showMessage(Constants.Message_Types.DATA_SAVE, "Ok");
            }
            else
            {

            }
            SimulateMasterLoad();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllControls();
        }

        private void ClearAllControls()
        {
            txtAmount.Text = "0";
            txtDescription.Text = "";
            txtPayee.Text = "";
            cboExpenseTitle.SelectedIndex = -1;
            cboPaymentModes.SelectedIndex = -1;
        }
    }
}
