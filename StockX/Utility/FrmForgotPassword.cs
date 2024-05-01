using StockXCore;
using StokXBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockX.Utility
{
    public partial class FrmForgotPassword : Form
    {
        LoginBLL loginBLL = new LoginBLL();
        public FrmForgotPassword()
        {
            InitializeComponent();
        }

        private async void btnSendSMS_Click(object sender, EventArgs e)
        {           
            if(txtMobileNo.Text.Trim()!="" && txtUsername.Text.Trim()!="")
            {
                if (loginBLL.validateMobileNumber(txtUsername.Text,txtMobileNo.Text))
                {                    
                   string TempPassword = Guid.NewGuid().ToString().Substring(0, 10);

                    if (await loginBLL.UpdatePassword(txtUsername.Text, txtMobileNo.Text ,TempPassword))
                    {
                       if(CommonUtility.SendSMS(txtMobileNo.Text, TempPassword))
                        {
                            MessageBox.Show("Password send to you mobile number " + txtMobileNo.Text + ", Please check", Constants.PRODUCT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearAllControls();
                            Close();
                        }
                    }
                    else { }
                }
                else { }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllControls();
        }

        private void ClearAllControls()
        {
            txtUsername.Text = "";
            txtMobileNo.Text = "";
            txtUsername.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
