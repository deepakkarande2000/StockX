using StockX.Transaction;
using StockXBEntity;
using StockXCore;
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
    public partial class frmItemCategoryMaster : Form
    {       
        ItemCategoryBLL _itemCategoryBLL;
        private int newscreenLocationX;
        private int newscreenLocationY;
        List<ItemCategoryEntity> lstCategory=new List<ItemCategoryEntity>();
        frmBilling _frmBilling;
        private int _width;
        private int _height = 0;

        public frmItemCategoryMaster()
        {
            InitializeComponent();
        }

        public frmItemCategoryMaster(int newscreenLocationX, int newscreenLocationY)
        {
            this.newscreenLocationX = newscreenLocationX;
            this.newscreenLocationY = newscreenLocationY;
            InitializeComponent();
        }

        public frmItemCategoryMaster(int newscreenLocationX, int newscreenLocationY, int v, int height)
        {
            this.newscreenLocationX = newscreenLocationX;
            this.newscreenLocationY = newscreenLocationY;
            InitializeComponent();
            _width = v;
            _height = height;
        }

        private void frmItemCategoryMaster_Load(object sender, EventArgs e)
        {
            this.Width = _width;
            this.Height = _height;
            OnSimulateMasterLoad();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void OnSimulateMasterLoad()
        {
            Location = new Point(newscreenLocationX, newscreenLocationY);
            fillAllCategory(lstCategory);
            ClearAllControls();
        }

        private async void fillAllCategory(List<ItemCategoryEntity> lstCategory)
        {
            _itemCategoryBLL = new ItemCategoryBLL();
            if (lstCategory.Count <= 0)
            {
                lstCategory = await _itemCategoryBLL.GetAllItemCategory();
            }
            
            gdvAllItemCategories.AutoGenerateColumns = false;
            gdvAllItemCategories.DataSource = lstCategory;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {

            lstCategory = await _itemCategoryBLL.AddData(new ItemCategoryEntity()
            {
                CategoryName = txtCategoryName.Text,
                ID = txtID.Text != "" ? Convert.ToInt64(txtID.Text) : 0
            });
            _frmBilling = new frmBilling();
            await _frmBilling.showMessage(Constants.Message_Types.DATA_SAVE, "Ok");
            fillAllCategory(lstCategory);
            ClearAllControls();
        }

        private void txtCategoryName_Leave(object sender, EventArgs e)
        {
            ExtensionMethod.SetToUpperCase(txtCategoryName);
        }

        private void gdvAllItemCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(gdvAllItemCategories.CurrentRow!=null)
            {
                txtID.Text = gdvAllItemCategories.CurrentRow.Cells[0].Value.ToString();
                txtCategoryName.Text = gdvAllItemCategories.CurrentRow.Cells[1].Value.ToString();
            }
            else
            {
                txtID.Text = "";
                txtCategoryName.Text = "";
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtID.Text!="")
            {
                lstCategory= await _itemCategoryBLL.Delete(new ItemCategoryEntity
                {
                    ID=Convert.ToInt64(txtID.Text),                    
                });
                fillAllCategory(lstCategory);
                ClearAllControls();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllControls();
        }

        private void ClearAllControls()
        {
            txtCategoryName.Text = "";
            txtID.Text = "";
        }
    }
}
