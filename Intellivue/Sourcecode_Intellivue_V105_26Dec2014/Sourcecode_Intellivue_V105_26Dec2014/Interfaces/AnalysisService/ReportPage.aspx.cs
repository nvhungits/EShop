//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace Sourcecode_Intellivue.Interfaces.AnalysisService
//{
//    public partial class ReportPage : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {
           
//        }
//    }
//}
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
//
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sourcecode_Intellivue.lib;
using Microsoft.Reporting.WebForms;
namespace Sourcecode_Intellivue.Interfaces.AnalysisService
{
    public partial class ReportPage : CoreClass
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string[] ParameterNames = Request.QueryString["ParameterNames"].Split("~".ToCharArray());
                string[] ParameterValues = Request.QueryString["ParameterValues"].Split("~".ToCharArray());
                string KeyName = Request.QueryString["KeyName"];

                ReportParameter[] Param = new ReportParameter[ParameterNames.Length];
                

                try
                {
                    for (int i = 0; i <= ParameterNames.Length - 1; i++)
                    {
                        Param[i] = new Microsoft.Reporting.WebForms.ReportParameter(ParameterNames[i], ParameterValues[i].Replace("%", "&"));
                    }

                    //Me.ReportViewer1.ServerReport.ReportServerUrl = New Uri(System.Configuration.ConfigurationManager.AppSettings("ReportServer"))
                    this.ReportViewer1.ServerReport.ReportServerUrl = new Uri(fsReportServerConnection());
                    this.ReportViewer1.ServerReport.ReportPath = System.Configuration.ConfigurationManager.AppSettings[KeyName];
                    this.ReportViewer1.ShowParameterPrompts = false;

                    this.ReportViewer1.ServerReport.SetParameters(Param);
                    //ReportViewer1.ServerReport.DataBind();
                }
                catch (Exception ex)
                {
                    ASPNET_MessageBox(ex.Message);
                }

            }
        }
        //public Interfaces_Analysis_Service_ReportPage()
        //{
        //    Load += Page_Load;
        //}
    }
}