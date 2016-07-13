using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
    //using Microsoft.VisualBasic;
//using System;
using System.Collections;
//using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Drawing;
//using Dundas.Charting.WebControl;
using System.Web.UI.DataVisualization;
using System.Web.UI.DataVisualization.Charting;
using Sourcecode_Intellivue.lib;

namespace Sourcecode_Intellivue.Interfaces.Dashboard.DasboardMng
{
    public partial class DashboardMng : CoreClass
    {
   
	//SqlConnection sqlCon = fsDatabaseConnection();
    SqlConnection sqlCon;// = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DatabaseConnection"]);
	string userId_edit = "";
	string user_name = "";

	string user_role = "";



	protected void Page_Load(object sender, System.EventArgs e)
	{
        sqlCon = fsDatabaseConnection();
		this.Culture = "en-AU";
		user_role = (string)Session["role"];

		if (Session["role"] == null) {
			Response.Redirect("~/Default.aspx");

		} else if (user_role == "Admin") {
		//userId_edit = Session("userId_edit")



		} else {
			string accessright = GlobalClass.GetAccessRight("D1");
			if (accessright == "F") {
				string strscript = "<script>alert('You are not authorization for this page!');window.location.href='../pgHomePage.aspx'</script>";
				if (!ClientScript.IsClientScriptBlockRegistered("clientscript")) {
					ClientScript.RegisterStartupScript(this.GetType(), "clientscript", strscript);
				}
			}
            userId_edit = (string)Session["userId"];


		}

		LoadTreeViewWidget1();
		LoadTreeViewWidget2();
		LoadTreeViewWidget3();
		LoadTreeViewWidget4();
		sdsDashboardList.ConnectionString = sqlCon.ConnectionString.ToString();

		if (!this.IsPostBack) {
			FillYear(ddlFrom1);
			FillYear(ddlFrom2);
			FillYear(ddlFrom3);
			FillYear(ddlFrom4);
			FillYear(ddlTo1);
			FillYear(ddlTo2);
			FillYear(ddlTo3);
			FillYear(ddlTo4);

			rblCategory1.Items[0].Selected = false;
			rblCategory1.Items[1].Selected = false;


			sdsDashboardList.SelectParameters["DASH_ID"].DefaultValue ="0";
			//btnTest.Attributes.Add("onclick", "javascript:Test()")
			//grvDashboardList.Attributes.Add("onclick", "javascript:AddTab()")
			//Me.btnSave.Attributes.Add("OnClick", "return test();")
		}
	}

	protected void KPI_Select(string para, CheckBoxList cbl)
	{
		cbl.Items.Clear();
		sqlCon.Open();
		//Execute Sql Statement
		SqlCommand sqlCmd = new SqlCommand("select * from dbo.tblDW_KPI where KPI_CATG = '" + para + "'", sqlCon);


		SqlDataReader rs = sqlCmd.ExecuteReader();

		//Read Data from RecordSet
		while ((rs.Read())) {
			cbl.Items.Add(new ListItem(rs["KPI_NAME"].ToString(), rs["KPI"].ToString()));
		}
		sqlCon.Close();

	}

	protected void rblCategory1_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		KPI_Select(rblCategory1.SelectedValue.ToString(), cblKPI1);
	}

