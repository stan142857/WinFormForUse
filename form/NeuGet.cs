using mingrisoft_3_.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mingrisoft_3_
{
    public partial class NeuGet : Form
    {
        public NeuGet()
        {
            InitializeComponent();
        }
        #region csv文档录入数据库
        private void btnCSVInsert_Click(object sender, EventArgs e)
        {
            int passFirst;
            CheckForIllegalCrossThreadCalls = false;
            DialogResult dr = MessageBox.Show("选择是，打开文件夹\n选择否，打开csv文件", "打开文件夹？", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            DialogResult dr0 = MessageBox.Show("选择是，去除\n选择否，不去", "去除首行？", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (dr0 == DialogResult.Yes)
            {
                passFirst = 0;
            }else
            {
                passFirst = 1;
            }
            if (dr == DialogResult.Yes)
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    Thread thread = new Thread(new ThreadStart(()=>getCSVFolder(passFirst)));
                    thread.Start();
                }
            }
            else
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //解决 没有与委托 匹配的重载
                    Thread thread = new Thread(new ThreadStart(()=>InsertCSVData(@openFileDialog1.FileName,passFirst)));
                    thread.Start();
                }
            }
        }
        void getCSVFolder(int passFirst)
        {
            string[] filesAll = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
            foreach(string item in filesAll)
            {
                if (item.EndsWith(".csv"))
                {
                    InsertCSVData(@item,passFirst);
                }
            }
        }
        void InsertCSVData(string fileDialog,int passFirst)
        {
            int countSucc = 0, countFail = 0,skipOne = passFirst;  // skipOne 设置是否跳过开头
            char[] ch = { '"' };
            LblTips.Text = "开始录入!";
            sqlHelperNeu shr = new sqlHelperNeu();
            LblTips.Text = "选择完成!";
            StreamReader sReader = new StreamReader(fileDialog, Encoding.GetEncoding("gb2312"));
            string strLine = string.Empty;
            while ((strLine = sReader.ReadLine()) != null)
            {
                if (skipOne > 0)
                {
                    string[] str = strLine.Split(new char[] { ',' }); //, StringSplitOptions.RemoveEmptyEntries
                    SqlParameter[] sp =
                    {
                    new SqlParameter("@TABLE_NAME",SqlDbType.NVarChar),
                    new SqlParameter("@TABLE_TYPE",SqlDbType.NVarChar),
                    new SqlParameter("@COMMENTS_tab",SqlDbType.NVarChar),
                    new SqlParameter("@COLUMN_NAME",SqlDbType.NVarChar),
                    new SqlParameter("@COMMENTS_col",SqlDbType.NVarChar)
                    };
                    try
                    {
                        for(int i = 0; i < 5; i++)
                        {
                            if (str[i]==null||str[i]=="")
                            {
                                LblTips.Text = "错误点：" + strLine + "-*-\n";
                                sp[i].Value = "0";
                            }
                            else
                            {
                                sp[i].Value = str[i];
                            }
                        }
                    }
                    catch (Exception)
                    { 
                        LblTips.Visible = true;
                        LblTips.Text = "csv文件与数据库格式不符！";
                        richTextBox1.Text = richTextBox1.Text + "路径：" + fileDialog + "格式有误---：" + strLine + "\n";
                    }
                    try
                    {
                        countSucc++;
                        shr.ExeNoQueryProc("Proc_InsertDBA", sp);
                        shr.closeConn();
                        richTextBox3.Text = "第" + countSucc + "条录入成功！"; ;
                    }
                    catch (Exception)
                    {
                        countFail++;
                        richTextBox2.Text = "第" + countFail + "条录入失败！开始下一条";
                        richTextBox1.Text = richTextBox1.Text + "路径："+fileDialog +"录入有误---：" + strLine  + "\n" ;
                        continue;
                    }
                }
                skipOne++;
            }
        }
        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            string sql = "delete from NeuNanJingLiShui";
            sqlHelperNeu shn = new sqlHelperNeu();
            shn.ExeNonQuery(sql);
            shn.closeConn();
        }
    }
}
