using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockX.Utility
{
    public partial class FrmSettings : Form
    {
        private int newscreenLocationX;
        private int newscreenLocationY;
        private int v;

        public FrmSettings()
        {
            InitializeComponent();
        }

        public FrmSettings(int newscreenLocationX, int newscreenLocationY, int v, int height)
        {
            InitializeComponent();
            this.newscreenLocationX = newscreenLocationX;
            this.newscreenLocationY = newscreenLocationY;

            this.v = v;
            Height = height;
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            this.Location = new Point(newscreenLocationX, newscreenLocationY);
            this.Size = new Size(v, Height);
            LoadAllPrinters();
            HideUnHidePanels("GeneralSettings");
        }

        private void LoadAllPrinters()
        {
            foreach (string printname in PrinterSettings.InstalledPrinters)
            {
                cboBillPrinter.Items.Add(printname);
            }
        }

        private void HideUnHidePanels(string panelname)
        {
            switch (panelname)
            {
                case "GeneralSettings":
                    pnlGeneralSettings.Visible = true;
                    pnlGeneralSettings.BringToFront();
                    pnlBilling.Visible = false;
                    pnlBilling.SendToBack();
                    pnlPrinterSetting.Visible = false;
                    pnlPrinterSetting.SendToBack();
                    break;
                case "BillSettings":
                    pnlGeneralSettings.Visible = false;
                    pnlGeneralSettings.BringToFront();
                    pnlBilling.Size = pnlGeneralSettings.Size;
                    pnlBilling.Location = pnlGeneralSettings.Location;
                    pnlBilling.Visible = true;
                    pnlBilling.BringToFront();
                    pnlPrinterSetting.Visible = false;
                    pnlPrinterSetting.SendToBack();
                    break;

                case "PrinterSettings":
                    pnlGeneralSettings.Visible = false;
                    pnlGeneralSettings.BringToFront();
                    pnlPrinterSetting.Size = pnlGeneralSettings.Size;
                    pnlPrinterSetting.Location = pnlGeneralSettings.Location;
                    pnlPrinterSetting.Visible = true;
                    pnlPrinterSetting.BringToFront();
                    pnlBilling.Visible = false;
                    pnlBilling.SendToBack();
                    break;

                default:
                    pnlGeneralSettings.Visible = true;
                    pnlBilling.Visible = false;
                    pnlPrinterSetting.Visible = false;
                    break;
            }
            
        }

        private void btnGeneralSettings_Click(object sender, EventArgs e)
        {
            HideUnHidePanels("GeneralSettings");
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            HideUnHidePanels("BillSettings");
        }

        private void btnPrinterSettings_Click(object sender, EventArgs e)
        {
            HideUnHidePanels("PrinterSettings");
        }
    }
}
