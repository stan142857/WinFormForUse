using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mingrisoft_3_.Helper;

namespace mingrisoft_3_
{
    public class CSVOpeHelper
    {
        public static void TableValuedToDB(DataTable dt)
        {
            sqlHelperNeu shr = new sqlHelperNeu();
            //接口
            const string TSqlStatement =
             "insert into NeuNanJingLiShui(TABLE_NAME,TABLE_TYPE,COMMENTS_tab,COLUMN_NAME,COMMENTS_col)" +
             " SELECT nc.TABLE_NAME,nc.TABLE_TYPE,nc.COMMENTS_tab,nc.COLUMN_NAME,nc.COMMENTS_col" +
             " FROM @NewNeuNanJingLiShui AS nc";
            SqlCommand cmd = new SqlCommand(TSqlStatement, shr.getConn());
            SqlParameter catParam = cmd.Parameters.AddWithValue("@NewNeuNanJingLiShui", dt);
            catParam.SqlDbType = SqlDbType.Structured;
            catParam.TypeName = "dbo.NeuNanJingLiShuiTVPs";
            try
            {
                shr.getConn().Open();
                if (dt != null && dt.Rows.Count != 0)
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                shr.closeConn();
            }

        }
        public static DataTable OpenCSV(string filePath)
        {
            Encoding encoding = Encoding.GetEncoding("uft-8"); //Encoding.ASCII;//
            DataTable dt = new DataTable();
            FileStream fs = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            
            StreamReader sr = new StreamReader(fs, encoding);
            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine = null;
            string[] tableHead = null;
            //标示列数
            int columnCount = 0;
            //标示是否是读取的第一行
            bool IsFirst = true;
            //逐行读取CSV中的数据
            DataColumn dc;
            //获取行数据
            while ((strLine = sr.ReadLine()) != null)
            {
                if (IsFirst == true)
                {
                    tableHead = strLine.Split(',');
                    IsFirst = false;
                    columnCount = tableHead.Length;
                    //创建列
                    for (int i = 0; i < columnCount; i++)
                    {
                        dc = new DataColumn(tableHead[i]);
                        dt.Columns.Add(dc);
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(strLine))
                    {
                        aryLine = strLine.Split(',');
                        DataRow dr = dt.NewRow();
                        for (int j = 0; j < columnCount; j++)
                        {
                            dr[j] = aryLine[j];
                        }
                        dt.Rows.Add(dr);
                    }
                }
            }
            if (aryLine != null && aryLine.Length > 0)
            {
                dt.DefaultView.Sort = tableHead[0] + " " + "asc";
            }

            sr.Close();
            fs.Close();
            return dt;
        }
    }
}