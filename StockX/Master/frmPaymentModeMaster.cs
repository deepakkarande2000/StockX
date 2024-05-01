using StockXBEntity;
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

namespace StockX.Master
{
    public partial class frmPaymentModeMaster : Form
    {
        PaymentModeBLL paymentModeBLL=new PaymentModeBLL();
        List<PaymentModeEntity> lstPaymentMode = new List<PaymentModeEntity>();
        private int newscreenLocationX;
        private int newscreenLocationY;

        public frmPaymentModeMaster()
        {
            InitializeComponent();
        }

        public frmPaymentModeMaster(int newscreenLocationX, int newscreenLocationY)
        {
            this.newscreenLocationX = newscreenLocationX;
            this.newscreenLocationY = newscreenLocationY;
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            lstPaymentMode = await paymentModeBLL.AddData(new StockXBEntity.PaymentModeEntity()
            {
                PaymentMode = txtPaymentMode.Text,
            });
            FillPaymentModes(lstPaymentMode);
        }

        private void frmPaymentMode_Load(object sender, EventArgs e)
        {
            Location = new Point(newscreenLocationX, newscreenLocationY);
            SimulateMasterLoad();
        }

        private void SimulateMasterLoad()
        {
            FillPaymentModes(lstPaymentMode);
        }

        private async void FillPaymentModes(List<PaymentModeEntity> lstPaymentMode)
        {
            if(lstPaymentMode.Count() <= 0)
            {
                lstPaymentMode = await paymentModeBLL.GetAllPaymentModes();
            }
            gdvAllTaxCategories.AutoGenerateColumns = false;
            gdvAllTaxCategories.DataSource = lstPaymentMode;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
