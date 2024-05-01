using StockX.Utility;
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
    public partial class frmShopeeDetails : Form
    {
        ShopeeDetailsBLL shopeeDetailsBLL=new ShopeeDetailsBLL();
        List<ShopeeDetailEntity> lstShopeeDetails = new List<ShopeeDetailEntity>();
        frmMessageBox _frmMessageBox = null;
        private int newscreenLocationX;
        private int newscreenLocationY;

        public frmShopeeDetails()
        {
            InitializeComponent();
        }

        public frmShopeeDetails(int newscreenLocationX, int newscreenLocationY)
        {
            this.newscreenLocationX = newscreenLocationX;
            this.newscreenLocationY = newscreenLocationY;
            InitializeComponent();
        }

        private void frmShopeeDetails_Load(object sender, EventArgs e)
        {this.Location = new Point(newscreenLocationX, newscreenLocationY);
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
        private void SimulateMasterLoad()
        {
            ClearAllControls();
            FillShopeeDetails(lstShopeeDetails.FirstOrDefault());
        }

        private async void FillShopeeDetails(ShopeeDetailEntity shopeeDetailEntity)
        {
            if (shopeeDetailEntity == null)
            {
                shopeeDetailEntity = await shopeeDetailsBLL.GetShopeeDetails();
            }

            if (shopeeDetailEntity != null)
            {
                txtAddress.Text= shopeeDetailEntity.Address;
                txtContactNo.Text = shopeeDetailEntity.ContactNo;
                txtEmail.Text = shopeeDetailEntity.Email;   
                txtLicenseNo.Text = shopeeDetailEntity.LicenseNo;
                txtShopeeName.Text = shopeeDetailEntity.ShopeeName;
            }
            else { ClearAllControls();
                MessageBox.Show("Shopee Details Not Found",Constants.PRODUCT_NAME,MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtLicenseNo.Focus();
            }
        }

        private void ClearAllControls()
        {
            txtAddress.Text = "";
            txtContactNo.Text = "";
            txtEmail.Text = "";
            txtLicenseNo.Text = "";
            txtShopeeName.Text = "";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
          lstShopeeDetails = await shopeeDetailsBLL.AddData(new ShopeeDetailEntity()
            {
                Address = txtAddress.Text,
                ContactNo = txtContactNo.Text,
                Email = txtEmail.Text,
                LicenseNo = txtLicenseNo.Text,
                ShopeeName = txtShopeeName.Text,
            });
            _frmMessageBox = new frmMessageBox();
            _frmMessageBox._Message = Constants.Message_Types.DATA_SAVE;
            _frmMessageBox._Button = "OK";
            _frmMessageBox.ShowDialog();
            FillShopeeDetails(lstShopeeDetails.FirstOrDefault());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
