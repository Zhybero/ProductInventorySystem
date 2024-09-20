using Newtonsoft.Json;
using PIS.FldrClass;
using PIS.FldrModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PIS.FldrMain
{
    public partial class frmLogin : Form
    {
        public static frmLogin Instance;
        public UserSession SessionCred;
        public frmLogin()
        {
            InitializeComponent();
            Instance = this;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUN.Text))
            {
                txtUN.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPW.Text))
            {
                txtPW.Focus();
                return; 
            }
            bool hasUser = await new ClsGetList().UserExist(txtUN.Text);
            if (!hasUser)
            {
                MessageBox.Show("Username Doesn't Exist!", "Error");
            }
            else
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync($"{new ClsGetIPAddress().IPAddress()}/v1/product/tblUserAll/GetLoginlALlUserInfo?Username={txtUN.Text}&Password={txtPW.Text}");
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var userSession = JsonConvert.DeserializeObject<UserSession>(jsonResponse); 
                    SessionCred = userSession; 
                    new frmMainMenu().Show();
                    this.Hide();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("You are not authorized!", "Warning");
                }
                else
                { 
                    MessageBox.Show("Invalid Information!", "Warning");
                }

            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
