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
    public partial class frmUnitMaster : Form
    {
        UnitMasterBLL _unitMasterBLL = new UnitMasterBLL();
        List<UnitCategoryEntity> lstUnitCategory = null;
        private int newscreenLocationX;
        private int newscreenLocationY;

        public frmUnitMaster()
        {
            InitializeComponent();
        }

        public frmUnitMaster(int newscreenLocationX, int newscreenLocationY)
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
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUnitName.Text != "" && txtQty.Text != "")
            {
                if (txtID.Text != "")
                {
                    lstUnitCategory = await _unitMasterBLL.Update(new StockXBEntity.UnitCategoryEntity() { UnitID = Convert.ToInt32(txtID.Text), Qty = Convert.ToDecimal(txtQty.Text), UnitName = txtUnitName.Text });
                }
                else
                {
                    lstUnitCategory = await _unitMasterBLL.AddData(new StockXBEntity.UnitCategoryEntity() { Qty = Convert.ToDecimal(txtQty.Text), UnitName = txtUnitName.Text });
                }


                fillUnitDetailGridview(lstUnitCategory);
            }
            else { }

        }

        private void frmUnitMaster_Load(object sender, EventArgs e)
        {
            this.Location = new Point(newscreenLocationX, newscreenLocationY);
            SimulateMasterLoad();
        }

        private void SimulateMasterLoad()
        {
            fillUnitDetailGridview(lstUnitCategory);
        }

        private async void fillUnitDetailGridview(List<UnitCategoryEntity> lstUnitCategory)
        {
            if (lstUnitCategory == null)
            {
                lstUnitCategory = await _unitMasterBLL.GetAllUnits();
            }
            else { }

            gdvAllTaxCategories.AutoGenerateColumns = false;
            gdvAllTaxCategories.DataSource = lstUnitCategory;
        }

        private void gdvAllTaxCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdvAllTaxCategories.CurrentRow.Cells["UnitName"].Value != null)
            {
                txtUnitName.Text = gdvAllTaxCategories.CurrentRow.Cells["UnitName"].Value.ToString();
            }
            if (gdvAllTaxCategories.CurrentRow.Cells["UnitID"].Value != null)
            {
                txtID.Text = gdvAllTaxCategories.CurrentRow.Cells["UnitID"].Value.ToString();
            }
            if (gdvAllTaxCategories.CurrentRow.Cells["Qty"].Value != null)
            {
                txtQty.Text = gdvAllTaxCategories.CurrentRow.Cells["Qty"].Value.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            lstUnitCategory = await _unitMasterBLL.Delete(new StockXBEntity.UnitCategoryEntity() { UnitID=Convert.ToInt32(txtID.Text)});
            
            fillUnitDetailGridview(lstUnitCategory);
        }
    }
}
