using PIS.FldrClass;
using PIS.FldrComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIS.FldrMain
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (form.Text != this.Text && form.Text!= new frmLogin().Text)
                {
                    form.Close();
                }
            }
            this.Hide(); 
            new frmLogin().Show();
        }

        private void frmMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        { 
            Application.Exit();
        }

        private void btnProductEntry_Click(object sender, EventArgs e)
        {
            new frmProduct().Show();
        }

        private async void frmMainMenu_Load(object sender, EventArgs e)
        {
            lblProduct.Text = (await new ClsGetList().GetCountProducts()).ToString();
            lblProductType.Text = (await new ClsGetList().GetCountProductsType()).ToString();
            lblUser.Text = (await new ClsGetList().GetCountUser()).ToString();
        }
    }
}
