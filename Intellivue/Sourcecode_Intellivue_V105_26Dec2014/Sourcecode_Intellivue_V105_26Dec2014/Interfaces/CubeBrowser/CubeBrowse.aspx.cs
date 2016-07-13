using System;
using System.Web.UI;
using DevExpress.Utils;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.XtraCharts;
using System.Collections.Generic;
using DevExpress.XtraPrinting;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraPrintingLinks;
using System.IO;
using System.Drawing;
using Microsoft.Win32;
using Microsoft.VisualBasic;
using DevExpress.XtraPivotGrid.Localization;
using System.Data.SqlClient;
using Sourcecode_Intellivue.lib;

namespace Sourcecode_Intellivue.Interfaces.CubeBrowser
{
    public partial class CubeBrowse : System.Web.UI.Page
    {
        string userId_edit = "";
        string user_name = "";
        string user_role = "";
        OLAPClass Olap = new OLAPClass("");
        SqlConnection connect = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session == null)
                {
                    Response.Redirect("~/Default.aspx");
                }

                if (Session["role"].ToString() == null)
                {
                    Response.Redirect("~/Default.aspx");

                }
                else if (Session["role"].ToString() == "Admin")
                {
                    //userId_edit = Session("userId_edit")
                    user_role = Session["role"].ToString();



                }
                else
                {
                    string accessright = GlobalClass.GetAccessRight("C1");
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
            }
            catch(Exception ex)
            {
            }
            //Set Connection String for PivotGrid
            //OLAPConnectionString="provider=MSOLAP;data source=Toan-PC;initial catalog=SSAS_DW;cube name=&quot;Sales Month&quot;" 
            ASPxPivotGrid1.OLAPConnectionString = Olap.OLAPConnectionString+";cube name='Sales Month';";
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

        protected void buttonSaveAs_Click(object sender, EventArgs e)
        {
            Export(true);
        }

        protected void buttonOpen_Click(object sender, EventArgs e)
        {
            Export(false);
        }

        protected void btnSaveCubeTemplate_Click(object sender, EventArgs e)
        {
            string cubeName = txtCubeName.Text + ".txt";


            string str = ASPxPivotGrid1.SaveLayoutToString();

            string FILE_NAME = "C:/" + cubeName;

            if ((!string.IsNullOrEmpty(cubeName.Trim())))
            {
                lblError.Visible = false;
                if ((checkExistDb(FILE_NAME)))
                {

                    if (System.IO.File.Exists(FILE_NAME) == true)
                    {
                        System.IO.StreamWriter objWriter = new System.IO.StreamWriter(FILE_NAME);

                        objWriter.Write(str);
                        objWriter.Close();


                    }
                    else
                    {
                        StreamWriter sw = File.CreateText(FILE_NAME);

                        sw.Write(str);
                        sw.Flush();
                        sw.Close();

                    }
                    saveFilePathToDB(txtCubeName.Text, FILE_NAME);
                }
                else
                {
                    lblError.Text = "Cube Name Already Exist.";
                    lblError.Visible = true;
                    lblError.ForeColor = Color.Red;
                }
            }
            else
            {
                lblError.Text = "Please enter Cube Name.";
                lblError.Visible = true;
                lblError.ForeColor = Color.Red;
            }
        }

        private void saveFilePathToDB(string cubeName, string filePath)
        {
            try
            {
                string commandstring = "Insert Into tblCubeManagement(CubeName,CubePath) Values ('" + cubeName + "','" + filePath + "')";
                SqlCommand cmd = new SqlCommand(commandstring, connect);

                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();

            }
            catch (Exception ex)
            {
            }

        }
        private bool checkExistDb(string filename)
        {
            try
            {
                string commandstring = "select * from tblCubeManagement where CubePath ='" + filename + "'";
                SqlCommand cmd = new SqlCommand(commandstring, connect);

                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    connect.Close();
                    return false;
                }
                connect.Close();

            }
            catch (Exception ex)
            {
            }

            return true;
        }

        protected void ASPxPivotGrid1_FieldAreaChanged(object sender, PivotFieldEventArgs e)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "Script", "trythis();", true);
        }







    }
}
