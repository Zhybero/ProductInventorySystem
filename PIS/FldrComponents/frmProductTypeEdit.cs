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
    public partial class frmProductTypeEdit : Form
    {
        int intNumberSuccess, intNumberFailed;
        public frmProductTypeEdit()
        {
            InitializeComponent();
        }

        private void frmProductTypeEdit_Load(object sender, EventArgs e)
        {
            LoadDgv();
        }
        public async void LoadDgv()
        {
            dgv1.Rows.Clear();
            var varlist = await new ClsGetList().GetModelProductTypeList();
            foreach (var list in varlist)
            {
                dgv1.Rows.Add(list.Code, list.Name);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            var dgvRows = dgv1.Rows.Cast<DataGridViewRow>().Where(row => row != null).ToList();
            foreach (var row in dgvRows)
            {
                if (Convert.ToBoolean(row.Cells[2].Value) == true)
                {
                    ModelProduct Mdl1 = new ModelProduct()
                    {
                        Code = row.Cells[0].Value.ToString(),
                        Name = row.Cells[1].Value.ToString(), 
                    };
                    var json = JsonConvert.SerializeObject(Mdl1);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", frmLogin.Instance.SessionCred.Token);
                    var result = await client.PutAsync($"{new ClsGetIPAddress().IPAddress()}/v1/product/UpdateModelProductType", content);
                    if (result.IsSuccessStatusCode)
                    {
                        intNumberSuccess += 1;
                        row.Cells[2].Value = 0;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult confirmDel = MessageBox.Show($"You're about to delete an item(s)", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmDel == DialogResult.Yes)
            {
                List<string> listCode = new List<string>();
                var dgvRowsDelete = dgv1.Rows.Cast<DataGridViewRow>().Where(row => row != null && Convert.ToBoolean(row.Cells[3].Value) == true).ToList();
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
                var result = await client.PostAsync($"{new ClsGetIPAddress().IPAddress()}/v1/product/DeleteProductType", content);
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

        private void dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        { 
            dgv1.CurrentRow.Cells[2].Value = 1;
        }
    }
}
