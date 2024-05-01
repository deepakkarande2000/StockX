using StockX.Master;
using StockX.Master;
using StockX.Reports;
using StockX.Utility;
using StockXBEntity;
using StockXCore;
using StockXExceptionLogger;
using StokXBLL;
using StokXBLL.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace StockX.Transaction
{
    public partial class frmBilling : Form
    {
        List<ItemMasterEntity> lstAllItemMaster = new List<ItemMasterEntity>();
        List<SoldItemsEntity> lstItemSold = new List<SoldItemsEntity>();
        List<SoldItemsEntity> lsttemp = new List<SoldItemsEntity>();
        List<ItemTaxEntity> lstItemTax = new List<ItemTaxEntity>();
        List<BillPaymentEntity> lstBillPayment = new List<BillPaymentEntity>();
        List<BillItemsEntity> lstBillItems = new List<BillItemsEntity>();
        
        List<PaymentModeEntity> lstPaymentMode = new List<PaymentModeEntity>();
        public List<BillPaymentEntity> lstBillPaymentMode = new List<BillPaymentEntity>();
        List<tblOutstandingMasterEntity> lstOutstanding = new List<tblOutstandingMasterEntity>();
        List<tblOutstandingTxnEntity> lstOutstandingTxn = new List<tblOutstandingTxnEntity>();

        ItemMasterBLL _itemMasterBLL = new ItemMasterBLL();
        CustomerMasterBLL customerMasterBLL = new CustomerMasterBLL();
        BillingBLL billingBLL = new BillingBLL();
        TaxMasterBLL taxMasterBLL = new TaxMasterBLL();
        OutstandingBLL outstandingBLL = new OutstandingBLL();
        PaymentModeBLL paymentModeBLL = new PaymentModeBLL();

        DataSet dsAllItemDetails = new DataSet();
        long MaxBillId = 0;
        long MaxSrNo = 0;
        string TodayDate = DateTime.UtcNow.ToString("yyyyMMdd");
        public long _billID;
        public decimal _amount = 0;
        bool booClearBarcodeText = false;
        decimal TotalamountTopaid = 0;

        /// <summary>
        /// Settings Variables
        /// </summary>
        bool bAskMesgForBillPrint = false;

        frmMessageBox frmMessageBox;

       

        private int newscreenLocationX;
        private int newscreenLocationY;

        public frmBilling()
        {
            InitializeComponent();
        }

        public frmBilling(int newscreenLocationX, int newscreenLocationY, int width, int height)
        {
            InitializeComponent();
            this.newscreenLocationX = newscreenLocationX;
            this.newscreenLocationY = newscreenLocationY;
            this.Height = height;
            this.Width=width;
            
        }

        private async void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBarcode.Text.Trim() != "")
                {
                    if (booClearBarcodeText)
                    {
                        txtBarcode.Text = "";
                        txtBarcode.Focus();
                    }
                    //lstItemSold.Clear();
                    //if (lstItemSold.Count > 0 && lstItemSold.Where(c => c.BarcodeID==txtBarcode.Text).Count() > 0)
                    //{
                    //   
                    //        var result = lstItemSold.Where(c => c.BarcodeID.Contains(txtBarcode.Text)).FirstOrDefault();

                    //        if (result != null)
                    //        {                            
                    //            lstItemSold.Add(result);
                    //        }
                    //    
                    //}

                    if (txtBarcode.Text.Trim().Length > 7)
                    {
                        if (lstItemSold.Count > 0 && lstItemSold.Where(c => c.BarcodeID.ToString().ToLower()
                        .Contains(txtBarcode.Text.ToLower())).Count() > 0)
                        {
                            var result = lstItemSold.Where(c => c.BarcodeID.ToLower().Contains(txtBarcode.Text.ToLower())).FirstOrDefault();
                          
                            if (result !=null)
                            {
                                result.Qty++;
                                result.Tax = result.Tax + result.Tax;
                                result.Total = result.Qty * result.Rate;
                                result.DiscAmount = result.DiscAmount + result.DiscAmount;
                                lstItemSold.Remove(result);
                                lstItemSold.Add(result);
                                AppendDatasourceToGrid(lstItemSold);
                                await CalculateTotal();
                                ClearAllControls();
                                txtBarcode.Text = "";
                                booClearBarcodeText = true;
                                //return;
                            }
                            else
                            {
                                booClearBarcodeText = false;
                            }
                            txtBarcode.SelectAll();
                        }
                        else
                        {
                            if (txtBarcode.Text.Trim().Length == 8)
                            {
                                var result = dsAllItemDetails.Tables[0].AsEnumerable()

                                    .Where(c => c.Field<string>("BarcodeID")
                                    .Contains(txtBarcode.Text)).FirstOrDefault();

                                if (result != null)
                                {
                                    StoreInSoldItemList(result);
                                    booClearBarcodeText = true;
                                    ClearAllControls();
                                    txtBarcode.SelectAll();
                                    //
                                }
                                else
                                {
                                    booClearBarcodeText = false;
                                }
                                txtBarcode.SelectAll();
                            }
                            else if (txtBarcode.Text.Trim().Length > 8)
                            {
                                var result = dsAllItemDetails.Tables[0].AsEnumerable()
                                    .Where(c => c.Field<string>("BarcodeID") == (txtBarcode.Text)).FirstOrDefault();

                                if (result != null)
                                {
                                    StoreInSoldItemList(result);
                                    booClearBarcodeText = true;
                                    ClearAllControls();
                                    txtBarcode.SelectAll();
                                }
                                else
                                {
                                    booClearBarcodeText = false;
                                }
                                txtBarcode.SelectAll();
                            }
                            else { booClearBarcodeText = false; }
                        }
                    }
                }
                else { booClearBarcodeText = false; }

            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionLog(ex);
                throw;
            }
        }

        public async Task SearchItemDetails(string Barcode,string ItemName)
        {

            if (ItemName.Trim() != "")
            {
                //lstItemSold.Clear();
                if (lstItemSold.Count > 0 && lstItemSold.Where(c => c.ItemName.ToLower() == ItemName.ToLower()).Count() > 0)
                {
                    var result = lstItemSold.Where(c => c.ItemName.ToLower().Contains(ItemName.ToLower())).FirstOrDefault();

                    if (result != null)
                    {
                        result.Qty++;
                        result.Tax = result.Tax + result.Tax;
                        result.Total = result.Qty * result.Rate;
                        result.DiscAmount = result.DiscAmount + result.DiscAmount;
                        lstItemSold.Remove(result);
                        lstItemSold.Add(result);
                        AppendDatasourceToGrid(lstItemSold);
                        await CalculateTotal();
                        ClearAllControls();
                    }
                    else { }
                }
                else
                {
                    if (ItemName.Trim().Length > 7)
                    {
                        if (lstItemSold.Count > 0)
                        {
                            if (lstItemSold.Where(c => c.ItemName.ToLower() == ItemName.ToLower()).Count() > 0)
                            {
                                txtBarcode.Text = "";
                                return;
                            }
                        }
                        if (ItemName.Trim().Length == 8)
                        {
                            var result = dsAllItemDetails.Tables[0].AsEnumerable()
                                .Where(c => c.Field<string>("ItemName").ToLower()
                                .Contains(ItemName.ToLower())).FirstOrDefault();

                            if (result != null)
                            {
                                StoreInSoldItemList(result);
                                ClearAllControls();
                            }
                            else
                            {

                            }
                        }
                        else if (ItemName.Trim().Length > 8)
                        {
                            var result = dsAllItemDetails.Tables[0].AsEnumerable()
                                .Where(c => c.Field<string>("ItemName").ToLower() == (ItemName.ToLower())).FirstOrDefault();

                            if (result != null)
                            {
                                StoreInSoldItemList(result);
                                ClearAllControls();
                            }
                        }
                        else { }

                    }

                }
            }

            //gdvItemDetails.AutoGenerateColumns = false;
            //gdvItemDetails.DataSource = null;
            //gdvItemDetails.DataSource = lstItemSold.Count > 0 ? lstItemSold.OrderByDescending(c => c.Counter).ToList() : null;
            //gdvItemDetails.Refresh();
            //gdvBillTaxDetails.DataSource = lstItemTax.ToList();
            //gdvBillTaxDetails.Refresh();
            //lblItemCount.Text = lstItemSold.Count.ToString(); ClearAllControls();
        }

        //private async void StoreInSoldItemList(List<ItemMasterEntity> result)
        //{
        //    decimal _tax = 0;
        //    _tax = CalculateTax(result);

        //    lstItemSold.Add(new SoldItemsEntity()
        //    {
        //        Counter = lstItemSold.Count + 1,
        //        BillID = MaxBillId,
        //        ItemName = (result.ItemArray[1].ToString()),
        //        BarcodeID = result.ItemArray[2].ToString(),
        //        Date = TodayDate,
        //        DiscAmount = Convert.ToDecimal(result.ItemArray[11].ToString()),
        //        DiscPer = Convert.ToDecimal(result.ItemArray[6].ToString()),
        //        ItemID = Convert.ToInt64(result.ItemArray[0].ToString()),
        //        Qty = Convert.ToDecimal(result.ItemArray[7].ToString()),
        //        Rate = Convert.ToDecimal(result.ItemArray[3].ToString()),
        //        Tax= _tax,
        //        Total = Convert.ToDecimal(result.ItemArray[12]),
        //        UnitID = Convert.ToInt32(result.ItemArray[9].ToString()),
        //        Weight= result.ItemArray[10].ToString(),
        //        BuyPrice= Convert.ToDecimal(result.ItemArray[13]),
        //    });
        //    await CalculateTotal(Convert.ToDecimal(result.ItemArray[12].ToString()), Convert.ToDecimal(result.ItemArray[11]));

        //    gdvItemDetails.AutoGenerateColumns = false;
        //    gdvItemDetails.DataSource = null;
        //    gdvItemDetails.DataSource = lstItemSold.Count > 0 ? lstItemSold.OrderByDescending(c => c.Counter).ToList() : null;
        //    gdvItemDetails.Refresh();
        //    gdvBillTaxDetails.DataSource = lstItemTax.ToList();
        //    gdvBillTaxDetails.Refresh();
        //    lblItemCount.Text = lstItemSold.Count.ToString(); ClearAllControls();
        //}


        private async void StoreInSoldItemList(DataRow result)
        {
            decimal _tax = 0;
            _tax = CalculateTax(result);

            lstItemSold.Add(new SoldItemsEntity()
            {
                Counter = lstItemSold.Count + 1,
                BillID = MaxBillId,
                ItemName = (result.ItemArray[1].ToString()),
                BarcodeID = result.ItemArray[2].ToString(),
                Date = TodayDate,
                DiscAmount = Convert.ToDecimal(result.ItemArray[9].ToString()),
                DiscPer = Convert.ToDecimal(result.ItemArray[8].ToString()),
                ItemID = Convert.ToInt64(result.ItemArray[0].ToString()),
                Qty = Convert.ToDecimal(result.ItemArray[10].ToString()),
                Rate = Convert.ToDecimal(result.ItemArray[7].ToString()),
                Tax = Convert.ToDecimal(result.ItemArray[11].ToString()),
                Total = Convert.ToDecimal(result.ItemArray[12]),
                UnitID = Convert.ToInt32(result.ItemArray[4].ToString()),
                Weight = result.ItemArray[5].ToString(),
                BuyPrice = Convert.ToDecimal(result.ItemArray[13]),
            });
            await CalculateTotal();

            AppendDatasourceToGrid(lstItemSold);

        }

        private void AppendDatasourceToGrid(List<SoldItemsEntity> lstItemSold)
        {
            gdvItemDetails.AutoGenerateColumns = false;
            gdvItemDetails.DataSource = null;
            gdvItemDetails.DataSource = lstItemSold.Count > 0 ? lstItemSold.OrderByDescending(c => c.Counter).ToList() : null;
            gdvItemDetails.Refresh();
            gdvBillTaxDetails.DataSource = lstItemTax.ToList();
            gdvBillTaxDetails.Refresh();
            lblItemCount.Text = lstItemSold.Count.ToString(); ClearAllControls();
        }

        private async Task CalculateTotal()
        {
            lblTotalAmount.Text = lstItemSold.Sum(x=>x.Total).ToString("0.00");
            lblTotalDiscount.Text = lstItemSold.Sum(c => c.DiscAmount).ToString("0.00");
            //decimal _tax = 0;
            //_tax = CalculateTax(result);
            lblTotalTax.Text = lstItemSold.Sum(c => c.Tax).ToString("0.00");// (Convert.ToDecimal(lblTotalTax.Text) + _tax).ToString();

        }

        private decimal CalculateTax(DataRow result)
        {
            if (dsAllItemDetails.Tables.Count > 1)
            {
                var objTax = dsAllItemDetails.Tables[1].AsEnumerable()
                    .Where(c => c.Field<long>("ItemID") == Convert.ToInt64(result.ItemArray[0].ToString()))
                    .ToList();

                if (objTax != null)
                {
                    decimal totaltax = 0;
                    foreach (var item in objTax)
                    {
                        totaltax += GetLocalTax(item);
                        lstItemTax.Add(new ItemTaxEntity
                        {
                            ItemID = Convert.ToInt64(item.ItemArray[1]),
                            TaxID = Convert.ToInt32(item.ItemArray[0]),
                            TaxAmount = GetLocalTax(item)
                        });                        
                    }
                    return totaltax;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }

            decimal GetLocalTax(DataRow item)
            {
                decimal totaltax = 0;
                totaltax = (Convert.ToDecimal(Convert.ToDecimal(result.ItemArray[12]) * Convert.ToDecimal(item.ItemArray[2])) / Constants.Enum.HUNDRED);
                return totaltax;
            }
        }


        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.OemMinus)
            {
                txtBillDiscount.BackColor = CommonUtility.SetTextBackgroundColor(txtBillDiscount);
                txtBillDiscount.SelectAll();
                txtBillDiscount.Focus();
            }
            if (e.KeyCode == Keys.F8)
            {
                gdvPaymentModes.Focus();
                gdvPaymentModes.CellBeginEdit += gdvPaymentModes_CellBeginEdit;
                gdvPaymentModes.Rows[0].Cells[1].KeyEntersEditMode(e);
            }
        }
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }   
            

        }
        
        private void frmBilling_Load(object sender, EventArgs e)
        {
            Location = new Point(newscreenLocationX, newscreenLocationY);
            SimulateMasterLoad();
        }

        private async void SimulateMasterLoad()
        {
            fillAllItemDetails();
            FillPaymentModes();
            ClearAllControls();
            SetDefaultValues();
            GetCustomerAllDetails();
            await GetLatestBillNumberForDate();
            txtCustomerName.Focus();
        }

        private async Task GetLatestBillNumberForDate()
        {
            try
            {
                var Date = dtpBillDate.Value;
                TodayDate = Date.ToString("yyyyMMdd");
                MaxSrNo = await billingBLL.GetLatestBillID(Date);
                txtBillID.Text =  TodayDate + "" + (MaxSrNo).ToString();
                MaxBillId = Convert.ToInt64(txtBillID.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void FillPaymentModes()
        {
            if (lstPaymentMode.Count <= 0)
            {
                lstPaymentMode = await paymentModeBLL.GetAllPaymentModes();
            }
            gdvPaymentModes.AutoGenerateColumns = false;
            gdvPaymentModes.DataSource = lstPaymentMode;
        }

        private void fillItemTaxMapping()
        {
            throw new NotImplementedException();
        }

        private async void GetCustomerAllDetails()
        {
            await customerMasterBLL.GetAllCustomers();
        }

        private void SetDefaultValues()
        {
            gdvItemDetails = CommonUtility.SetGridColor(gdvItemDetails,Color.FromArgb(65, 176, 110));
            gdvCustomerDetails.Visible = false;
            dtpBillDate.Value = DateTime.UtcNow;
            TodayDate = dtpBillDate.Value.ToString("yyyyMMdd");
            gdvBillTaxDetails = CommonUtility.SetGridColor(gdvBillTaxDetails, Color.FromArgb(65, 176, 110));
        }

        private void ClearAllControls()
        {
            //txtBarcode.TextChanged -= txtBarcode_TextChanged;
            //txtBarcode.Text = "";
            //txtBarcode.TextChanged += txtBarcode_TextChanged;
            txtBarcode.Text = "";
            txtItemName.Text = "";
            txtQty.Text = ""; booClearBarcodeText = false;
        }

        private async void fillAllItemDetails()
        {
            dsAllItemDetails = await _itemMasterBLL.GetAllItems();
            txtItemName.SelectedValueChanged -= txtItemName_SelectedValueChanged;
            if (dsAllItemDetails != null)
            {
                if (dsAllItemDetails.Tables.Count >0)
                {                    
                    txtItemName.DisplayMember = "ItemName";
                    txtItemName.ValueMember = "ID";
                    txtItemName.DataSource = dsAllItemDetails.Tables[0];
                }
                else
                {
                    txtItemName.DataSource = null;
                }
            }
            else { }
            txtItemName.SelectedValueChanged += txtItemName_SelectedValueChanged;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string message = "";
            if (!ValidateInputs(out message))
            {                
               await showMessage(message, "Ok");
                return;
            }            
            await GetLatestBillNumberForDate();
            lstBillPayment = lstBillPayment.Where(c => c.Amount > 0).ToList();
            if (lstBillPayment.Count == 0)
            {
                await showMessage("Please enter payment mode with amount");
                //MessageBox.Show(, Constants.PRODUCT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (lblPending.Text != "")
                {
                    message = "";
                    if (txtCustomerID.Text.Trim() == "")
                    {
                        message = await showMessage("Customer Is not registered.....!, Do you want to continue\n" +
                            "if YES - Pending Amount will not save in the record and continue\n" +
                            "if No - You have to register the customer in customer Master\n" +
                            "then save the bill", "YesNo");

                        if(message==Constants.Message_Button_Type.NO)
                        {
                            return;
                        }
                        else { }
                    }
                    else { }
                    if (Convert.ToDecimal(lblPending.Text) > 0 && Convert.ToDecimal(lblPending.Text)<=50 && message=="")
                    {
                       string messageResponse = await showMessage("Panding Amount is " + lblPending.Text +
                            ", Do you want to save it in pending.....?", "YesNo");

                        if (messageResponse ==Constants.Message_Button_Type.YES)
                        {
                            SaveOutstanding();
                        }
                        else
                        {
                            lstOutstanding.Clear();
                            lstOutstandingTxn.Clear();
                        }
                    }
                    else
                    {
                        if (message == Constants.Message_Button_Type.NO || message=="")
                        {
                            SaveOutstanding();
                        }
                    }
                }
            }
            
            if (billingBLL.AddData(new BillingEntity()
            {
                SrNo = MaxSrNo,
                BillID = MaxBillId,
                CustomerID = txtCustomerID.Text != "" ? Convert.ToInt64(txtCustomerID.Text) : 0,
                Date = TodayDate,
                TotalBillAmount = Convert.ToDecimal(lblTotalAmount.Text),
                TotalDiscount = Convert.ToDecimal(lblTotalDiscount.Text),
                TotalTax = Convert.ToDecimal(lblTotalTax.Text)
            },GetAllBillItems(),lstBillPayment,GetBillTaxes(),lstOutstanding,lstOutstandingTxn))
            {
                btnSave.Enabled = false;
                gdvItemDetails.Enabled = false;
                if (bAskMesgForBillPrint)
                {
                    string _message = await showMessage(Constants.Message_Types.DATA_SAVE_ASK_FOR_BILLPRINT, "YESNO");

                    if (_message == Constants.Message_Button_Type.YES)
                    {
                        frmReports frmReports = new frmReports();
                        frmReports.BillNo = MaxBillId.ToString();
                        frmReports.ReportName = "Bill";
                        await frmReports.GenerateReport();
                        await showMessage(Constants.Message_Types.BILL_PRINT_DONE, "Ok");
                        GlobalCollection.dsPendingResult = await outstandingBLL.GetOutstandingCustomers();
                        ClearControlsAfterSave();
                        SimulateMasterLoad();
                    }
                    else
                    {

                    }
                }
                else {
                   await showMessage("Bill No " + MaxBillId + " is saved Successfully....if you want to Print the bill\n" +
                        "then click on printer icon button OR \n" +
                        "click on clear button to add new bill...... choices are yours...!");
                }
                
            }
            else { }
        }

        private void SaveOutstanding()
        {
            lstOutstanding.Add(new tblOutstandingMasterEntity
            {
                CustomerID = Convert.ToInt64(txtCustomerID.Text),
                Outstanding = Convert.ToDecimal(lblPending.Text),
                BillID = (MaxBillId)
            });

            lstOutstandingTxn.Add(new tblOutstandingTxnEntity
            {
                CustomerID = Convert.ToInt64(txtCustomerID.Text),
                paidAmount = Convert.ToDecimal(lblPaid.Text),
                TxnDate = TodayDate
            });
        }

        public async Task<string> showMessage(string message,string button="OK")
        {
            frmMessageBox = new frmMessageBox();
            frmMessageBox._Message = message;
            frmMessageBox._Button = button;
            frmMessageBox.ShowDialog();
            return frmMessageBox.result;            
        }
        private void ClearControlsAfterSave()
        {
            lstBillItems.Clear();
            lstBillPayment.Clear();
            lstItemSold.Clear();
            lstItemTax.Clear();
            lblTotalAmount.Text = "0";
            lblTotalDiscount.Text = "0";
            lblPrice.Text = "0";
            lblItemCount.Text = "0";
            lblTotalTax.Text = "0";
            lblPaid.Text = "0";
            lblExtra.Text = "0";
            lblPending.Text = "0";
            txtCustomerID.Text = "";
            txtCustomerName.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            gdvBillTaxDetails.DataSource = null;
            gdvItemDetails.DataSource = null;
            gdvPaymentModes.DataSource = null;
            btnSave.Enabled = true;
            gdvItemDetails.Enabled = true;
            lstOutstanding.Clear();
            lstOutstandingTxn.Clear();

        }

        private bool ValidateInputs(out string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Please Fill up below mentioned fields");
            if (gdvItemDetails.Rows.Count <= 0)
            {
                sb.AppendLine("Items are not added into the cart");
                message = sb.ToString();
                return false;
            }
            if (txtCustomerName.Text.Trim() == "")
            {
                sb.AppendLine("Customer not Selected");
                message = sb.ToString();
                return false;
            }
            
            message = "";
            return true;
             
        }

        private List<BillItemsEntity> GetAllBillItems()
        {
            foreach (var item in lstItemSold)
            {
                lstBillItems.Add(new BillItemsEntity()
                {
                    BillID = MaxBillId,
                    Qty = Convert.ToDecimal(item.Qty),
                    Rate = Convert.ToDecimal(item.Rate),
                    ItemID = Convert.ToInt64(item.ItemID),
                    UnitID = Convert.ToInt32(item.UnitID),
                    Date= TodayDate,
                    DiscPer = Convert.ToDecimal(item.DiscPer),
                    DiscAmount = Convert.ToDecimal(item.DiscAmount),
                    Total = Convert.ToDecimal(((item.Qty * item.Rate) - item.DiscAmount)),                    
                });
            }
            return lstBillItems;
        }

        private List<BillTaxEntity> GetBillTaxes()
        {
            List<BillTaxEntity> lstBilltax = new List<BillTaxEntity>();

            foreach (var item in lstItemTax)
            {
                lstBilltax.Add( new BillTaxEntity()
                {
                    BillID= MaxBillId,
                    Date= TodayDate,
                    ItemID = item.ItemID,
                    TaxAmount=item.TaxAmount,
                    TaxID = item.TaxID
                });
            }
            return lstBilltax;
        }
                              

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void ShowCustomerGrid(bool Hideshow)
        {
            if (Hideshow)
            {
                gdvCustomerDetails.Visible = true;
                gdvCustomerDetails.BringToFront();
                gdvCustomerDetails.Height = gdvCustomerDetails.Height * 4;
            }
            else
            {
                gdvCustomerDetails.Visible = false;
            }
        }

       

        private void gdvCustomerDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                txtCustomerID.Text = gdvCustomerDetails.CurrentRow.Cells["ID"].Value.ToString();
                txtCustomerName.Text = gdvCustomerDetails.CurrentRow.Cells["Name"].Value.ToString();
                txtAddress.Text = gdvCustomerDetails.CurrentRow.Cells["Address"].Value.ToString();
                txtContact.Text = gdvCustomerDetails.CurrentRow.Cells["Contact"].Value.ToString();
                ShowCustomerGrid(false);
                txtBarcode.Focus();
                txtBarcode.SelectAll();
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                if (gdvItemDetails.Rows.Count > 0)
                {
                    gdvPaymentModes.Focus();
                }                
            }
        }

        private void gdvItemDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            frmCustomerMaster frmCustomerMaster = new frmCustomerMaster(newscreenLocationX,newscreenLocationY);
            frmCustomerMaster.ShowDialog();
        }
               

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {

            if (txtCustomerName.Text.Trim() != "")
            {
                gdvCustomerDetails.AutoGenerateColumns = false;
                gdvCustomerDetails.DataSource = null;

                if (txtCustomerName.Text.Trim().Length <= 1)
                {
                    dynamic result = "";
                    if (txtCustomerName.Text.Trim() == ".")
                    {
                         result = GlobalCollection.lstAllCustomerInfo.ToList();
                    }
                    else
                    {
                         result = GlobalCollection.lstAllCustomerInfo
                        .Where(c => c.Name.Trim().ToLower()
                        .StartsWith(txtCustomerName.Text.Trim().ToLower())).ToList();
                    }
                    
                    if (result != null)
                    {
                        ShowCustomerGrid(true);
                        gdvCustomerDetails.DataSource = result;
                    }
                    else { ShowCustomerGrid(false); }
                }
                else
                {
                    var result = GlobalCollection.lstAllCustomerInfo.Where(c => c.Name.ToLower().Contains(txtCustomerName.Text.ToLower())).ToList();

                    if (result.Count > 0)
                    {
                        ShowCustomerGrid(true);
                        gdvCustomerDetails.DataSource = result;
                    }
                    else { ShowCustomerGrid(false); }
                }
            }
            else
            {
                ShowCustomerGrid(false);
            }
        }

        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if(gdvCustomerDetails.Rows.Count <= 0)
                {
                    return;
                }
                gdvCustomerDetails.Focus();
                gdvCustomerDetails.Rows[0].Selected = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtBarcode.Focus();
                txtBarcode.BackColor = CommonUtility.SetTextBackgroundColor(txtBarcode);
            }
        }

       
           
        

        private void CalculatePaidAndPending()
        {
            lstBillPayment.Clear();
            for (int i = 0; i < gdvPaymentModes.Rows.Count; i++)
            {
                lstBillPayment.Add(new BillPaymentEntity()
                {
                    BillID = Convert.ToInt64(MaxBillId),
                    Amount = Convert.ToDecimal(gdvPaymentModes.Rows[i].Cells["Amount"].Value),
                    BillDate = DateTime.UtcNow.ToString("yyyyMMdd"),
                    PaymentMode = Convert.ToInt32(gdvPaymentModes.Rows[i].Cells["PaymentModeID"].Value),
                });
            }
            if (lstBillPayment.Count > 0)
            {
                lblExtra.Text = "0";
                lblPending.Text = "0";

                TotalamountTopaid = lstBillPayment.Where(c => c.Amount > 0).Sum(c => c.Amount);

                if (Convert.ToDecimal(lblTotalAmount.Text) < TotalamountTopaid)
                {
                    lblExtra.Text = (TotalamountTopaid - Convert.ToDecimal(lblTotalAmount.Text)).ToString("0.00");
                    lblPaid.Text = lblTotalAmount.Text;
                    lblPending.Text = "0";
                }
                else if (Convert.ToDecimal(lblTotalAmount.Text) > TotalamountTopaid)
                {
                    lblPending.Text = (Convert.ToDecimal(lblTotalAmount.Text)- TotalamountTopaid).ToString("0.00");
                    lblExtra.Text = "0";
                    lblPaid.Text = TotalamountTopaid.ToString("0.00");
                } else if (Convert.ToDecimal(lblTotalAmount.Text) == TotalamountTopaid)
                {
                    lblPending.Text = "0";
                    lblExtra.Text = "0";
                    lblPaid.Text = TotalamountTopaid.ToString("0.00");
                }
                else
                {
                    lblPaid.Text = "0";
                    lblExtra.Text = "0";
                    lblPending.Text = "0";
                }
            }
        }

        private void gdvPaymentModes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculatePaidAndPending();
        }

        private void gdvPaymentModes_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            CalculatePaidAndPending();
        }

        private void dtpBillDate_ValueChanged(object sender, EventArgs e)
        {
            //;
           // GetLatestBillNumberForDate();
        }

        private void txtCustomerName_Leave(object sender, EventArgs e)
        {
            //txtCustomerName.Text = ExtensionMethod.SetToUpperCase(txtCustomerName);
        }

        private void txtCustomerName_Enter(object sender, EventArgs e)
        {
            txtCustomerName.BackColor = CommonUtility.SetTextBackgroundColor(txtCustomerName);
        }

        private void txtBillDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //btnSave_Click(sender, e);
                btnSave.Focus();
            }
            else { }
        }

        private void gdvPaymentModes_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.OemMinus)
            {
                FocusOnDiscountAmount();
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (gdvPaymentModes.CurrentRow.Index == gdvPaymentModes.Rows.Count-1)
                {
                    FocusOnDiscountAmount();
                }
            }
        }

        private void FocusOnDiscountAmount()
        {
            txtBillDiscount.Focus();
            txtBillDiscount.BackColor = CommonUtility.SetTextBackgroundColor(txtBillDiscount);
            txtBillDiscount.SelectAll();
        }

        private async void txtItemName_SelectedValueChanged(object sender, EventArgs e)
        {
            if(txtItemName.SelectedValue!=null)
            {
                               
            }
        }

        private async void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtItemName.Text != "")
                {
                    await SearchItemDetails("", txtItemName.Text);
                }
                else { }
            }
            else { }
        }

        private void gdvItemDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (gdvItemDetails.CurrentCell.ColumnIndex == 0)
            {
                lsttemp.AddRange(lstItemSold);

                var obj = lsttemp
                            .Where(c => c.ItemID == Convert.ToInt64(gdvItemDetails.CurrentRow.Cells["ItemID"].Value))
                            .FirstOrDefault();

                lsttemp.Remove(obj);

                lstItemSold.Clear();

                foreach (var item in lsttemp)
                {
                    var result = dsAllItemDetails.Tables[0].AsEnumerable()
                                    .Where(c => c.Field<string>("ItemName").ToLower() == item.ItemName.ToString().ToLower())
                                    .FirstOrDefault();

                    if (result != null)
                    {
                        StoreInSoldItemList(result);
                        ClearAllControls();
                    }
                    else
                    {

                    }
                }
               if(lsttemp.Count==0)
                {
                    gdvItemDetails.DataSource = lsttemp;
                    ClearControlsAfterSave();
                }
                lsttemp.Clear();
            }
        }

        private async void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllControls();
            ClearControlsAfterSave();
            FillPaymentModes();
            await GetLatestBillNumberForDate();
        }

        private void txtBillDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtBillDiscount.Text != "")
            {
                TotalamountTopaid = TotalamountTopaid - Convert.ToDecimal(txtBillDiscount.Text);
            }
            else { }
            lblTotalAmount.Text = TotalamountTopaid.ToString("0.00");
            lblPaid.Text = TotalamountTopaid.ToString("0.00");
        }

        private async void btnPrint_Click(object sender, EventArgs e)
        {
            frmBillDetails frmBillDetails = new frmBillDetails();            
            await frmBillDetails.PrintBill(MaxBillId.ToString());
        }
    }
}
