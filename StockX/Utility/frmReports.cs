using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using StockXBEntity;
using StockXCore;
using StokXBLL;
using StokXBLL.Repository;

namespace StockX.Utility
{
    public partial class frmReports : Form
    {
        private int newscreenLocationX;
        private int newscreenLocationY;

        LoginBLL loginBLL = new LoginBLL();
        BillingBLL billingBLL = new BillingBLL();
        CustomerMasterBLL customerMasterBLL = new CustomerMasterBLL();
        StockTxnHistoryBLL stockTxnHistoryBLL = new StockTxnHistoryBLL();
        DailyExpenseBLL dailyExpenseBLL = new DailyExpenseBLL();
        ReportDocument rptdoc = new ReportDocument();

        string ReportPath = System.IO.Directory.GetCurrentDirectory() + "\\Reports\\";
        public string ReportName = "";
        public string BillNo = "";
        public Int64 ExpenseID = 0;
        public bool bPrintReport = true;
        public string SelectedPrinterName = "HP DJ 3830 series";//"Microsoft XPS Document Writer";
        frmMessageBox frmMessageBox;

        private string strUserID = "";
        private string strPassword = "";
        private string strDatabaseName = "";
        private string strServerName = "";

        TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
        TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
        ConnectionInfo crConnectionInfo = new ConnectionInfo();
        public frmReports()
        {
            InitializeComponent();
        }
        public frmReports(int newscreenLocationX, int newscreenLocationY, int width, int height)
        {
            InitializeComponent();
            this.newscreenLocationX = newscreenLocationX;
            this.newscreenLocationY = newscreenLocationY;
            this.Height = height;
            this.Width = width;
            panel1.Width = this.Width - 50;
            panel3.Width = this.Width - 50;
            crystalReportViewer1.Size =new Size(this.Width - 50,this.Height-100);
        }


        private async void btnShow_Click(object sender, EventArgs e)
        {
            if (cboReportName.Text.Trim() != "")
            {
                ReportName = cboReportName.Text;
                if (cboReportName.Text == "Bill" || cboReportName.Text == "Bill A6")
                {
                    if (txtBillNo.Text.Trim() != "")
                    {
                        BillNo = txtBillNo.Text.Trim();
                    }
                    else
                    {
                        ShowMessage("Please Provide Bill Number to print Bill", "Ok");
                        return;
                    }
                }
                else if (cboReportName.Text.Trim() == "Voucher")
                {
                    if (txtBillNo.Text.Trim() != "")
                    {
                        ExpenseID = Convert.ToInt64(txtBillNo.Text.Trim());
                    }
                    else
                    {
                        ShowMessage("Please Provide Voucher Number to Print", "Ok");
                        return;
                    }
                    
                }
                else { }

                if(cboReportName.Text.Trim()== "Stock Stmt For Banks")
                {
                    if(dtpFromDate.Value > dtpToDate.Value)
                    {
                        ShowMessage("From date Should less than To date", "Ok");
                        return;
                    }
                }
                else { }
            }
            else
            {
                ShowMessage("Please Select Report", "Ok");
                return;
            }
            await GenerateReport();
        }

