using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace mingrisoft_3_.Helper
{
    class sqlHelperNeu
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9H2IJLA\MSSQLDEVELOP17;User ID=NeuDBA;Password=********;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlDataReader sdr;
        public sqlHelperNeu()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public SqlConnection getConn()
        {
            return con;
        }

        public SqlDataReader QueryOperation(String StrQueryCommand)
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = StrQueryCommand;
            if (sdr != null)
                sdr.Close();
            sdr = cmd.ExecuteReader();
            return sdr;
        }
        public DataTable Query(String StrQueryCommand)
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(StrQueryCommand, con);
            sda.Fill(dt);
            return dt;
        }
        public bool ExeNonQuery(String StrCmd)
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = StrCmd;
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;

        }
        public void closeConn()
        {
            if (con.State != System.Data.ConnectionState.Closed)
                con.Close();
        }

        public bool ExeNoQueryProc(String cmdName, SqlParameter[] ps)
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = cmdName;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (SqlParameter p in ps)
            {
                cmd.Parameters.Add(p);
            }
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public DataTable QueryOperationProc(String cmdName, SqlParameter[] ps)
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = cmdName;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            if (ps != null)
            {
                foreach (SqlParameter p in ps)
                {
                    cmd.Parameters.Add(p);
                }
            }
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            return dt;
        }

        public DataTable QueryProc(String cmdStr, SqlParameter[] ps)
        {
            DataTable dt = new DataTable();
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = cmdStr;
            if (ps != null)
            {
                foreach (SqlParameter p in ps)
                {
                    cmd.Parameters.Add(p);
                }
            }
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            con.Close();
            return dt;
        }
    }
}