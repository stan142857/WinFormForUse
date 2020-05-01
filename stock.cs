using NPlot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mingrisoft_3_
{
    public partial class stock : Form
    {
        public stock()
        {
            InitializeComponent();
        }

        private void BtnIns_Click(object sender, EventArgs e)
        {
            SqlHelper shr = new SqlHelper();
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sReader = new StreamReader(openFileDialog1.FileName, Encoding.UTF8);
                string strLine = string.Empty;
                while ((strLine = sReader.ReadLine()) != null)
                {
                    string[] str = strLine.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    
                    SqlParameter[] sp =
                    {
                        new SqlParameter("@time",SqlDbType.Date),
                        new SqlParameter("@closePri",SqlDbType.Money),
                        new SqlParameter("@highPri",SqlDbType.Money),
                        new SqlParameter("@lowPri",SqlDbType.Money),
                        new SqlParameter("@openPri",SqlDbType.Money),
                        new SqlParameter("@lastClosePri",SqlDbType.Money),
                        new SqlParameter("@change",SqlDbType.Money),
                        new SqlParameter("@changePer",SqlDbType.Float),
                        new SqlParameter("@changeHand",SqlDbType.Float),
                        new SqlParameter("@volume",SqlDbType.VarChar),
                        new SqlParameter("@turnover",SqlDbType.VarChar),
                        new SqlParameter("@totalMarCap",SqlDbType.VarChar),
                        new SqlParameter("@marCap",SqlDbType.VarChar)
                    };
                    try
                    {
                        sp[0].Value = str[0];
                        sp[1].Value = str[3];
                        sp[2].Value = str[4];
                        sp[3].Value = str[5];
                        sp[4].Value = str[6];
                        sp[5].Value = str[7];
                        sp[6].Value = str[8];
                        sp[7].Value = str[9];
                        sp[8].Value = str[10];
                        sp[9].Value = str[11];
                        sp[10].Value = str[12];
                        sp[11].Value = str[13];
                        sp[12].Value = str[14];
                    }catch(Exception ex)
                    {
                        LblTips.Visible = true;
                        LblTips.Text = "csv文件与数据库格式不符！";
                    }
                    try
                    {
                        shr.ExeNoQueryProc("Proc_Insert000826", sp);
                        shr.closeConn();
                    }
                    catch(Exception ex)
                    {
                        continue;
                    }

                }
            }
        }
        private void BtnClearDb_Click(object sender, EventArgs e)
        {
            SqlHelper shr = new SqlHelper();
            string str = "truncate table stock_000826";
            shr.ExeNonQuery(str);
            shr.closeConn();
        }
        private void Btnrefesh_Click(object sender, EventArgs e)
        {
            int[] opens = { 1, 2 };     //开始数目
            double[] closes = { 2.2, 2.003 }; //结束数目
            float[] lows = { 1, 1 };    //最高
            System.Int64[] highs = { 3, 2 }; //最低
            int[] times = { 0, 1, 2, 3, 4, 5 };      //时间
            CandlePlot cp = new CandlePlot
            {
                CloseData = closes,
                OpenData = opens,
                LowData = lows,
                HighData = highs,
                AbscissaData = times
            };
            plot.Title = "蜡烛图";
            this.plot.Add(cp);

            panelPlot.Refresh();
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            
        }
        //读取数据库数据并用蜡烛图表示
        private void BtnReadDb_Click(object sender, EventArgs e)
        {
            string sql = "select * from stock_000826 where Id < 500";
            SqlHelper shr = new SqlHelper();

            DataTable dt = shr.Query(sql);
            CandlePlot cp = new CandlePlot();
            cp.DataSource = dt;
            cp.AbscissaData = "Id";
            cp.OpenData = "openPri";
            cp.LowData = "lowPri";
            cp.HighData = "highPri";
            cp.CloseData = "closePri";
            cp.Label = "走势图";
            
            /*
            SqlDataReader sdr =  shr.QueryOperation(sql);
            ArrayList arrayStart = new ArrayList();
            ArrayList arrayEnd = new ArrayList();
            ArrayList arrayHigh = new ArrayList();
            ArrayList arrayLow = new ArrayList();
            ArrayList arrayTime = new ArrayList();
            while(sdr.Read())
            {
                arrayStart.Add(sdr[5].ToString());
                arrayLow.Add(sdr[4].ToString());
                arrayHigh.Add(sdr[3].ToString());
                arrayEnd.Add(sdr[2].ToString());
                arrayTime.Add(sdr[0]);
            }

            Double[] Start = arrayStart.Cast<object>().Select(t => Convert.ToDouble(t)).ToArray();
            Double[] Low = arrayLow.Cast<object>().Select(t => Convert.ToDouble(t)).ToArray();
            Double[] High = arrayHigh.Cast<object>().Select(t => Convert.ToDouble(t)).ToArray();
            Double[] End = arrayEnd.Cast<object>().Select(t => Convert.ToDouble(t)).ToArray();
            int[] Time = arrayTime.Cast<object>().Select(t => Convert.ToInt32(t)).ToArray();

            CandlePlot cp = new CandlePlot();
            cp.CloseData = End;
            cp.OpenData = Start;
            cp.LowData = Low;
            cp.HighData = High;
            cp.AbscissaData = Time;
            */

            plot.Title = "走势图";
            plot.CreateGraphics();
            try
            {
                this.plot.Add(cp);
            }catch(Exception ex)
            {
                throw ex;
            }
            
            panelPlot.Refresh();
        }
    }
}
