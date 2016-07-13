
// ============================================================================ '
// =         Copyright (c) 2006. MMSOFT Co., Ltd. All Rights Reserved.        = '
// =                                                                          = '
// =  Permission to use, copy, modify, and distribute this software and its   = '
// =  documentation for any purpose, without fee, and without a written       = '
// =  agreement, is here by granted, provided that the above copyright notice,= '
// =  this paragraph and the following two paragraphs appear in all copies,   = '
// =  modifications, and distributions.  Created by:                          = '
// =                                                                          = '
// =                        M.M..S.O.F.T.W.A.R.E                              = '
// =                                                                          = '
// =  MM Software Co., Ltd, 35 Tan Vinh Street, Ward 4                        = '
// =  District 4, Ho Chi Minh City, Viet Nam.                                 = '
// =  For technical information, contact mmsoftvn@gmail.com                   = '
// =                                                                          = '
// =  IN NO EVENT SHALL REGENTS BE LIABLE TO ANY PARTY FOR DIRECT, INDIRECT,  = '
// =  SPECIAL, INCIDENTAL, OR CONSEQUENTIAL DAMAGES, INCLUDING LOST PROFITS,  = '
// =  ARISING OUT OF THE USE OF THIS SOFTWARE AND ITS DOCUMENTATION, EVEN IF  = '
// =  REGENTS HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.             = '
// =                                                                          = '
// =  REGENTS SPECIFICALLY DISCLAIMS ANY WARRANTIES, INCLUDING, BUT NOT       = '
// =  LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A = '
// =  PARTICULAR PURPOSE. THE SOFTWARE AND ACCOMPANYING DOCUMENTATION, IF     = '
// =  ANY, PROVIDED HEREUNDER IS PROVIDED "AS IS". REGENTS HAS NO OBLIGATION  = '
// =  TO PROVIDE MAINTENANCE, SUPPORT, UPDATES, ENHANCEMENTS, OR              = '
// =  MODIFICATIONS.                                                          = '
// ============================================================================ '
// Convert to C# version by VMCuong , 17/12/2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using Microsoft.VisualBasic;
//using System;
using System.Collections;
//using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
//
using Sourcecode_Intellivue.lib;
using Microsoft.Reporting.WebForms;
namespace Sourcecode_Intellivue.Interfaces.StandardReports
{
   
    partial class InvestorSummary : CoreClass
    {
        ReportParameter[] Param = new ReportParameter[5];
        GlobalClass an;
        string userId_edit = "";
        string username_edit = "";
        string user_edit_command = "";
        string user_name = "";

        string user_role = "";
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //If Session("username").ToString().ToLower() = "intellivue" Then
            //Change the Culture to Australia (for displaying datetime)
            this.Culture = "en-AU";
            user_role = (string)Session["role"];
            if (Session["role"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else if (user_role == "Admin")
            {
                userId_edit = (string)Session["userId_edit"];
                user_edit_command = (string)Session["user_info_command"];
                username_edit = (string)Session["username_edit"];
                Initial();
            }
            else
            {
                string accessright = GlobalClass.GetAccessRight("R9");
                if (accessright == "F")
                {
                    string strscript = "<script>alert('You are not authorization for this page!');window.location.href='../pgHomePage.aspx'</script>";
                    if (!ClientScript.IsClientScriptBlockRegistered("clientscript"))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "clientscript", strscript);
                    }
                }
                userId_edit = (string)Session["userId"];
                user_edit_command = "edit";
                username_edit = (string)Session["username"];

            }
        }

        protected void Page_Unload(object sender, System.EventArgs e)
        {
            this.objData.CloseData();
        }
        //Load Product for combobox
        private void LoadProduct()
        {
            string sql = "EXEC sp_getAllProduct";
            this.LoadCombobox(sql, this.InvestmentOption);
        }
        //Initial for the first loading page
        private void Initial()
        {
            this.LoadCurrentDate(this.MyDate);
            this.LoadProduct();
        }

        //This function used to load data again
        //Because of loosing state
        private void SecondInitial()
        {
            this.CheckDatetime(Request.Form["Date"], "Wrong date input!");
            loadReportViewer();
        }

        //This function used to load the Report
        //Based on Request Input
        private void loadReportViewer()
        {
            try
            {
                //*****Need to change UserID*******
                Param[0] = new ReportParameter("UserID", Session["username"].ToString().ToUpper());


                Param[1] = new ReportParameter("InvestmentOption", Request.Form["InvestmentOption"]);
                Param[2] = new ReportParameter("UnitPriceType", Request.Form["UnitPriceType"]);
                Param[3] = new ReportParameter("Date", Request.Form["Date"]);
                Param[4] = new ReportParameter("GroupBy", Request.Form["GroupBy"]);





                //Me.ReportViewer1.ServerReport.ReportServerUrl = New Uri(System.Configuration.ConfigurationManager.AppSettings("ReportServer"))
                //Me.ReportViewer1.ServerReport.ReportServerUrl = New Uri(fsReportServerConnection())
                // Me.ReportViewer1.ServerReport.ReportPath = System.Configuration.ConfigurationManager.AppSettings("InvestorSummary")
                // Me.ReportViewer1.ShowParameterPrompts = False
                //Me.ReportViewer1.ServerReport.SetParameters(Param)
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message)
                ASPNET_MessageBox(ex.Message);
            }

        }
        //public Interfaces_Standard_Reports_InvestorSummary()
        //{
        //    Unload += Page_Unload;
        //    Load += Page_Load;
        //}
    }
}
