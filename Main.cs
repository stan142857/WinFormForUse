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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void 线程测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            threadTest threadTest = new threadTest();
            threadTest.Show();
            threadTest.MdiParent = this;
        }
    }
}
