﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ITL_v2.Models
{
    public class ConnectionSQL
    {
        public String conStr { set; get; }
        public SqlConnection sqlcon { set; get; }
        public String queryStr { set; get; }
        public SqlCommand sqlcmd { set; get; }
        public SqlDataReader sqlr { set; get; }
        public ConnectionSQL(String DB, String Table)
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