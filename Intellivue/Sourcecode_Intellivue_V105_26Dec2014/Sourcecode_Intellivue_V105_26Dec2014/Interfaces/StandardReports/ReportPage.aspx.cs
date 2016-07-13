using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
//using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Diagnostics;
//
using Sourcecode_Intellivue.lib;
using System.IO;
namespace Sourcecode_Intellivue.Interfaces.StandardReports
{
    partial class ReportPage : CoreClass
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string[] ParameterNames = Request.QueryString["ParameterNames"].Split("~".ToCharArray());
                string[] ParameterValues = Request.QueryString["ParameterValues"].Split("~".ToCharArray());
                string KeyName = Request.QueryString["KeyName"];

                Microsoft.Reporting.WebForms.ReportParameter[] Param = new Microsoft.Reporting.WebForms.ReportParameter[ParameterNames.Length];


                try
                {
                    for (int i = 0; i <= ParameterNames.Length - 1; i++)
                    {
                        //Response.Write("Param name \"" + ParameterNames[i] + "\" = \"" + ParameterValues[i] + "\"<br />");
                        Param[i] = new Microsoft.Reporting.WebForms.ReportParameter(ParameterNames[i], ParameterValues[i].Replace("%", "&"));
                        //Response.Write("Param \"" + Param[i].Name + "\" = \"" + Param[i].Values[0] + "\"<br /><br />");                        
                    }

                    //Response.Write("Key = " + KeyName);
                    //Me.ReportViewer1.ServerReport.ReportServerUrl = New Uri(System.Configuration.ConfigurationManager.AppSettings("ReportServer"))

                    //string 

                    string report_path = Directory.GetParent(Server.MapPath("/")).FullName;
                    //Response.Write(report_path + "<br />");

                    string report_path_value = System.Configuration.ConfigurationManager.AppSettings[KeyName];
                    report_path += report_path_value;
                    report_path = report_path.Replace("\\", "/");
                    report_path = "file:///"+report_path;
                    //Response.Write(report_path + "<br /><br />");

                    this.ReportViewer1.ServerReport.ReportServerUrl = new Uri(fsReportServerConnection());
                    this.ReportViewer1.ServerReport.ReportPath = report_path_value;
                    this.ReportViewer1.ShowParameterPrompts = false;

                    //Response.Write(Directory.GetParent(Server.MapPath("/")).FullName + "<br />");


                    this.ReportViewer1.ServerReport.SetParameters(Param);

                }
                catch (Exception ex)
                {
                    Response.Write(ex.StackTrace);
                }

            }
        }
        //public Interfaces_Standard_Reports_ReportPage()
        //{
        //    Load += Page_Load;
        //}
    }
}
