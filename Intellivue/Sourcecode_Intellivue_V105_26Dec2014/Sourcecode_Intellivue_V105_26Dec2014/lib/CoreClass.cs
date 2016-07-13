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
    public class CoreClass : System.Web.UI.Page
    {
        public  DatabaseClass objData=new DatabaseClass();
        public OLAPClass objOLAPData=new OLAPClass("");
        public  object FieldCheck(object sData)
        {
            object functionReturnValue = null;
            if (sData==DBNull.Value)
                functionReturnValue = "Null";
            else
                if (sData.ToString().Trim()=="")
                    functionReturnValue = "Null";
                else
                    functionReturnValue = "'" + sData.ToString().Trim().Replace("'", "''") + "'";
            return functionReturnValue;
        }

        public  object ValueCheck(object sData)
        {
            object functionReturnValue = null;
            if (sData == DBNull.Value)
                functionReturnValue = "Null";
            else
                if (checkNumeric(sData.ToString().Trim()))
                    functionReturnValue = sData.ToString().Trim().Replace( ",", "");
                else
                    functionReturnValue = "Null";
            return functionReturnValue;
        }

        public  bool checkNumeric(string text)
        {
            double test;
            return double.TryParse(text, out test);
        }
        public  void LoadCurrentDate(System.Web.UI.HtmlControls.HtmlInputText obj)
        {
            string d = "";
            string m = "";
            string y = "";
            System.DateTime dt = default(System.DateTime);

            dt = DateTime.Now;

            //Get day
            if (dt.Day < 10)
            {
                d = "0" + dt.Day.ToString();
            }
            else
            {
                d = dt.Day.ToString();
            }

            //Get month
            if (dt.Month < 10)
            {
                m = "0" + dt.Month.ToString();
            }
            else
            {
                m = dt.Month.ToString();
            }

            //Get year
            y = dt.Year.ToString();

            //Initial the textbox
            obj.Value = d + "/" + m + "/" + y;
        }
        public  void LoadCombobox(string sql, System.Web.UI.HtmlControls.HtmlSelect obj)
        {
            ListItem item = default(ListItem);
            try
            {
                objData.ConnectData();
                objData.ExeReader(sql);
                obj.Items.Clear();
                while (objData.dataRead.Read())
                {
                    item = new ListItem(objData.dataRead.GetString(0), objData.dataRead.GetValue(1).ToString());
                    obj.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message)
                ASPNET_MessageBox(ex.Message);
            }
            finally
            {
                objData.CloseData();
            }
        }
        public  string GetMonthName(string num)
        {
            string functionReturnValue = null;

            if (num == "1")
            {
                functionReturnValue = "January";
            }
            else if (num == "2")
            {
                functionReturnValue = "February";
            }
            else if (num == "3")
            {
                functionReturnValue = "March";
            }
            else if (num == "4")
            {
                functionReturnValue = "April";
            }
            else if (num == "5")
            {
                functionReturnValue = "May";
            }
            else if (num == "6")
            {
                functionReturnValue = "June";
            }
            else if (num == "7")
            {
                functionReturnValue = "July";
            }
            else if (num == "8")
            {
                functionReturnValue = "August";
            }
            else if (num == "9")
            {
                functionReturnValue = "September";
            }
            else if (num == "10")
            {
                functionReturnValue = "October";
            }
            else if (num == "11")
            {
                functionReturnValue = "November";
            }
            else if (num == "12")
            {
                functionReturnValue = "December";
            }
            else
            {
                functionReturnValue = num;
            }
            return functionReturnValue;
        }

        public  void ASPNET_MessageBox(string str)
        {
            System.Web.HttpContext.Current.Response.Write("<script language=\"javascript\">");
            System.Web.HttpContext.Current.Response.Write("       window.alert('" + str + "');");
            System.Web.HttpContext.Current.Response.Write("     history.back(-1)");
            System.Web.HttpContext.Current.Response.Write("</script>");
        }
        public  void CheckDatetime(string dt, string errorMessage)
        {
            try
            {
                System.DateTime.Parse(dt);
            }
            catch (Exception ex)
            {
                ASPNET_MessageBox(errorMessage);
            }
        }
        public  void CheckDate(string dt, string errorMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(dt))
                {
                    System.DateTime.Parse(dt);
                }
            }
            catch (Exception ex)
            {
                ASPNET_MessageBox(errorMessage);
            }
        }
        public  string fsReportServerConnection()
        {
            return System.Configuration.ConfigurationManager.AppSettings["ReportServer"];
        }

        public  SqlConnection fsDatabaseConnection()
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DatabaseConnection"]);
            return conn;
        }
    }

}
