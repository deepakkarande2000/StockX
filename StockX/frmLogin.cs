using StockX.Utility;
using StockXBEntity;
using StockXCore;
using StokXBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockX
{
    public partial class frmLogin : Form
    {
       public bool _isLoginSuccess = false;
        LoginBLL _loginBLL = new LoginBLL();
        frmMessageBox frmMessageBox; 
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            GetConnectionString();
            fillLanguages();
        }

        private void fillLanguages()
        {
            cboLanguage.Items.Add("English");
            cboLanguage.Items.Add("Marathi");
            cboLanguage.Items.Add("Spanish");
            cboLanguage.Items.Add("French");
            cboLanguage.Items.Add("Bharat01");
            cboLanguage.SelectedIndex = 0;
        }

        private async void GetConnectionString()
        {
            _loginBLL.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
             await _loginBLL.GetAppSettings();
            if (!_loginBLL.CheckExpiry())
            {
                ShowMessage("It Seems you License is expired please contact to support ","Ok");
                Close();
                Dispose();
            }
        }
        private void ShowMessage(string _message, string Buttontext)
        {
            frmMessageBox = new frmMessageBox();
            frmMessageBox._Message = _message;
            frmMessageBox._Button = Buttontext;
            frmMessageBox._Icon = MessageBoxIcon.Error;
            frmMessageBox.ShowDialog();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
            return;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() != "" && txtPassword.Text.Trim() != "")
            {
                if (ValidateUser())
                {
                    _isLoginSuccess = true;
                    Close();
                }
                else
                {
                  MessageBox.Show("Login Fail,Please Try Again", Constants.PRODUCT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Warning);                   
                    txtUserName.Focus();
                    _isLoginSuccess = false;
                }
            }
            else { _isLoginSuccess = false; }
        }

        private bool ValidateUser()
        {          
            _loginBLL = new LoginBLL();
            var result = _loginBLL.ValidateLoginUser(new UserEntity()
            {
                UserName = txtUserName.Text.Trim(),
                Password = txtPassword.Text.Trim()
            });
                        
            if (result != null)
            {
                if (result.Tables.Count > 0)
                {
                    if (result.Tables[0].Rows[0].ItemArray[0].ToString() != "User Not Found")
                    {
                        GlobalCollection.dsCurrentLoginUserDetails = result; return true;
                    }
                    else { return false; }
                }
                else
                {
                    return false;
                }
            }
            else { return false; }            
        }

        private void lnkforgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmForgotPassword forgotPassword = new FrmForgotPassword();
            forgotPassword.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ChangeLanguage(string lang)
        {
            foreach (Control c in this.Controls)
            {

                ComponentResourceManager resources = new ComponentResourceManager(typeof(frmLogin));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }

        private void cboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLanguage.SelectedItem.ToString() == "English")
            {
                ChangeLanguage("en");
            }
            else if (cboLanguage.SelectedItem.ToString() == "Spanish")
            {
                ChangeLanguage("es-ES");
            }
            else if (cboLanguage.SelectedItem.ToString() == "Marathi")
            {
                ChangeLanguage("mr-IN");
            }
            else if (cboLanguage.SelectedItem.ToString() == "Bharat01")
            {
                ChangeLanguage("bh-BH");
            }
            else
            {
                ChangeLanguage("fr-FR");
            }
        }
    }
}
