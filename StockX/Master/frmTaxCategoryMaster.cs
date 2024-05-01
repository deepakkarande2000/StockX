using StockXBEntity;
using StokXBLL;
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
    public partial class frmTaxCategoryMaster : Form
    {
        TaxMasterBLL _taxMasterBLL = new TaxMasterBLL();
        List<TaxCategoryEntity> lstTaxCategories = null;
        private int newscreenLocationX;
        private int newscreenLocationY;

        public frmTaxCategoryMaster()
        {
            InitializeComponent();
        }

        public frmTaxCategoryMaster(int newscreenLocationX, int newscreenLocationY)
        {
            this.newscreenLocationX = newscreenLocationX;
            this.newscreenLocationY = newscreenLocationY;
            InitializeComponent();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void frmTaxCategoryMaster_Load(object sender, EventArgs e)
        {Location = new Point(newscreenLocationX, newscreenLocationY);
            SimulateMasterLoad();
        }

        private void SimulateMasterLoad()
        {
            ClearAllControls();
            FillDatagridView(lstTaxCategories);
        }

        private void ClearAllControls()
        {
            txtID.Text = "";
            txtPercentage.Text = "0";
            txtTaxName.Text = "";
        }

        private async void FillDatagridView(List<TaxCategoryEntity> lstTaxCategories)
        {
            gdvAllTaxCategories.AutoGenerateColumns = false;
            if (lstTaxCategories == null)
            {
                lstTaxCategories = await _taxMasterBLL.GetAllTaxCategories();
            }
            gdvAllTaxCategories.DataSource = lstTaxCategories;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            lstTaxCategories = await _taxMasterBLL.AddData(new TaxCategoryEntity() { TaxName = txtTaxName.Text, Percentage = Convert.ToDecimal(txtPercentage.Text) });
            FillDatagridView(lstTaxCategories);
            ClearAllControls();
        }
    }
}
