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
    public partial class frmUserMaster : Form
    {
        UserMasterBLL _userMasterBLL = new UserMasterBLL();
        UserCategoryBLL _userCategoryBLL = new UserCategoryBLL();
        List<UserEntity> lstAllUsers = new List<UserEntity>();
        private int newscreenLocationX;
        private int newscreenLocationY;

        public frmUserMaster()
        {
            InitializeComponent();
        }

        public frmUserMaster(int newscreenLocationX, int newscreenLocationY)
        {
            this.newscreenLocationX = newscreenLocationX;
            this.newscreenLocationY = newscreenLocationY;
            InitializeComponent();
        }

        private void frmUserMaster_Load(object sender, EventArgs e)
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
            FillUserDetailsGrid(lstAllUsers);
            FillUserCategories();
            ClearAllControls();
        }

        private async void FillUserCategories()
        {
            List<UserCategoryEntity> lstUserCategory = new List<UserCategoryEntity>();
            lstUserCategory = await _userCategoryBLL.GetAllUserCategories();
            if (lstUserCategory != null)
            {
                cboUserCategory.DisplayMember = "CategoryName";
                cboUserCategory.ValueMember = "ID";
                cboUserCategory.DataSource = lstUserCategory;
                cboUserCategory.SelectedIndex = -1;
            }
            else
            {

            }
        }

        private void ClearAllControls()
        {
            txtConfirmPassword.Text = "";
            txtID.Text = "";
            txtPassword.Text = "";
            txtUsername.Text = "";
            cboUserCategory.SelectedIndex = -1;
        }

        private async void FillUserDetailsGrid(List<UserEntity> lstAllUsers)
        {
            if (lstAllUsers.Count == 0)
            {
                lstAllUsers = await _userMasterBLL.GetAllUsers();
            }  
            else {
                
            }
            gdvAllTaxCategories.AutoGenerateColumns = false;
            gdvAllTaxCategories.DataSource = lstAllUsers;
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() != "" && txtConfirmPassword.Text.Trim()!="")
            {
                if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
                {
                    MessageBox.Show("Password and Confirm Password Does not Match",Constants.PRODUCT_NAME,MessageBoxButtons.OK,MessageBoxIcon.Information); ;
                    return;
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string Message = await ValidateInputs();
            if (Message!="")
            {
                MessageBox.Show(Message, Constants.PRODUCT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lstAllUsers = await _userMasterBLL.AddData(new UserEntity
            {
                DesignationId = Convert.ToInt32(cboUserCategory.SelectedValue),
                IsActive = (chkUserActive.Checked == true ? 1 : 0),
                Password = txtConfirmPassword.Text.Trim(),
                UserName = txtUsername.Text.Trim(),
                AskToupdatePassword = 0,
                MobileNo = txtMobileNo.Text
            });
            FillUserDetailsGrid(lstAllUsers);
        }

        private async Task<string> ValidateInputs()
        {
            StringBuilder sb = new StringBuilder();

            if (txtUsername.Text.Trim() == "")
            {
                sb.AppendLine("Enter Username");
            }
            if (txtConfirmPassword.Text.Trim() == "")
            {
                sb.AppendLine("Enter Confirm Password");
            }
            if (txtMobileNo.Text.Trim() == "")
            {
                sb.AppendLine("Enter Mobile");
            }

            return sb.ToString();
        }

        private void lblCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmUserCategoryMaster _frmUserCategoryMaster = new frmUserCategoryMaster();
            _frmUserCategoryMaster.ShowDialog();
            FillUserCategories();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
