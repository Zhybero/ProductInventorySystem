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

namespace PIS.FldrComponents
{
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            AutoNumber();
            BuildComboBox();
        }

        public async void AutoNumber()
        {
            lblAutoNumber.Text = await new ClsGetList().GetProductAutoNum();
        }
        public async void BuildComboBox()
        {
            await new ClsComboBox().GetcboProductList(cboPTCode);
        }

        private void btnAddPType_Click(object sender, EventArgs e)
        {
            new frmProductType().Show();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                txtName.Focus();
            }
            else if (string.IsNullOrEmpty(txtDesc.Text))
            {
                txtDesc.Focus();
            }
            else if (string.IsNullOrEmpty(txtQty.Text) || int.Parse(txtQty.Text)<=0)
            {
                txtQty.Focus();
            }
            else if (string.IsNullOrEmpty(txtUP.Text) || double.Parse(txtUP.Text)<=0)
            {
                txtUP.Focus();
            }
            else if (string.IsNullOrEmpty(cboPTCode.Text) || cboPTCode.SelectedValue == null)
            {
                cboPTCode.Focus();
            }
            else
            {
                var mdl1 = new ModeltblProductEntry()
                {
                    ProductName = txtName.Text,
                    ProductDesc = txtDesc.Text,
                    PTypeCode = cboPTCode.SelectedValue.ToString(),
                    Qty = int.Parse(txtQty.Text),
                    UnitPrice = double.Parse(txtUP.Text),
                };
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", frmLogin.Instance.SessionCred.Token);
                    var content = new StringContent(JsonConvert.SerializeObject(mdl1), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{new ClsGetIPAddress().IPAddress()}/v1/product/ProductEntry", content);
                    if (response.IsSuccessStatusCode)
                    {
                        AutoNumber();
                        txtName.Clear();
                        txtDesc.Clear();
                        txtQty.Text="0";
                        txtUP.Text="0.00";
                        cboPTCode.SelectedIndex = 1;
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        MessageBox.Show("You Are Not Authorize!", "Authorization");
                    }
                    else
                    {
                        MessageBox.Show("Failed to save!", "Error");
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUP_Validating(object sender, CancelEventArgs e)
        {
            double.Parse(txtUP.Text).ToString("N2");
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            new frmProductEdit().Show();
        }
    }
}
