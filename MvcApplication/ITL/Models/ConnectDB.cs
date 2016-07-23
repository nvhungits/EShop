using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace ITL.Models
{
    public class ConnectDB
    {
        public String conStr { set; get; }
        public SqlConnection sqlcon { set; get; }
        public String queryStr { set; get; }
        public SqlCommand sqlcmd { set; get; }

        public ConnectDB() { }
        public ConnectDB(String DB, String Table)
        {
            this.conStr = ConfigurationManager.ConnectionStrings[DB].ConnectionString;
            this.sqlcon = new SqlConnection(this.conStr);
            this.queryStr = "Select * from " + Table;
            sqlcmd = new SqlCommand(this.queryStr, this.sqlcon);
        }

        public void Close()
        {
            this.sqlcon.Close();
            this.sqlcmd.Connection.Close();
        }
    }
}