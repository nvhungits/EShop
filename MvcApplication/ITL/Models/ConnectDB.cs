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
        private String conStr;
        private SqlConnection sqlcon;

        public ConnectDB(String DB)
        {
            this.conStr = ConfigurationManager.ConnectionStrings[DB].ConnectionString;
            this.sqlcon = new SqlConnection(this.conStr);
            try
            {
                this.sqlcon.Open();
                Console.WriteLine("Connected to \'"+DB+"\' database");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error form ITL.ConnectDB\n" + e.Message);
            }
        }

        public SqlCommand ConnectToTable(String table)
        {
            String queryStr = "Select * from " + table;
            SqlCommand sqlcmd = new SqlCommand(queryStr, this.sqlcon);
            try
            {
                sqlcmd.Connection.Open();
                Console.WriteLine("Connected to \'"+table+"\' Table");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error form ITL.ConnectToTable\n" + e.Message);
            }
            return sqlcmd;
        }
    }
}