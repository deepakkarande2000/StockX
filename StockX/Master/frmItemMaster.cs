using StockX.Utility;
using StockXBEntity;
using StockXCore;
using StokXBLL;
using StokXBLL.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using DataTable = System.Data.DataTable;
using Constants = StockXCore.Constants;

namespace StockX.Master
{
    public partial class frmItemMaster : Form
    {
        TaxMasterBLL _taxMasterBLL = new TaxMasterBLL();
        ItemCategoryBLL _itemCategoryBLL = new ItemCategoryBLL();
        UnitMasterBLL _unitMasterBLL = new UnitMasterBLL();
        ItemMasterBLL _itemMasterBLL = new ItemMasterBLL();
        
        List<TaxCategoryEntity> lstTaxCategory=new List<TaxCategoryEntity>();
        List<UnitCategoryEntity> lstUnitCategory=new List<UnitCategoryEntity> ();
        List<ItemCategoryEntity> lstItemCategory = new List<ItemCategoryEntity>();
        List<ItemMasterEntity> lstItemMaster = new List<ItemMasterEntity>();
        List<ItemTaxMappingEntity> lstItemTaxMapping = new List<ItemTaxMappingEntity>();
        List<TaxCategoryEntity> lstSoldItemTaxes = new List<TaxCategoryEntity>();

        frmMessageBox frmMessageBox = new frmMessageBox();

        DataSet dsAllItemDetails = new DataSet();

        private int newscreenLocationX;
        private int newscreenLocationY;
        int _widht = 0;
        int _height = 0;
        long _itemId = 0;
        decimal _discountAmount = 0;
        public frmItemMaster()
        {
            this.gdvTaxDetails.CellValueChanged -= gdvTaxDetails_CellValueChanged;
            InitializeComponent();
           
        }

