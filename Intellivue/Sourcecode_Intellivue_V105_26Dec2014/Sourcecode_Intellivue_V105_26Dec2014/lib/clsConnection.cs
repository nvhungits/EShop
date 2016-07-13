using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace Sourcecode_Intellivue.lib
{
    public class clsConnection
    {
        public SqlConnection fsDatabaseConnection()
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DatabaseConnection"]);
            return conn;
        }
        public string fsReportServerConnection()
        {
            return System.Configuration.ConfigurationManager.AppSettings["ReportServer"];
        }
    }
}
