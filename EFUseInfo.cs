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
    public partial class EFUseInfo : Form
    {
        public EFUseInfo()
        {
            InitializeComponent();
        }

        InfoManageEntities info = new InfoManageEntities();
        private void EFUseInfo_Load(object sender, EventArgs e)
        {
            DGVUSERS.DataSource = info.ZYF_JG_YP.ToList();
        }
        public void BindGVDUSERS()
        {
            InfoManageEntities db = new InfoManageEntities();

        }

        private void BTNQUERY_Click(object sender, EventArgs e)
        {
            var yp = info.ZYF_JG_YP as IQueryable<ZYF_JG_YP>;
            IQueryable<ZYF_JG_YP> ypid = yp.Where(m => m.YPID == "YP00001");
        }
    }
}
