using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace DataBaseAbstract
{
  public abstract  class Database
    {
        public virtual string ConnectionString { get; set; } = string.Empty;    
        public abstract void Connect();
        public abstract void ExecuteQuery(string query);
        public abstract object ExecuteQueryWithReader(string query);
        public abstract DataSet ExecuteQueryWithDataSet (string query);
    }

   
}
