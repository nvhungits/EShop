//c# version converted by Vo Manh Cuong, 15/12/2014
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
//
using Sourcecode_Intellivue.lib;
//
using System.Web.UI.WebControls;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.Reporting.WebForms;
namespace Sourcecode_Intellivue.Interfaces.AnalysisService
{
    partial class AdviserMonth : CoreClass
    {
        ReportParameter[] Param = new ReportParameter[6];
        string userId_edit = "";
        string username_edit = "";
        string user_edit_command = "";
        string user_name = "";

        string user_role = "";

        protected void Page_Load(object sender, System.EventArgs e)
        {

            this.Culture = "en-AU";
            user_role = Session["role"] != null ? Session["role"].ToString() : "";

            if (Session["role"] == null)
            {
                Response.Redirect("~/Default.aspx");

            }
            else if (user_role == "Admin")
            {
                userId_edit = Session["userId_edit"] != null ? Session["userId_edit"].ToString() : "";
                user_edit_command = Session["user_info_command"] != null ? Session["user_info_command"].ToString() : "";
                username_edit = Session["username_edit"] != null ? Session["username_edit"].ToString() : ""; //Session["username_edit"].ToString();
                if (!Page.IsPostBack)
                {
                    Initial();
                }

            }
            else
            {
                string accessright = GlobalClass.GetAccessRight("A2");
                if (accessright == "F")
                {
                    string strscript = "<script>alert('You are not authorization for this page!');window.location.href='../pgHomePage.aspx'</script>";
                    if (!ClientScript.IsClientScriptBlockRegistered("clientscript"))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "clientscript", strscript);
                    }
                }
                userId_edit = Session["userId"].ToString();
                user_edit_command = "edit";
                username_edit = Session["username"].ToString();

            }

