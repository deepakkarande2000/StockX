using StockXBEntity;
using StockXCore;
using StokXBLL.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockX.Master
{
    public partial class frmStockMaster : Form
    {
        private int newscreenLocationX;
        private int newscreenLocationY;

        List<ItemMasterEntity> lstItemDetails = new List<ItemMasterEntity>();
        List<StockMasterEntity> lstStockDetails=new List<StockMasterEntity>();
        List<SupplierMasterEntity> lstSupplier = new List<SupplierMasterEntity>();
        List<StockTxnHistoryEntity> lstStockTxn = new List<StockTxnHistoryEntity>();

        StockMasterBLL stockMasterBLL=new StockMasterBLL();
        ItemMasterBLL itemMasterBLL =new ItemMasterBLL();
        SupplierMasterBLL supplierMasterBLL = new SupplierMasterBLL();
        StockTxnHistoryBLL stockTxnHistoryBLL = new StockTxnHistoryBLL();
        DataSet dsAllStockDetails = new DataSet();
        public frmStockMaster()
        {
            InitializeComponent();
        }

        public frmStockMaster(int newscreenLocationX, int newscreenLocationY)
        {
            
            this.newscreenLocationX = newscreenLocationX;
            this.newscreenLocationY = newscreenLocationY;
            InitializeComponent();
            this.cboItems.SelectedIndexChanged -= cboItems_SelectedIndexChanged;
            
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

        private void frmStockMaster_Load(object sender, EventArgs e)
        {
            cboItems.SelectedIndexChanged += cboItems_SelectedIndexChanged;
            this.Location = new Point(newscreenLocationX, newscreenLocationY);
            SimulateMasterLoad();
        }

        private void SimulateMasterLoad()
        {
            fillItemDetails();
            fillSuppliers();
            fillStockDatagrid();
            ClearAllControls();
            SetDefaultValues();

        }

        private async void fillSuppliers()
        {
            cboSupplier.SelectedValueChanged -= cboSupplier_SelectedValueChanged;
               lstSupplier = await supplierMasterBLL.GetAllSuppliers();
            cboSupplier.DataSource = lstSupplier;
            cboSupplier.ValueMember = "ID";
            cboSupplier.DisplayMember = "Name";
            cboSupplier.SelectedValue = -1;
            cboSupplier.Text = "";
            cboSupplier.SelectedValueChanged += cboSupplier_SelectedValueChanged;
        }

        private async void fillStockDatagrid()
        {
            dsAllStockDetails = await stockMasterBLL.GetStockDetails();
            gdvItemDetails.AutoGenerateColumns = false;
            gdvItemDetails.DataSource = dsAllStockDetails.Tables[0];

            gdvPurchaseHistory.AutoGenerateColumns = false;
            gdvPurchaseHistory.DataSource = lstStockTxn;
        }

        private async void fillItemDetails()
        {
            lstItemDetails = await itemMasterBLL.GetOnlyItemsDetails();

            cboItems.DataSource = lstItemDetails;
            cboItems.DisplayMember = "ItemName";
            cboItems.ValueMember = "ID";
        }

        private void SetDefaultValues()
        {
            lblTodayDate.Text = DateTime.UtcNow.ToLongDateString();
        }

        private void ClearAllControls()
        {            
            cboItems.SelectedIndex = -1;
            cboSupplier.SelectedIndex = -1;
            lblUnitID.Text = "0";
            lblExistingQty.Text = "0";
            lblTotalQty.Text = "0";
            txtNewQty.Text = "0";
            lblAddress.Text = "";
            lblUnit.Text = "";
            lblUnitQty.Text = "0";
            lblSupContact.Text = "";
            lblTotal.Text = "0";
            txtPrice.Text = "0";
            txtSupplierBillNo.Text = "";

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string _message = await ValidateInputs();

            if (_message != "")
            {
                MessageBox.Show(_message, Constants.PRODUCT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lstStockDetails = await stockMasterBLL.AddData(new StockMasterEntity()
            {
                ItemID = Convert.ToInt64(cboItems.SelectedValue),
                Qty = Convert.ToDecimal(lblTotalQty.Text),
                UnitID = Convert.ToInt32(lblUnitID.Text),
                UnitQty = Convert.ToDecimal(lblUnitQty.Text),
            });

            lstStockTxn= await stockTxnHistoryBLL.AddData(new StockTxnHistoryEntity()
            {
                BillNo = txtSupplierBillNo.Text.Trim(),
                ItemID = Convert.ToInt64(cboItems.SelectedValue),
                PurchaseDate = dtpBillDate.Value.Date.ToString("yyyyMMdd"),
                Qty = Convert.ToDecimal(lblTotalQty.Text),
                SupplierID = Convert.ToInt64(cboSupplier.SelectedValue),
                Total = Convert.ToDecimal(lblTotal.Text),
                UnitID = Convert.ToInt32(lblUnitID.Text),
                Price= Convert.ToDecimal(txtPrice.Text)
            });

            MessageBox.Show(Constants.Message_Types.DATA_SAVE, Constants.PRODUCT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearAllControls();
            fillStockDatagrid();
        }

        private async Task<string> ValidateInputs()
        {
            StringBuilder sb = new StringBuilder();
            if (txtNewQty.Text == "" || txtNewQty.Text == "0" )
            {
                sb.AppendLine("New Qty Not entered");

            }
            else if (txtSupplierBillNo.Text.Trim() == "")
            {
                sb.AppendLine("Supplier Bill No is missing");
            }
            else if (cboSupplier.Text.Trim() == "")
            {
                sb.AppendLine("Supplier Not selected");

            }
            else if (cboItems.Text.Trim() == "")
            {
                sb.AppendLine("Item Not Selected");

            }
            else
            {

            }
            return sb.ToString();
        }

        private void cboItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboItems.Text != "")
            {
                dynamic items = cboItems.SelectedItem;
                GetExistingStock(items.ID);
            }
            else { }
        }

        private void GetExistingStock(dynamic iD)
        {
            DataRow dr= GetStockDetails(Convert.ToInt64(iD));
            if (dr != null)
            {
                lblExistingQty.Text = dr["StockQty"].ToString();
                lblUnitID.Text = dr["UnitID"].ToString();
                lblUnit.Text = dr["UnitName"].ToString();
                lblUnitQty.Text = dr["UnitQty"].ToString();
            }
            else
            {
                var result=lstItemDetails.Where(c=>c.ID==iD).FirstOrDefault();
                if (result != null)
                {
                    lblExistingQty.Text = "0";
                    lblUnitID.Text = result.UnitID.ToString();
                    lblUnit.Text = "0";
                    lblUnitQty.Text = "0";
                }
            }
        }

        private DataRow GetStockDetails(dynamic itemID)
        {
            if (dsAllStockDetails != null && dsAllStockDetails.Tables.Count > 0)
            {
                DataRow dr = dsAllStockDetails.Tables[0].AsEnumerable().Where(c => c.Field<Int64>("ItemID") == itemID).FirstOrDefault();

                if (dr != null)
                {
                    return dr;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private void txtNewQty_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalQty();
            CalculateTotalPrice();
        }

        private void CalculateTotalQty()
        {
            if (txtNewQty.Text.Trim() != "")
            {
                lblTotalQty.Text = (Convert.ToDecimal(lblExistingQty.Text) + Convert.ToDecimal(txtNewQty.Text)).ToString();
            }
            else { }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            string text = ((Control)sender).Text;

            // Is Negative Number?
            if (e.KeyChar == '-' && text.Length == 0)
            {
                e.Handled = false;
                return;
            }

            // Is Float Number?
            if (e.KeyChar == '.' && text.Length > 0 && !text.Contains("."))
            {
                e.Handled = false;
                return;
            }

            // Is Digit?
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void cboSupplier_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboSupplier.SelectedValue != null)
            {
                decimal supplierID = Convert.ToDecimal(cboSupplier.SelectedValue);

                if (lstSupplier.Count > 0)
                {
                    var details = lstSupplier.Where(c => c.ID == supplierID).FirstOrDefault();

                    if (details!=null)
                    {
                        lblAddress.Text = details.Address;
                        lblSupContact.Text = details.ContactNo;
                    }
                    else
                    {
                        lblAddress.Text = "";
                        lblSupContact.Text = "";
                    }
                }
                else { }
            }
            else { }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void CalculateTotalPrice()
        {
            if (txtPrice.Text.Trim() != "" && txtNewQty.Text.Trim() != "")
            {
                lblTotal.Text = (Convert.ToDecimal(txtPrice.Text) * Convert.ToInt32(txtNewQty.Text)).ToString();
            }
            else { }
        }

        private void btnAddNewSupplier_Click(object sender, EventArgs e)
        {
            frmSupplierMaster frmSupplierMaster = new frmSupplierMaster(newscreenLocationX, newscreenLocationY);
            frmSupplierMaster.ShowDialog();
            fillSuppliers();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllControls();
        }
    }
}