        public frmItemMaster(int newscreenLocationX, int newscreenLocationY, int width, int height)
        {
            InitializeComponent();
            this.newscreenLocationX = newscreenLocationX;
            this.newscreenLocationY = newscreenLocationY;
            _widht = width;
            _height=height;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void frmItemMaster_Load(object sender, EventArgs e)
        {
            Location=new System.Drawing.Point(newscreenLocationX, newscreenLocationY);
            this.Height = _height;
            this.Width = _widht;

            SimulateMasterLoad();
            this.gdvTaxDetails.CellValueChanged += gdvTaxDetails_CellValueChanged;
        }

        private void SimulateMasterLoad()
        {
            fillItemCategory();
            fillTaxCategory();
            fillUnitCategory();
            GetLatestItemID();
            GetAllItemDetails(lstItemMaster);
            ClearAllFields();
            SetDefaultValues();
        }

        private void SetDefaultValues()
        {
            lblTodayDate.Text = DateTime.Now.Date.ToLongDateString();
            gdvItemDetails = CommonUtility.SetGridColor(gdvItemDetails,Color.Purple);
            gdvTaxDetails.Enabled = false ;
            cboTax.Enabled = false;
            btnAddTax.Enabled = false;
        }

        private async void GetAllItemDetails(List<ItemMasterEntity> lstItemDetails)
        {           
                dsAllItemDetails = await _itemMasterBLL.GetAllItems();
                if(dsAllItemDetails != null && dsAllItemDetails.Tables.Count > 0)
                {
                    gdvItemDetails.AutoGenerateColumns = false;
                    gdvItemDetails.DataSource = dsAllItemDetails.Tables[0];
                }
                else { }         
            
        }

        private async void GetLatestItemID()
        {
            txtID.Text = await _itemMasterBLL.GetLatestItemID();
            _itemId = txtID.Text != "" ? Convert.ToInt64(txtID.Text) : 0;
        }

        private async void fillUnitCategory()
        {
            lstUnitCategory = await _unitMasterBLL.GetAllUnits();
            cboUnitCategory.DataSource = lstUnitCategory;
            cboUnitCategory.DisplayMember = "UnitName";
            cboUnitCategory.ValueMember = "UnitID";
        }

        private async void fillTaxCategory()
        {
            if (lstTaxCategory.Count <= 0)
            {
                lstTaxCategory = await _taxMasterBLL.GetAllTaxCategories();
            }
            else { }
            

            cboTax.DataSource= lstTaxCategory;
            cboTax.DisplayMember = "TaxName";
            cboTax.ValueMember = "ID";
            cboTax.SelectedIndex = -1;
        }

        private async void fillItemCategory()
        {
            lstItemCategory = await _itemCategoryBLL.GetAllItemCategory();
            cboItemCategory.DataSource = lstItemCategory;
            cboItemCategory.DisplayMember = "CategoryName";
            cboItemCategory.ValueMember = "ID";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (chkApplyTaxes.Checked == false)
            {
               DialogResult ds= MessageBox.Show("Are you sure, You dont want to apply taxes for this item",Constants.PRODUCT_NAME,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (ds == DialogResult.No)
                {
                    chkApplyTaxes.Focus();
                    return;
                }
            }
            else { }
             _itemId = txtID.Text != "" ? Convert.ToInt64(txtID.Text) : 0;

            lstItemMaster = await _itemMasterBLL.AddData(new ItemMasterEntity()
            {
                ID = _itemId,
                ApplyTax = chkApplyTaxes.Checked == true ? 1 : 0,
                BarcodeID = txtBarcode.Text,
                CategoryID = Convert.ToInt32(cboItemCategory.SelectedValue),
                DiscPer = Convert.ToDecimal(txtDiscountPer.Text),
                DiscAmount = _discountAmount,
                ItemName = txtItemName.Text,
                Rate = Convert.ToDecimal(txtBasePrice.Text),
                UnitID = Convert.ToInt32(cboUnitCategory.SelectedValue),
                Qty = Convert.ToDecimal(txtQty.Text),
                Total = Convert.ToDecimal(txtSellPrice.Text),
                BuyPrice = Convert.ToDecimal(txtBuyPrice.Text),
            });
            await InsertItemTax( lstItemTaxMapping);
            SimulateMasterLoad();
        }

        private async Task InsertItemTax(List<ItemTaxMappingEntity> lstItemTaxMapping)
        {
            foreach (var item in lstItemTaxMapping)
            {
                await _taxMasterBLL.CreateAsync(new ItemTaxMappingEntity()
                {
                    ItemID = item.ItemID,
                    TaxID = item.TaxID
                });
            }
            lstItemTaxMapping.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            txtBarcode.Text = "";
            txtDiscountPer.Text = "0";
            txtItemName.Text = "";
            txtSellPrice.Text = "0.00";
            cboItemCategory.SelectedIndex = -1;
            cboUnitCategory.SelectedIndex = -1;
            lstSoldItemTaxes.Clear();            
            lstItemTaxMapping.Clear();
            lstTaxCategory.Clear();
        }

        private void txtSellPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtSellPrice.Text.Trim() != "")
            {
                CalculateBasePrice();
               
            }
            else {
                txtBasePrice.Text = "0";
                txtTaxAmount.Text = "0";
            }
        }

        private void CalculateBasePrice()
        {
            if (lstSoldItemTaxes.Count > 0)
            {
                decimal TotalPrice = Convert.ToDecimal(txtSellPrice.Text);
                decimal TotalTax = CalculateTax(TotalPrice);
                txtTaxAmount.Text = TotalTax.ToString();
                txtBasePrice.Text = (TotalPrice - TotalTax).ToString();
            }
            else { txtBasePrice.Text = txtSellPrice.Text; }
        }

        private decimal CalculateTax(decimal TotalPrice)
        {
            decimal _tax = 0;
            foreach (var item in lstSoldItemTaxes)
            {
                _tax += (TotalPrice * item.Percentage) / Constants.Enum.HUNDRED;
            }
            return _tax;
        }

