using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyks
{
    class dbConnectors
    {
        public const string host = "ADMINISTRATOR\\SQLEXPRESS";
        string conString = "Data Source=" + host + ";Initial Catalog=quanlyks;Integrated Security=True";
        public SqlConnection con;

        public DataTable runQuery(string sql)
        {
            try
            {
                con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    return dt;
                }
                else
                {
                    throw new ApplicationException("Rỗng");

                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public bool executeQuery(string sql)
        {
            try
            {
                con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

    }
}
