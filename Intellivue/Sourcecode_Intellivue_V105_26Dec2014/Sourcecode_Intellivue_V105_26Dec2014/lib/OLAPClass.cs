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
using Microsoft.AnalysisServices.AdomdClient;

namespace Sourcecode_Intellivue.lib
{
    public class OLAPClass
    {
        public string OLAPConnectionString = System.Configuration.ConfigurationManager.AppSettings["OLAPConnectionString"];
        public AdomdConnection OLAPConn;
        public AdomdCommand OLAPDataComm;

        public AdomdDataReader OLAPDataRead;

        //Initial Object
        public OLAPClass(string connectString ) 
        {
	        //Initial connection string
	        if (connectString != "")
		        OLAPConnectionString = connectString;
	        else
		        OLAPConnectionString = System.Configuration.ConfigurationManager.AppSettings["OLAPConnectionString"];
        }

        //Open OLAP Connection
        public void OLAPConnectData()
        {
	        if (OLAPConn == null)
		        OLAPConn = new AdomdConnection();
	        if (OLAPConn.State == ConnectionState.Closed) {
		        OLAPConn.ConnectionString = OLAPConnectionString;
		        OLAPConn.Open();
	        }

	        if (OLAPDataComm == null)
		        OLAPDataComm = new AdomdCommand();
	        OLAPDataComm.Connection = OLAPConn;
	        OLAPDataComm.CommandTimeout = 20;
	        OLAPDataComm.CommandType = CommandType.Text;
        }

        //Close OLAP Connection
        public void OLAPCloseData()
        {
	        if ((OLAPConn != null))
		        if (OLAPConn.State == ConnectionState.Open)
			        OLAPConn.Close();
	        OLAPConn = null;
        }

        //Run OLAP ExecuteReader 
        public void ExeReader(string strQuery)
        {
	        if (OLAPConn == null)
		        OLAPConnectData();
	        if ((OLAPDataRead != null))
		        OLAPDataRead.Close();
	        OLAPDataComm.CommandText = strQuery;
	        OLAPDataRead = OLAPDataComm.ExecuteReader();
        }
    }
}
