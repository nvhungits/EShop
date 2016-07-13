//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace Sourcecode_Intellivue.Interfaces.AnalysisService
//{
//    public partial class FumByProductByDate : System.Web.UI.Page
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
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using Sourcecode_Intellivue.lib;
namespace Sourcecode_Intellivue.Interfaces.AnalysisService
{
partial class FumByProductByDate : CoreClass
{
	Microsoft.Reporting.WebForms.ReportParameter[] Param = new Microsoft.Reporting.WebForms.ReportParameter[4];
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
                string accessright = GlobalClass.GetAccessRight("A3");
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
		LoadProduct();
		LoadInvestmentOption("","");
		LoadYear();
		LoadMonth("");
	}

	private void SecondInitial()
	{
		LoadInvestmentOption(Request.Form["Product"], Request.Form["InvestmentOption"]);
		LoadMonth(Request.Form["Month"]);
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
		mdx = mdx + " ON ROWS FROM [FUM By Product] ";
		mdx = mdx + " WHERE [Product].[Product Group].&[O]";
		// Response.Write(mdx)
		try {
			this.objOLAPData.OLAPConnectData();
			//Response.Write(mdx)
			this.objOLAPData.ExeReader(mdx);
			this.Product.Items.Clear();
			while (this.objOLAPData.OLAPDataRead.Read()) {
				item = new ListItem(this.objOLAPData.OLAPDataRead.GetValue(1).ToString(), this.objOLAPData.OLAPDataRead.GetString(2).ToString());
				this.Product.Items.Add(item);
				//Response.Write(Me.objOLAPData.OLAPDataRead.GetString(4))
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
		mdx = mdx + " FROM [FUM By Product]";
		if (string.IsNullOrEmpty(ProductStr)) {
			mdx = mdx + " WHERE ([Product].[Product Group].&[O])";
		} else {
			if (ProductStr != "All") {
				mdx = mdx + " WHERE ([Product].[Product Group].&[O],strtomember('[Product].[Source Parent Product Name].&[" + ProductStr + "]') )";
			} else {
				mdx = mdx + " WHERE ([Product].[Product Group].&[O],strtomember('[Product].[Source Parent Product Name].[All]') )";
			}
		}
		try {
			this.objOLAPData.OLAPConnectData();
			//Response.Write(mdx)
			this.objOLAPData.ExeReader(mdx);
			this.InvestmentOption.Items.Clear();
			while (this.objOLAPData.OLAPDataRead.Read()) {
				item = new ListItem(this.objOLAPData.OLAPDataRead.GetString(1), this.objOLAPData.OLAPDataRead.GetValue(1).ToString());
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
		mdx = mdx + "MEMBER [Measures].[ParameterCaption] AS '[FUM Time].[Year].CURRENTMEMBER.MEMBER_CAPTION' ";
		mdx = mdx + "MEMBER [Measures].[ParameterValue] AS '[FUM Time].[Year].CURRENTMEMBER.UNIQUENAME' ";
		mdx = mdx + "MEMBER [Measures].[ParameterLevel] AS '[FUM Time].[Year].CURRENTMEMBER.LEVEL.ORDINAL' ";
		mdx = mdx + " SELECT {[Measures].[ParameterCaption], [Measures].[ParameterValue], [Measures].[ParameterLevel]} ON COLUMNS , ";
		mdx = mdx + " [FUM Time].[Year].ALLMEMBERS ";
		mdx = mdx + " HAVING([Measures].[ParameterLevel] <> 0)";

		mdx = mdx + "  ON ROWS";
		mdx = mdx + " FROM [FUM By Product]";

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

	private void LoadMonth(string MonthStr )//(string MonthStr = "")
	{
		ListItem item = default(ListItem);
		string mdx = "WITH ";
		mdx = mdx + "MEMBER [Measures].[ParameterCaption] AS '[FUM Time].[Month of Year].CURRENTMEMBER.MEMBER_CAPTION' ";
		mdx = mdx + "MEMBER [Measures].[ParameterValue] AS '[FUM Time].[Month of Year].CURRENTMEMBER.UNIQUENAME' ";
		mdx = mdx + "MEMBER [Measures].[ParameterLevel] AS '[FUM Time].[Month of Year].CURRENTMEMBER.LEVEL.ORDINAL' ";
		mdx = mdx + " SELECT {[Measures].[ParameterCaption], [Measures].[ParameterValue], [Measures].[ParameterLevel]} ON COLUMNS , ";
		mdx = mdx + " [FUM Time].[Month of Year].ALLMEMBERS ON ROWS";
		mdx = mdx + " FROM [FUM By Product] ";
		try {
			this.objOLAPData.OLAPConnectData();
			this.objOLAPData.ExeReader(mdx);
			this.Month.Items.Clear();
			while (this.objOLAPData.OLAPDataRead.Read()) {
				item = new ListItem(this.GetMonthName(this.objOLAPData.OLAPDataRead.GetString(1)), this.objOLAPData.OLAPDataRead.GetValue(1).ToString());
				this.Month.Items.Add(item);
			}
			if (!string.IsNullOrEmpty(MonthStr)) {
				//Set SelectedIndex for the value before submitted
				this.Month.SelectedIndex = this.Month.Items.IndexOf(this.Month.Items.FindByValue(MonthStr));
			}
		} catch (Exception ex) {
			ASPNET_MessageBox(ex.Message);
		} finally {
			this.objOLAPData.OLAPCloseData();
		}
	}
    //public Interfaces_Analysis_Service_FumByProductByDate()
    //{
    //    Unload += Page_Unload;
    //    Load += Page_Load;
    //}

}
}