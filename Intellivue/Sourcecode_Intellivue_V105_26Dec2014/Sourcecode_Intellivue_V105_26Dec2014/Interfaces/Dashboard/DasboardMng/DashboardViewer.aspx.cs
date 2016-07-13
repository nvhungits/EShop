using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
//using Microsoft.VisualBasic;
//using System;
using System.Collections;
//using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
//using Dundas.Charting.WebControl;
using System.Drawing;
//
using Sourcecode_Intellivue.lib;
using System.Web.UI.DataVisualization;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;
namespace Sourcecode_Intellivue.Interfaces.Dashboard.DasboardMng
{


public partial class DashboardViewer : CoreClass
{
	SqlConnection sqlCon;// = fsDatabaseConnection();
	DataTable dt = new DataTable();
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
			string accessright = GlobalClass.GetAccessRight("D2");
			if (accessright == "F") {
				string strscript = "<script>alert('You are not authorization for this page!');window.location.href='../pgHomePage.aspx'</script>";
				if (!ClientScript.IsClientScriptBlockRegistered("clientscript")) {
					ClientScript.RegisterStartupScript(this.GetType(), "clientscript", strscript);
				}
			}
			userId_edit =(string) Session["userId"];


		}
		if (!IsPostBack) {
			loadDashboardList();

			if ((Page.Request["dashID"] != null)) {
				if ((Page.Request["dashID"] != null)) {
					lblDashboard.Text = this.Page.Request["dashName"].ToString() + " (Level 1)";
				}
				showDrawChart(int.Parse(this.Page.Request["dashID"].ToString()));
			}
			//'EmployeeDetails.Visible = False


		}
		if (IsPostBack) {
			//loadAdviser()

		}

	}


	protected void loadDashboardList()
	{
		string sql = null;
		SqlCommand cmd = null;
		int dashID = 0;
		SqlDataAdapter da = null;
		SqlConnection con = fsDatabaseConnection();
		try {
			dashID = 0;
			sql = "prc_DashboardManagement_GetDashboardList";
			sqlCon.Open();
			cmd = new SqlCommand(sql, sqlCon);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@DASH_ID", dashID);
			SqlDataReader rs = cmd.ExecuteReader();
			while ((rs.Read())) {
				ddlDashboardList.Items.Add(new ListItem(rs["DASH_NAME"].ToString(), rs["DASH_ID"].ToString()));
			}

			///''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			sqlCon.Close();

		} catch (Exception ex) {
		}
	}

	protected void showDrawChart(int dashID)
	{
		string sql = null;
		SqlDataAdapter da1 = null;
		DataSet ds1 = null;
		DataRow dr1 = null;
		int i = 0;

		string KPICategory = null;
		int fromYear = 0;
		int toYear = 0;
		string KPI = null;
		string dimension = null;
		int measureID = 0;
		string saleType = null;
		string dashName = null;

		try {
			sql = "exec prc_DashboardManagement_GetDashboardWidgetList '" + dashID.ToString() + "'";
			sqlCon.Open();
			i = 0;

			da1 = new SqlDataAdapter(sql, sqlCon);
			ds1 = new DataSet();
			da1.Fill(ds1);

			foreach (DataRow dr1_loopVariable in ds1.Tables[0].Rows) {
				dr1 = dr1_loopVariable;
				if (dr1["WIDGET_NAME"].ToString() == "Widget 1") {
					KPICategory = dr1["KPI_CATG"].ToString();
					fromYear = int.Parse(dr1["FROM_YEAR"].ToString());
					toYear = int.Parse(dr1["TO_YEAR"].ToString());
					KPI = dr1["KPI"].ToString().Replace("#", "_");
					dimension = dr1["DIM_ID"].ToString().Replace("#", "_");
					measureID = int.Parse(dr1["MEASURE_ID"].ToString());
					saleType = dr1["SALE_TYPE"].ToString();
					dashName = dr1["DASH_NAME"].ToString();

                    showChart(KPI, measureID.ToString(), dimension, "", "", "", "", fromYear.ToString(), toYear.ToString(), "1",
					saleType, Chart1, measureID, saleType, dimension, dashID, dashName);
					Chart1.DataBind();
				} else if (dr1["WIDGET_NAME"].ToString() == "Widget 2") {
					KPICategory = dr1["KPI_CATG"].ToString();
					fromYear = int.Parse(dr1["FROM_YEAR"].ToString());
					toYear = int.Parse(dr1["TO_YEAR"].ToString());
					KPI = dr1["KPI"].ToString().Replace("#", "_");
					dimension = dr1["DIM_ID"].ToString().Replace("#", "_");
					measureID = int.Parse(dr1["MEASURE_ID"].ToString());
					saleType = dr1["SALE_TYPE"].ToString();
					dashName = dr1["DASH_NAME"].ToString();

                    showChart(KPI, measureID.ToString(), dimension, "", "", "", "", fromYear.ToString(), toYear.ToString(), "1",
					saleType, Chart2, measureID, saleType, dimension, dashID, dashName);
					Chart2.DataBind();

				}
			}


		} catch (Exception ex) {
		} finally {
			sqlCon.Close();
		}
	}



	private void showChart(string strKPI, string strMesureID, string strCurDimension, string strPreDimesionLV1, string strPreDimesionLV1ValueSelected, string strPreDimesionLV2, string strPreDimesionLV2ValueSelected, string strFrom, string strTo, string strCurrentLevel,
	string strKindOfTimeChart, Chart chartName, int measureID, string saleType, string dimension, int dashID, string dashName)
	{
		string[] strKPIArray = null;

		strKPIArray = strKPI.Split('_');

		for (int i = 0; i <= strKPIArray.Length - 1; i++) {
			loadChartData("exec prc_DashboardManagement_GetDashboardController '" + strKPIArray[i] + "',12,'" + strCurDimension + "','','','',''," + strFrom + "," + strTo + ",1," + strKindOfTimeChart + "", strKPIArray[i], strCurDimension, chartName, measureID, saleType, dimension, dashID, dashName);
		}

		if (Chart1.Series.Count > 0) {
			getChartType(hdfTypeLV1.Value.Trim(), Chart1, rdb3d1);
		}
		if (Chart2.Series.Count > 0) {
			getChartType(hdfTypeLV2.Value.Trim(), Chart2, rdb3d2);
		}
		//If Chart3.Series.Count > 0 Then
		//    getChartType(hdfTypeLV3.Value.Trim(), Chart3, rdb3d3)
		//End If


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
	private void loadChartData(string strGetData, string strSeries, string strDimension, Chart chartName, int measureID, string saleType, string dimension, int dashID, string dashName)
	{
		///'''/*npkhoi: check axis of chart, show kpi and year where type chart =pie
		bool flagTypeChart = checkTypeChart(hdfTypeLV1.Value.Trim());
		///''''''''''''''''*/
		loadDashboardGrid(ref strGetData);

		try {
			SqlDataAdapter da = new SqlDataAdapter(strGetData, sqlCon);
			DataSet ds = new DataSet();
			DataRow dr = null;
			da.Fill(ds);
			int intPoint = 0;


			if (!(seriesContains(strSeries, chartName))) {
				Legend secondLegend = new Legend(strSeries);
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
                    this.Chart1.Legends.Add(strSeries);
                    this.Chart1.Legends[strSeries].Docking = Docking.Bottom;
				}

				//chartName.Series.Add(strSeries)
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
				//Me.Chart1.Legends(strSeries).Title = strSeries
				Chart1.Legends[strSeries].Docking = Docking.Bottom;


			} else {
			}
			foreach (DataRow dr_loopVariable in ds.Tables[0].Rows) {
				dr = dr_loopVariable;
				//Dim legendItem As New LegendItem
				//Chart1.Series[strSeries].LegendText = dr("KPI").ToString()
				if (flagTypeChart) {
					intPoint = Chart1.Series["Default"].Points.AddXY(dr["Year"], dr["SALE_AMT"]);
					Chart1.Series["Default"].Points[intPoint].MapAreaAttributes = "onmouseover=\"window.status='" + dr["KPI"].ToString() + " " + dr["Year"].ToString() + " " + dr["SALE_AMT"].ToString() + "'\"";
					//Chart1.Series["Default"].Points[intPoint].Href = "DashboardViewerSecond.aspx?kpi=" + dr["KPI"].ToString() + "&year=" + dr["Year"].ToString() + "&dimen=" + strDimension + "&measure=" + measureID.ToString() + "&saleType=" + saleType + "&dimension=" + dimension + "&dashID=" + dashID.ToString() + "&dashName=" + dashName + "";
                    Chart1.Series["Default"].Points[intPoint].Url = "DashboardViewerSecond.aspx?kpi=" + dr["KPI"].ToString() + "&year=" + dr["Year"].ToString() + "&dimen=" + strDimension + "&measure=" + measureID.ToString() + "&saleType=" + saleType + "&dimension=" + dimension + "&dashID=" + dashID.ToString() + "&dashName=" + dashName + "";
					Chart1.Series["Default"].Points[intPoint].LegendText = dr["KPI"].ToString() + " " + dr["Year"].ToString();
					Chart1.Series["Default"].Points[intPoint].LegendToolTip = "#VAL{C}";
					Chart1.Series["Default"].Points[intPoint].ToolTip = "#LEGENDTEXT: #VAL{C}";
                    //
                    Chart1.Series["Default"].Points[intPoint].MapAreaAttributes = "onmouseover=\"test('" + dr["KPI"].ToString() + "','" + dr["Year"].ToString() + "','" + strDimension + "','" + measureID.ToString() + "','" + saleType + "','" + dimension + "','" + dashID.ToString() + "')\"";

				} else {
					//intPoint = Chart1.Series[strSeries].Points.AddXY(dr("Year"), dr("SALE_AMT"))
					//Chart1.Series[strSeries].Points[intPoint].MapAreaAttributes = "onmouseover=""window.status='" + dr("KPI").ToString() + " " + dr("Year").ToString() + " " + dr("SALE_AMT").ToString() + "'"""
					//'Chart1.Series[strSeries].Points[intPoint].MapAreaAttributes = "onmouseover=getDetails()"
					//'Chart1.Series[strSeries].Points[intPoint].Href = "newDashLV2.aspx?kpi=" + dr("KPI").ToString() + "&year=" + dr("Year").ToString() + "&dimen=" + strDimension + ""
					//Chart1.Series[strSeries].Points[intPoint].Href = "javascript:getSecondLevel('" + dr("KPI").ToString() + "','" + dr("Year").ToString() + "','" + strDimension + "')"
					//Chart1.Series[strSeries].Points[intPoint].ToolTip = "#LEGENDTEXT: #VAL{C}"
					//Chart1.Series[strSeries].Points[intPoint].LegendText = dr("KPI").ToString() + " " + dr("Year").ToString()
					//Chart1.Series[strSeries].Points[intPoint].LegendToolTip = "#VAL{C}"
					intPoint = chartName.Series[strSeries].Points.AddXY(dr["Year"], dr["SALE_AMT"]);
					//chartName.Series[strSeries].Points[intPoint].MapAreaAttributes = "onmouseover=""window.status='" + dr("KPI").ToString() + " " + dr("Year").ToString() + " " + dr("SALE_AMT").ToString() + "'"""

                    chartName.Series[strSeries].Points[intPoint].MapAreaAttributes = "onmouseover=\"test('" + dr["KPI"].ToString() + "','" + dr["Year"].ToString() + "','" + strDimension + "','" + measureID.ToString() + "','" + saleType + "','" + dimension + "','" + dashID.ToString() + "')\"";

					//chartName.Series[strSeries].Points[intPoint].Href = "DashboardViewerSecond.aspx?kpi=" + dr["KPI"].ToString() + "&year=" + dr["Year"].ToString() + "&dimen=" + strDimension + "&measure=" + measureID.ToString() + "&saleType=" + saleType + "&dimension=" + dimension + "&dashID=" + dashID.ToString() + "&dashName=" + dashName + "";
                    chartName.Series[strSeries].Points[intPoint].Url = "DashboardViewerSecond.aspx?kpi=" + dr["KPI"].ToString() + "&year=" + dr["Year"].ToString() + "&dimen=" + strDimension + "&measure=" + measureID.ToString() + "&saleType=" + saleType + "&dimension=" + dimension + "&dashID=" + dashID.ToString() + "&dashName=" + dashName + "";
					//Chart1.Series[strSeries].Points[intPoint].Href = "javascript:getSecondLevel('" + dr("KPI").ToString() + "','" + dr("Year").ToString() + "','" + strDimension + "')"
					chartName.Series[strSeries].Points[intPoint].ToolTip = "KPI: " + dr["KPI"].ToString() + " Year: " + dr["Year"].ToString() + " Value: " + dr["SALE_AMT"].ToString() + "";
				}
			}
		//For Each dr In ds.Tables(0).Rows
		//    intPoint = chartName.Series[strSeries].Points.AddXY(dr("Year"), dr("SALE_AMT"))
		//    chartName.Series[strSeries].Points[intPoint].MapAreaAttributes = "onmouseover=""window.status='" + dr("KPI").ToString() + " " + dr("Year").ToString() + " " + dr("SALE_AMT").ToString() + "'"""
		//    chartName.Series[strSeries].Points[intPoint].Href = "DashboardViewerSecond.aspx?kpi=" + dr("KPI").ToString() + "&year=" + dr("Year").ToString() + "&dimen=" + strDimension + "&measure=" + measureID.ToString + "&saleType=" + saleType + "&dimension=" + dimension + "&dashID=" + dashID.ToString + "&dashName=" + dashName + ""
		//    'Chart1.Series[strSeries].Points[intPoint].Href = "javascript:getSecondLevel('" + dr("KPI").ToString() + "','" + dr("Year").ToString() + "','" + strDimension + "')"
		//    chartName.Series[strSeries].Points[intPoint].ToolTip = "KPI: " + dr("KPI").ToString() + " Year: " + dr("Year").ToString() + " Value: " + dr("SALE_AMT").ToString() + ""
		//Next



		} catch (Exception ex) {

		} finally {
		}
	}

	private void getChartType(string strValue, Chart chartTemp, HtmlInputRadioButton radioTemp)
	{

		try {
			foreach (Series series in chartTemp.Series) {
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
					//    series.Type = SeriesChartType.FastPoint
					case "35":
						series.ChartType = SeriesChartType.Funnel;
						break;
					case "23":
                        series.ChartType = SeriesChartType.RangeBar;//Gantt;
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

			if ((radioTemp.Checked)) {
				chartTemp.ChartAreas["Default"].Area3DStyle.Enable3D = true;
			} else {
				chartTemp.ChartAreas["Default"].Area3DStyle.Enable3D = false;
			}

			chartTemp.ChartAreas["Default"].BackColor = System.Drawing.Color.LightBlue;
			chartTemp.ChartAreas["Default"].BackSecondaryColor = System.Drawing.Color.White;
			chartTemp.ChartAreas["Default"].BackGradientStyle = GradientStyle.TopBottom;

		} catch (Exception ex) {
			//lblMessage.Text = "Data is not available for this Chart."
		}
	}

	public bool seriesContains(string name, Chart chartName)
	{
		try {
			string strName = chartName.Series["name"].Name;
		} catch (Exception ex) {
			return false;
		}
		return true;
	}

	protected void ddlDashboardList_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		try {
			lblDashboard.Text = ddlDashboardList.SelectedItem.ToString() + " (Level 1)";
			showDrawChart(int.Parse(ddlDashboardList.SelectedValue.ToString()));

		} catch (Exception ex) {
		}
	}

	protected void btnLV1_Click(object sender, System.EventArgs e)
	{
		try {
			showDrawChart(int.Parse(ddlDashboardList.SelectedValue.ToString()));

			if ((dashID.Value.ToString() != null)) {
				//testShowChart(ref kpi.Value, year.Value, strDimension.Value, strMesureID.Value, strKindOfTimeChart.Value, strDimensionArr.Value);
                testShowChart(kpi.Value, year.Value, strDimension.Value, strMesureID.Value, strKindOfTimeChart.Value, strDimensionArr.Value);
			}


		} catch (Exception ex) {
		}

	}
	protected void btnLV2_Click(object sender, System.EventArgs e)
	{
		try {
			//testShowChart(ref kpi.Value, year.Value, strDimension.Value, strMesureID.Value, strKindOfTimeChart.Value, strDimensionArr.Value);
            testShowChart(kpi.Value, year.Value, strDimension.Value, strMesureID.Value, strKindOfTimeChart.Value, strDimensionArr.Value);
			showDrawChart(int.Parse(dashID.Value));

		} catch (Exception ex) {
		}

	}
	//Protected Sub btnLV3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLV3.Click
	//    Try
	//        showDrawChart(Integer.Parse(ddlDashboardList.SelectedValue.ToString))


	//    Catch ex As Exception

	//    End Try

	//End Sub
	//Protected Sub showAdviserDetail(ByVal AdviserID As String)
	//    Dim con As SqlConnection = fsDatabaseConnection()
	//    Try
	//        con.Open()

	//        Dim da As New SqlDataAdapter("prc_ViewDashboard_Adviser_Details '" + AdviserID + "'", con)
	//        Dim ds As New DataSet
	//        da.Fill(ds)
	//        Dim dr As DataRow = ds.Tables(0).Rows(0)

	//        lblAdviserName.Text = dr("ADVSR_FIRSTNAME") + " " + dr("ADVSR_LASTNAME")
	//        lblAdviserGroupName.Text = dr("ADVSR_PRNT_NAME")
	//        lblNoOfAccounts.Text = dr("NumberOfAccounts")
	//        EmployeeImage.ImageUrl = dr("ImagePath")
	//        lblEmail.Text = dr("EmailAddr1")
	//        lblAddress.Text = dr("Addrline1")
	//        lblMobile.Text = dr("Mobile")
	//        DataBind()
	//        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

	//    Catch ex As Exception

	//    Finally
	//        con.Close()
	//    End Try
	//End Sub

	//This is for test show Chart 2
	private void testShowChart(string strKPI, string strYear, string strDimension, string strMesureID, string strKindOfTimeChart, string strDimensionBeforeSplit)
	{

		string[] strDimensionArr = null;


		string strFrom = strYear;
		string strTo = strYear;
		string strCurrentLevel = "2";
		//If (Page.Request("saleType") <> Nothing) Then
		//    strKindOfTimeChart = Me.Page.Request("saleType").ToString()
		//End If

		string strSeries = strKPI;
		string strDimenLV2 = "";
		string strDimenLV3 = "";

		//If (Page.Request("dimension") <> Nothing) Then
		//    strDimensionArr = Me.Page.Request("dimension").ToString.Split("_")
		//End If

		strDimensionArr = strDimensionBeforeSplit.Split('_');

		if ((strDimensionArr.Length > 0)) {
			strDimenLV2 = strDimensionArr[0];

			//lblDashboard.Text = lblDashboard.Text + " by " + getDimensionPrettyName(strDimenLV2)

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
				}


				foreach (DataRow dr_loopVariable in ds.Tables[0].Rows) {
					dr = dr_loopVariable;
					intPoint = Chart2.Series[strSeries].Points.AddXY(dr[getDimensionNameColumn(strDimenLV2)], dr[getMeasureNameColumn(strMesureID)]);
					Chart2.Series[strSeries].Points[intPoint].MapAreaAttributes = "onmouseover=\"window.status='" + dr["KPI"].ToString() + " " + dr[getDimensionNameColumn(strDimenLV2)].ToString() + " " + dr[getMeasureNameColumn(strMesureID)].ToString() + "'\"";

					//Chart.Series[strSeries].Points[intPoint].Href = "javascript:getThirdLevel('" + strKPI + "_" + strDimenLV3 + "_" + strDimenLV2 + "_" + dr(getDimensionIDColumn(strDimenLV2)).ToString() + "_" + strYear + "')"
					Chart2.Series[strSeries].Points[intPoint].ToolTip = "" + dr[getDimensionNameColumn(strDimenLV2)].ToString() + ": " + dr[getMeasureNameColumn(strMesureID)].ToString() + "";
					//load level3 if have dimension
					if ((strDimensionArr.Length > 1)) {
						string removedLevel = "(Level 1)";
                        string dashName = lblDashboard.Text.Replace(removedLevel, "");// String.Replace(lblDashboard.Text, removedLevel, "");
                        
						dashName.Trim();

						//Chart2.Series[strSeries].Points[intPoint].Href = "DashboardViewerThird.aspx?kpi=" + strKPI + "&measure=" + strMesureID + "&dimenlv3=" + strDimenLV3 + "&dimenlv2=" + strDimenLV2 + "&dimenlv2value=" + dr[getDimensionIDColumn(strDimenLV2)].ToString() + "&year=" + strYear + "&dimension=" + strDimensionBeforeSplit + "&dashname=" + dashName + "";
                        Chart2.Series[strSeries].Points[intPoint].Url = "DashboardViewerThird.aspx?kpi=" + strKPI + "&measure=" + strMesureID + "&dimenlv3=" + strDimenLV3 + "&dimenlv2=" + strDimenLV2 + "&dimenlv2value=" + dr[getDimensionIDColumn(strDimenLV2)].ToString() + "&year=" + strYear + "&dimension=" + strDimensionBeforeSplit + "&dashname=" + dashName + "";
					}
				}


			} catch (Exception ex) {
			} finally {
				sqlCon.Close();
			}

			getChartType(hdfTypeLV2.Value.Trim(), Chart2, rdb3d2);

		}

	}

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

	public bool seriesContains(string name)
	{
		try {
			string strName = Chart2.Series["name"].Name;
		} catch (Exception ex) {
			return false;
		}
		return true;
	}

	protected void btnLV5_Click(object sender, System.EventArgs e)
	{

		try {

			//testShowChart(ref kpi.Value, year.Value, strDimension.Value, strMesureID.Value, strKindOfTimeChart.Value, strDimensionArr.Value);
            testShowChart(kpi.Value, year.Value, strDimension.Value, strMesureID.Value, strKindOfTimeChart.Value, strDimensionArr.Value);
			showDrawChart(int.Parse(dashID.Value));


		} catch (Exception ex) {
		}

	}


	protected void loadAdviser()
	{
		//Dim sql As String
		//Dim cmd As SqlCommand
		//Dim dashID As Integer
		//Dim da As SqlDataAdapter
		//Dim con As SqlConnection = fsDatabaseConnection()
		//Try

		//    'Adviser's performance
		//    da = New SqlDataAdapter("prc_ViewDashboard_Adviser_Performance", con)
		//    Dim ds As New DataSet
		//    Dim dr As DataRow
		//    Dim pidx As Integer
		//    Dim j As Integer
		//    da.Fill(ds)

		//    For Each dr In ds.Tables(0).Rows
		//        pidx = Chart3.Series("Series1").Points.AddXY(dr("ADVSR_FIRSTNAME"), dr("Performance"))
		//        Chart3.Series("Series1").Points(pidx).MapAreaAttributes = String.Format("onmouseover=""dispEmp({0})"" ", dr("ADVSR_IDNF"))
		//    Next

		//    For j = 0 To Chart3.Series("Series1").Points.Count - 1
		//        Chart3.Series("Series1").Points(j).ToolTip = "#VALY{C}"
		//    Next

		//    txtBestAdviser.Value = ds.Tables(0).Rows(4)("ADVSR_IDNF")
		//    Dim src As String
		//    src = "../Dundas/AdviserDetails.aspx?AdviserID=" + txtBestAdviser.Value
		//    'EmployeeDetails.InnerHtml("scr = ../Dundas/AdviserDetails.aspx?AdviserID=" + AdviserID)
		//    'Dim EmployeeDetails As HtmlControl = (HtmlControl) me.FindControl("EmployeeDetails")
		//    'me.EmployeeDetails.Attributes["src"] = src.ToString()
		//    'showAdviserDetail(ds.Tables(0).Rows(4)("ADVSR_IDNF"))
		//    Chart3.DataBind()
		//    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		//    sqlCon.Close()
		//Catch ex As Exception

		//End Try

	}

	protected void loadDashboardGrid(ref string getDataQuery)
	{


		try {
			//sqlCon.Open()

			SqlDataAdapter dataadap = new SqlDataAdapter(getDataQuery, sqlCon);
			DataSet dataset = new DataSet();
			dataadap.Fill(dataset, "UserInfo");

			DataRow row1 = dt.NewRow();
			DataTable tempTable = dataset.Tables["UserInfo"];
			dt.Merge(tempTable);
			Session["ChartData"] = dt;
			grdDashboardData.DataSource = dt.DefaultView;
			grdDashboardData.DataBind();



		} catch (Exception ex) {
		} finally {
			//sqlCon.Close()
		}

	}


	protected void grdDashboardData_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
	{
		DataTable mytable = null;

		mytable = (DataTable)Session["ChartData"];
		grdDashboardData.DataSource = mytable.DefaultView;
		grdDashboardData.DataBind();

		grdDashboardData.PageIndex = e.NewPageIndex;

		grdDashboardData.DataBind();
	}


	protected void grdDashboardData_SelectedIndexChanged(object sender, System.EventArgs e)
	{
	}


    //public Interfaces_Dashboard_dasboard_mng_DashboardViewer()
    //{
    //    Load += Page_Load;
    //}
}
}
