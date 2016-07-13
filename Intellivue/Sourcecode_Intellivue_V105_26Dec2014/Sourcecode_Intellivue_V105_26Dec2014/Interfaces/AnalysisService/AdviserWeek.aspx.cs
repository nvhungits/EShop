//c# version converted by Vo Manh Cuong, 15/12/2014
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
//
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using Sourcecode_Intellivue.lib;
using Microsoft.Reporting.WebForms;
namespace Sourcecode_Intellivue.Interfaces.AnalysisService
{
 public partial class AdviserWeek : CoreClass
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
		user_role = Session["role"]!=null?Session["role"].ToString():"";
        
		if (Session["role"] == null) {
			Response.Redirect("~/Default.aspx");

		} else if (user_role == "Admin") {
			userId_edit = Session["userId_edit"]!=null?Session["userId_edit"].ToString():"";
            user_edit_command = Session["user_info_command"] != null ? Session["user_info_command"].ToString() : "";
            username_edit = Session["username_edit"] != null ? Session["username_edit"].ToString() : ""; //Session["username_edit"].ToString();
			if (!Page.IsPostBack) {
				Initial();
			}

		} else {
			string accessright = GlobalClass.GetAccessRight("A1");
			if (accessright == "F") {
				string strscript = "<script>alert('You are not authorization for this page!');window.location.href='../pgHomePage.aspx'</script>";
				if (!ClientScript.IsClientScriptBlockRegistered("clientscript")) {
					ClientScript.RegisterStartupScript(this.GetType(), "clientscript", strscript);
				}
			}
			userId_edit = Session["userId"].ToString();
			user_edit_command = "edit";
            username_edit = Session["username"].ToString();

		}

