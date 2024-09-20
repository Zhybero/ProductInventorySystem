using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIS.FldrClass
{
    public class ClsComboBox
    {

        public async Task GetcboProductList(ComboBox ComboBox1)
        {
            var varList = await new ClsGetList().GetModelProductTypeList();
            ComboBox1.DataSource = null;
            ComboBox1.DataSource = varList;
            ComboBox1.DisplayMember = "Name";
            ComboBox1.ValueMember = "Code";
        }
        public async Task GetcboDgvProductList(DataGridViewComboBoxColumn ComboBox1)
        {
            var varList = await new ClsGetList().GetModelProductTypeList();
            ComboBox1.DataSource = null;
            ComboBox1.DataSource = varList;
            ComboBox1.DisplayMember = "Name";
            ComboBox1.ValueMember = "Code";
        }
    }
}