        public async Task GenerateReport()
        {
           if(strServerName=="")
            { GetDatabaseName(); }
            ReportPath = "D:\\Work\\StockX\\StockX\\Reports\\";
            crystalReportViewer1.Refresh();
            ParameterFields BillIDField = new ParameterFields();
            ParameterFields ExpenseIDField = new ParameterFields();
            ParameterFields FromDateField = new ParameterFields();
            ParameterFields ToDateField = new ParameterFields();
            rptdoc = new ReportDocument();
            

            switch (ReportName)
            {
                case "Bill A6":
                    rptdoc.Load(ReportPath + "rptBillA6.rpt");
                    rptdoc.SetDatabaseLogon(strUserID, strPassword, strServerName, strDatabaseName);

                    DataSet dsBillDetails = new DataSet();
                    dsBillDetails = await billingBLL.GetBillDetails(BillNo);

                    if (dsBillDetails != null && dsBillDetails.Tables.Count > 0 && dsBillDetails.Tables[0].Rows.Count > 0)
                    {
                        DataSet dsBillTaxDetails = new DataSet();
                        dsBillTaxDetails = await billingBLL.GetBillTax(BillNo);
                        ParameterField paramBillID = new ParameterField();
                        paramBillID.Name = "@BillID";
                        ParameterDiscreteValue discreteValue = new ParameterDiscreteValue();
                        discreteValue.Value = BillNo;

                        paramBillID.CurrentValues.Add(discreteValue);

                        BillIDField.Add(paramBillID);
                        //rptdoc.Subreports["rptBillTaxDetails"].SetDataSource(dsBillTaxDetails.Tables[0]);
                        //rptdoc.Subreports["rptBillTaxDetails"].SetParameterValue("@BillID", BillNo);
                        //rptdoc.SetDataSource(dsBillDetails.Tables[0]);
                        // GetDatabaseCredential(rptdoc);
                        //rptdoc.ReportDefinition.Sections["Section3"].Height += 100;
                        crystalReportViewer1.ReportSource = rptdoc;
                        crystalReportViewer1.ParameterFieldInfo = BillIDField;
                    }
                    else
                    {
                        ShowMessage("Bill Details Are Not Found Please Check Bill Number", "Ok");
                        return;
                    }

                    break;
                case "Bill":
                    rptdoc.Load(ReportPath + "rptBill.rpt");
                     rptdoc.SetDatabaseLogon(strUserID, strPassword, strServerName, strDatabaseName);
                    
                    DataSet dsNewBillDetails = new DataSet();
                    dsNewBillDetails = await billingBLL.GetBillDetails(BillNo);

                    if (dsNewBillDetails != null && dsNewBillDetails.Tables.Count > 0 && dsNewBillDetails.Tables[0].Rows.Count > 0)
                    {
                        DataSet dsBillTaxDetails = new DataSet();
                        dsBillTaxDetails = await billingBLL.GetBillTax(BillNo);
                        ParameterField paramBillID = new ParameterField();
                        paramBillID.Name = "@BillID";
                        ParameterDiscreteValue discreteValue = new ParameterDiscreteValue();
                        discreteValue.Value = BillNo;
                        paramBillID.CurrentValues.Add(discreteValue);
                        BillIDField.Add(paramBillID);
                        rptdoc.Subreports["rptBillTaxDetails"].SetDataSource(dsBillTaxDetails.Tables[0]);
                        //rptdoc.Subreports["rptBillTaxDetails"].SetParameterValue("@BillID", BillNo);
                        rptdoc.SetDataSource(dsNewBillDetails.Tables[0]);
                        // GetDatabaseCredential(rptdoc);
                        crystalReportViewer1.ReportSource = rptdoc;
                        crystalReportViewer1.ParameterFieldInfo = BillIDField;
                    }
                    else
                    {
                        ShowMessage("Bill Details Are Not Found Please Check Bill Number", "Ok");
                        return;
                    }

                    break;
                case "Pending Report":
                    rptdoc.Load(ReportPath + "rptPendingDetails.rpt");
                    GetDatabaseCredential(rptdoc);
                    crystalReportViewer1.ReportSource = rptdoc;
                    break;
                case "Available Stock Report":
                    rptdoc.Load(ReportPath + "rptAvailableStockReport.rpt");
                    GetDatabaseCredential(rptdoc);
                    crystalReportViewer1.ReportSource = rptdoc;
                    break;

                case "All Items Report":
                    rptdoc.Load(ReportPath + "rptAllItemsReport.rpt");
                    GetDatabaseCredential(rptdoc);
                    crystalReportViewer1.ReportSource = rptdoc;
                    break;

                case "Balance Sheet Report":
                    rptdoc.Load(ReportPath + "rptBalanceSheetReport.rpt");
                    GetDatabaseCredential(rptdoc);
                    crystalReportViewer1.ReportSource = rptdoc;
                    break;

                case "Voucher":
                    rptdoc.Load(ReportPath + "rptVoucherDetails.rpt");
                    GetDatabaseCredential(rptdoc);
                    DataSet dsExpenseDetail = new DataSet();
                    dsExpenseDetail = await dailyExpenseBLL.GetDailyExpensesByID(ExpenseID);

                    if (dsExpenseDetail != null && dsExpenseDetail.Tables.Count > 0 && dsExpenseDetail.Tables[0].Rows.Count > 0)
                    {                       
                        ParameterField paramID = new ParameterField();
                        paramID.Name = "@ID";
                        ParameterDiscreteValue discreteValue = new ParameterDiscreteValue();
                        discreteValue.Value = ExpenseID;
                        paramID.CurrentValues.Add(discreteValue);
                        ExpenseIDField.Add(paramID);                       
                        rptdoc.SetDataSource(dsExpenseDetail.Tables[0]);
                        crystalReportViewer1.ReportSource = rptdoc;
                        crystalReportViewer1.ParameterFieldInfo = ExpenseIDField;
                    }
                    else
                    {
                        ShowMessage("Voucher Details Are Not Found Please Check Voucher Number", "Ok");
                        return;
                    }
                    crystalReportViewer1.ReportSource = rptdoc;
                    break;

                case "Stock Stmt For Banks":
                    rptdoc.Load(ReportPath + "rptStockStatementReport.rpt");                    
                    DataSet dsStockStmt = await stockTxnHistoryBLL.GetStockHistoryStmt(dtpFromDate.Value.Date.ToString("yyyyMMdd"),
                        dtpToDate.Value.ToString("yyyyMMdd"));
                    if(dsStockStmt!=null)
                    {
                        if (dsStockStmt.Tables.Count > 0)
                        {
                            ParameterField paramFromDate = new ParameterField();
                            ParameterField paramToDate = new ParameterField();
                            paramFromDate.Name = "@FromDate";
                            paramToDate.Name = "@ToDate";

                            ParameterDiscreteValue disFromValue = new ParameterDiscreteValue();
                            disFromValue.Value = dtpFromDate.Value.Date.ToString("yyyyMMdd");
                            paramFromDate.CurrentValues.Add(disFromValue);

                            ParameterDiscreteValue disToValue = new ParameterDiscreteValue();
                            disToValue.Value = dtpToDate.Value.Date.ToString("yyyyMMdd");
                            paramToDate.CurrentValues.Add(disToValue);

                            FromDateField.Add(paramFromDate);
                            FromDateField.Add(paramToDate);
                            
                            rptdoc.SetDataSource(dsStockStmt.Tables[0]);
                            GetDatabaseCredential(rptdoc);
                            crystalReportViewer1.ReportSource = rptdoc;
                            crystalReportViewer1.ParameterFieldInfo = FromDateField;
                        }
                    }
                    
                    crystalReportViewer1.ReportSource = rptdoc;
                    break;
                
                case "Barcode Printing":
                    rptdoc.Load(ReportPath + "rptBarcodeReport.rpt");
                    GetDatabaseCredential(rptdoc);
                    crystalReportViewer1.ReportSource = rptdoc;
                    break;

                default:
                    break;
            }

            try
            {
                if (!bPrintReport)
                {
                    crystalReportViewer1.Show();
                    crystalReportViewer1.Refresh();
                }
                else
                {
                    PrintReport();                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ShowMessage(string _message,string Buttontext)
        {
            frmMessageBox = new frmMessageBox();
            frmMessageBox._Message = _message;
            frmMessageBox._Button = Buttontext;
            frmMessageBox._Icon = MessageBoxIcon.Error;
            frmMessageBox.ShowDialog();
        }

        private void GetDatabaseName()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            if (connectionString!="")
            {
                string[] arrConnstring = connectionString.Split(';');
                
                if (arrConnstring.Count() > 0)
                {
                    string[] tempserver = arrConnstring[0].Split('=').ToArray();
                    strServerName = tempserver[1].ToString();

                    tempserver = null;
                    tempserver = arrConnstring[1].Split('=').ToArray();
                    strDatabaseName = tempserver[1].ToString();

                    tempserver = null;
                    tempserver = arrConnstring[2].Split('=').ToArray();
                    strUserID = tempserver[1];

                    tempserver = null;
                    tempserver = arrConnstring[3].Split('=').ToArray();
                    strPassword = tempserver[1];
                }
                else { }
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

        }
        private void frmReports_Load(object sender, EventArgs e)
        {
            Location = new Point(newscreenLocationX, newscreenLocationY);
            FillReportName();
            SetDefaultValues();
            GetDatabaseName();
        }

        private void GetDatabaseCredential(ReportDocument cryRpt)
        {
            try
            {
                // RptDaily_Report_CL cryRpt = new RptDaily_Report_CL();
                TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();

                crConnectionInfo.ServerName = strServerName;
                crConnectionInfo.DatabaseName = strDatabaseName;
                // crConnectionInfo.IntegratedSecurity = true;
                crConnectionInfo.UserID = strUserID;
                crConnectionInfo.Password = strPassword;


                //CrTables = cryRpt.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in cryRpt.Database.Tables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                foreach (ReportDocument subreport in cryRpt.Subreports)
                {
                    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in subreport.Database.Tables)
                    {
                        crtableLogoninfo = CrTable.LogOnInfo;
                        crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                        CrTable.ApplyLogOnInfo(crtableLogoninfo);
                    }
                }
                ///cryRpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void SetDefaultValues()
        {
            dtpFromDate.MaxDate = DateTime.UtcNow.Date;
            dtpToDate.MaxDate = DateTime.UtcNow.Date;
            dtpFromDate.Visible = false;
            dtpToDate.Visible = false;
            lblParamName.Visible = false;
            txtBillNo.Visible = false;
        }

        private void FillReportName()
        {
            cboReportName.Items.Add("Available Stock Report");
            cboReportName.Items.Add("All Items Report");
            cboReportName.Items.Add("Balance Sheet Report");
            cboReportName.Items.Add("Barcode Printing");
            cboReportName.Items.Add("Bill");
            cboReportName.Items.Add("Bill A6");            
            cboReportName.Items.Add("Pending Report");
            cboReportName.Items.Add("Voucher");
            cboReportName.Items.Add("Stock Stmt For Banks");            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SelectedPrinterName = "";

            if (crystalReportViewer1.ReportSource != null)
            {
                if (SelectedPrinterName == "")
                {
                    PrintDialog printDialog = new PrintDialog();
                    printDialog.ShowDialog();
                    SelectedPrinterName = printDialog.PrinterSettings.PrinterName;
                    
                }
                else { 
                }
                PrintReport();
            }
            else
            {
                ShowMessage("Please select Report to print", "OK");
                return;
            }
        }

        private void PrintReport()
        {
            try
            {
                rptdoc.PrintOptions.PrinterName = SelectedPrinterName;

                if (ReportName == "Bill A6")
                {
                    System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
                    printerSettings.PrinterName = SelectedPrinterName;

                    System.Drawing.Printing.PageSettings page = new System.Drawing.Printing.PageSettings();
                    page.Landscape = false;
                    page.PaperSize = new System.Drawing.Printing.PaperSize("custom", 275, 3000);
                    rptdoc.PrintToPrinter(printerSettings, page, false);
                }
                else
                {
                    rptdoc.PrintToPrinter(1, false, 0, 0);
                }
            }
            catch (Exception ex)
            {
                StockXExceptionLogger.ExceptionLogger.WriteExceptionLog(ex);
            }
        }

        private void cboReportName_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cboReportName.Text.Trim()=="Bill" || cboReportName.Text=="Bill A6")
            {
                lblParamName.Visible = true;
                txtBillNo.Visible = true;
                lblParamName.Text = "Bill Number";
            }
            else if (cboReportName.Text.Trim() == "Voucher")
            {
                txtBillNo.Visible = true;
                lblParamName.Visible = true;
                lblParamName.Text = "Voucher No.";
            }else
            {
                txtBillNo.Visible = false;
                lblParamName.Visible = false;
            }
        }
    }
}