        private void gdvTaxDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void chkApplyTaxes_CheckedChanged(object sender, EventArgs e)
        {
            if(chkApplyTaxes.Checked)
            {
                gdvTaxDetails.Enabled = true;
                cboTax.Enabled = true;
                btnAddTax.Enabled = true;
            }
            else
            {
                gdvTaxDetails.Enabled = false;
                cboTax.Enabled = false;
                btnAddTax.Enabled = false;
            }
        }

        private void gdvTaxDetails_CurrentCellChanged(object sender, EventArgs e)
        {
            if (gdvTaxDetails.CurrentCell != null)
            {
                if (gdvTaxDetails.CurrentCell.ColumnIndex == 0)
                {
                    //lstSoldItemTaxes.Clear();
                    //for (int i = 0; i < gdvTaxDetails.RowCount; i++)
                    //{
                    //    if (gdvTaxDetails.Rows[i].Cells[0].Selected != null && (bool)(gdvTaxDetails.Rows[i].Cells[0].Selected) == true)
                    //    {
                    //        lstItemTaxMapping.Add(new ItemTaxMappingEntity()
                    //        {
                    //            ItemID = _itemId,
                    //            TaxID = Convert.ToInt64(gdvTaxDetails.Rows[i].Cells[1].Value)
                    //        });
                    //        lstSoldItemTaxes.Add(new TaxCategoryEntity
                    //        {
                    //            ID = Convert.ToInt64(gdvTaxDetails.Rows[i].Cells[1].Value),
                    //            Percentage = Convert.ToDecimal(gdvTaxDetails.Rows[i].Cells[3].Value),
                    //        });

                    //    }
                    //    else
                    //    {

                    //    }
                    //}

                    //if (lstSoldItemTaxes.Count > 0)
                    //{ CalculateBasePrice(); }
                }
            }
        }

