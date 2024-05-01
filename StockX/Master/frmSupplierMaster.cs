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
    public partial class frmSupplierMaster : Form
    {
        SupplierMasterBLL supplierMasterBLL=new SupplierMasterBLL();
        List<SupplierMasterEntity> lstSupplier = new List<SupplierMasterEntity>();
        private int newscreenLocationX;
        private int newscreenLocationY;

        public frmSupplierMaster()
        {
            InitializeComponent();
        }

        public frmSupplierMaster(int newscreenLocationX, int newscreenLocationY)
        {
            InitializeComponent();
            this.newscreenLocationX = newscreenLocationX;
            this.newscreenLocationY = newscreenLocationY;
        }

        private void frmSupplierMaster_Load(object sender, EventArgs e)
        {
            this.Location = new Point(newscreenLocationX, newscreenLocationY);
            SimulateMasterLoad();
        }

        private void SimulateMasterLoad()
        {
            ClearAllControls();
            FillSupplierDetails(lstSupplier);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void ClearAllControls()
        {
            txtAddress.Text = "";
            txtContact.Text = "";
            txtID.Text = "";
            txtName.Text = "";
        }

        private async void FillSupplierDetails(List<SupplierMasterEntity> lstSupplier)
        {
            if (lstSupplier.Count <= 0)
            {
                lstSupplier = await supplierMasterBLL.GetAllSuppliers();
            }
            else { }
            gdvCustomerDetails.AutoGenerateColumns = false;
            gdvCustomerDetails.DataSource = lstSupplier;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            lstSupplier= await supplierMasterBLL.AddData(new SupplierMasterEntity()
            {
                Address = txtAddress.Text,
                ContactNo = txtContact.Text,
                Email = txtEmail.Text,
                Name = txtName.Text,
                RegDate = DateTime.UtcNow.ToString("yyyyMMdd")
            });
            SimulateMasterLoad();
        }
    }
}
