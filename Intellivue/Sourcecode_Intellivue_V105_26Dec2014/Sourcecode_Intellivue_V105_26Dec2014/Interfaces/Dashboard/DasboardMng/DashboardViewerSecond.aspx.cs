﻿using System;
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
using System.Data.SqlClient;
//using Dundas.Charting.WebControl;
//
using Sourcecode_Intellivue.lib;
using System.Web.UI.DataVisualization;
using System.Web.UI.DataVisualization.Charting;
namespace Sourcecode_Intellivue.Interfaces.Dashboard.DasboardMng
{


    public partial class DashboardViewerSecond : CoreClass
    {

        SqlConnection sqlCon;// = fsDatabaseConnection();
        protected void Page_Load(object sender, System.EventArgs e)
        {
            sqlCon = fsDatabaseConnection();
            if (!IsPostBack)
            {
                showChart();
            }
        }

        private void showChart()
        {
            string strKPI = "";
            string strYear = "";
            string strDimension = "";
            string strMesureID = "";
            string strKindOfTimeChart = "";
            string[] strDimensionArr = null;

            if ((Page.Request["dashName"] != null))
            {
                lblDashboard.Text = this.Page.Request["dashName"].ToString() + " (Level 2)";
            }

            if ((Page.Request["kpi"] != null))
            {
                strKPI = this.Page.Request["kpi"].ToString();
            }
            if ((Page.Request["year"] != null))
            {
                strYear = this.Page.Request["year"].ToString();
            }
            if ((Page.Request["dimen"] != null))
            {
                strDimension = this.Page.Request["dimen"].ToString();
            }

            if ((Page.Request["measure"] != null))
            {
                strMesureID = this.Page.Request["measure"].ToString();
            }

            string strFrom = strYear;
            string strTo = strYear;
            string strCurrentLevel = "2";
            if ((Page.Request["saleType"] != null))
            {
                strKindOfTimeChart = this.Page.Request["saleType"].ToString();
            }

            string strSeries = strKPI;
            string strDimenLV2 = "";
            string strDimenLV3 = "";

            if ((Page.Request["dimension"] != null))
            {
                strDimensionArr = this.Page.Request["dimension"].ToString().Split('_');
            }

            if ((strDimensionArr.Length > 0))
            {
                strDimenLV2 = strDimensionArr[0];

                lblDashboard.Text = lblDashboard.Text + " by " + getDimensionPrettyName(strDimenLV2);

                string strConn = "exec prc_DashboardManagement_GetDashboardController '" + strKPI + "'," + strMesureID + ",'" + strDimenLV2 + "','','','',''," + strFrom + "," + strTo + "," + strCurrentLevel + "," + strKindOfTimeChart + "";

                try
                {
                    sqlCon.Open();

                    SqlDataAdapter da = new SqlDataAdapter(strConn, sqlCon);
                    DataSet ds = new DataSet();
                    DataRow dr = null;
                    da.Fill(ds);
                    int intPoint = 0;

                    if (!(seriesContains(strSeries)))
                    {
                        Chart.Series.Add(strSeries);
                    }


                    foreach (DataRow dr_loopVariable in ds.Tables[0].Rows)
                    {
                        dr = dr_loopVariable;
                        intPoint = Chart.Series[strSeries].Points.AddXY(dr[getDimensionNameColumn(strDimenLV2)], dr[getMeasureNameColumn(strMesureID.ToString())]);
                        Chart.Series[strSeries].Points[intPoint].MapAreaAttributes = "onmouseover=\"window.status='" + dr["KPI"].ToString() + " " + dr[getDimensionNameColumn(strDimenLV2)].ToString() + " " + dr[getMeasureNameColumn(strMesureID)].ToString() + "'\"";

                        Chart.Series[strSeries].Points[intPoint].Url = "javascript:getThirdLevel('" + strKPI + "_" + strDimenLV3 + "_" + strDimenLV2 + "_" + dr[getDimensionIDColumn(strDimenLV2)].ToString() + "_" + strYear + "')";
                        Chart.Series[strSeries].Points[intPoint].ToolTip = "" + dr[getDimensionNameColumn(strDimenLV2)].ToString() + ": " + dr[getMeasureNameColumn(strMesureID)].ToString() + "";
                        //load level3 if have dimension
                        if ((strDimensionArr.Length > 1))
                        {
                            Chart.Series[strSeries].Points[intPoint].Url = "DashboardViewerThird.aspx?kpi=" + strKPI + "&measure=" + strMesureID + "&dimenlv3=" + strDimenLV3 + "&dimenlv2=" + strDimenLV2 + "&dimenlv2value=" + dr[getDimensionIDColumn(strDimenLV2)].ToString() + "&year=" + strYear + "&dimension=" + Page.Request["dimension"].ToString() + "&dashname=" + Page.Request["dashName"].ToString() + "";
                        }
                    }


                }
                catch (Exception ex)
                {
                }
                finally
                {
                    sqlCon.Close();
                }

                getChartType(hdfTypeLV2.Value.Trim());

            }

        }

        private void getChartType(string strValue)
        {

            try
            {
                foreach (Series series in Chart.Series)
                {
                    switch (strValue)
                    {
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

                if ((rdb3d2.Checked))
                {
                    Chart.ChartAreas["Default"].Area3DStyle.Enable3D = true;
                }
                else
                {
                    Chart.ChartAreas["Default"].Area3DStyle.Enable3D = false;
                }

                Chart.ChartAreas["Default"].BackColor = System.Drawing.Color.LightBlue;
                Chart.ChartAreas["Default"].BackSecondaryColor = System.Drawing.Color.White;
                Chart.ChartAreas["Default"].BackGradientStyle = GradientStyle.TopBottom;

            }
            catch (Exception ex)
            {
                //lblMessage.Text = "Data is not available for this Chart."
            }
        }

        private string getDimensionPrettyName(string strCurDimension)
        {
            switch (strCurDimension)
            {
                case "ACC":
                    return "ACCOUNT";
                case "ADV":
                    return "ADVISER";
                case "PRO":
                    return "PRODUCT";
                case "TIM":
                    return "TIME PERIOD";
            }

            return "";
        }

        public bool seriesContains(string name)
        {
            try
            {
                string strName = Chart.Series["name"].Name;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        private string getDimensionNameColumn(string strCurDimension)
        {
            switch (strCurDimension)
            {
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
            switch (strMeasure)
            {
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
            switch (strCurDimension)
            {
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


        protected void btnLV2_Click(object sender, System.EventArgs e)
        {
            showChart();
        }
        //public Interfaces_Dashboard_dasboard_mng_DashboardViewerSecond()
        //{
        //    Load += Page_Load;
        //}

        //Protected Sub lbnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbnBack.Click
        //    Dim dashID As String
        //    Dim dashName As String
        //    If (Page.Request("dashID") <> Nothing) Then
        //        dashID = Me.Page.Request("dashID").ToString()
        //    End If
        //    If (Page.Request("dashName") <> Nothing) Then
        //        dashName = Me.Page.Request("dashName").ToString()
        //    End If
        //    Response.Redirect("DashboardViewer.aspx?dashID=" + dashID + "&dashName=" + dashName + "")
        //End Sub

    }
}