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
    public partial class frmCustomerMaster : Form
    {
        CustomerMasterBLL customerMasterBLL = new CustomerMasterBLL();
        List<CustomerMasterEntity> lstCustomerDetails = new List<CustomerMasterEntity>();
        private int newscreenLocationX;
        private int newscreenLocationY;

        public frmCustomerMaster()
        {
            InitializeComponent();
        }

        public frmCustomerMaster(int newscreenLocationX, int newscreenLocationY)
        {
            this.newscreenLocationX = newscreenLocationX;
            this.newscreenLocationY = newscreenLocationY;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCustomerMaster_Load(object sender, EventArgs e)
        {
            this.Location = new Point(newscreenLocationX, newscreenLocationY);
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
            FillCustomerDetailGrid(lstCustomerDetails);
            ClearAllControls();
        }

        private void ClearAllControls()
        {
            txtAddress.Text = "";
            txtContact.Text = "";
            txtID.Text = "";
            txtName.Text = "";
        }

        private async void FillCustomerDetailGrid(List<CustomerMasterEntity> lstCustomerDetails)
        {
            if (lstCustomerDetails.Count <= 0)
            {
                lstCustomerDetails = await customerMasterBLL.GetAllCustomers();
            }
            else { }
            gdvCustomerDetails.AutoGenerateColumns = false;
            gdvCustomerDetails.DataSource = lstCustomerDetails;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            lstCustomerDetails = await customerMasterBLL.AddData(new CustomerMasterEntity()
            {                
                Address = txtAddress.Text,
                ContactNo = txtContact.Text,
                Email = txtEmail.Text,
                Name = txtName.Text,
                RegDate = DateTime.UtcNow.ToString("yyyyMMdd")
            });
            FillCustomerDetailGrid(lstCustomerDetails);
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            txtName.Text = ExtensionMethod.SetToUpperCase(txtName);
        }
    }
}
