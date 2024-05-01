using StockXCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockX.Utility
{
    public partial class frmMessageBox : Form
    {
        public string _Message { get; set; }        
        public string _Button { get; set; }
        public MessageBoxIcon _Icon { get; set; }

        public string result { get; set; }
        public frmMessageBox()
        {
            InitializeComponent();
            this.Opacity = 0.96d;
            this.WindowState = FormWindowState.Maximized;        
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMessageBox_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(100, 0, 0, 0);
            switch (_Button.ToLower())
            {
                case "ok":
                    btnOne.Text = Constants.Message_Button_Type.OK;
                    btnTwo.Text = "";
                    btnTwo.Hide();
                    break;

                case "yesno":
                    btnOne.Text = Constants.Message_Button_Type.YES;
                    btnTwo.Show();
                    btnTwo.Text = Constants.Message_Button_Type.NO;
                    break;
                default:
                    break;
            }
            //if (_Message.Length > 50)
            //{
            //    string str1 = _Message.Substring(0, 50);
            //    string str2 = _Message.Substring(str1.Length, _Message.Length - 1);
            //    _Message = str1 + "\n" + str2;
            //}
            //else
            //{

            //}
            if (_Message.Length>10 && _Message.Length <50)
            {
                pnlLogo.Size = new Size(400,250);
                pnlLine.Width = 400;
                pnlLine.Location = new Point(0,pnlLine.Location.Y);
                btnOne.Location = new Point((pnlLogo.Width / 2) - (btnOne.Width / 2), (200));
            }
            if (_Message.Length > 50 && _Message.Length < 150)
            {
                pnlLogo.Size = new Size(700, 250);
                pnlLine.Width = 700;
                pnlLine.Location = new Point(0, pnlLine.Location.Y);
                //btnOne.Location = new Point((pnlLogo.Width / 4) - (btnOne.Width / 2), (190));
                //btnTwo.Location = new Point((pnlLogo.Width / 2) - (btnOne.Width / 2), (190));
            }
            pnlLogo.Location = new Point(((this.Width / 2) - (pnlLogo.Width / 2)),( (this.Height / 2) - (pnlLogo.Height / 2)));
            lblMessage.Text = _Message;            
            lblMessage.Location = new Point(100, lblMessage.Location.Y);
            panel5.Location = new Point((pnlLine.Width / 2) - (panel5.Width / 2), panel5.Location.Y);































































































































































































































































































































































































































































































































































































































































        }

        //protected override void OnPaintBackground(PaintEventArgs e)
        //{
        //    e.Graphics.FillRectangle(Brushes.Transparent
        //        , e.ClipRectangle);
        //}

        private void btnOne_Click(object sender, EventArgs e)
        {
            if(btnOne.Text== Constants.Message_Button_Type.OK)
            {
                result = "";
                Close();
            }
            else if (btnOne.Text == Constants.Message_Button_Type.YES)
            {
                result = Constants.Message_Button_Type.YES;
                Close();
            }
            else
            {
                result = "";
                Close();
            }
        }

        public void DisplayMessage(string Message, MessageBoxButtons buttons, MessageBoxIcon Icon)
        {
            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    break;
                case MessageBoxButtons.OKCancel:
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    break;
                case MessageBoxButtons.YesNoCancel:
                    break;
                case MessageBoxButtons.YesNo:
                    break;
                case MessageBoxButtons.RetryCancel:
                    break;
                default:
                    break;
            }
            MessageBox.Show(Message, Constants.PRODUCT_NAME, buttons, Icon);
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            if (btnTwo.Text == Constants.Message_Button_Type.NO)
            {
                result = Constants.Message_Button_Type.NO;
                Close();
            }
        }
    }
}
