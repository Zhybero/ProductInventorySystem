using Newtonsoft.Json;
using PIS.FldrClass;
using PIS.FldrMain;
using PIS.FldrModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PIS.FldrComponents
{
    public partial class frmProductEdit : Form
    {
        int intNumberSuccess, intNumberFailed;
        public frmProductEdit()
        {
            InitializeComponent();
        }

        private void frmProductEdit_Load(object sender, EventArgs e)
        {
            BuildComboBox();
            LoadDgv();
        }

        public async void BuildComboBox()
        {
            await new ClsComboBox().GetcboDgvProductList(ColPType);
        }

        public async void LoadDgv()
        {
            dgv1.Rows.Clear();
            var varlist = await new ClsGetList().GetModelProductEntryList();
            foreach (var list in varlist)
            {
                dgv1.Rows.Add(list.ProductCode, list.ProductName, list.ProductDesc, list.PTypeCode, list.Qty, list.UnitPrice);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        { 
            dgv1.CurrentRow.Cells[6].Value = 1;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult confirmDel = MessageBox.Show($"You're about to delete an item(s)", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmDel == DialogResult.Yes)
            {
                List<string> listCode = new List<string>();
                var dgvRowsDelete = dgv1.Rows.Cast<DataGridViewRow>().Where(row => row != null && Convert.ToBoolean(row.Cells[7].Value) == true).ToList();
                foreach (var list in dgvRowsDelete)
                {
                    listCode.Add(list.Cells[0].Value.ToString());
                }
                var Mdl1 = new ModelDelete()
                {
                    Code = listCode
                };
                var json = JsonConvert.SerializeObject(Mdl1);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var result = await client.PostAsync($"{new ClsGetIPAddress().IPAddress()}/v1/product/DeleteProductEntry", content);
                if (result.IsSuccessStatusCode)
                {
                    LoadDgv();
                }
                else
                {
                    MessageBox.Show("Failed to save!", "Error");
                }
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            var dgvRows = dgv1.Rows.Cast<DataGridViewRow>().Where(row => row != null).ToList();
            foreach (var row in dgvRows)
            {
                if (Convert.ToBoolean(row.Cells[6].Value) == true)
                {
                    ModeltblProductEntry Mdl1 = new ModeltblProductEntry()
                    {
                        ProductCode = row.Cells[0].Value.ToString(), 
                        ProductName = row.Cells[1].Value.ToString(),
                        ProductDesc = row.Cells[2].Value.ToString(),
                        PTypeCode = row.Cells[3].Value.ToString(),
                        Qty = int.Parse(row.Cells[4].Value.ToString()),
                        UnitPrice = double.Parse(row.Cells[5].Value.ToString()),
                    };
                    var json = JsonConvert.SerializeObject(Mdl1);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", frmLogin.Instance.SessionCred.Token);
                    var result = await client.PutAsync($"{new ClsGetIPAddress().IPAddress()}/v1/product/UpdateModelProductEntry", content);
                    if (result.IsSuccessStatusCode)
                    {
                        intNumberSuccess += 1;
                        row.Cells[6].Value = 0;
                    }
                    else
                    {
                        intNumberFailed += 1;
                    }
                }
            }
            string strTMsg = intNumberSuccess.ToString() + " Succeeded, " + intNumberFailed.ToString() + " Failed";
            MessageBox.Show(strTMsg);
            intNumberSuccess = 0;
            intNumberFailed = 0;
        }
    }
}