            this.MaintainScrollPositionOnPostBack = true;
        }

        protected void Page_Unload(object sender, System.EventArgs e)
        {
            this.objOLAPData.OLAPCloseData();
        }

        private void Initial()
        {
            string kpiCategory = "";
            LoadCategory();
            //initial default Category: FUM
            try
            {
                kpiCategory = "[KPI].[KPI Category Name].&[" + this.Category.Items[this.Category.SelectedIndex].ToString() + "]";
            }
            catch (Exception ex)
            {
                ASPNET_MessageBox(ex.Message);
            }
            LoadKPI(kpiCategory, "");
            LoadProduct();
            LoadInvestmentOption("", "");
            LoadYear();
            LoadMonth("");
        }

        private void SecondInitial()
        {
            LoadKPI(Request.Form["Category"], Request.Form["KPI"]);
            LoadInvestmentOption(Request.Form["Product"], Request.Form["InvestmentOption"]);
            LoadMonth(Request.Form["Month"]);
        }

        private void LoadCategory()
        {
            ListItem item = default(ListItem);
            string mdx = "WITH ";
            mdx = mdx + "MEMBER [Measures].[ParameterCaption] AS '[KPI].[KPI Category Name].CURRENTMEMBER.MEMBER_CAPTION' ";
            mdx = mdx + "MEMBER [Measures].[ParameterValue] AS '[KPI].[KPI Category Name].CURRENTMEMBER.UNIQUENAME' ";
            mdx = mdx + "MEMBER [Measures].[ParameterLevel] AS '[KPI].[KPI Category Name].CURRENTMEMBER.LEVEL.ORDINAL' ";
            mdx = mdx + " SELECT {[Measures].[ParameterCaption], [Measures].[ParameterValue], [Measures].[ParameterLevel]} ON COLUMNS, ";
            mdx = mdx + " Filter([KPI].[KPI Category Name].ALLMEMBERS,[KPI].[KPI Category Name].CURRENTMEMBER.LEVEL.ORDINAL>0) ON ROWS";
            mdx = mdx + " FROM [SALES MONTH]";
            try
            {
                this.objOLAPData.OLAPConnectData();
                //Response.Write(mdx)
                this.objOLAPData.ExeReader(mdx);
                this.Category.Items.Clear();
                while (this.objOLAPData.OLAPDataRead.Read())
                {
                    item = new ListItem(this.objOLAPData.OLAPDataRead.GetString(0), this.objOLAPData.OLAPDataRead.GetValue(2).ToString());
                    this.Category.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                ASPNET_MessageBox(ex.Message);

            }
            finally
            {
                this.objOLAPData.OLAPCloseData();
            }
        }

        private void LoadProduct()
        {
            ListItem item = default(ListItem);
            string mdx = "WITH ";
            mdx = mdx + "MEMBER [Measures].[ParameterCaption] AS '[Product].[Source Parent Product Name].CURRENTMEMBER.NAME' ";
            mdx = mdx + "MEMBER [Measures].[ParameterValue] AS '[Product].[Source Parent Product Name].CURRENTMEMBER.UNIQUENAME' ";
            mdx = mdx + "MEMBER [Measures].[ParameterLevel] AS '[Product].[Source Parent Product Name].CURRENTMEMBER.LEVEL.ORDINAL' ";
            mdx = mdx + " SELECT {[Measures].[ParameterCaption], [Measures].[ParameterValue], [Measures].[ParameterLevel]} ON COLUMNS , ";
            mdx = mdx + " [Product].[Source Parent Product Name].ALLMEMBERS ";
            mdx = mdx + " HAVING ( [Measures].[ParameterCaption] <> \"\" )";
            mdx = mdx + " ON ROWS FROM [SALES MONTH] ";
            mdx = mdx + " WHERE [Product].[Product Group].&[O]";
            // Response.Write(mdx)
            try
            {
                this.objOLAPData.OLAPConnectData();
                //Response.Write(mdx)
                this.objOLAPData.ExeReader(mdx);
                this.Product.Items.Clear();
                while (this.objOLAPData.OLAPDataRead.Read())
                {
                    item = new ListItem(this.objOLAPData.OLAPDataRead.GetString(1), this.objOLAPData.OLAPDataRead.GetString(2));
                    this.Product.Items.Add(item);
                    //Response.Write(Me.objOLAPData.OLAPDataRead.GetString(4))
                }
            }
            catch (Exception ex)
            {
                ASPNET_MessageBox(ex.Message);
            }
            finally
            {
                this.objOLAPData.OLAPCloseData();
            }
        }



        private void LoadKPI(string CategoryStr, string KPIStr)//(string CategoryStr = "", string KPIStr = "")
        {
            ListItem item = default(ListItem);
            string mdx = "WITH ";
            mdx = mdx + "MEMBER [Measures].[ParameterCaption] AS '[KPI].[KPI Name].CURRENTMEMBER.MEMBER_CAPTION' ";
            mdx = mdx + "MEMBER [Measures].[ParameterValue] AS '[KPI].[KPI Name].CURRENTMEMBER.UNIQUENAME' ";
            mdx = mdx + "MEMBER [Measures].[ParameterLevel] AS '[KPI].[KPI Name].CURRENTMEMBER.LEVEL.ORDINAL' ";
            mdx = mdx + " SELECT {[Measures].[ParameterCaption], [Measures].[ParameterValue], [Measures].[ParameterLevel]} ON COLUMNS , ";
            mdx = mdx + " [KPI].[KPI Name].ALLMEMBERS ON ROWS";

            if (string.IsNullOrEmpty(CategoryStr))
            {
                mdx = mdx + " FROM [SALES MONTH] WHERE (StrToMember('[KPI].[KPI Category Name].&[FUM]',CONSTRAINED))";
            }
            else
            {
                mdx = mdx + " FROM [SALES MONTH] WHERE (StrToMember('" + CategoryStr + "',CONSTRAINED))";
            }

            try
            {
                this.objOLAPData.OLAPConnectData();
                //Response.Write(mdx)
                this.objOLAPData.ExeReader(mdx);
                this.KPI.Items.Clear();
                while (this.objOLAPData.OLAPDataRead.Read())
                {
                    item = new ListItem(this.objOLAPData.OLAPDataRead.GetString(1), this.objOLAPData.OLAPDataRead.GetValue(2).ToString());
                    this.KPI.Items.Add(item);
                }
                if (!string.IsNullOrEmpty(KPIStr))
                {
                    //Set SelectedIndex for the value before submitted
                    this.KPI.SelectedIndex = this.KPI.Items.IndexOf(this.KPI.Items.FindByValue(KPIStr));
                }
            }
            catch (Exception ex)
            {
                ASPNET_MessageBox(ex.Message);
            }
            finally
            {
                this.objOLAPData.OLAPCloseData();
            }
        }

        private void LoadInvestmentOption(string ProductStr, string InvOptionStr)//(string ProductStr = "", string InvOptionStr = "")
        {
            ListItem item = default(ListItem);
            string mdx = "WITH ";
            mdx = mdx + "MEMBER [Measures].[ParameterCaption] AS '[Product].[Source Product Name].CURRENTMEMBER.MEMBER_CAPTION' ";
            mdx = mdx + "MEMBER [Measures].[ParameterValue] AS '[Product].[Source Product Name].CURRENTMEMBER.UNIQUENAME' ";
            mdx = mdx + "MEMBER [Measures].[ParameterLevel] AS '[Product].[Source Product Name].CURRENTMEMBER.LEVEL.ORDINAL' ";
            mdx = mdx + " SELECT {[Measures].[ParameterCaption], [Measures].[ParameterValue], [Measures].[ParameterLevel]} ON COLUMNS , ";
            mdx = mdx + " [Product].[Source Product Name].ALLMEMBERS ON ROWS";
            mdx = mdx + " FROM [SALES MONTH]";
            if (string.IsNullOrEmpty(ProductStr))
            {
                mdx = mdx + " WHERE ([Product].[Product Group].&[O])";
            }
            else
            {
                mdx = mdx + " WHERE ([Product].[Product Group].&[O],strtomember('" + ProductStr + "') )";
            }
            try
            {
                this.objOLAPData.OLAPConnectData();
                //Response.Write(mdx)
                this.objOLAPData.ExeReader(mdx);
                this.InvestmentOption.Items.Clear();
                while (this.objOLAPData.OLAPDataRead.Read())
                {
                    item = new ListItem(this.objOLAPData.OLAPDataRead.GetString(1), this.objOLAPData.OLAPDataRead.GetValue(2).ToString());
                    this.InvestmentOption.Items.Add(item);
                }

                if (!string.IsNullOrEmpty(InvOptionStr))
                {
                    //Set SelectedIndex for the value before submitted
                    this.InvestmentOption.SelectedIndex = this.InvestmentOption.Items.IndexOf(this.InvestmentOption.Items.FindByValue(InvOptionStr));
                }
            }
            catch (Exception ex)
            {
                ASPNET_MessageBox(ex.Message);
            }
            finally
            {
                this.objOLAPData.OLAPCloseData();
            }
        }



        private void LoadYear()
        {
            ListItem item = default(ListItem);
            string mdx = "WITH ";
            mdx = mdx + "MEMBER [Measures].[ParameterCaption] AS '[Month].[Year].CURRENTMEMBER.MEMBER_CAPTION' ";
            mdx = mdx + "MEMBER [Measures].[ParameterValue] AS '[Month].[Year].CURRENTMEMBER.UNIQUENAME' ";
            mdx = mdx + "MEMBER [Measures].[ParameterLevel] AS '[Month].[Year].CURRENTMEMBER.LEVEL.ORDINAL' ";
            mdx = mdx + " SELECT {[Measures].[ParameterCaption], [Measures].[ParameterValue], [Measures].[ParameterLevel]} ON COLUMNS , ";
            mdx = mdx + " [Month].[Year].ALLMEMBERS ";
            mdx = mdx + " HAVING([Measures].[ParameterLevel] <> 0)";

            mdx = mdx + "  ON ROWS";
            mdx = mdx + " FROM [SALES MONTH]";

            try
            {
                this.objOLAPData.OLAPConnectData();
                //Response.Write(mdx)
                this.objOLAPData.ExeReader(mdx);
                this.Year.Items.Clear();
                while (this.objOLAPData.OLAPDataRead.Read())
                {
                    item = new ListItem(this.objOLAPData.OLAPDataRead.GetString(0), this.objOLAPData.OLAPDataRead.GetValue(2).ToString());
                    this.Year.Items.Add(item);
                }

                //Choose the last year
                this.Year.SelectedIndex = this.Year.Items.Count - 1;
            }
            catch (Exception ex)
            {
                ASPNET_MessageBox(ex.Message);
            }
            finally
            {
                this.objOLAPData.OLAPCloseData();
            }
        }

        private void LoadMonth(string MonthStr)//(string MonthStr = "")
        {
            ListItem item = default(ListItem);
            string mdx = "WITH ";
            mdx = mdx + "MEMBER [Measures].[ParameterCaption] AS '[Month].[Month of Year].CURRENTMEMBER.MEMBER_CAPTION' ";
            mdx = mdx + "MEMBER [Measures].[ParameterValue] AS '[Month].[Month of Year].CURRENTMEMBER.UNIQUENAME' ";
            mdx = mdx + "MEMBER [Measures].[ParameterLevel] AS '[Month].[Month of Year].CURRENTMEMBER.LEVEL.ORDINAL' ";
            mdx = mdx + " SELECT {[Measures].[ParameterCaption], [Measures].[ParameterValue], [Measures].[ParameterLevel]} ON COLUMNS , ";
            mdx = mdx + " [Month].[Month of Year].ALLMEMBERS ON ROWS";
            mdx = mdx + " FROM [SALES MONTH] ";
            try
            {
                this.objOLAPData.OLAPConnectData();
                this.objOLAPData.ExeReader(mdx);
                this.Month.Items.Clear();
                while (this.objOLAPData.OLAPDataRead.Read())
                {
                    item = new ListItem(this.GetMonthName(this.objOLAPData.OLAPDataRead.GetString(1)), this.objOLAPData.OLAPDataRead.GetValue(2).ToString());
                    this.Month.Items.Add(item);
                }
                if (!string.IsNullOrEmpty(MonthStr))
                {
                    //Set SelectedIndex for the value before submitted
                    this.Month.SelectedIndex = this.Month.Items.IndexOf(this.Month.Items.FindByValue(MonthStr));
                }
            }
            catch (Exception ex)
            {
                ASPNET_MessageBox(ex.Message);
            }
            finally
            {
                this.objOLAPData.OLAPCloseData();
            }
        }
        //public Interfaces_Analysis_Service_AdviserMonth()
        //{
        //    Unload += Page_Unload;
        //    Load += Page_Load;
        //}

    }
}