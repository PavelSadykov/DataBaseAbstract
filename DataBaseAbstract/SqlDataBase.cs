using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataBaseAbstract
{
    public class SqlDataBase : Database
    {
        private SqlConnection conn;
        public override string ConnectionString { get; set; } = "";
        public override void Connect()
        {
            conn = new SqlConnection(ConnectionString);
            conn.Open();
        }


        public override void ExecuteQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }


        public override object ExecuteQueryWithReader(string query)
        {
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader sqlReader = command.ExecuteReader();
            return sqlReader;
        }


        public override DataSet ExecuteQueryWithDataSet(string query)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(dataSet);
            return dataSet;
        }
    }
}
