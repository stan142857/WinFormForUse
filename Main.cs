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

        private void 股票查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stock stock = new stock();
            stock.Show();
            stock.MdiParent = this;
        }

        private void eF使用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EFUseInfo eFUseInfo = new EFUseInfo();
            eFUseInfo.Show();
            eFUseInfo.MdiParent = this;
        }

        private void 接口排序泛型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            geneTest geneTest = new geneTest();
            geneTest.Show();
            geneTest.MdiParent = this;
        }

        private void 本质论ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BenZhiLunSeven benZhiLunSeven = new BenZhiLunSeven();
            benZhiLunSeven.Show();
            benZhiLunSeven.MdiParent = this;
        }

        private void fORM1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CSVRead cSVRead = new CSVRead();
            cSVRead.Show();
            cSVRead.MdiParent = this;
        }
    }
}
