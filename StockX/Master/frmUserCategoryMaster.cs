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

namespace StockX.Master
{
    public partial class frmUserCategoryMaster : Form
    {
        UserCategoryBLL userCategoryBLL = new UserCategoryBLL();
        List<UserCategoryEntity> lstUserCategory = new List<UserCategoryEntity>();
        private int newscreenLocationX;
        private int newscreenLocationY;
        private int _width;
        private int _height;

        frmBilling frmBilling;
        public frmUserCategoryMaster()
        {
            InitializeComponent();
        }      

        public frmUserCategoryMaster(int newscreenLocationX, int newscreenLocationY, int width, int height)
        {
            _width = width;
            _height = height;
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
        private void frmUserCategoryMaster_Load(object sender, EventArgs e)
        {
            this.Size = new Size(_width, _height);
            Location = new Point(newscreenLocationX, newscreenLocationY);
            SimulateMasterLoad();
        }

        private void SimulateMasterLoad()
        {
            FillCategoryGrid(lstUserCategory);
            ClearAllControls();
        }

        private void ClearAllControls()
        {
            txtCategoryName.Text = "";
            txtID.Text = "";
        }

        private async void FillCategoryGrid(List<UserCategoryEntity> lstUserCategory)
        {
            if(lstUserCategory.Count <=0 )
            {
                lstUserCategory = await userCategoryBLL.GetAllUserCategories();                
            }
            else {  }

            gdvUserCategory.AutoGenerateColumns = false;
            gdvUserCategory.DataSource = lstUserCategory;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            lstUserCategory = await userCategoryBLL.AddData(new UserCategoryEntity
            {
                ID = txtID.Text.Trim() != "" ? Convert.ToInt32(txtID.Text.Trim()) : 0,
                CategoryName = txtCategoryName.Text.Trim()
            });
            FillCategoryGrid(lstUserCategory);
            await frmBilling.showMessage(Constants.Message_Types.DATA_SAVE, "Ok");
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            lstUserCategory = await userCategoryBLL.Delete(new UserCategoryEntity { ID=Convert.ToInt32(txtID.Text.Trim()) });
            FillCategoryGrid(lstUserCategory);
            frmBilling = new frmBilling();
            await frmBilling.showMessage(Constants.Message_Types.DELETE,"Ok");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gdvUserCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(gdvUserCategory.CurrentRow != null)
            {
                txtID.Text = gdvUserCategory.CurrentRow.Cells[0].Value.ToString();
                txtCategoryName.Text = gdvUserCategory.CurrentRow.Cells[1].Value.ToString();
            }
            else
            {
                txtCategoryName.Text = "";
                txtID.Text = "";
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearAllControls();
    }
}