        private void btnAddTax_Click(object sender, EventArgs e)
        {           
            if (cboTax.SelectedItem != null)
            {
                long taxId = 0;
                decimal percentage = 0;
                GetTaxDetails(cboTax.SelectedItem,out taxId, out  percentage);                

                lstItemTaxMapping.Add(new ItemTaxMappingEntity()
                {
                    ItemID = _itemId,
                    TaxID = taxId
                });
                lstSoldItemTaxes.Add(new TaxCategoryEntity
                {
                    ID = taxId,
                    TaxName = cboTax.Text,
                    Percentage = percentage,
                });

                if (lstSoldItemTaxes.Count > 0)
                {
                    gdvTaxDetails.DataSource = null;
                    gdvTaxDetails.DataSource = lstSoldItemTaxes;
                    CalculateBasePrice();
                }
                else { }
            }
            else
            {
                MessageBox.Show("Please select Tax", Constants.PRODUCT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetTaxDetails(object selectedItem, out long taxId, out decimal percentage)
        {
            dynamic tempTax = selectedItem;
            if (tempTax != null)
            {
                taxId = Convert.ToInt64(tempTax.ID);
                percentage = Convert.ToDecimal(tempTax.Percentage);
            }
            else
            {
                taxId = 0;
                percentage = 0;
            }
        }

        private decimal GetTaxPercentage()
        {
            return Convert.ToDecimal(lstTaxCategory.Where(c => c.ID == Convert.ToInt64(cboTax.SelectedValue)).Select(c => c.Percentage).FirstOrDefault());
        }

        private void gdvTaxDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void txtItemName_Leave(object sender, EventArgs e)
        {
            txtItemName.Text = ExtensionMethod.SetToUpperCase(txtItemName);
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateDiscountPercentAndAmount();
        }

        private void CalculateDiscountPercentAndAmount()
        {
            if (txtDiscountPer.Text.Trim() == "") { txtDiscountPer.Text = "0"; }
            if ((Convert.ToDecimal(txtDiscountPer.Text.Trim()) > 0 || Convert.ToDecimal(txtDiscountAmount.Text.Trim()) > 0)
                && Convert.ToDecimal(txtSellPrice.Text.Trim()) > 0)
            {
                if ((Convert.ToDecimal(txtDiscountPer.Text.Trim()) > 0 || (Convert.ToDecimal(txtDiscountAmount.Text.Trim()) > 0) && Convert.ToDecimal(txtSellPrice.Text.Trim()) > 0))
                {
                    txtSellPrice.Text = CalculateSellPriceAfterDiscount();
                }
                else { }
            }
            else
            {
                if (txtSellPrice.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter sell price before entering Discount", Constants.PRODUCT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSellPrice.Focus();
                    txtSellPrice.SelectAll();
                    return;
                }
            }
        }

        private string CalculateSellPriceAfterDiscount()
        {
            return (Convert.ToDecimal(txtSellPrice.Text) - CalculateDiscount()).ToString();
        }


        private decimal CalculateDiscount()
        {
            if(txtDiscountPer.Text.Trim() != "" && Convert.ToDecimal(txtDiscountPer.Text)>0)
            {
                _discountAmount = ((Convert.ToDecimal(txtSellPrice.Text.Trim()) * Convert.ToDecimal(txtDiscountPer.Text.Trim())) / Constants.Enum.HUNDRED);
                txtDiscountAmount.Text =Math.Round( Convert.ToDecimal(_discountAmount),MidpointRounding.ToEven).ToString();
            }
            if (txtDiscountAmount.Text.Trim() != "" && Convert.ToDecimal(txtDiscountAmount.Text)>0)
            {
                _discountAmount = Convert.ToDecimal(txtDiscountAmount.Text);
                txtDiscountPer.Text = (Convert.ToDecimal(txtSellPrice.Text.Trim()) / Convert.ToDecimal(txtDiscountAmount.Text.Trim())).ToString();
            }

            return _discountAmount;
        }

        private void txtDiscountAmount_TextChanged(object sender, EventArgs e)
        {
            CalculateDiscountPercentAndAmount();
        }

        private void btnNewBarcode_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            string r = random.Next(0, 999999).ToString("D6");
            r+= random.Next(0, 999999).ToString("D7");
            txtBarcode.Text = r;//Guid.NewGuid().ToString("N").Substring(0,10);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
        private async Task<string> showMessage(string message, string button = "OK")
        {
            Form form = new Form();

            using (frmMessageBox frmMessageBox = new frmMessageBox())
            {
                //form.StartPosition = FormStartPosition.CenterScreen;
                //form.FormBorderStyle = FormBorderStyle.None;
                //form.BackColor = Color.Black;
                //form.Opacity = .70d;
                //form.WindowState = FormWindowState.Maximized;
                //form.Location = this.Location;
                //form.ShowInTaskbar = false;
                //form.TopMost = true;
                //frmMessageBox.Owner = form;
                frmMessageBox.WindowState = FormWindowState.Maximized;
                //frmMessageBox.Opacity = 0.70d;
                frmMessageBox._Message = message;
                frmMessageBox._Button = button;               
                frmMessageBox.ShowDialog();
                return frmMessageBox.result;

                //form.Dispose();
            }
        }
        private async void btnDownloadItems_Click(object sender, EventArgs e)
        {
            string directoryinfo = System.IO.Directory.GetCurrentDirectory();

            string filename = directoryinfo + "\\" + DateTime.UtcNow.ToString("dd_MM_yyyy_HH_mm_ss") + "ItemList";

            string message = CommonUtility.WriteExcel(filename, dsAllItemDetails.Tables[0]);
            await showMessage(message);
        }

        private void btnUploadItems_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.xls)|*.xls";
            openFileDialog.ShowDialog();

            string filename=openFileDialog.FileName;

          GetExcel(filename);
        }

        private DataTable GetDataTable(string sql, string connectionString)
        {
            DataTable dt = null;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    using (OleDbDataReader rdr = cmd.ExecuteReader())
                    {
                        dt.Load(rdr);
                        return dt;
                    }
                }
            }
        }

        private void GetExcel(string fullPathToExcel)
        {             
            string connString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=yes'", fullPathToExcel);
            System.Data.DataTable dt = GetDataTable("SELECT * from [Sheet1$]", connString);

            foreach (DataRow dr in dt.Rows)
            {
                //Do what you need to do with your data here
            }
        }
    }
}
