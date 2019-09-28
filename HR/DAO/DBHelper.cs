using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class DBHelper
    {
        static string connStr = "Data Source=.;Initial Catalog=HR4;Integrated Security=True";

        public static DataTable select(string sql, params SqlParameter[] ps)
        {
            SqlConnection conn = new SqlConnection(connStr);
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            if (ps != null)
            {
                sda.SelectCommand.Parameters.AddRange(ps);
            }
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public static DataTable FenYe(string sql, SqlParameter[] ps)
        {
            SqlConnection cn = new SqlConnection(connStr);
            SqlDataAdapter ad = new SqlDataAdapter(sql, cn);
            ad.SelectCommand.CommandType = CommandType.StoredProcedure;
            ad.SelectCommand.Parameters.AddRange(ps);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public static int InsertUpdateDelete(string sql, params SqlParameter[] ps)
        {
            int rs = 0;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (ps != null)
                {
                    cmd.Parameters.AddRange(ps);
                }
                try
                {
                    conn.Open();
                    rs= cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }

                return rs;
            }
        }

        public static object SelecSinger(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (ps != null)
                {
                    cmd.Parameters.AddRange(ps);
                }
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        public static object ProSelect(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (ps != null)
                {
                    cmd.Parameters.AddRange(ps);
                }
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        public static SqlDataReader SelectReader(string sql, params SqlParameter[] ps)
        {
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (ps != null)
                {
                    cmd.Parameters.AddRange(ps);
                }
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }



    }
}