	protected void rblCategory2_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		KPI_Select(rblCategory2.SelectedValue.ToString(), cblKPI2);
	}

	protected void rblCategory3_SelectedIndexChanged(object sender, System.EventArgs e)
	{
        KPI_Select(rblCategory3.SelectedValue.ToString(), cblKPI3);
	}

	protected void rblCategory4_SelectedIndexChanged(object sender, System.EventArgs e)
	{
        KPI_Select(rblCategory4.SelectedValue.ToString(), cblKPI4);
	}

	protected void LoadTreeViewWidget1()
	{
		//Load TreeView
		obout_ASPTreeView_2_NET.Tree oTree = new obout_ASPTreeView_2_NET.Tree();
		string html = null;

		oTree.AddRootNode("Dimension", true, "Folder_Y.gif");
		//Account
		html = "<input class='c' type='checkbox' id='chk_w1_1acc_r1' onclick='ob_t2c(this)'>Account";
		oTree.Add("root", "r1", html, false, "ball_blueS.gif");

		html = "<input class='c' type='checkbox' id='chk_w1_2adv_a0' onclick='ob_t2c(this)'>Adviser";
		oTree.Add("r1", "a0", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w1_3pro_a0_0' onclick='ob_t2c(this)'>Product";
		oTree.Add("a0", "a0_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w1_4tim_a0_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a0_0", "a0_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_3tim_a0_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a0", "a0_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_4pro_a0_1_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a0_1", "a0_1_0", html, False, "ball_yellowS.gif")

		html = "<input class='c' type='checkbox' id='chk_w1_2pro_a1' onclick='ob_t2c(this)'>Product";
		oTree.Add("r1", "a1", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w1_3adv_a1_0' onclick='ob_t2c(this)'>Adviser";
		oTree.Add("a1", "a1_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w1_4tim_a1_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a1_0", "a1_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_3tim_a1_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a1", "a1_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_4adv_a1_1_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a1_1", "a1_1_0", html, False, "ball_yellowS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w1_2tim_a2' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("r1", "a2", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_3adv_a2_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a2", "a2_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_4pro_a2_0_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a2_0", "a2_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_3pro_a2_1' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a2", "a2_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_4adv_a2_1_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a2_1", "a2_1_0", html, False, "ball_yellowS.gif")
		//Adviser
		html = "<input class='c' type='checkbox' id='chk_w1_1adv_r2' onclick='ob_t2c(this)'>Adviser";
		oTree.Add("root", "r2", html, false, "ball_blueS.gif");

		html = "<input class='c' type='checkbox' id='chk_w1_2acc_a3' onclick='ob_t2c(this)'>Account";
		oTree.Add("r2", "a3", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w1_3pro_a3_0' onclick='ob_t2c(this)'>Product";
		oTree.Add("a3", "a3_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w1_4tim_a3_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a3_0", "a3_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_3tim_a3_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a3", "a3_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_4pro_a3_1_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a3_1", "a3_1_0", html, False, "ball_yellowS.gif")

		html = "<input class='c' type='checkbox' id='chk_w1_2pro_a4' onclick='ob_t2c(this)'>Product";
		oTree.Add("r2", "a4", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w1_3acc_a4_0' onclick='ob_t2c(this)'>Account";
		oTree.Add("a4", "a4_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w1_4tim_a4_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a4_0", "a4_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_3tim_a4_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a4", "a4_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_4acc_a4_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a4_1", "a4_1_0", html, False, "ball_yellowS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w1_2tim_a5' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("r2", "a5", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_3acc_a5_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a5", "a5_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_4pro_a5_0_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a5_0", "a5_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_3pro_a5_1' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a5", "a5_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_4acc_a5_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a5_1", "a5_1_0", html, False, "ball_yellowS.gif")
		//Product
		html = "<input class='c' type='checkbox' id='chk_w1_1pro_r3' onclick='ob_t2c(this)'>Product";
		oTree.Add("root", "r3", html, false, "ball_blueS.gif");

		html = "<input class='c' type='checkbox' id='chk_w1_2acc_a6' onclick='ob_t2c(this)'>Account";
		oTree.Add("r3", "a6", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w1_3adv_a6_0' onclick='ob_t2c(this)'>Adviser";
		oTree.Add("a6", "a6_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w1_4tim_a6_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a6_0", "a6_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_3tim_a6_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a6", "a6_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_4adv_a6_1_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a6_1", "a6_1_0", html, False, "ball_yellowS.gif")

		html = "<input class='c' type='checkbox' id='chk_w1_2adv_a7' onclick='ob_t2c(this)'>Adviser";
		oTree.Add("r3", "a7", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w1_3acc_a7_0' onclick='ob_t2c(this)'>Account";
		oTree.Add("a7", "a7_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w1_4tim_a7_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a7_0", "a7_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_3tim_a7_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a7", "a7_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_4acc_a7_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a7_1", "a7_1_0", html, False, "ball_yellowS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w1_2tim_a8' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("r3", "a8", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_3acc_a8_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a8", "a8_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_4adv_a8_0_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a8_0", "a8_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_3adv_a8_1' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a8", "a8_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_4acc_a8_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a8_1", "a8_1_0", html, False, "ball_yellowS.gif")
		//Time period
		//html = "<input class='c' type='checkbox' id='chk_w1_1tim_r4' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("root", "r4", html, False, "ball_blueS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w1_2acc_a9' onclick='ob_t2c(this)'>Account"
		//oTree.Add("r4", "a9", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_3adv_a9_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a9", "a9_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_4pro_a9_0_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a9_0", "a9_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_3pro_a9_1' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a9", "a9_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_4adv_a9_1_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a9_1", "a9_1_0", html, False, "ball_yellowS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w1_2adv_a10' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("r4", "a10", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_3acc_a10_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a10", "a10_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_4pro_a10_0_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a10_0", "a10_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_3pro_a10_1' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a10", "a10_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_4acc_a10_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a10_1", "a10_1_0", html, False, "ball_yellowS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w1_2pro_a11' onclick='ob_t2c(this)'>Product"
		//oTree.Add("r4", "a11", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_3acc_a11_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a11", "a11_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_4adv_a11_0_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a11_0", "a11_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_3adv_a11_1' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a11", "a11_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w1_4acc_a11_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a11_1", "a11_1_0", html, False, "ball_yellowS.gif")

		oTree.FolderIcons = "tree2/icons";
		oTree.FolderScript = "tree2/script";
		oTree.FolderStyle = "tree2/style/Classic";

		oTree.SelectedEnable = false;
		//oTree.SelectedId = "a1_0"
		oTree.ShowIcons = true;
		oTree.Width = "280px";
		oTree.Height = "180px";
		TreeViewWidget1.Text = oTree.HTML();
	}

	protected void LoadTreeViewWidget2()
	{
		//Load TreeView
		obout_ASPTreeView_2_NET.Tree oTree = new obout_ASPTreeView_2_NET.Tree();
		string html = null;

		oTree.AddRootNode("Dimension", true, "Folder_Y.gif");
		//Account
		html = "<input class='c' type='checkbox' id='chk_w2_1acc_r1' onclick='ob_t2c(this)'>Account";
		oTree.Add("root", "r1", html, false, "ball_blueS.gif");

		html = "<input class='c' type='checkbox' id='chk_w2_2adv_a0' onclick='ob_t2c(this)'>Adviser";
		oTree.Add("r1", "a0", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w2_3pro_a0_0' onclick='ob_t2c(this)'>Product";
		oTree.Add("a0", "a0_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w2_4tim_a0_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a0_0", "a0_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_3tim_a0_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a0", "a0_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_4pro_a0_1_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a0_1", "a0_1_0", html, False, "ball_yellowS.gif")

		html = "<input class='c' type='checkbox' id='chk_w2_2pro_a1' onclick='ob_t2c(this)'>Product";
		oTree.Add("r1", "a1", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w2_3adv_a1_0' onclick='ob_t2c(this)'>Adviser";
		oTree.Add("a1", "a1_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w2_4tim_a1_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a1_0", "a1_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_3tim_a1_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a1", "a1_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_4adv_a1_1_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a1_1", "a1_1_0", html, False, "ball_yellowS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w2_2tim_a2' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("r1", "a2", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_3adv_a2_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a2", "a2_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_4pro_a2_0_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a2_0", "a2_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_3pro_a2_1' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a2", "a2_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_4adv_a2_1_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a2_1", "a2_1_0", html, False, "ball_yellowS.gif")
		//Adviser
		html = "<input class='c' type='checkbox' id='chk_w2_1adv_r2' onclick='ob_t2c(this)'>Adviser";
		oTree.Add("root", "r2", html, false, "ball_blueS.gif");

		html = "<input class='c' type='checkbox' id='chk_w2_2acc_a3' onclick='ob_t2c(this)'>Account";
		oTree.Add("r2", "a3", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w2_3pro_a3_0' onclick='ob_t2c(this)'>Product";
		oTree.Add("a3", "a3_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w2_4tim_a3_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a3_0", "a3_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_3tim_a3_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a3", "a3_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_4pro_a3_1_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a3_1", "a3_1_0", html, False, "ball_yellowS.gif")

		html = "<input class='c' type='checkbox' id='chk_w2_2pro_a4' onclick='ob_t2c(this)'>Product";
		oTree.Add("r2", "a4", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w2_3acc_a4_0' onclick='ob_t2c(this)'>Account";
		oTree.Add("a4", "a4_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w2_4tim_a4_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a4_0", "a4_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_3tim_a4_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a4", "a4_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_4acc_a4_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a4_1", "a4_1_0", html, False, "ball_yellowS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w2_2tim_a5' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("r2", "a5", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_3acc_a5_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a5", "a5_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_4pro_a5_0_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a5_0", "a5_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_3pro_a5_1' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a5", "a5_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_4acc_a5_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a5_1", "a5_1_0", html, False, "ball_yellowS.gif")
		//Product
		html = "<input class='c' type='checkbox' id='chk_w2_1pro_r3' onclick='ob_t2c(this)'>Product";
		oTree.Add("root", "r3", html, false, "ball_blueS.gif");

		html = "<input class='c' type='checkbox' id='chk_w2_2acc_a6' onclick='ob_t2c(this)'>Account";
		oTree.Add("r3", "a6", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w2_3adv_a6_0' onclick='ob_t2c(this)'>Adviser";
		oTree.Add("a6", "a6_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w2_4tim_a6_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a6_0", "a6_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_3tim_a6_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a6", "a6_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_4adv_a6_1_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a6_1", "a6_1_0", html, False, "ball_yellowS.gif")

		html = "<input class='c' type='checkbox' id='chk_w2_2adv_a7' onclick='ob_t2c(this)'>Adviser";
		oTree.Add("r3", "a7", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w2_3acc_a7_0' onclick='ob_t2c(this)'>Account";
		oTree.Add("a7", "a7_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w2_4tim_a7_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a7_0", "a7_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_3tim_a7_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a7", "a7_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_4acc_a7_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a7_1", "a7_1_0", html, False, "ball_yellowS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w2_2tim_a8' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("r3", "a8", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_3acc_a8_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a8", "a8_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_4adv_a8_0_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a8_0", "a8_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_3adv_a8_1' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a8", "a8_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_4acc_a8_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a8_1", "a8_1_0", html, False, "ball_yellowS.gif")
		//Time period
		//html = "<input class='c' type='checkbox' id='chk_w2_1tim_r4' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("root", "r4", html, False, "ball_blueS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w2_2acc_a9' onclick='ob_t2c(this)'>Account"
		//oTree.Add("r4", "a9", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_3adv_a9_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a9", "a9_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_4pro_a9_0_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a9_0", "a9_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_3pro_a9_1' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a9", "a9_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_4adv_a9_1_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a9_1", "a9_1_0", html, False, "ball_yellowS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w2_2adv_a10' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("r4", "a10", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_3acc_a10_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a10", "a10_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_4pro_a10_0_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a10_0", "a10_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_3pro_a10_1' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a10", "a10_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_4acc_a10_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a10_1", "a10_1_0", html, False, "ball_yellowS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w2_2pro_a11' onclick='ob_t2c(this)'>Product"
		//oTree.Add("r4", "a11", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_3acc_a11_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a11", "a11_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_4adv_a11_0_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a11_0", "a11_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_3adv_a11_1' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a11", "a11_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w2_4acc_a11_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a11_1", "a11_1_0", html, False, "ball_yellowS.gif")

		oTree.FolderIcons = "tree2/icons";
		oTree.FolderScript = "tree2/script";
		oTree.FolderStyle = "tree2/style/Classic";

		oTree.SelectedEnable = false;
		//oTree.SelectedId = "a1_0"
		oTree.ShowIcons = true;
		oTree.Width = "280px";
		oTree.Height = "180px";
		TreeViewWidget2.Text = oTree.HTML();
	}

	protected void LoadTreeViewWidget3()
	{
		//Load TreeView
		obout_ASPTreeView_2_NET.Tree oTree = new obout_ASPTreeView_2_NET.Tree();
		string html = null;

		oTree.AddRootNode("Dimension", true, "Folder_Y.gif");
		//Account
		html = "<input class='c' type='checkbox' id='chk_w3_1acc_r1' onclick='ob_t2c(this)'>Account";
		oTree.Add("root", "r1", html, false, "ball_blueS.gif");

		html = "<input class='c' type='checkbox' id='chk_w3_2adv_a0' onclick='ob_t2c(this)'>Adviser";
		oTree.Add("r1", "a0", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w3_3pro_a0_0' onclick='ob_t2c(this)'>Product";
		oTree.Add("a0", "a0_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w3_4tim_a0_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a0_0", "a0_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_3tim_a0_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a0", "a0_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_4pro_a0_1_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a0_1", "a0_1_0", html, False, "ball_yellowS.gif")

		html = "<input class='c' type='checkbox' id='chk_w3_2pro_a1' onclick='ob_t2c(this)'>Product";
		oTree.Add("r1", "a1", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w3_3adv_a1_0' onclick='ob_t2c(this)'>Adviser";
		oTree.Add("a1", "a1_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w3_4tim_a1_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a1_0", "a1_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_3tim_a1_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a1", "a1_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_4adv_a1_1_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a1_1", "a1_1_0", html, False, "ball_yellowS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w3_2tim_a2' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("r1", "a2", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_3adv_a2_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a2", "a2_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_4pro_a2_0_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a2_0", "a2_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_3pro_a2_1' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a2", "a2_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_4adv_a2_1_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a2_1", "a2_1_0", html, False, "ball_yellowS.gif")
		//Adviser
		html = "<input class='c' type='checkbox' id='chk_w3_1adv_r2' onclick='ob_t2c(this)'>Adviser";
		oTree.Add("root", "r2", html, false, "ball_blueS.gif");

		html = "<input class='c' type='checkbox' id='chk_w3_2acc_a3' onclick='ob_t2c(this)'>Account";
		oTree.Add("r2", "a3", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w3_3pro_a3_0' onclick='ob_t2c(this)'>Product";
		oTree.Add("a3", "a3_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w3_4tim_a3_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a3_0", "a3_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_3tim_a3_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a3", "a3_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_4pro_a3_1_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a3_1", "a3_1_0", html, False, "ball_yellowS.gif")

		html = "<input class='c' type='checkbox' id='chk_w3_2pro_a4' onclick='ob_t2c(this)'>Product";
		oTree.Add("r2", "a4", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w3_3acc_a4_0' onclick='ob_t2c(this)'>Account";
		oTree.Add("a4", "a4_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w3_4tim_a4_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a4_0", "a4_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_3tim_a4_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a4", "a4_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_4acc_a4_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a4_1", "a4_1_0", html, False, "ball_yellowS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w3_2tim_a5' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("r2", "a5", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_3acc_a5_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a5", "a5_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_4pro_a5_0_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a5_0", "a5_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_3pro_a5_1' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a5", "a5_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_4acc_a5_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a5_1", "a5_1_0", html, False, "ball_yellowS.gif")
		//Product
		html = "<input class='c' type='checkbox' id='chk_w3_1pro_r3' onclick='ob_t2c(this)'>Product";
		oTree.Add("root", "r3", html, false, "ball_blueS.gif");

		html = "<input class='c' type='checkbox' id='chk_w3_2acc_a6' onclick='ob_t2c(this)'>Account";
		oTree.Add("r3", "a6", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w3_3adv_a6_0' onclick='ob_t2c(this)'>Adviser";
		oTree.Add("a6", "a6_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w3_4tim_a6_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a6_0", "a6_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_3tim_a6_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a6", "a6_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_4adv_a6_1_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a6_1", "a6_1_0", html, False, "ball_yellowS.gif")

		html = "<input class='c' type='checkbox' id='chk_w3_2adv_a7' onclick='ob_t2c(this)'>Adviser";
		oTree.Add("r3", "a7", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w3_3acc_a7_0' onclick='ob_t2c(this)'>Account";
		oTree.Add("a7", "a7_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w3_4tim_a7_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a7_0", "a7_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_3tim_a7_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a7", "a7_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_4acc_a7_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a7_1", "a7_1_0", html, False, "ball_yellowS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w3_2tim_a8' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("r3", "a8", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_3acc_a8_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a8", "a8_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_4adv_a8_0_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a8_0", "a8_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_3adv_a8_1' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a8", "a8_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_4acc_a8_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a8_1", "a8_1_0", html, False, "ball_yellowS.gif")
		//Time period
		//html = "<input class='c' type='checkbox' id='chk_w3_1tim_r4' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("root", "r4", html, False, "ball_blueS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w3_2acc_a9' onclick='ob_t2c(this)'>Account"
		//oTree.Add("r4", "a9", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_3adv_a9_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a9", "a9_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_4pro_a9_0_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a9_0", "a9_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_3pro_a9_1' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a9", "a9_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_4adv_a9_1_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a9_1", "a9_1_0", html, False, "ball_yellowS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w3_2adv_a10' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("r4", "a10", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_3acc_a10_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a10", "a10_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_4pro_a10_0_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a10_0", "a10_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_3pro_a10_1' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a10", "a10_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_4acc_a10_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a10_1", "a10_1_0", html, False, "ball_yellowS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w3_2pro_a11' onclick='ob_t2c(this)'>Product"
		//oTree.Add("r4", "a11", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_3acc_a11_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a11", "a11_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_4adv_a11_0_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a11_0", "a11_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_3adv_a11_1' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a11", "a11_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w3_4acc_a11_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a11_1", "a11_1_0", html, False, "ball_yellowS.gif")

		oTree.FolderIcons = "tree2/icons";
		oTree.FolderScript = "tree2/script";
		oTree.FolderStyle = "tree2/style/Classic";

		oTree.SelectedEnable = false;
		//oTree.SelectedId = "a1_0"
		oTree.ShowIcons = true;
		oTree.Width = "280px";
		oTree.Height = "180px";
		TreeViewWidget3.Text = oTree.HTML();
	}

	protected void LoadTreeViewWidget4()
	{
		//Load TreeView
		obout_ASPTreeView_2_NET.Tree oTree = new obout_ASPTreeView_2_NET.Tree();
		string html = null;

		oTree.AddRootNode("Dimension", true, "Folder_Y.gif");
		//Account
		html = "<input class='c' type='checkbox' id='chk_w4_1acc_r1' onclick='ob_t2c(this)'>Account";
		oTree.Add("root", "r1", html, false, "ball_blueS.gif");

		html = "<input class='c' type='checkbox' id='chk_w4_2adv_a0' onclick='ob_t2c(this)'>Adviser";
		oTree.Add("r1", "a0", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w4_3pro_a0_0' onclick='ob_t2c(this)'>Product";
		oTree.Add("a0", "a0_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w4_4tim_a0_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a0_0", "a0_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_3tim_a0_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a0", "a0_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_4pro_a0_1_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a0_1", "a0_1_0", html, False, "ball_yellowS.gif")

		html = "<input class='c' type='checkbox' id='chk_w4_2pro_a1' onclick='ob_t2c(this)'>Product";
		oTree.Add("r1", "a1", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w4_3adv_a1_0' onclick='ob_t2c(this)'>Adviser";
		oTree.Add("a1", "a1_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w4_4tim_a1_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a1_0", "a1_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_3tim_a1_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a1", "a1_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_4adv_a1_1_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a1_1", "a1_1_0", html, False, "ball_yellowS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w4_2tim_a2' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("r1", "a2", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_3adv_a2_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a2", "a2_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_4pro_a2_0_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a2_0", "a2_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_3pro_a2_1' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a2", "a2_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_4adv_a2_1_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a2_1", "a2_1_0", html, False, "ball_yellowS.gif")
		//Adviser
		html = "<input class='c' type='checkbox' id='chk_w4_1adv_r2' onclick='ob_t2c(this)'>Adviser";
		oTree.Add("root", "r2", html, false, "ball_blueS.gif");

		html = "<input class='c' type='checkbox' id='chk_w4_2acc_a3' onclick='ob_t2c(this)'>Account";
		oTree.Add("r2", "a3", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w4_3pro_a3_0' onclick='ob_t2c(this)'>Product";
		oTree.Add("a3", "a3_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w4_4tim_a3_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a3_0", "a3_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_3tim_a3_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a3", "a3_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_4pro_a3_1_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a3_1", "a3_1_0", html, False, "ball_yellowS.gif")

		html = "<input class='c' type='checkbox' id='chk_w4_2pro_a4' onclick='ob_t2c(this)'>Product";
		oTree.Add("r2", "a4", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w4_3acc_a4_0' onclick='ob_t2c(this)'>Account";
		oTree.Add("a4", "a4_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w4_4tim_a4_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a4_0", "a4_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_3tim_a4_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a4", "a4_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_4acc_a4_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a4_1", "a4_1_0", html, False, "ball_yellowS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w4_2tim_a5' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("r2", "a5", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_3acc_a5_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a5", "a5_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_4pro_a5_0_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a5_0", "a5_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_3pro_a5_1' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a5", "a5_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_4acc_a5_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a5_1", "a5_1_0", html, False, "ball_yellowS.gif")
		//Product
		html = "<input class='c' type='checkbox' id='chk_w4_1pro_r3' onclick='ob_t2c(this)'>Product";
		oTree.Add("root", "r3", html, false, "ball_blueS.gif");

		html = "<input class='c' type='checkbox' id='chk_w4_2acc_a6' onclick='ob_t2c(this)'>Account";
		oTree.Add("r3", "a6", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w4_3adv_a6_0' onclick='ob_t2c(this)'>Adviser";
		oTree.Add("a6", "a6_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w4_4tim_a6_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a6_0", "a6_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_3tim_a6_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a6", "a6_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_4adv_a6_1_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a6_1", "a6_1_0", html, False, "ball_yellowS.gif")

		html = "<input class='c' type='checkbox' id='chk_w4_2adv_a7' onclick='ob_t2c(this)'>Adviser";
		oTree.Add("r3", "a7", html, false, "ball_redS.gif");
		html = "<input class='c' type='checkbox' id='chk_w4_3acc_a7_0' onclick='ob_t2c(this)'>Account";
		oTree.Add("a7", "a7_0", html, false, "ball_greenS.gif");
		//html = "<input class='c' type='checkbox' id='chk_w4_4tim_a7_0_0' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a7_0", "a7_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_3tim_a7_1' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("a7", "a7_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_4acc_a7_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a7_1", "a7_1_0", html, False, "ball_yellowS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w4_2tim_a8' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("r3", "a8", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_3acc_a8_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a8", "a8_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_4adv_a8_0_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a8_0", "a8_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_3adv_a8_1' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a8", "a8_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_4acc_a8_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a8_1", "a8_1_0", html, False, "ball_yellowS.gif")
		//Time period
		//html = "<input class='c' type='checkbox' id='chk_w4_1tim_r4' onclick='ob_t2c(this)'>Time period"
		//oTree.Add("root", "r4", html, False, "ball_blueS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w4_2acc_a9' onclick='ob_t2c(this)'>Account"
		//oTree.Add("r4", "a9", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_3adv_a9_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a9", "a9_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_4pro_a9_0_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a9_0", "a9_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_3pro_a9_1' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a9", "a9_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_4adv_a9_1_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a9_1", "a9_1_0", html, False, "ball_yellowS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w4_2adv_a10' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("r4", "a10", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_3acc_a10_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a10", "a10_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_4pro_a10_0_0' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a10_0", "a10_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_3pro_a10_1' onclick='ob_t2c(this)'>Product"
		//oTree.Add("a10", "a10_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_4acc_a10_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a10_1", "a10_1_0", html, False, "ball_yellowS.gif")

		//html = "<input class='c' type='checkbox' id='chk_w4_2pro_a11' onclick='ob_t2c(this)'>Product"
		//oTree.Add("r4", "a11", html, False, "ball_redS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_3acc_a11_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a11", "a11_0", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_4adv_a11_0_0' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a11_0", "a11_0_0", html, False, "ball_yellowS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_3adv_a11_1' onclick='ob_t2c(this)'>Adviser"
		//oTree.Add("a11", "a11_1", html, False, "ball_greenS.gif")
		//html = "<input class='c' type='checkbox' id='chk_w4_4acc_a11_1_0' onclick='ob_t2c(this)'>Account"
		//oTree.Add("a11_1", "a11_1_0", html, False, "ball_yellowS.gif")

		oTree.FolderIcons = "tree2/icons";
		oTree.FolderScript = "tree2/script";
		oTree.FolderStyle = "tree2/style/Classic";

		oTree.SelectedEnable = false;
		//oTree.SelectedId = "a1_0"
		oTree.ShowIcons = true;
		oTree.Width = "280px";
		oTree.Height = "180px";
		TreeViewWidget4.Text = oTree.HTML();
	}

	protected void FillYear(DropDownList ddl)
	{
		int year = 0;
		for (year = 1998; year <= 2005; year++) {
			ddl.Items.Add(new ListItem(year.ToString(), year.ToString()));
		}
	}

	protected void btnSave_Click(object sender, System.EventArgs e)
	{
		int countWidget = 0;
		int countKPI = 0;
		int i = 0;
		int j = 0;
		int k = 0;
		bool result = false;
		string strDimension = null;
		string[] arrPara = null;

		//Checking Dashboard
		string dashboardName = txtName.Text.ToString().Trim();
		if (dashboardName.Equals("")) {
			lblError.Text = "Please input Dashboard Name";
			return;
		}

		//Checking Widget
		countWidget = hdfWidget.Value.ToString().Length;
		strDimension = hdfPara.Value.ToString();
		arrPara = strDimension.Split(',');
		for (i = 0; i <= (countWidget - 1); i++) {
			if (i == 0) {
				lblError.Text = "";
				//Checking Category on widget 1
				if (rblCategory1.Items[0].Selected == false & rblCategory1.Items[1].Selected == false) {
					lblError.Text = "Please select one Category on widget 1";
					return;
				}

				//Checking KPI on widget 1
				result = false;
				countKPI = cblKPI1.Items.Count;
				for (j = 0; j <= (countKPI - 1); j++) {
					if (cblKPI1.Items[j].Selected) {
						result = true;
					}
				}
				if (result == false) {
					lblError.Text = "Please select one KPI on widget 1";
					return;
				}

				//Checking dimension on widget 1
				result = false;
				for (k = 0; k <= arrPara.Length - 2; k++) {
					if (arrPara[k].Substring(4, 2).ToString() == "w1") {
						result = true;
					}
				}
				if (result == false) {
					lblError.Text = "Please select one dimension on widget 1";
					return;
				}
			} else if (i == 1) {
				lblError.Text = "";
				//Checking Category on widget 2
				if (rblCategory2.Items[0].Selected == false & rblCategory2.Items[1].Selected == false) {
					lblError.Text = "Please select one Category on widget 2";
					return;
				}

				//Checking KPI on widget 2
				result = false;
				countKPI = cblKPI2.Items.Count;
				for (j = 0; j <= (countKPI - 1); j++) {
					if (cblKPI2.Items[j].Selected) {
						result = true;
					}
				}
				if (result == false) {
					lblError.Text = "Please select one KPI on widget 2";
					return;
				}

				//Checking dimension on widget 2
				result = false;
				for (k = 0; k <= arrPara.Length - 2; k++) {
					if (arrPara[k].Substring(4, 2).ToString() == "w2") {
						result = true;
					}
				}
				if (result == false) {
					lblError.Text = "Please select one dimension on widget 2";
					return;
				}
			} else if (i == 2) {
				lblError.Text = "";
				//Checking Category on widget 3
				if (rblCategory3.Items[0].Selected == false & rblCategory3.Items[1].Selected == false) {
					lblError.Text = "Please select one Category on widget 3";
					return;
				}

				//Checking KPI on widget 3
				result = false;
				countKPI = cblKPI3.Items.Count;
				for (j = 0; j <= (countKPI - 1); j++) {
					if (cblKPI3.Items[j].Selected) {
						result = true;
					}
				}
				if (result == false) {
					lblError.Text = "Please select one KPI on widget 3";
					return;
				}

				//Checking dimension on widget 3
				result = false;
				for (k = 0; k <= arrPara.Length - 2; k++) {
					if (arrPara[k].Substring(4, 2).ToString() == "w3") {
						result = true;
					}
				}
				if (result == false) {
					lblError.Text = "Please select one dimension on widget 3";
					return;
				}
			} else {
				lblError.Text = "";
				//Checking Category on widget 4
				if (rblCategory4.Items[0].Selected == false & rblCategory4.Items[1].Selected == false) {
					lblError.Text = "Please select one Category on widget 4";
					return;
				}

				//Checking KPI on widget 4
				result = false;
				countKPI = cblKPI4.Items.Count;
				for (j = 0; j <= (countKPI - 1); j++) {
					if (cblKPI4.Items[j].Selected) {
						result = true;
					}
				}
				if (result == false) {
					lblError.Text = "Please select one KPI on widget 4";
					return;
				}

				//Checking dimension on widget 4
				result = false;
				for (k = 0; k <= arrPara.Length - 2; k++) {
					if (arrPara[k].Substring(4, 2).ToString() == "w4") {
						result = true;
					}
				}
				if (result == false) {
					lblError.Text = "Please select one dimension on widget 4";
					return;
				}
			}
		}

		SqlParameter dashboardID = new SqlParameter("@LAST_RECORD", SqlDbType.Int);
		SqlCommand cmd = new SqlCommand();
		string sql = null;
		string widgetName = null;
		string KPICategory = null;
		int fromYear = 0;
		int toYear = 0;
		string KPI = "";
		string dimension = "";
		int dashID = 0;
		int measureID = 0;
		string saleType = null;
		string chartType = null;


		dashboardName = txtName.Text.ToString();
		sql = "prc_InsertDashboard";
		sqlCon.Open();
		cmd = new SqlCommand(sql, sqlCon);
		dashboardID.Direction = ParameterDirection.Output;
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@DASH_NAME", dashboardName);
		cmd.Parameters.AddWithValue("@DASH_TITLE", "");
		cmd.Parameters.Add(dashboardID);
		cmd.ExecuteNonQuery();
		sqlCon.Close();

		countWidget = hdfWidget.Value.ToString().Length;
		dashID = int.Parse(dashboardID.Value.ToString());
		for (i = 0; i <= (countWidget - 1); i++) {
			if (i == 0) {
				widgetName = "Widget 1";
				KPICategory = rblCategory1.SelectedValue.ToString();
				fromYear = int.Parse(ddlFrom1.Text.ToString());
				toYear = int.Parse(ddlTo1.Text.ToString());
				countKPI = cblKPI1.Items.Count;
				for (j = 0; j <= (countKPI - 1); j++) {
					if (cblKPI1.Items[j].Selected) {
						KPI = KPI + cblKPI1.Items[j].Value.ToString() + "#";
					}
				}
				KPI = KPI.Substring(0, KPI.Length - 1);
				for (k = 0; k <= arrPara.Length - 2; k++) {
					if (arrPara[k].Substring(4, 2).ToString() == "w1") {
						dimension = dimension + arrPara[k].Substring(8, 3).ToString().ToUpper() + "#";
					}
				}
				dimension = dimension.Substring(0, dimension.Length - 1);
				measureID = int.Parse(rblMeasure1.SelectedValue.ToString());
				saleType = rblType1.SelectedValue.ToString();
				// npkhoi add chart type
				if (!string.IsNullOrEmpty(hdfTypeLV1.Value)) {
					chartType = hdfTypeLV1.Value;
				} else {
					chartType = "10";
				}
				// /npkhoi add chart type
				insertWidget(widgetName, KPICategory, fromYear, toYear, KPI, dimension, dashID, measureID, saleType, chartType);
			} else if (i == 1) {
				widgetName = "Widget 2";
				KPICategory = rblCategory2.SelectedValue.ToString();
				fromYear = int.Parse(ddlFrom2.Text.ToString());
				toYear = int.Parse(ddlTo2.Text.ToString());
				countKPI = cblKPI2.Items.Count;
				KPI = "";
				for (j = 0; j <= (countKPI - 1); j++) {
					if (cblKPI2.Items[j].Selected) {
						KPI = KPI + cblKPI2.Items[j].Value.ToString() + "#";
					}
				}
				KPI = KPI.Substring(0, KPI.Length - 1);
				dimension = "";
				for (k = 0; k <= arrPara.Length - 2; k++) {
					if (arrPara[k].Substring(4, 2).ToString() == "w2") {
						dimension = dimension + arrPara[k].Substring(8, 3).ToString().ToUpper() + "#";
					}
				}
				dimension = dimension.Substring(0, dimension.Length - 1);
				measureID = int.Parse(rblMeasure2.SelectedValue.ToString());
				saleType = rblType2.SelectedValue.ToString();
				// npkhoi add chart type
				if (!string.IsNullOrEmpty(hdfTypeLV2.Value)) {
					chartType = hdfTypeLV2.Value;
				} else {
					chartType = "10";
				}

				insertWidget(widgetName, KPICategory, fromYear, toYear, KPI, dimension, dashID, measureID, saleType, chartType);
			} else if (i == 2) {
				widgetName = "Widget 3";
				KPICategory = rblCategory3.SelectedValue.ToString();
				fromYear = int.Parse(ddlFrom3.Text.ToString());
				toYear = int.Parse(ddlTo3.Text.ToString());
				countKPI = cblKPI3.Items.Count;
				KPI = "";
				for (j = 0; j <= (countKPI - 1); j++) {
					if (cblKPI3.Items[j].Selected) {
						KPI = KPI + cblKPI3.Items[j].Value.ToString() + "#";
					}
				}
				KPI = KPI.Substring(0, KPI.Length - 1);
				dimension = "";
				for (k = 0; k <= arrPara.Length - 2; k++) {
					if (arrPara[k].Substring(4, 2).ToString() == "w3") {
						dimension = dimension + arrPara[k].Substring(8, 3).ToString().ToUpper() + "#";
					}
				}
				dimension = dimension.Substring(0, dimension.Length - 1);
				measureID = int.Parse(rblMeasure3.SelectedValue.ToString());
				saleType = rblType3.SelectedValue.ToString();
				// npkhoi add chart type
				if (!string.IsNullOrEmpty(hdfTypeLV2.Value)) {
					chartType = hdfTypeLV3.Value;
				} else {
					chartType = "10";
				}

				insertWidget(widgetName, KPICategory, fromYear, toYear, KPI, dimension, dashID, measureID, saleType, chartType);
			} else {
				widgetName = "Widget 4";
				KPICategory = rblCategory4.SelectedValue.ToString();
				fromYear = int.Parse(ddlFrom4.Text.ToString());
				toYear = int.Parse(ddlTo4.Text.ToString());
				countKPI = cblKPI4.Items.Count;
				KPI = "";
				for (j = 0; j <= (countKPI - 1); j++) {
					if (cblKPI4.Items[j].Selected) {
						KPI = KPI + cblKPI4.Items[j].Value.ToString() + "#";
					}
				}
				KPI = KPI.Substring(0, KPI.Length - 1);
				dimension = "";
				for (k = 0; k <= arrPara.Length - 2; k++) {
					if (arrPara[k].Substring(4, 2).ToString() == "w4") {
						dimension = dimension + arrPara[k].Substring(8, 3).ToString().ToUpper() + "#";
					}
				}
				dimension = dimension.Substring(0, dimension.Length - 1);
				measureID = int.Parse(rblMeasure4.SelectedValue.ToString());
				saleType = rblType4.SelectedValue.ToString();
				// npkhoi add chart type
				if (!string.IsNullOrEmpty(hdfTypeLV2.Value)) {
					chartType = hdfTypeLV4.Value;
				} else {
					chartType = "10";
				}

				insertWidget(widgetName, KPICategory, fromYear, toYear, KPI, dimension, dashID, measureID, saleType, chartType);
			}
		}

		lblError.Text = "Save successfully";
		grvDashboardList.DataBind();
	}

	protected void insertWidget(string widgetName, string KPICategory, int fromYear, int toYear, string KPI, string dimension, int dashID, int measureID, string saleType, string chartType)
	{
		SqlCommand cmd = new SqlCommand();
		string sql = null;
		sql = "prc_DashboardManagement_InsertWidget";
		sqlCon.Open();
		cmd = new SqlCommand(sql, sqlCon);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@WIDGET_NAME", widgetName);
		cmd.Parameters.AddWithValue("@KPI_CATG", KPICategory);
		cmd.Parameters.AddWithValue("@FROM_YEAR", fromYear);
		cmd.Parameters.AddWithValue("@TO_YEAR", toYear);
		cmd.Parameters.AddWithValue("@KPI", KPI);
		cmd.Parameters.AddWithValue("@DIM", dimension);
		cmd.Parameters.AddWithValue("@DASH_ID", dashID);
		cmd.Parameters.AddWithValue("@MEASURE_ID", measureID);
		cmd.Parameters.AddWithValue("@SALE_TYPE", saleType);
		cmd.Parameters.AddWithValue("@CHART_TYPE", chartType);

		cmd.ExecuteNonQuery();
		sqlCon.Close();
	}

	protected void grvDashboardList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
	{
		//Response.Write(e.NewEditIndex)
		//Response.Write(grvDashboardList.Rows(e.NewEditIndex).Cells(0).Text)
		string sql = null;
		SqlCommand cmd = null;
		int dashID = 0;
		int i = 0;

		sql = "prc_DashboardManagement_GetDashboardList";
		dashID = int.Parse(grvDashboardList.Rows[e.NewEditIndex].Cells[0].Text);
		sqlCon.Open();
		cmd = new SqlCommand(sql, sqlCon);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@DASH_ID", dashID);
		SqlDataReader rs = cmd.ExecuteReader();
		while ((rs.Read())) {
			if (i == 0) {
				txtName.Text = rs["DASH_NAME"].ToString();
			} else if (i == 1) {
				Response.Write("hello khoa");
				widget2.Style.Add("display", "");

			} else {
			}
			i = i + 1;
		}
		sqlCon.Close();

	}


	#region "begin chart function"

	private string getDimensionNameColumn(string strCurDimension)
	{
		switch (strCurDimension) {
			case "ACC":
				return "CTRT_NAME";
			case "ADV":
				return "ADVSR_NAME";
			case "PRO":
				return "PROD_NAME";
			case "TIM":
				return "EFVE_DATE";
		}

		return "";
	}

	private string getDimensionIDColumn(string strCurDimension)
	{
		switch (strCurDimension) {
			case "ACC":
				return "CTRT_IDNF";
			case "ADV":
				return "ADVSR_IDNF";
			case "PRO":
				return "PROD_IDNF";
			case "TIM":
				return "EFVE_DATE";
		}

		return "";
	}

	private string getMeasureNameColumn(string strMeasure)
	{
		switch (strMeasure) {
			case "12":
				return "SALE_AMT";
			case "13":
				return "SALE_COUNT";
			case "14":
				return "UNIT_CTRT_BLCE";
			case "15":
				return "FUM_AMNT";
		}

		return "";
	}

	public bool seriesContains(string name)
	{
		try {
			string strName = Chart1.Series["name"].Name;
		} catch (Exception ex) {
			return false;
		}
		return true;
	}

	private void getChartType(string strValue)
	{
		try {
			//If Chart1.Series.Count = 2 Then
			//    Chart1.Series(0).Type = Dundas.Charting.WebControl.SeriesChartType.Column
			//    Chart1.Series(0).ChartArea = "Default"
			//    Chart1.Series(1).Type = Dundas.Charting.WebControl.SeriesChartType.FastLine
			//    Chart1.Series(1).ChartArea = "Default"
			//Else
			int temp = Chart1.Series.Count;
			foreach (Series series in Chart1.Series) {
				switch (strValue) {
					case "0":
						series.ChartType = SeriesChartType.Point;
						break;
					//Case "1"
					//    series.Type = Dundas.Charting.WebControl.SeriesChartType.FastPoint
					case "2":
						series.ChartType = SeriesChartType.Bubble;
						break;
					case "3":
						series.ChartType = SeriesChartType.Spline;
						break;
					case "4":
						series.ChartType = SeriesChartType.StackedBar100;
						break;
					case "5":
						series.ChartType = SeriesChartType.StepLine;
						break;
					case "6":
						series.ChartType = SeriesChartType.FastLine;
						break;
					case "7":
						series.ChartType = SeriesChartType.Bar;
						break;
					case "8":
						series.ChartType = SeriesChartType.Line;

						break;
					//series.Type = Dundas.Charting.WebControl.SeriesChartType.Line
					case "10":
						series.ChartType = SeriesChartType.Column;
						break;
					case "13":
						series.ChartType = SeriesChartType.Area;
						break;
					case "14":
						series.ChartType = SeriesChartType.SplineArea;
						break;
					case "17":
						series.ChartType = SeriesChartType.Pie;
						series.BorderWidth = 4;
						break;
					case "18":
						series.ChartType = SeriesChartType.Doughnut;
						break;
					case "20":
						series.ChartType = SeriesChartType.Candlestick;
						break;
					case "23":
                        series.ChartType = SeriesChartType.RangeBar;//Gantt; Gantt was renamed to RangeBar in MS Chart instead of Dundus Chart
						break;
					case "25":
						series.ChartType = SeriesChartType.Radar;
						break;
					case "28":
						series.ChartType = SeriesChartType.Polar;
						break;
					case "29":
						series.ChartType = SeriesChartType.ErrorBar;
						break;
					case "30":
						series.ChartType = SeriesChartType.BoxPlot;
						break;
					case "33":
						series.ChartType = SeriesChartType.Kagi;
						break;
					case "35":
						series.ChartType = SeriesChartType.Funnel;
						series["FunnelPointGap"] = "3";
						break;
					case "36":
						series.ChartType = SeriesChartType.Pyramid;
						break;
					default:
						series.ChartType = SeriesChartType.Column;
						break;
				}



				//series.ChartArea = "Default"
			}
			//            End If


			if ((rdb3d1.Checked)) {
				Chart1.ChartAreas["Default"].Area3DStyle.Enable3D = true;
			} else {
				Chart1.ChartAreas["Default"].Area3DStyle.Enable3D = false;
			}

			Chart1.ChartAreas["Default"].BackColor = Color.White;
		//Chart1.ChartAreas["Default"].BackGradientEndColor = Color.White
		//Chart1.ChartAreas["Default"].BackGradientType = Dundas.Charting.WebControl.GradientType.TopBottom

		} catch (Exception ex) {
			//lblMessage.Text = "Data is not available for this Chart."
		}
	}

	private void getChartType2(string strValue)
	{

		try {
			foreach (Series series in Chart2.Series) {
				switch (strValue) {
					case "13":
						series.ChartType = SeriesChartType.Area;
						break;
					case "7":
						series.ChartType = SeriesChartType.Bar;
						break;
					case "30":
						series.ChartType = SeriesChartType.BoxPlot;
						break;
					case "2":
						series.ChartType = SeriesChartType.Bubble;
						break;
					case "20":
						series.ChartType = SeriesChartType.Candlestick;
						break;
					case "10":
						series.ChartType = SeriesChartType.Column;
						break;
					case "18":
						series.ChartType = SeriesChartType.Doughnut;
						break;
					case "29":
						series.ChartType = SeriesChartType.ErrorBar;
						break;
					case "6":
						series.ChartType = SeriesChartType.FastLine;
						break;
					//Case "1"
					//    series.Type = Dundas.Charting.WebControl.SeriesChartType.FastPoint
					case "35":
						series.ChartType = SeriesChartType.Funnel;
						break;
					case "23":
                        series.ChartType = SeriesChartType.RangeBar;//.Gantt;
						break;
					case "33":
						series.ChartType = SeriesChartType.Kagi;
						break;
					case "3":
						series.ChartType = SeriesChartType.Line;
						break;
					case "17":
						series.ChartType = SeriesChartType.Pie;
						break;
					case "0":
						series.ChartType = SeriesChartType.Point;
						break;
					case "28":
						series.ChartType = SeriesChartType.Polar;
						break;
					case "36":
						series.ChartType = SeriesChartType.Pyramid;
						break;
					case "25":
						series.ChartType = SeriesChartType.Radar;
						break;
					case "4":
						series.ChartType = SeriesChartType.Spline;
						break;
					case "14":
						series.ChartType = SeriesChartType.SplineArea;
						break;
					case "5":
						series.ChartType = SeriesChartType.StepLine;
						break;
					default:
						series.ChartType = SeriesChartType.Column;
						break;
				}


				series.ChartArea = "Default";
			}

			if ((rdb3d2.Checked)) {
				Chart2.ChartAreas["Default"].Area3DStyle.Enable3D = true;
			} else {
				Chart2.ChartAreas["Default"].Area3DStyle.Enable3D = false;
			}

			Chart2.ChartAreas["Default"].BackColor = Color.LightBlue;
		//Chart2.ChartAreas["Default"].BackGradientEndColor = Color.White
		//Chart2.ChartAreas["Default"].BackGradientType = Dundas.Charting.WebControl.GradientType.TopBottom
		} catch (Exception ex) {
			//lblMessage.Text = "Data is not available for this Chart."
		}
	}

	private void getChartType3(string strValue)
	{
        
		try {
			foreach (Series series in Chart3.Series) {
				switch (strValue) {
					case "13":
                        series.ChartType = SeriesChartType.Area;//Type = SeriesChartType.Area;
						break;
					case "7":
						series.ChartType = SeriesChartType.Bar;
						break;
					case "30":
						series.ChartType = SeriesChartType.BoxPlot;
						break;
					case "2":
						series.ChartType = SeriesChartType.Bubble;
						break;
					case "20":
                        series.ChartType = SeriesChartType.Candlestick;//CandleStick;
						break;
					case "10":
						series.ChartType = SeriesChartType.Column;
						break;
					case "18":
						series.ChartType = SeriesChartType.Doughnut;
						break;
					case "29":
						series.ChartType = SeriesChartType.ErrorBar;
						break;
					case "6":
						series.ChartType = SeriesChartType.FastLine;
						break;
					//Case "1"
					//    series.ChartType = SeriesChartType.FastPoint
					case "35":
						series.ChartType = SeriesChartType.Funnel;
						break;
					case "23":
                        series.ChartType = SeriesChartType.RangeBar;//.Gantt;
						break;
					case "33":
						series.ChartType = SeriesChartType.Kagi;
						break;
					case "3":
						series.ChartType = SeriesChartType.Line;
						break;
					case "17":
						series.ChartType = SeriesChartType.Pie;
						break;
					case "0":
						series.ChartType = SeriesChartType.Point;
						break;
					case "28":
						series.ChartType = SeriesChartType.Polar;
						break;
					case "36":
						series.ChartType = SeriesChartType.Pyramid;
						break;
					case "25":
						series.ChartType = SeriesChartType.Radar;
						break;
					case "4":
						series.ChartType = SeriesChartType.Spline;
						break;
					case "14":
						series.ChartType = SeriesChartType.SplineArea;
						break;
					case "5":
						series.ChartType = SeriesChartType.StepLine;
						break;
					default:
						series.ChartType = SeriesChartType.Column;
						break;
				}


				series.ChartArea = "Default";
			}

			if ((rdb3d3.Checked)) {
				Chart3.ChartAreas["Default"].Area3DStyle.Enable3D = true;
			} else {
				Chart3.ChartAreas["Default"].Area3DStyle.Enable3D = false;
			}

			Chart3.ChartAreas["Default"].BackColor = Color.LightBlue;
            Chart3.ChartAreas["Default"].BackSecondaryColor=Color.White;//.BackGradientEndColor = Color.White;
			Chart3.ChartAreas["Default"].BackGradientStyle = GradientStyle.TopBottom;

		} catch (Exception ex) {
			//lblMessage.Text = "Data is not available for this Chart."
		}
	}

	private void getChartType4(string strValue)
	{

		try {
			foreach (Series series in Chart4.Series) {
				switch (strValue) {
					case "13":
						series.ChartType = SeriesChartType.Area;
						break;
					case "7":
						series.ChartType = SeriesChartType.Bar;
						break;
					case "30":
						series.ChartType = SeriesChartType.BoxPlot;
						break;
					case "2":
						series.ChartType = SeriesChartType.Bubble;
						break;
					case "20":
						series.ChartType = SeriesChartType.Candlestick;
						break;
					case "10":
						series.ChartType = SeriesChartType.Column;
						break;
					case "18":
						series.ChartType = SeriesChartType.Doughnut;
						break;
					case "29":
						series.ChartType = SeriesChartType.ErrorBar;
						break;
					case "6":
						series.ChartType = SeriesChartType.FastLine;
						break;
					//Case "1"
					//    series.ChartType = Dundas.Charting.WebControl.SeriesChartType.FastPoint
					case "35":
						series.ChartType = SeriesChartType.Funnel;
						break;
					case "23":
                        series.ChartType = SeriesChartType.RangeBar;//.Gantt;
						break;
					case "33":
						series.ChartType = SeriesChartType.Kagi;
						break;
					case "3":
						series.ChartType = SeriesChartType.Line;
						break;
					case "17":
						series.ChartType = SeriesChartType.Pie;
						break;
					case "0":
						series.ChartType = SeriesChartType.Point;
						break;
					case "28":
						series.ChartType = SeriesChartType.Polar;
						break;
					case "36":
						series.ChartType = SeriesChartType.Pyramid;
						break;
					case "25":
						series.ChartType = SeriesChartType.Radar;
						break;
					case "4":
						series.ChartType = SeriesChartType.Spline;
						break;
					case "14":
						series.ChartType = SeriesChartType.SplineArea;
						break;
					case "5":
						series.ChartType = SeriesChartType.StepLine;
						break;
					default:
						series.ChartType = SeriesChartType.Column;
						break;
				}


				series.ChartArea = "Default";
			}

			if ((rdb3d4.Checked)) {
				Chart4.ChartAreas["Default"].Area3DStyle.Enable3D = true;
			} else {
				Chart4.ChartAreas["Default"].Area3DStyle.Enable3D = false;
			}


			Chart4.ChartAreas["Default"].BackColor = Color.LightBlue;
            Chart4.ChartAreas["Default"].BackSecondaryColor = Color.White;//BackGradientEndColor = Color.White;  BackGradientEndColor moved to BackSecondaryColor in MS Chart
            Chart4.ChartAreas["Default"].BackGradientStyle = GradientStyle.TopBottom;//BackGradientType = GradientType.TopBottom; 
		} catch (Exception ex) {
			//lblMessage.Text = "Data is not available for this Chart."
		}
	}

	private string getDimension(string strSplit)
	{
		string[] arrPara = null;
		arrPara = hdfPara.Value.ToString().Split(',');
		string dimension = "";

		for (int k = 0; k <= arrPara.Length - 2; k++) {
			if (arrPara[k].Substring(4, 2).ToString() == strSplit) {
				dimension = dimension + arrPara[k].Substring(8, 3).ToString().ToUpper() + "#";
			}
		}

		return dimension.Substring(0, dimension.Length - 1);

	}

	private void showDrawChart()
	{
		int countKPI = 0;
		int j = 0;
		int k = 0;
		SqlCommand cmd = new SqlCommand();
		string widgetName = "";
		string KPICategory = null;
		int fromYear = 0;
		int toYear = 0;
		string KPI = "";
		string dimension = "";
		int dashID = 0;
		int measureID = 0;
		string saleType = null;
		bool result = false;
		string[] arrPara = null;

		arrPara = hdfPara.Value.ToString().Split(',');

		switch (hdfSelectedTab.Value) {
			case "1":
				lblDrawChart.Text = "";
				//Checking Category on widget 1
				if (rblCategory1.Items[0].Selected == false & rblCategory1.Items[1].Selected == false) {
					lblDrawChart.Text = "Please select one Category on widget 1";
					return;
				}

				//Checking KPI on widget 1
				result = false;
				countKPI = cblKPI1.Items.Count;
				for (j = 0; j <= (countKPI - 1); j++) {
					if (cblKPI1.Items[j].Selected) {
						result = true;
					}
				}

				if (result == false) {
					lblDrawChart.Text = "Please select one KPI on widget 1";
					return;
				}

				//Checking dimension on widget 1
				result = false;
				for (k = 0; k <= arrPara.Length - 2; k++) {
					if (arrPara[k].Substring(4, 2).ToString() == "w1") {
						result = true;
					}
				}

				if (result == false) {
					lblDrawChart.Text = "Please select one dimension on widget 1";
					return;
				}

				KPICategory = rblCategory1.SelectedValue.ToString();
				fromYear = int.Parse(ddlFrom1.Text.ToString());
				toYear = int.Parse(ddlTo1.Text.ToString());
				countKPI = cblKPI1.Items.Count;
				for (j = 0; j <= (countKPI - 1); j++) {
					if (cblKPI1.Items[j].Selected) {
						KPI = KPI + cblKPI1.Items[j].Value.ToString() + "#";
					}
				}

				KPI = KPI.Substring(0, KPI.Length - 1);

				dimension = getDimension("w1");
				measureID = int.Parse(rblMeasure1.SelectedValue.ToString());
				saleType = rblType1.SelectedValue.ToString();

				//Chart1.Legends.Clear()
				showChart1(KPI, measureID.ToString(), dimension, "", "", "", "", fromYear.ToString(), toYear.ToString(), "1",
				saleType);


				Chart1.DataBind();
				break;
			//For Each series As Dundas.Charting.WebControl.Series In Chart1.Series
			//    chart1Type = series.Type
			//Next
			//insertWidget(widgetName, KPICategory, fromYear, toYear, KPI, dimension, dashID, measureID, saleType)

			case "2":
				lblDrawChart.Text = "";
				//Checking Category on widget 2
				if (rblCategory2.Items[0].Selected == false & rblCategory2.Items[1].Selected == false) {
					lblDrawChart.Text = "Please select one Category on widget 2";
					return;
				}

				//Checking KPI on widget 2
				result = false;
				countKPI = cblKPI2.Items.Count;
				for (j = 0; j <= (countKPI - 1); j++) {
					if (cblKPI2.Items[j].Selected) {
						result = true;
					}
				}

				if (result == false) {
					lblDrawChart.Text = "Please select one KPI on widget 2";
					return;
				}

				//Checking dimension on widget 2
				result = false;
				for (k = 0; k <= arrPara.Length - 2; k++) {
					if (arrPara[k].Substring(4, 2).ToString() == "w2") {
						result = true;
					}
				}

				if (result == false) {
					lblDrawChart.Text = "Please select one dimension on widget 2";
					return;
				}

				KPICategory = rblCategory2.SelectedValue.ToString();
				fromYear = int.Parse(ddlFrom2.Text.ToString());
				toYear = int.Parse(ddlTo2.Text.ToString());
				countKPI = cblKPI2.Items.Count;
				KPI = "";
				for (j = 0; j <= (countKPI - 1); j++) {
					if (cblKPI2.Items[j].Selected) {
						KPI = KPI + cblKPI2.Items[j].Value.ToString() + "#";
					}
				}

				KPI = KPI.Substring(0, KPI.Length - 1);
				dimension = "";
				for (k = 0; k <= arrPara.Length - 2; k++) {
					if (arrPara[k].Substring(4, 2).ToString() == "w2") {
						dimension = dimension + arrPara[k].Substring(8, 3).ToString().ToUpper() + "#";
					}
				}

				dimension = dimension.Substring(0, dimension.Length - 1);
				measureID = int.Parse(rblMeasure2.SelectedValue.ToString());
				saleType = rblType2.SelectedValue.ToString();
                showChart1(KPI, measureID.ToString(), dimension, "", "", "", "", fromYear.ToString(), toYear.ToString(), "1",
				saleType);
				Chart1.DataBind();
				break;
			//insertWidget(widgetName, KPICategory, fromYear, toYear, KPI, dimension, dashID, measureID, saleType)

			case "3":
				lblDrawChart.Text = "";
				//Checking Category on widget 3
				if (rblCategory3.Items[0].Selected == false & rblCategory3.Items[1].Selected == false) {
					lblDrawChart.Text = "Please select one Category on widget 3";
					return;
				}

				//Checking KPI on widget 3
				result = false;
				countKPI = cblKPI3.Items.Count;
				for (j = 0; j <= (countKPI - 1); j++) {
					if (cblKPI3.Items[j].Selected) {
						result = true;
					}
				}

				if (result == false) {
					lblDrawChart.Text = "Please select one KPI on widget 3";
					return;
				}

				//Checking dimension on widget 3
				result = false;
				for (k = 0; k <= arrPara.Length - 2; k++) {
					if (arrPara[k].Substring(4, 2).ToString() == "w3") {
						result = true;
					}
				}

				if (result == false) {
					lblDrawChart.Text = "Please select one dimension on widget 3";
					return;
				}

				KPICategory = rblCategory3.SelectedValue.ToString();
				fromYear = int.Parse(ddlFrom3.Text.ToString());
				toYear = int.Parse(ddlTo3.Text.ToString());
				countKPI = cblKPI3.Items.Count;
				KPI = "";
				for (j = 0; j <= (countKPI - 1); j++) {
					if (cblKPI3.Items[j].Selected) {
						KPI = KPI + cblKPI3.Items[j].Value.ToString() + "#";
					}
				}

				KPI = KPI.Substring(0, KPI.Length - 1);
				dimension = "";
				for (k = 0; k <= arrPara.Length - 2; k++) {
					if (arrPara[k].Substring(4, 2).ToString() == "w3") {
						dimension = dimension + arrPara[k].Substring(8, 3).ToString().ToUpper() + "#";
					}
				}

				dimension = dimension.Substring(0, dimension.Length - 1);
				measureID = int.Parse(rblMeasure3.SelectedValue.ToString());
				saleType = rblType3.SelectedValue.ToString();
                showChart1(KPI, measureID.ToString(), dimension, "", "", "", "", fromYear.ToString(), toYear.ToString(), "1",
				saleType);
				Chart1.DataBind();
				break;
			//insertWidget(widgetName, KPICategory, fromYear, toYear, KPI, dimension, dashID, measureID, saleType)
			case "4":
				lblDrawChart.Text = "";
				//Checking Category on widget 4
				if (rblCategory4.Items[0].Selected == false & rblCategory4.Items[1].Selected == false) {
					lblDrawChart.Text = "Please select one Category on widget 4";
					return;
				}
				//Checking KPI on widget 4
				result = false;
				countKPI = cblKPI4.Items.Count;
				for (j = 0; j <= (countKPI - 1); j++) {
					if (cblKPI4.Items[j].Selected) {
						result = true;
					}
				}

				if (result == false) {
					lblDrawChart.Text = "Please select one KPI on widget 4";
					return;
				}
				//Checking dimension on widget 4
				result = false;
				for (k = 0; k <= arrPara.Length - 2; k++) {
					if (arrPara[k].Substring(4, 2).ToString() == "w4") {
						result = true;
					}
				}

				if (result == false) {
					lblDrawChart.Text = "Please select one dimension on widget 4";
					return;
				}
				KPICategory = rblCategory4.SelectedValue.ToString();
				fromYear = int.Parse(ddlFrom4.Text.ToString());
				toYear = int.Parse(ddlTo4.Text.ToString());
				countKPI = cblKPI4.Items.Count;
				KPI = "";
				for (j = 0; j <= (countKPI - 1); j++) {
					if (cblKPI4.Items[j].Selected) {
						KPI = KPI + cblKPI4.Items[j].Value.ToString() + "#";
					}
				}

				KPI = KPI.Substring(0, KPI.Length - 1);
				dimension = "";
				for (k = 0; k <= arrPara.Length - 2; k++) {
					if (arrPara[k].Substring(4, 2).ToString() == "w4") {
						dimension = dimension + arrPara[k].Substring(8, 3).ToString().ToUpper() + "#";
					}
				}

				dimension = dimension.Substring(0, dimension.Length - 1);
				measureID = int.Parse(rblMeasure4.SelectedValue.ToString());
				saleType = rblType4.SelectedValue.ToString();
                showChart1(KPI, measureID.ToString(), dimension, "", "", "", "", fromYear.ToString(), toYear.ToString(), "1",
				saleType);
				Chart1.DataBind();
				break;
			//insertWidget(widgetName, KPICategory, fromYear, toYear, KPI, dimension, dashID, measureID, saleType)

		}
	}

	protected void btnDrawChart_Click(object sender, System.EventArgs e)
	{
		Chart1.Legends.Clear();
		showDrawChart();
	}


	protected void btnLV2_Click(object sender, System.EventArgs e)
	{
		showDrawChart();
		showChart2();


		//Dim strKPI As String = ""
		//Dim strYear As String = ""
		//Dim strDimension As String = ""

		//strKPI = hdfKPI.Value
		//strYear = hdfYear.Value
		//strDimension = hdfDimension.Value

		//'showChart("EXEC prc_DashboardManagement_GetDashboardMonthData '" + strKPI + "',12,'PRO','','','',''," + strYear + "," + strYear + ",2", "Series1")
		//showChart2("exec prc_DashboardManagement_GetDashboardController '" + strKPI + "',12,'" + strDimension + "','','','',''," + strYear + "," + strYear + ",2,'w'", "Series1")

		//Chart2.Series["Series1"].ChartArea = "Default"

		//Chart2.DataBind()

	}


	protected void btnLV3_Click(object sender, System.EventArgs e)
	{

		showDrawChart();

		//showChart2()

		//showChart3()

	}


	protected void btnLV4_Click(object sender, System.EventArgs e)
	{
		showDrawChart();

		//showChart2()

		//showChart3()

		//showChart4()


	}

	private void loadChart1Data(string strGetData, string strSeries, string strDimension, string strMeasure)
	{
		///'''/*npkhoi: check axis of chart, show kpi and year where type chart =pie
		bool flagTypeChart = checkTypeChart(hdfTypeLV1.Value.Trim());
		///''''''''''''''''*/

		try {
			sqlCon.Open();

			SqlDataAdapter da = new SqlDataAdapter(strGetData, sqlCon);
			DataSet ds = new DataSet();
			DataRow dr = null;
			da.Fill(ds);
			int intPoint = 0;


			if (!(seriesContains(strSeries))) {
				Legend secondLegend = new Legend(strSeries);
				//npkhoi: if flag= true then add lengend = SeriesName else lengend = "Default"
				if (flagTypeChart) {
					try {
						this.Chart1.Series.Add("Default");

					} catch (Exception ex) {
					}


					this.Chart1.Legends.Add(secondLegend);
				//Chart1.Legends(strSeries).LegendStyle = LegendStyle.Table
				//Me.Chart1.Legends(secondLegend).Docking = LegendDocking.Bottom
				} else {
					Chart1.Series.Add(strSeries);
					//Me.Chart1.Legends.Add("Default")
					//Me.Chart1.Legends("Default").Docking = LegendDocking.Bottom
				}


				//Me.Chart1.Legends.Add(secondLegend)
			}

			if (flagTypeChart) {
				// Add Color column

				LegendCellColumn firstColumn = new LegendCellColumn();
				firstColumn.ColumnType = LegendCellColumnType.SeriesSymbol;
				//firstColumn.HeaderText = strSeries
				firstColumn.HeaderBackColor = Color.WhiteSmoke;
				Chart1.Legends[strSeries].CellColumns.Add(firstColumn);

				//Me.Chart1.Series[strSeries].Legend = strSeries

				// Add Legend Text column

				LegendCellColumn secondColumn = new LegendCellColumn();
				secondColumn.ColumnType = LegendCellColumnType.Text;
				//secondColumn.HeaderText = strSeries
				secondColumn.Text = "#LEGENDTEXT";
				//flagTrue only
				secondColumn.HeaderBackColor = Color.WhiteSmoke;
				Chart1.Legends[strSeries].CellColumns.Add(secondColumn);

				this.Chart1.Series["Default"].Legend = strSeries;
				//Me.Chart1.Legends[strSeries].Title = strSeries
				Chart1.Legends[strSeries].Docking = Docking.Bottom;


			} else {
			}

			foreach (DataRow dr_loopVariable in ds.Tables[0].Rows) {
				dr = dr_loopVariable;
				//Dim legendItem As New LegendItem
				//Chart1.Series[strSeries].LegendText = dr("KPI").ToString()
				if (flagTypeChart) {
					intPoint = Chart1.Series["Default"].Points.AddXY(dr["Year"], dr[getMeasureNameColumn(strMeasure)]);
					Chart1.Series["Default"].Points[intPoint].MapAreaAttributes = "onmouseover=\"window.status='" + dr["KPI"].ToString() + " " + dr["Year"].ToString() + " " + dr[getMeasureNameColumn(strMeasure)].ToString() + "'\"";
					//Chart1.Series["Default"].Points[intPoint].Href = "javascript:getSecondLevel('" + dr("KPI").ToString() + "_" + dr("Year").ToString() + "_" + strDimension + "')"
					Chart1.Series["Default"].Points[intPoint].Url = "javascript:getSecondLevel('" + dr["KPI"].ToString() + "_" + dr["Year"].ToString() + "_" + strDimension + "')";
					Chart1.Series["Default"].Points[intPoint].LegendText = dr["KPI"].ToString() + " " + dr["Year"].ToString();
					Chart1.Series["Default"].Points[intPoint].LegendToolTip = "#VAL{C}";
					Chart1.Series["Default"].Points[intPoint].ToolTip = "#LEGENDTEXT: #VAL{C}";


				} else {
					intPoint = Chart1.Series[strSeries].Points.AddXY(dr["Year"], dr[getMeasureNameColumn(strMeasure)]);
					Chart1.Series[strSeries].Points[intPoint].MapAreaAttributes = "onmouseover=\"window.status='" + dr["KPI"].ToString() + " " + dr["Year"].ToString() + " " + dr[getMeasureNameColumn(strMeasure)].ToString() + "'\"";
					//Chart1.Series[strSeries].Points[intPoint].MapAreaAttributes = "onmouseover=getDetails()"
					//Chart1.Series[strSeries].Points[intPoint].Href = "newDashLV2.aspx?kpi=" + dr("KPI").ToString() + "&year=" + dr("Year").ToString() + "&dimen=" + strDimension + ""
					//Chart1.Series[strSeries].Points[intPoint].Href = "javascript:getSecondLevel('" + dr("KPI").ToString() + "_" + dr("Year").ToString() + "_" + strDimension + "')"
					Chart1.Series[strSeries].Points[intPoint].Url = "javascript:getSecondLevel('" + dr["KPI"].ToString() + "_" + dr["Year"].ToString() + "_" + strDimension + "')";
					Chart1.Series[strSeries].Points[intPoint].ToolTip = "#LEGENDTEXT: #VAL{C}";
					Chart1.Series[strSeries].Points[intPoint].LegendText = dr["KPI"].ToString() + " " + dr["Year"].ToString();
					Chart1.Series[strSeries].Points[intPoint].LegendToolTip = "#VAL{C}";
				}
			}


		} catch (Exception ex) {
		} finally {
			sqlCon.Close();
		}
	}

	private void showChart1(string strKPI, string strMesureID, string strCurDimension, string strPreDimesionLV1, string strPreDimesionLV1ValueSelected, string strPreDimesionLV2, string strPreDimesionLV2ValueSelected, string strFrom, string strTo, string strCurrentLevel,
	string strKindOfTimeChart)
	{
		///'''/*npkhoi: check axis of chart, show kpi and year where type chart =pie
		bool flagTypeChart = checkTypeChart(hdfTypeLV1.Value.Trim());
		///''''''''''''''''*/

		string[] strKPIArray = null;

		strKPIArray = strKPI.Split('#');

		hdfDimension.Value = strCurDimension;
		string[] arrCurDimension = strCurDimension.Split('#');
		strCurDimension = arrCurDimension[0];


		for (int i = 0; i <= strKPIArray.Length - 1; i++) {
			if (strKPIArray.Length > 1) {
				int chartH = 0;
				chartH = (int)Chart1.Height.Value;
				this.Chart1.Height = chartH + 50;
			}
			loadChart1Data("exec prc_DashboardManagement_GetDashboardController '" + strKPIArray[i] + "'," + strMesureID + ",'" + strCurDimension + "','','','',''," + strFrom + "," + strTo + ",1," + strKindOfTimeChart + "", strKPIArray[i], strCurDimension, strMesureID);
		}

		getChartType(hdfTypeLV1.Value.Trim());

	}

	private void showChart2()
	{
		///'''/*npkhoi: check axis of chart, show kpi and year where type chart =pie
		bool flagTypeChart = checkTypeChart(hdfTypeLV2.Value.Trim());
		///''''''''''''''''*/

		string[] strDimensionArr = hdfDimension.Value.Split('#');

		if ((strDimensionArr.Length > 0 & hdfLV2Value.Value.Length > 0)) {
			lblChart2.Text = hdfLV2Value.Value;

			string[] arrValue = hdfLV2Value.Value.Split('_');

			string strKPI = arrValue[0];
			string strYear = arrValue[1];
			string strDimension = arrValue[2];


			string strMesureID = rblMeasure4.SelectedValue.ToString();
			string strFrom = strYear;
			string strTo = strYear;
			string strCurrentLevel = "2";
			string strKindOfTimeChart = rblType1.SelectedValue.ToString();
			string strSeries = strKPI;
			string strDimenLV2 = "";
			string strDimenLV3 = "";

			strDimenLV2 = strDimensionArr[0];

			this.Chart2.Height = 400;
			string strConn = "exec prc_DashboardManagement_GetDashboardController '" + strKPI + "'," + strMesureID + ",'" + strDimenLV2 + "','','','',''," + strFrom + "," + strTo + "," + strCurrentLevel + "," + strKindOfTimeChart + "";

			try {
				sqlCon.Open();

				SqlDataAdapter da = new SqlDataAdapter(strConn, sqlCon);
				DataSet ds = new DataSet();
				DataRow dr = null;
				da.Fill(ds);
				int intPoint = 0;

				if (!(seriesContains(strSeries))) {
					Chart2.Series.Add(strSeries);


					///''''''/* npkhoi: if flag= true then add lengend = SeriesName else lengend = "Default"
					Legend secondLegend = new Legend(strSeries);
					if (flagTypeChart) {
						this.Chart2.Legends.Add(secondLegend);
					} else {
						//Me.Chart2.Legends.Add("Default")
						//Me.Chart2.Legends("Default").Docking = LegendDocking.Bottom
					}
					///'''*/
				}

				///'''''''''/*npkhoi add column for chart pie if flagTypeChart= true
				if (flagTypeChart) {
					// Add Color column
					LegendItem legendItem = new LegendItem();
					LegendCellColumn firstColumn = new LegendCellColumn();
					firstColumn.ColumnType = LegendCellColumnType.SeriesSymbol;
					//firstColumn.HeaderText = strSeries
					firstColumn.HeaderBackColor = Color.WhiteSmoke;

					Chart2.Legends[strSeries].CellColumns.Add(firstColumn);

					//Me.Chart1.Series[strSeries].Legend = strSeries

					// Add Legend Text column

					LegendCellColumn secondColumn = new LegendCellColumn();
					secondColumn.ColumnType = LegendCellColumnType.Text;
					secondColumn.HeaderText = "";
					//strSeries
					secondColumn.Text = "#VALX";
					//flagTrue only
					///''erorr
					//secondColumn.Href = "javascript:getThirdLevel('" + strKPI + "_" + strDimenLV3 + "_" + strDimenLV2 + "_" + dr(getDimensionIDColumn(strDimenLV2)).ToString() + "_" + strYear + "')"
					secondColumn.HeaderBackColor = Color.WhiteSmoke;
					Chart2.Legends[strSeries].CellColumns.Add(secondColumn);

					this.Chart2.Series[strSeries].Legend = strSeries;
					this.Chart2.Legends[strSeries].Title = strSeries;
                    Chart2.Legends[strSeries].Docking = Docking.Bottom; // LegendDocking.Bottom;


				} else {
				}
				///'''''''''*/add column for chart pie


				foreach (DataRow dr_loopVariable in ds.Tables[0].Rows) {
					dr = dr_loopVariable;
					//intPoint = Chart2.Series[strSeries].Points.AddXY(dr(getDimensionNameColumn(strDimension), dr(getMeasureNameColumn(strMeasure))))
					intPoint = Chart2.Series[strSeries].Points.AddXY(dr[getDimensionNameColumn(strDimenLV2)], dr[getMeasureNameColumn(strMesureID)]);
					Chart2.Series[strSeries].Points[intPoint].MapAreaAttributes = "onmouseover=\"window.status='" + dr["KPI"].ToString() + " " + dr[getDimensionNameColumn(strDimenLV2)].ToString() + " " + dr[getMeasureNameColumn(strMesureID)].ToString() + "'\"";

					//Chart2.Series[strSeries].Points[intPoint].Href = "javascript:getThirdLevel('" + strKPI + "_" + strDimenLV3 + "_" + strDimenLV2 + "_" + dr(getDimensionIDColumn(strDimenLV2)).ToString() + "_" + strYear + "')"
					//Chart2.Series[strSeries].Points[intPoint].ToolTip = ""

					///'''''''''''/* npkhoi add tooltip for chart and legend
					if (flagTypeChart) {
						Chart2.Series[strSeries].Points[intPoint].LegendToolTip = "#VAL{C}";
						Chart2.Series[strSeries].Points[intPoint].ToolTip = "#VAL{C}";
					} else {
						Chart2.Series[strSeries].Points[intPoint].ToolTip = "#LEGENDTEXT: #VAL{C}";
						Chart2.Series[strSeries].Points[intPoint].LegendText = dr["KPI"].ToString() + " " + dr[getDimensionNameColumn(strDimenLV2)];
						Chart2.Series[strSeries].Points[intPoint].LegendToolTip = "#VAL{C}";
					}
					///'''''''''''*/ add tooltip for chart and legend
				}

			} catch (Exception ex) {
			} finally {
				sqlCon.Close();
			}

			getChartType2(hdfTypeLV2.Value.Trim());
		}

	}

	/// <summary>
	/// Is type chart pie -npkhoi -10/14/2011
	/// </summary>
	/// <param name="flagTypeChart"></param>
	/// <returns>True</returns> if type chart =pie
	/// <remarks>False</remarks> if type chart !=pie
	/// 
	private bool checkTypeChart(string flagTypeChart)
	{
		int intWidget1 = 0;
		try {
			intWidget1 = Convert.ToInt32(flagTypeChart);

		} catch (Exception ex) {
		}
		//npkhoi : if axis # axis of column chart =true , else =false
		if ((intWidget1 == 17 | intWidget1 == 18 | intWidget1 == 35)) {
			return true;
		} else {
			return false;
		}
	}






    //public Interfaces_Dashboard_dasboard_mng_dashboard_mng()
    //{
    //    Load += Page_Load;
    //}

	//Private Sub showChart3()
	//    ''''''/*npkhoi -10/14/2011: check axis of chart, show kpi and year where type chart =pie
	//    Dim flagTypeChart As Boolean = checkTypeChart(hdfTypeLV3.Value.Trim)
	//    '''''''''''''''''''*/

	//    Dim strDimensionArr As String() = hdfDimension.Value.Split("#")
	//    If (strDimensionArr.Length > 1 And hdfLV3Value.Value.Length > 0) Then
	//        lblChart3.Text = hdfLV3Value.Value

	//        Dim arrValue As String() = hdfLV3Value.Value.Split("_")

	//        Dim strKPI As String = arrValue(0)
	//        Dim strDimenLV3 As String = arrValue(1)
	//        Dim strDimenLV2 As String = arrValue(2)
	//        Dim strDimenLV2Value As String = arrValue(3)
	//        Dim strYear As String = arrValue(4)

	//        Dim strMesureID As String = rblMeasure4.SelectedValue.ToString()
	//        Dim strFrom As String = strYear
	//        Dim strTo As String = strYear
	//        Dim strCurrentLevel As String = "3"
	//        Dim strKindOfTimeChart As String = rblType1.SelectedValue.ToString()
	//        Dim strSeries As String = strKPI
	//        Dim strDimenLV4 As String = ""

	//        strDimenLV2 = strDimensionArr(0)
	//        strDimenLV3 = strDimensionArr(1)

	//        Me.Chart3.Height = 400
	//        Dim strConn As String = "exec prc_DashboardManagement_GetDashboardController '" + strKPI + "'," + strMesureID + ",'" + strDimenLV3 + "','" + strDimenLV2 + "','" + strDimenLV2Value + "','',''," + strFrom + "," + strTo + "," + strCurrentLevel + "," + strKindOfTimeChart + ""

	//        Try
	//            sqlCon.Open()

	//            Dim da As SqlDataAdapter = New SqlDataAdapter(strConn, sqlCon)
	//            Dim ds As DataSet = New DataSet()
	//            Dim dr As DataRow
	//            da.Fill(ds)
	//            Dim intPoint As Integer

	//            If Not (seriesContains(strSeries)) Then
	//                Chart3.Series.Add(strSeries)

	//                '''''''''/* npkhoi -10/14/2011: if flag= true then add lengend = SeriesName else lengend = "Default"
	//                Dim secondLegend As Legend = New Legend(strSeries)
	//                If flagTypeChart Then
	//                    Me.Chart3.Legends.Add(secondLegend)
	//                Else
	//                    Me.Chart3.Legends.Add("Default")
	//                    Me.Chart3.Legends("Default").Docking = LegendDocking.Bottom
	//                End If
	//                ''''''*/
	//            End If


	//            ''''''''''''/*npkhoi -10/14/2011: add column for chart pie if flagTypeChart= true
	//            If flagTypeChart Then
	//                ' Add Color column
	//                Dim legendItem As New LegendItem
	//                Dim firstColumn As New LegendCellColumn()
	//                firstColumn.ColumnType = LegendCellColumnType.SeriesSymbol
	//                'firstColumn.HeaderText = strSeries
	//                firstColumn.HeaderBackColor = Color.WhiteSmoke

	//                Chart3.Legends(strSeries).CellColumns.Add(firstColumn)

	//                'Me.Chart1.Series[strSeries].Legend = strSeries

	//                ' Add Legend Text column

	//                Dim secondColumn As New LegendCellColumn()
	//                secondColumn.ColumnType = LegendCellColumnType.Text
	//                secondColumn.HeaderText = "" 'strSeries
	//                secondColumn.Text = "#VALX" 'flagTrue only
	//                secondColumn.HeaderBackColor = Color.WhiteSmoke
	//                Chart3.Legends(strSeries).CellColumns.Add(secondColumn)

	//                Me.Chart3.Series[strSeries].Legend = strSeries
	//                Me.Chart3.Legends(strSeries).Title = strSeries
	//                Chart3.Legends(strSeries).Docking = LegendDocking.Bottom

	//            Else

	//            End If
	//            ''''''''''''*/add column for chart pie

	//            For Each dr In ds.Tables(0).Rows
	//                'intPoint = Chart3.Series[strSeries].Points.AddXY(dr(getDimensionNameColumn(strDimension), dr(getMeasureNameColumn(strMeasure))))
	//                intPoint = Chart3.Series[strSeries].Points.AddXY(dr(getDimensionNameColumn(strDimenLV3)), dr(getMeasureNameColumn(strMesureID)))
	//                Chart3.Series[strSeries].Points[intPoint].MapAreaAttributes = "onmouseover=""window.status='" + dr("KPI").ToString() + " " + dr(getDimensionNameColumn(strDimenLV3)).ToString() + " " + dr(getMeasureNameColumn(strMesureID)).ToString() + "'"""
	//                'Chart3.Series[strSeries].Points[intPoint].MapAreaAttributes = "onmouseover=getDetails()"
	//                'Chart3.Series[strSeries].Points[intPoint].Href = "newDashLV2.aspx?kpi=" + dr("KPI").ToString() + "&year=" + dr("Year").ToString() + "&dimen=" + strDimension + ""
	//                Chart3.Series[strSeries].Points[intPoint].Href = "javascript:getFourLevel('" + strKPI + "_" + strDimenLV4 + "_" + strDimenLV2 + "_" + strDimenLV2Value + "_" + strDimenLV3 + "_" + dr(getDimensionIDColumn(strDimenLV3)).ToString() + "_" + strYear + "')"
	//                ' Chart3.Series[strSeries].Points[intPoint].ToolTip = ""

	//                ''''''''''''''/*npkhoi -10/14/2011: add tooltip for chart and legend
	//                If flagTypeChart Then
	//                    Chart3.Series[strSeries].Points[intPoint].LegendToolTip = "#VAL{C}"
	//                    Chart3.Series[strSeries].Points[intPoint].ToolTip = "#VAL{C}"
	//                Else
	//                    Chart3.Series[strSeries].Points[intPoint].ToolTip = "#LEGENDTEXT: #VAL{C}"
	//                    Chart3.Series[strSeries].Points[intPoint].LegendText = dr("KPI").ToString() + " " + dr(getDimensionNameColumn(strDimenLV3))
	//                    Chart3.Series[strSeries].Points[intPoint].LegendToolTip = "#VAL{C}"
	//                End If
	//                ''''''''''''''*/ add tooltip for chart and legend


	//            Next

	//        Catch ex As Exception

	//        Finally
	//            sqlCon.Close()
	//        End Try

	//        getChartType3(hdfTypeLV3.Value.Trim())
	//    End If

	//End Sub

	//Private Sub showChart4()
	//    ''''''/*npkhoi -10/14/2011: check axis of chart, show kpi and year where type chart =pie
	//    Dim flagTypeChart As Boolean = checkTypeChart(hdfTypeLV4.Value.Trim)
	//    '''''''''''''''''''*/
	//    Dim strDimensionArr As String() = hdfDimension.Value.Split("#")
	//    If (strDimensionArr.Length > 2 And hdfLV4Value.Value.Length > 0) Then
	//        lblChart4.Text = hdfLV3Value.Value


	//        Dim arrValue As String() = hdfLV4Value.Value.Split("_")

	//        Dim strKPI As String = arrValue(0)
	//        Dim strDimenLV4 As String = arrValue(1)
	//        Dim strDimenLV2 As String = arrValue(2)
	//        Dim strDimenLV2Value As String = arrValue(3)
	//        Dim strDimenLV3 As String = arrValue(4)
	//        Dim strDimenLV3Value As String = arrValue(5)
	//        Dim strYear As String = arrValue(6)



	//        Dim strMesureID As String = rblMeasure4.SelectedValue.ToString()
	//        Dim strFrom As String = strYear
	//        Dim strTo As String = strYear
	//        Dim strCurrentLevel As String = "4"
	//        Dim strKindOfTimeChart As String = rblType1.SelectedValue.ToString()
	//        Dim strSeries As String = strKPI
	//        Dim strDimenLV5 As String = ""

	//        strDimenLV2 = strDimensionArr(0)
	//        strDimenLV3 = strDimensionArr(1)
	//        strDimenLV4 = strDimensionArr(2)

	//        Me.Chart4.Height = 400
	//        Dim strConn As String = "exec prc_DashboardManagement_GetDashboardController '" + strKPI + "'," + strMesureID + ",'" + strDimenLV4 + "','" + strDimenLV2 + "','" + strDimenLV2Value + "','" + strDimenLV3 + "','" + strDimenLV3Value + "'," + strFrom + "," + strTo + "," + strCurrentLevel + "," + strKindOfTimeChart + ""

	//        Try
	//            sqlCon.Open()

	//            Dim da As SqlDataAdapter = New SqlDataAdapter(strConn, sqlCon)
	//            Dim ds As DataSet = New DataSet()
	//            Dim dr As DataRow
	//            da.Fill(ds)
	//            Dim intPoint As Integer

	//            If Not (seriesContains(strSeries)) Then
	//                Chart4.Series.Add(strSeries)

	//                '''''''''/* npkhoi -10/14/2011: if flag= true then add lengend = SeriesName else lengend = "Default"
	//                Dim secondLegend As Legend = New Legend(strSeries)
	//                If flagTypeChart Then
	//                    Me.Chart4.Legends.Add(secondLegend)
	//                Else
	//                    Me.Chart4.Legends.Add("Default")
	//                    Me.Chart4.Legends("Default").Docking = LegendDocking.Bottom
	//                End If
	//                ''''''*/
	//            End If

	//            ''''''''''''/*npkhoi add column for chart pie if flagTypeChart= true
	//            If flagTypeChart Then
	//                ' Add Color column
	//                Dim legendItem As New LegendItem
	//                Dim firstColumn As New LegendCellColumn()
	//                firstColumn.ColumnType = LegendCellColumnType.SeriesSymbol
	//                firstColumn.HeaderBackColor = Color.WhiteSmoke
	//                Me.Chart4.Legends(strSeries).CellColumns.Add(firstColumn)



	//                ' Add Legend Text column

	//                Dim secondColumn As New LegendCellColumn()
	//                secondColumn.ColumnType = LegendCellColumnType.Text
	//                secondColumn.HeaderText = "" 'strSeries
	//                secondColumn.Text = "#VALX" 'flagTrue only
	//                secondColumn.HeaderBackColor = Color.WhiteSmoke
	//                Me.Chart4.Legends(strSeries).CellColumns.Add(secondColumn)

	//                Me.Chart4.Series[strSeries].Legend = strSeries
	//                Me.Chart4.Legends(strSeries).Title = strSeries
	//                Me.Chart4.Legends(strSeries).Docking = LegendDocking.Bottom

	//            Else

	//            End If
	//            ''''''''''''*/add column for chart pie


	//            For Each dr In ds.Tables(0).Rows
	//                'intPoint = Chart4.Series[strSeries].Points.AddXY(dr(getDimensionNameColumn(strDimension), dr(getMeasureNameColumn(strMeasure))))
	//                intPoint = Chart4.Series[strSeries].Points.AddXY(dr(getDimensionNameColumn(strDimenLV4)), dr(getMeasureNameColumn(strMesureID)))
	//                Chart4.Series[strSeries].Points[intPoint].MapAreaAttributes = "onmouseover=""window.status='" + dr("KPI").ToString() + " " + dr(getDimensionNameColumn(strDimenLV4)).ToString() + " " + dr(getMeasureNameColumn(strMesureID)).ToString() + "'"""
	//                'Chart4.Series[strSeries].Points[intPoint].Href = "javascript:getFourLevel('" + strKPI + "_" + strDimenLV5 + "_" + strDimenLV4 + "_" + dr(getDimensionIDColumn(strDimenLV4)).ToString() + "')"
	//                'Chart4.Series[strSeries].Points[intPoint].ToolTip = ""

	//                ''''''''''''''/*npkhoi -10/14/2011: add tooltip for chart and legend
	//                If flagTypeChart Then
	//                    Chart4.Series[strSeries].Points[intPoint].LegendToolTip = "#VAL{C}"
	//                    Chart3.Series[strSeries].Points[intPoint].ToolTip = "#VAL{C}"
	//                Else
	//                    Chart4.Series[strSeries].Points[intPoint].ToolTip = "#LEGENDTEXT: #VAL{C}"
	//                    Chart4.Series[strSeries].Points[intPoint].LegendText = dr("KPI").ToString() + " " + dr(getDimensionNameColumn(strDimenLV4))
	//                    Chart4.Series[strSeries].Points[intPoint].LegendToolTip = "#VAL{C}"
	//                End If
	//                ''''''''''''''*/ add tooltip for chart and legend
	//            Next
	//        Catch ex As Exception
	//        Finally
	//            sqlCon.Close()
	//        End Try

	//        getChartType4(hdfTypeLV4.Value.Trim())
	//    End If

	//End Sub

	#endregion





}

}
