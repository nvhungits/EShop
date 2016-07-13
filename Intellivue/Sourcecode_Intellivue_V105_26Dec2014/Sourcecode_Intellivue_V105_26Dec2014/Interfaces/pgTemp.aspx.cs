using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using System.Data;
using System.Diagnostics;
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

// =  WRITTEN BY VO TAN PHONG. LASTEST MODIFIED 05 OCT 2006                   = '


namespace Sourcecode_Intellivue.Interfaces
{
    
    partial class pgTemp : System.Web.UI.Page
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Session["username"].ToString().ToLower() != "intellivue")
            {
                Response.Redirect("~/Default.aspx");
            }
            else if (Request.QueryString["red"] == "1")
            {
                Response.Redirect("~/Interfaces/pgUnderConstruction.aspx");
            }
            else if (Request.QueryString["red"] == "2")
            {
                Response.Redirect("~/Interfaces/Dashboard/AjaxManageDashboard.aspx");
            }
            else if (Request.QueryString["red"] == "3")
            {
                Response.Redirect("~/Interfaces/pgUnderConstruction.aspx");
            }
            else if (Request.QueryString["red"] == "4")
            {
                Response.Redirect("~/Interfaces/pgUnderConstruction.aspx");
            }
            else if (Request.QueryString["red"] == "5")
            {
                Response.Redirect("~/Interfaces/pgUnderConstruction.aspx");
            }
            else if (Request.QueryString["red"] == "6")
            {
                Response.Redirect("~/Interfaces/pgUnderConstruction.aspx");
            }
            else if (Request.QueryString["red"] == "7")
            {
                Response.Redirect("~/Interfaces/pgUnderConstruction.aspx");
            }
            else if (Request.QueryString["red"] == "8")
            {
                Response.Redirect("~/Interfaces/Dashboard/pgViewDashboard.aspx");
            }
            else if (Request.QueryString["red"] == "9")
            {
                Response.Redirect("~/Interfaces/Standard Reports/AdviserFumReport.aspx");
            }
            else if (Request.QueryString["red"] == "10")
            {
                Response.Redirect("~/Interfaces/Standard Reports/AdviserInflowReport.aspx");
            }
            else if (Request.QueryString["red"] == "11")
            {
                Response.Redirect("~/Interfaces/Standard Reports/AdviserNetflowReport.aspx");
            }
            else if (Request.QueryString["red"] == "12")
            {
                Response.Redirect("~/Interfaces/Standard Reports/AdviserOutflowReport.aspx");
            }
            else if (Request.QueryString["red"] == "13")
            {
                Response.Redirect("~/Interfaces/Standard Reports/FumReport.aspx");
            }
            else if (Request.QueryString["red"] == "14")
            {
                Response.Redirect("~/Interfaces/Standard Reports/FundsFlowByAccountReport.aspx");
            }
            else if (Request.QueryString["red"] == "15")
            {
                Response.Redirect("~/Interfaces/Standard Reports/FundsFlowByProduct.aspx");
            }
            else if (Request.QueryString["red"] == "16")
            {
                Response.Redirect("~/Interfaces/Standard Reports/InvestmentOptionTransactionReport.aspx");
            }
            else if (Request.QueryString["red"] == "17")
            {
                Response.Redirect("~/Interfaces/Standard Reports/InvestorSummary.aspx");
            }
            else if (Request.QueryString["red"] == "18")
            {
                Response.Redirect("~/Interfaces/pgUnderConstruction.aspx");
            }
            else if (Request.QueryString["red"] == "19")
            {
                Response.Redirect("~/Interfaces/pgUnderConstruction.aspx");
            }
            else if (Request.QueryString["red"] == "20")
            {
                Response.Redirect("~/Interfaces/pgUnderConstruction.aspx");
            }
            else if (Request.QueryString["red"] == "21")
            {
                Response.Redirect("~/Interfaces/Analysis Service/AdviserWeek.aspx");
            }
            else if (Request.QueryString["red"] == "22")
            {
                Response.Redirect("~/Interfaces/Analysis Service/AdviserMonth.aspx");
            }
            else if (Request.QueryString["red"] == "23")
            {
                Response.Redirect("~/Interfaces/Analysis Service/FumByProductByDate.aspx");
            }
            else if (Request.QueryString["red"] == "24")
            {
                Response.Redirect("~/Interfaces/pgUnderConstruction.aspx");
            }
            else if (Request.QueryString["red"] == "25")
            {
                Response.Redirect("~/Interfaces/pgUnderConstruction.aspx");
            }
            else if (Request.QueryString["red"] == "26")
            {
                Response.Redirect("~/Interfaces/pgUnderConstruction.aspx");
            }
            else if (Request.QueryString["red"] == "27")
            {
                Response.Redirect("~/Interfaces/pgUnderConstruction.aspx");
            }
            else if (Request.QueryString["red"] == "28")
            {
                Response.Redirect("~/Interfaces/System Config/pgInterfaceConfig.aspx");
            }
            else if (Request.QueryString["red"] == "29")
            {
                Response.Redirect("~/Interfaces/pgUnderConstruction.aspx");
            }
            else if (Request.QueryString["red"] == "30")
            {
                Response.Redirect("~/Interfaces/pgUnderConstruction.aspx");
            }
            else if (Request.QueryString["red"] == "31")
            {
                Response.Redirect("~/Interfaces/Analysis Service/FumByDateByProduct.aspx");
            }
        }
        //public Interfaces_Dashboard_pgTemp()
        //{
        //    Load += Page_Load;
        //}
    }
}
