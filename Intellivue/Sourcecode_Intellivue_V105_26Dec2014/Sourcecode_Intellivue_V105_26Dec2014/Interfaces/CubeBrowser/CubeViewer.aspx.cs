using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
//
//using Microsoft.VisualBasic;
//using System;
//using System.Collections;
using System.Collections.Generic;
//using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using DevExpress.Utils;
//
using Sourcecode_Intellivue.lib;

namespace Sourcecode_Intellivue.Interfaces
{
    

    public partial class CubeViewer : System.Web.UI.Page
    {

        string userId_edit = "";
        string user_name = "";
        string user_role = "";
        OLAPClass Olap = new OLAPClass("");
        SqlConnection connect = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.Culture = "en-AU";
            user_role = (string)Session["role"];

            if (Session["role"] == null)
            {
                Response.Redirect("~/Default.aspx");

            }
            else if (user_role == "Admin")
            {
                //userId_edit = Session("userId_edit")



            }
            else
            {
                string accessright = GlobalClass.GetAccessRight("C2");
                if (accessright == "F")
                {
                    string strscript = "<script>alert('You are not authorization for this page!');window.location.href='../pgHomePage.aspx'</script>";
                    if (!ClientScript.IsClientScriptBlockRegistered("clientscript"))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "clientscript", strscript);
                    }
                }
                userId_edit = Session["userId"].ToString();


            }
            //Set connection for ASPPivotGrid
            ASPxPivotGrid1.OLAPConnectionString = Olap.OLAPConnectionString + ";cube name='Sales Month';";
            //
            if (!Page.IsPostBack)
            {
                loadCubeName();
            }

        }
        protected void btnLoadCube_Click(object sender, System.EventArgs e)
        {
            string str = "";
            try
            {
                string FILE_NAME = ddlCubeName.SelectedValue;

                System.IO.StreamReader objReader = new System.IO.StreamReader(FILE_NAME);

                str = objReader.ReadToEnd();

                objReader.Close();
            }
            catch
            {
                str = "Could not read the file";
            }
            ASPxPivotGrid1.Visible = true;

            ASPxPivotGrid1.LoadLayoutFromString(str);
        }

        protected void buttonSaveAs_Click(object sender, System.EventArgs e)
        {
            Export(true);
        }

        protected void buttonOpen_Click(object sender, System.EventArgs e)
        {
            Export(false);
        }

        private void loadCubeName()
        {
            try
            {
                string commandstring = "Select * from tblCubeManagement";
                SqlCommand cmd = new SqlCommand(commandstring, connect);

                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ddlCubeName.Items.Add(new ListItem(reader[1].ToString(), reader[2].ToString()));

                }
                reader.Close();
                connect.Close();

            }
            catch (Exception ex)
            {
            }
        }

        private void Export(bool saveAs)
        {
            ASPxPivotGridExporter1.OptionsPrint.PrintHeadersOnEveryPage = checkPrintHeadersOnEveryPage.Checked;
            if (checkPrintFilterHeaders.Checked)
            {
                ASPxPivotGridExporter1.OptionsPrint.PrintFilterHeaders = DefaultBoolean.True;
            }
            else
            {
                ASPxPivotGridExporter1.OptionsPrint.PrintFilterHeaders = DefaultBoolean.False;
            }
            if (checkPrintColumnHeaders.Checked)
            {
                ASPxPivotGridExporter1.OptionsPrint.PrintColumnHeaders = DefaultBoolean.True;
            }
            else
            {
                ASPxPivotGridExporter1.OptionsPrint.PrintColumnHeaders = DefaultBoolean.False;
            }
            if (checkPrintRowHeaders.Checked)
            {
                ASPxPivotGridExporter1.OptionsPrint.PrintRowHeaders = DefaultBoolean.True;
            }
            else
            {
                ASPxPivotGridExporter1.OptionsPrint.PrintRowHeaders = DefaultBoolean.False;
            }
            if (checkPrintDataHeaders.Checked)
            {
                ASPxPivotGridExporter1.OptionsPrint.PrintDataHeaders = DefaultBoolean.True;
            }
            else
            {
                ASPxPivotGridExporter1.OptionsPrint.PrintDataHeaders = DefaultBoolean.False;
            }

            string fileName = "PivotGrid";
            switch (listExportFormat.SelectedIndex)
            {
                case 0:
                    ASPxPivotGridExporter1.ExportPdfToResponse(fileName, saveAs);
                    break;
                case 1:
                    ASPxPivotGridExporter1.ExportXlsToResponse(fileName, saveAs);
                    break;
                case 2:
                    ASPxPivotGridExporter1.ExportMhtToResponse(fileName, "utf-8", "ASPxPivotGrid Printing Sample", true, saveAs);
                    break;
                case 3:
                    ASPxPivotGridExporter1.ExportRtfToResponse(fileName, saveAs);
                    break;
                case 4:
                    ASPxPivotGridExporter1.ExportTextToResponse(fileName, saveAs);
                    break;
                case 5:
                    ASPxPivotGridExporter1.ExportHtmlToResponse(fileName, "utf-8", "ASPxPivotGrid Printing Sample", true, saveAs);
                    break;
                case 6:
                    ASPxPivotGridExporter1.ExportCsvToResponse(fileName, saveAs);
                    break;
            }


        }

        //public Interfaces_CubeBrowser_CubeViewer()
        //{
        //    Load += Page_Load;
        //}
    }
}
