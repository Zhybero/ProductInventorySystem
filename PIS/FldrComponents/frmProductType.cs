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
    public partial class frmProductType : Form
    {
        public frmProductType()
        {
            InitializeComponent();
        }

        private void frmProductType_Load(object sender, EventArgs e)
        {
            AutoNumber();
        }

        public async void AutoNumber()
        {
            lblAutoNumber.Text = await new ClsGetList().ProductTypeAutoNum();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                txtName.Focus();
            }
            else
            {
                var mdl1 = new ModelProduct()
                {
                    Name = txtName.Text,
                };
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", frmLogin.Instance.SessionCred.Token);
                    var content = new StringContent(JsonConvert.SerializeObject(mdl1), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{new ClsGetIPAddress().IPAddress()}/v1/product/ProductType", content); 
                    if (response.IsSuccessStatusCode)
                    { 
                        AutoNumber();
                        txtName.Clear();
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

        private void btnList_Click(object sender, EventArgs e)
        {
            new frmProductTypeEdit().Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
