using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DataBaseAbstract
{
    public class SqliteDataBase : Database
    {

        private SQLiteConnection conn;
        public override string ConnectionString { get; set; } = "";
        public override void Connect()
        {
            conn = new SQLiteConnection (ConnectionString);
            conn.Open();
        }


        public override void ExecuteQuery(string query)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }


        public override object ExecuteQueryWithReader(string query)
        {
           SQLiteCommand command = new SQLiteCommand(query, conn);
            SQLiteDataReader sqliteReader = command.ExecuteReader();
            return sqliteReader;
        }


        public override DataSet ExecuteQueryWithDataSet(string query)
        {
            DataSet dataSet = new DataSet();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
            adapter.Fill(dataSet);
            return dataSet;
        }
    }
}

