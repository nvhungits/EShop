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
    public class DatabaseClass
    {
        public SqlConnection dataConn;
        public SqlCommand dataComm;
        public SqlDataReader dataRead;
        public DataSet dataSet;
        public SqlDataAdapter dataAdapter;
        public String strConnectionString = System.Configuration.ConfigurationManager.AppSettings["DatabaseConnection"];
	    public DatabaseClass()
	    {
		    //
		    // TODO: Add constructor logic here
		    //
	    }

        public void New(string ConnectString) 
        {

	        //Initial connection string
	        //If ConnectString <> "" Then strConnectionString = ConnectString Else strDataString = System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionStringRead")
        }

        public void ConnectData()
        {
	        if (dataConn == null)
		        dataConn = new System.Data.SqlClient.SqlConnection();
	        if (dataConn.State == System.Data.ConnectionState.Closed) {
		        dataConn.ConnectionString = null;
		        dataConn.ConnectionString = strConnectionString;
		        dataConn.Open();
	        }

	        if (dataComm == null)
		        dataComm = new System.Data.SqlClient.SqlCommand();
	        dataComm.Connection = dataConn;
	        dataComm.CommandTimeout = 20;
	        dataComm.CommandType = CommandType.Text;
        }
        //Close Connection
        public void CloseData()
        {
            if ((dataRead != null))
	            dataRead.Close();
            if ((dataConn != null))
	            if (dataConn.State == ConnectionState.Open)
		            dataConn.Close();
            dataRead = null;
            dataConn = null;
        }

        //run ExecuteNonQuery (do not return value)
        public void ExeNonQuery(string strQuery)
        {
            if (dataConn == null)
	            ConnectData();
            dataComm.CommandText = strQuery;
            dataComm.ExecuteNonQuery();
        }

        //Run ExecuteReader 
        public void ExeReader(string strQuery)
        {
            if (dataConn == null)
	            ConnectData();
            if ((dataRead != null))
	            dataRead.Close();
            dataComm.CommandText = strQuery;
            dataRead = dataComm.ExecuteReader();
        }

        //run ExecuteScalar
        public object ExeScalar(string strQuery)
        {
            if (dataConn == null)
	            ConnectData();
            if ((dataRead != null))
	            dataRead.Close();
            dataComm.CommandText = strQuery;
            return dataComm.ExecuteScalar();
        }

        public System.Data.DataSet ExeDataset(string strQuery)
        {
            if (dataConn == null)
	            ConnectData();
            dataAdapter = new System.Data.SqlClient.SqlDataAdapter();
            dataAdapter.SelectCommand = dataComm;
            dataSet = new System.Data.DataSet();
            dataComm.CommandText = strQuery;
            try {
	            dataAdapter.Fill(dataSet, "");
	            return dataSet;
            } catch (Exception ex) {
	            CloseData();
	            return null;
            }
        }
    }
}
