using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RfIDAicTec.Models;
using RfIDAicTec.Shared;
using RfIDAicTec.Sheard;
using RFIDReaderAPI.Models;
namespace RfIDAicTec
{
    public partial class CreateTransactionForm : Form
    {
        private List<Tag_Model> _tag_Models;
        private HttpClientService _httpClientService = new HttpClientService(); 
        public CreateTransactionForm(List<Tag_Model> tag_Models)
        {
            _tag_Models = tag_Models;
            InitializeComponent();
        }

        private void ChangeTransactionType(TransactionEnum transactionEnum)
        {
            switch (transactionEnum)
            {
                case TransactionEnum.TransactionIn:
                    cbCustmerSupplier.DisplayMember = "nameAr";
                    cbCustmerSupplier.ValueMember = "Id";
                    lblCustmerSupplier.Text = "Supplier :";
                    lblCustmerSupplier.Visible = true;
                    cbCustmerSupplier.Visible = true;
                    cbCustmerSupplier.DataSource = null;
                    lblDatetTime.Visible = true;
                    lblinvoice.Visible = true;
                    txtDatein.Visible = true;
                    txtInvoice.Visible = true;
                    break;
                case TransactionEnum.TransactionOut:
                    cbCustmerSupplier.DisplayMember = "nameAr";
                    cbCustmerSupplier.ValueMember = "Id";
                    lblCustmerSupplier.Text = "Customer :";
                    lblCustmerSupplier.Visible = true;
                    cbCustmerSupplier.Visible = true;
                    lblDatetTime.Visible = true;
                    lblinvoice.Visible = true;
                    txtDatein.Visible = true;
                    txtInvoice.Visible = true;
                    cbCustmerSupplier.DataSource = null;
                    break;
              
                default:
                    lblCustmerSupplier.Visible = false;
                    cbCustmerSupplier.Visible = false;
                    lblDatetTime.Visible = false;
                    lblinvoice.Visible = false;
                    txtDatein.Visible = false;
                    txtInvoice.Visible = false;
                    break;
            }
            
            
        }

        private async void cbtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbtype.Text)
            {
                case "Transaction in":
                    var resultSupplier = await _httpClientService.CallService<RequestResult<List<CustomerModel>>>("api/Custmer", UserData.UserToken);
                    ChangeTransactionType(TransactionEnum.TransactionIn);
                    cbCustmerSupplier.DataSource = resultSupplier.Data.Data.ToList();
                    break;
                case "Transaction out":
                    var resultCustmer = await _httpClientService.CallService<RequestResult<List<CustomerModel>>>("api/Supplier", UserData.UserToken);
                    ChangeTransactionType(TransactionEnum.TransactionOut);
                    cbCustmerSupplier.DataSource = resultCustmer.Data.Data.ToList(); break;
                default:
                    ChangeTransactionType(TransactionEnum.Stock);

                    break;
            }
        }
        
        private async void button1_Click(object sender, EventArgs e)
        {
            switch (cbtype.Text)
            {
                case "Transaction in":
                    List<TransferInDetail> transferInDetails = new List<TransferInDetail>();
                    foreach (var item in _tag_Models)
                    {
                        transferInDetails.Add(new TransferInDetail { productCode = item.TID, qty = (int)item.TotalCount });
                    }
                    TransactionInModel transactionInMode = new TransactionInModel { SupllierId = cbCustmerSupplier.SelectedIndex,InvoiceNo=txtInvoice.Text,TransferDate=txtDatein.Value,TransferInDetails= transferInDetails };
                    var resultSupplier =  _httpClientService.CallServicePost("Product/TransferIn", transactionInMode, UserData.UserToken);
                    break;
                case "Transaction out":
                    List<TransferOutDetail> transferOutDetails = new List<TransferOutDetail>();
                    foreach (var item in _tag_Models)
                    {
                        transferOutDetails.Add(new TransferOutDetail {productCode = item.TID, qty = (int)item.TotalCount});
                    }
                    TransactionOutModel transactionOutModel = new TransactionOutModel { CustmerId = cbCustmerSupplier.SelectedIndex, InvoiceNo = txtInvoice.Text, TransferDate = txtDatein.Value, TransferOutDetails = transferOutDetails };
                    var resultCustmer= _httpClientService.CallServicePost("Product/TransferIn", transactionOutModel, UserData.UserToken);
                    break;
                case "Stock":
                    List<ScanModel> scanModels = new List<ScanModel>();
                    foreach (var item in _tag_Models)
                    {
                        scanModels.Add(new ScanModel { ProductCode = item.TID , ScannedStock = (int)item.TotalCount  });
                    }
                    var resultScaning = _httpClientService.CallServicePost("Product/Scan", scanModels, UserData.UserToken);
                    break;
                default:
                    MessageBox.Show("Please choose valid Transaction type");
                    break;
            }
        }
    }
}
