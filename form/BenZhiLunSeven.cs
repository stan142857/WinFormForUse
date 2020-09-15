using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mingrisoft_3_
{
    public partial class BenZhiLunSeven : Form
    {
        public BenZhiLunSeven()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var par = new { title = "title",yop = "1122" };
            var par1 = new { title = "title1",yop = "11122" };
            string s = $"get {par}par1";
            string s1 = @" sdads 
                    /
                /       /
                " + s;
            textBox1.Text = s1;
        }
    }
}