		this.MaintainScrollPositionOnPostBack = true;
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
		try {
			kpiCategory = "[KPI].[KPI Category Name].&[" + this.Category.Items[this.Category.SelectedIndex].ToString() + "]";
		} catch (Exception ex) {
			ASPNET_MessageBox(ex.Message);
		}
		LoadKPI(kpiCategory,"");
		LoadProduct();
		LoadInvestmentOption("","");
		LoadYear();
		LoadWeek("","");
	}


	private void SecondInitial()
	{
		LoadKPI(Request.Form["Category"], Request.Form["KPI"]);
		LoadInvestmentOption(Request.Form["Product"], Request.Form["InvestmentOption"]);
		LoadWeek(Request.Form["Year"], Request.Form["Week"]);
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
		mdx = mdx + " FROM [SALES WEEK]";
		try {
			this.objOLAPData.OLAPConnectData();
			//Response.Write(mdx)
			this.objOLAPData.ExeReader(mdx);
			this.Category.Items.Clear();
			while (this.objOLAPData.OLAPDataRead.Read()) {
				item = new ListItem(this.objOLAPData.OLAPDataRead.GetString(0), this.objOLAPData.OLAPDataRead.GetValue(2).ToString());
				this.Category.Items.Add(item);
			}
		} catch (Exception ex) {
			ASPNET_MessageBox(ex.Message);
		} finally {
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
		mdx = mdx + " ON ROWS FROM [SALES WEEK] ";
		mdx = mdx + " WHERE [Product].[Product Group].&[O]";
		// Response.Write(mdx)
		try {
			this.objOLAPData.OLAPConnectData();
			//Response.Write(mdx)
			this.objOLAPData.ExeReader(mdx);
			this.Product.Items.Clear();
			while (this.objOLAPData.OLAPDataRead.Read()) {
				item = new ListItem(this.objOLAPData.OLAPDataRead.GetString(1), this.objOLAPData.OLAPDataRead.GetString(2));
				this.Product.Items.Add(item);
				//Response.Write(Me.objOLAPData.OLAPDataRead.GetString(4))
			}
		} catch (Exception ex) {
			ASPNET_MessageBox(ex.Message);
		} finally {
			this.objOLAPData.OLAPCloseData();
		}
	}



	private void LoadKPI(string CategoryStr , string KPIStr )//(string CategoryStr = "", string KPIStr = "")
	{
		ListItem item = default(ListItem);
		string mdx = "WITH ";
		mdx = mdx + "MEMBER [Measures].[ParameterCaption] AS '[KPI].[KPI Name].CURRENTMEMBER.MEMBER_CAPTION' ";
		mdx = mdx + "MEMBER [Measures].[ParameterValue] AS '[KPI].[KPI Name].CURRENTMEMBER.UNIQUENAME' ";
		mdx = mdx + "MEMBER [Measures].[ParameterLevel] AS '[KPI].[KPI Name].CURRENTMEMBER.LEVEL.ORDINAL' ";
		mdx = mdx + " SELECT {[Measures].[ParameterCaption], [Measures].[ParameterValue], [Measures].[ParameterLevel]} ON COLUMNS , ";
		mdx = mdx + " [KPI].[KPI Name].ALLMEMBERS ";
		mdx = mdx + " Having ([Measures].[ParameterCaption] <> \"Cancelled From Inception\")";
		mdx = mdx + " ON ROWS ";
		if (string.IsNullOrEmpty(CategoryStr)) {
			mdx = mdx + " FROM [SALES WEEK] WHERE (StrToMember('[KPI].[KPI Category Name].&[Inflow]',CONSTRAINED))";
		} else {
			mdx = mdx + " FROM [SALES WEEK] WHERE (StrToMember('" + CategoryStr + "',CONSTRAINED))";
		}



		try {
			this.objOLAPData.OLAPConnectData();
			//Response.Write(mdx)
			this.objOLAPData.ExeReader(mdx);
			this.KPI.Items.Clear();
			while (this.objOLAPData.OLAPDataRead.Read()) {
				item = new ListItem(this.objOLAPData.OLAPDataRead.GetString(1), this.objOLAPData.OLAPDataRead.GetValue(2).ToString());
				this.KPI.Items.Add(item);
			}
			if (!string.IsNullOrEmpty(KPIStr)) {
				//Set SelectedIndex for the value before submitted
				this.KPI.SelectedIndex = this.KPI.Items.IndexOf(this.KPI.Items.FindByValue(KPIStr));
			}
		} catch (Exception ex) {
			ASPNET_MessageBox(ex.Message);
		} finally {
			this.objOLAPData.OLAPCloseData();
		}
	}

	private void LoadInvestmentOption(string ProductStr , string InvOptionStr )//(string ProductStr = "", string InvOptionStr = "")
	{
		ListItem item = default(ListItem);
		string mdx = "WITH ";
		mdx = mdx + "MEMBER [Measures].[ParameterCaption] AS '[Product].[Source Product Name].CURRENTMEMBER.MEMBER_CAPTION' ";
		mdx = mdx + "MEMBER [Measures].[ParameterValue] AS '[Product].[Source Product Name].CURRENTMEMBER.UNIQUENAME' ";
		mdx = mdx + "MEMBER [Measures].[ParameterLevel] AS '[Product].[Source Product Name].CURRENTMEMBER.LEVEL.ORDINAL' ";
		mdx = mdx + " SELECT {[Measures].[ParameterCaption], [Measures].[ParameterValue], [Measures].[ParameterLevel]} ON COLUMNS , ";
		mdx = mdx + " [Product].[Source Product Name].ALLMEMBERS ON ROWS";
		mdx = mdx + " FROM [SALES WEEK]";
		if (string.IsNullOrEmpty(ProductStr)) {
			mdx = mdx + " WHERE ([Product].[Product Group].&[O])";
		} else {
			mdx = mdx + " WHERE ([Product].[Product Group].&[O],strtomember('" + ProductStr + "') )";
		}
		try {
			this.objOLAPData.OLAPConnectData();
			//Response.Write(mdx)
			this.objOLAPData.ExeReader(mdx);
			this.InvestmentOption.Items.Clear();
			while (this.objOLAPData.OLAPDataRead.Read()) {
				item = new ListItem(this.objOLAPData.OLAPDataRead.GetString(1), this.objOLAPData.OLAPDataRead.GetValue(2).ToString());
				this.InvestmentOption.Items.Add(item);
			}

			if (!string.IsNullOrEmpty(InvOptionStr)) {
				//Set SelectedIndex for the value before submitted
				this.InvestmentOption.SelectedIndex = this.InvestmentOption.Items.IndexOf(this.InvestmentOption.Items.FindByValue(InvOptionStr));
			}
		} catch (Exception ex) {
			ASPNET_MessageBox(ex.Message);
		} finally {
			this.objOLAPData.OLAPCloseData();
		}
	}



	private void LoadYear()
	{
		ListItem item = default(ListItem);
		string mdx = "WITH ";
		mdx = mdx + "MEMBER [Measures].[ParameterCaption] AS '[Week].[Year].CURRENTMEMBER.MEMBER_CAPTION' ";
		mdx = mdx + "MEMBER [Measures].[ParameterValue] AS '[Week].[Year].CURRENTMEMBER.UNIQUENAME' ";
		mdx = mdx + "MEMBER [Measures].[ParameterLevel] AS '[Week].[Year].CURRENTMEMBER.LEVEL.ORDINAL' ";
		mdx = mdx + " SELECT {[Measures].[ParameterCaption], [Measures].[ParameterValue], [Measures].[ParameterLevel]} ON COLUMNS , ";
		mdx = mdx + " [Week].[Year].ALLMEMBERS ";
		mdx = mdx + " HAVING([Measures].[ParameterLevel] <> 0)";

		mdx = mdx + "  ON ROWS";
		mdx = mdx + " FROM [SALES WEEK]";

		try {
			this.objOLAPData.OLAPConnectData();
			//Response.Write(mdx)
			this.objOLAPData.ExeReader(mdx);
			this.Year.Items.Clear();
			while (this.objOLAPData.OLAPDataRead.Read()) {
				item = new ListItem(this.objOLAPData.OLAPDataRead.GetString(0), this.objOLAPData.OLAPDataRead.GetValue(2).ToString());
				this.Year.Items.Add(item);
			}

			//Choose the last year
			this.Year.SelectedIndex = this.Year.Items.Count - 1;

		} catch (Exception ex) {
			ASPNET_MessageBox(ex.Message);
		} finally {
			this.objOLAPData.OLAPCloseData();
		}
	}

	private void LoadWeek(string YearStr , string WeekStr )//(string YearStr = "", string WeekStr = "")
	{
		ListItem item = default(ListItem);
		string mdx = "WITH ";
		mdx = mdx + "MEMBER [Measures].[ParameterCaption] AS '[Week].[Week of Year].CURRENTMEMBER.MEMBER_CAPTION' ";
		mdx = mdx + "MEMBER [Measures].[ParameterValue] AS '[Week].[Week of Year].CURRENTMEMBER.UNIQUENAME' ";
		mdx = mdx + "MEMBER [Measures].[ParameterLevel] AS '[Week].[Week of Year].CURRENTMEMBER.LEVEL.ORDINAL' ";
		mdx = mdx + " SELECT {[Measures].[ParameterCaption], [Measures].[ParameterValue], [Measures].[ParameterLevel]} ON COLUMNS , ";
		mdx = mdx + " [Week].[Week of Year].ALLMEMBERS ON ROWS";
		mdx = mdx + " FROM [SALES WEEK] ";
		try {
			this.objOLAPData.OLAPConnectData();
			//Response.Write(mdx)

			this.objOLAPData.ExeReader(mdx);
			this.Week.Items.Clear();
			while (this.objOLAPData.OLAPDataRead.Read()) {

				item = new ListItem(this.objOLAPData.OLAPDataRead.GetString(1), this.objOLAPData.OLAPDataRead.GetValue(2).ToString());
				this.Week.Items.Add(item);
			}
			if (!string.IsNullOrEmpty(WeekStr)) {
				//Set SelectedIndex for the value before submitted
				this.Week.SelectedIndex = this.Week.Items.IndexOf(this.Week.Items.FindByValue(WeekStr));
			}
		} catch (Exception ex) {
			ASPNET_MessageBox(ex.Message);
		} finally {
			this.objOLAPData.OLAPCloseData();
		}
	}
    //public Interfaces_Analysis_Service_AdviserWeek()
    //{
    //    Unload += Page_Unload;
    //    Load += Page_Load;
    //}

}
}