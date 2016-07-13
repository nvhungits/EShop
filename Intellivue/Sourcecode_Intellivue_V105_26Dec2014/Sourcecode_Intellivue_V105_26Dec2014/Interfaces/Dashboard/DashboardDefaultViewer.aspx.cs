using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Web.UI.DataVisualization.Charting;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections.Generic;
using Sourcecode_Intellivue.lib;

namespace Sourcecode_Intellivue.Interfaces.Dashboard
{
    public partial class DashboardDefaultViewer : CoreClass
    {
        string userId_edit;
        string user_name;
        string user_role;
        protected void Page_Load(object sender, EventArgs e)
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


            }
            else
            {
                string accessright = GlobalClass.GetAccessRight("D3");
                if (accessright == "F")
                {
                    string strscript = "<script>alert('You are not authorization for this page!');window.location.href='../pgHomePage.aspx'</script>";
                    if (!ClientScript.IsClientScriptBlockRegistered("clientscript"))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "clientscript", strscript);
                    }
                }
                

            }

            this.MaintainScrollPositionOnPostBack = true;

            //loadInOutFlowChart("select KPI,SUM(SALE_AMT) As Amount,cast((YEAR(EFVE_DATE)) as CHAR(4)) as Year from tblDW_SALE_WEEK where (KPI='CTI' or KPI='ICR' or KPI='ICI') and (EFVE_DATE<'12/31/2004' and EFVE_DATE>'1/1/2003')" & _
            //"group by KPI,YEAR(EFVE_DATE)", SeriesChartType.Column, "Total Inflow Amount in 2003-2004", InflowChart)
            loadOutFlowChart("select  CONVERT(varchar(3), EffDate, 100) As EffDate,Actual,Benchmark from tblDashboardDemo", SeriesChartType.Column, "", InflowChart);
            //loadOutFlowChart("select KPI,SUM(SALE_AMT) As Amount from tblDW_SALE_WEEK where (KPI='WDL' or KPI='DEC' or KPI='ICO') and (EFVE_DATE<'12/31/2003' and EFVE_DATE>'1/1/2003')" & _
            //"group by KPI", SeriesChartType.Pie, "Total Outflow Amount in 2003", OutflowChart)

            //loadFUMChart(SeriesChartType.Line, "Detail Fum By Year", FUMChart)

            loadPieChart("select KPI,SUM(Actual) As Actual from tblDashboardDemo where KPI IS not null group by KPI", OutflowChart);

            loadLineChart("select  CONVERT(varchar(3), EffDate, 100) As EffDate,Actual,Benchmark from tblDashboardDemo", SeriesChartType.Line, "", FUMChart);

            string query = "select B.KPI_CATG,SUM(SALE_AMT) As Amount,cast((YEAR(EFVE_DATE)) as CHAR(4)) as Year from tblDW_SALE_WEEK A join tblDW_KPI B on A.KPI = B.KPI join tblDW_KPI_CATG C on B.KPI_CATG=C.KPI_CATG " + "where (C.KPI_CATG='INFL' or C.KPI_CATG='OUTFL') and (EFVE_DATE<'12/31/2004' and EFVE_DATE>'1/1/2003')" + "group by B.KPI_CATG,YEAR(EFVE_DATE)";

            loadQuarterChart("SELECT DATEPART(QUARTER,EffDate) [Quarter], SUM(Actual) as 'Actual' FROM tblDashboardDemo GROUP BY DATEPART(QUARTER,EffDate) order by Quarter desc", CombinationChart);
        }


        string strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();
        //"Data Source=PC26\SQLSERVER2008;Initial Catalog=DW_Test;User ID=sa; Password=admin123"

        private void loadInOutFlowChart(string query, SeriesChartType type, string title, Chart chart)
        {

            try
            {
                SqlConnection objConn = new SqlConnection(strConnString);
                SqlCommand cmd = default(SqlCommand);

                cmd = new SqlCommand(query, objConn);




                objConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                List<string> list = new List<string>();
                while ((reader.Read()))
                {
                    list.Add(reader[0].ToString());
                }
                List<string> kpiList = list.Distinct().ToList();

                //If type = SeriesChartType.StackedColumn Or type = SeriesChartType.Column Then
                foreach (object kpi in kpiList)
                {
                    
                    chart.Series.Add(kpi.ToString());
                }
                //End If

                reader.Close();
                reader = cmd.ExecuteReader();

                if (type == SeriesChartType.StackedColumn | type == SeriesChartType.Column)
                {

                    while ((reader.Read()))
                    {
                        chart.Series[reader[0].ToString().Trim()].Points.AddXY(reader.GetString(2), reader.GetDecimal(1));
                        //chart.Series(1).Points.AddXY(reader.GetString(0), reader.GetDecimal(2))
                        chart.Series[reader[0].ToString().Trim()].LegendText = reader[0].ToString().Trim();
                        chart.Series[reader[0].ToString().Trim()].ChartType = type;

                    }


                    foreach (Series seri in chart.Series)
                    {
                        for (int point = 0; point <= seri.Points.Count - 1; point++)
                        {
                            seri.Points[point].Url = "DashboardViewerLvl2.aspx?Year=#VALX&KPI=" + seri.LegendText + "";
                        }
                    }
                    chart.Legends.Add(new Legend("Amount"));
                }

                if (type == SeriesChartType.Pie)
                {
                    //chart.DataBindTable(reader)
                    //chart.Series(0).XValueMember = "KPI"

                    //chart.Series(0).YValueMembers = "KPI"
                    //chart.DataBind()
                    while ((reader.Read()))
                    {
                        decimal t = reader.GetDecimal(1);
                        chart.Series[reader[0].ToString().Trim()].Points.AddY(reader.GetDecimal(1));
                        //chart.Series(1).Points.AddXY(reader.GetString(0), reader.GetDecimal(2))
                        chart.Series[reader[0].ToString().Trim()].LegendText = reader[0].ToString().Trim();
                        chart.Series[reader[0].ToString().Trim()].ChartType = type;
                        chart.Series[reader[0].ToString().Trim()].Label = "#VALY{C0}";
                    }

                    chart.Legends.Add(new Legend("KPI"));

                }


                //chart.Titles.Add("Total Settlement in 2010")

                chart.Legends[0].Position.Auto = false;
                chart.Legends[0].Position = new ElementPosition(73, 5, 30, 20);

                //InflowChart.Legends.Item(0).Docking = Docking.Bottom
                chart.Titles.Add(title);


                chart.Legends[0].Title = "Legend";




                //chart.Series(0)("PixelPointWidth") = "60"
                //InflowChart.Series(1)("PixelPointWidth") = "60"

                chart.Series[0].ToolTip = "#VALY{C0}";
                chart.Series[1].ToolTip = "#VALY{C0}";
                chart.Series[2].ToolTip = "#VALY{C0}";

                chart.ChartAreas[0].AxisY.LabelStyle.Format = "C0";
                reader.Close();
                objConn.Close();

            }
            catch (Exception ex)
            {
            }
        }

        private void loadOutFlowChart(string query, SeriesChartType type, string title, Chart chart)
        {

            try
            {
                SqlConnection objConn = new SqlConnection(strConnString);
                SqlCommand cmd = default(SqlCommand);

                cmd = new SqlCommand(query, objConn);




                objConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                //Dim reader As SqlDataReader = cmd.ExecuteReader()
                chart.Series.Add("Benchmark");
                chart.Series.Add("ActualSale");
                chart.Series[0].ChartType = SeriesChartType.Column;
                chart.Series[1].ChartType = SeriesChartType.Column;


                if (type == SeriesChartType.Pie)
                {
                    //While (reader.Read())
                    //    Dim t As Decimal = reader.GetDecimal(1)
                    //    chart.Series(0).Points.AddY(reader.GetDecimal(1))
                    //    'chart.Series(1).Points.AddXY(reader.GetString(0), reader.GetDecimal(2))
                    //    'chart.Legends.Add(New Legend(reader(0).ToString().Trim()))
                    //    'chart.Series(0).LegendText = reader(0).ToString().Trim()



                    //    chart.Series(0).ChartType = type
                    //    chart.Series(0).Label = "#VALY{C0}"
                    //End While

                    SqlDataAdapter adp = new SqlDataAdapter(query, objConn);
                    DataTable dtb = new DataTable();
                    adp.Fill(dtb);
                    chart.DataSource = dtb;
                    chart.Series[0].XValueMember = "KPI";
                    chart.Series[0].YValueMembers = "Amount";
                    chart.DataBind();
                    chart.Legends.Add(new Legend("KPI"));
                    chart.Series[0].ToolTip = "#VALY{C0}";

                    foreach (Series seri in chart.Series)
                    {
                        for (int point = 0; point <= seri.Points.Count - 1; point++)
                        {
                            seri.Points[point].Url = "DashboardViewerLvl2.aspx?Year=2003&KPI=#VALX";
                        }
                    }
                }

                if (type == SeriesChartType.Column)
                {
                    while ((reader.Read()))
                    {
                        chart.Series[0].Points.AddXY(reader.GetString(0), reader.GetDecimal(2));
                        chart.Series[1].Points.AddXY(reader.GetString(0), reader.GetDecimal(1));
                        //InflowChart.Series(1).Points.AddXY(reader.GetString(0), reader.GetDecimal(2))
                    }

                    chart.Series[0]["PixelPointWidth"] = "8";
                    chart.Series[1]["PixelPointWidth"] = "20";
                }
                chart.Legends.Add(new Legend("KPI"));


                chart.Legends[0].Title = "Legend";
                chart.ChartAreas[0].AxisX.Interval = 1;
                chart.Titles.Add(title);
                chart.Legends[0].Position.Auto = false;
                chart.Legends[0].Position = new ElementPosition(73, 0, 30, 20);
                //reader.Close()
                objConn.Close();

            }
            catch (Exception ex)
            {
            }
        }

        private void loadFUMChart(SeriesChartType type, string title, Chart chart)
        {

            try
            {
                SqlConnection objConn = new SqlConnection(strConnString);
                SqlCommand cmd = default(SqlCommand);

                string query = "select SUM(FUM) As Amount, cast((YEAR(EFVE_DATE)) as CHAR(4)) as Year from tblDW_FUM group by YEAR(EFVE_DATE)";
                cmd = new SqlCommand(query, objConn);




                objConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                //chart.Titles.Add("Total Settlement in 2010")
                chart.Legends.Add(new Legend("Amount"));
                chart.Legends[0].Position.Auto = false;
                chart.Legends[0].Position = new ElementPosition(70, 5, 30, 20);
                chart.Legends[0].BorderWidth = 1;
                chart.Legends[0].BorderDashStyle = ChartDashStyle.Solid;
                //InflowChart.Legends.Item(0).Docking = Docking.Bottom
                chart.Titles.Add(title);





                chart.Series.Add("FUM");
                //If type = SeriesChartType.StackedColumn Or type = SeriesChartType.Column Then
                while ((reader.Read()))
                {
                    chart.Series[0].Points.AddXY(reader.GetString(1), reader.GetDecimal(0));

                    //InflowChart.Series(1).Points.AddXY(reader.GetString(0), reader.GetDecimal(2))
                }

                foreach (Series seri in chart.Series)
                {
                    for (int point = 0; point <= seri.Points.Count - 1; point++)
                    {
                        seri.Points[point].Url = "#";
                    }
                }

                // End If



                chart.Legends["Amount"].Title = "Legend";

                chart.Series[0].ChartType = type;


                foreach (DataPoint dp in chart.Series[0].Points)
                {
                    dp.MarkerSize = 6;
                    dp.MarkerStyle = MarkerStyle.Circle;
                    dp.MarkerColor = Color.Blue;

                }

                //chart.Series(0)("PixelPointWidth") = "60"
                //InflowChart.Series(1)("PixelPointWidth") = "60"

                chart.Series[0].ToolTip = "#VALY{C0}";

                chart.ChartAreas[0].AxisY.LabelStyle.Format = "C0";
                reader.Close();
                objConn.Close();

            }
            catch (Exception ex)
            {
            }
        }
        private void loadCombineFlowChart(string query, SeriesChartType type, string title, Chart chart)
        {

            try
            {
                SqlConnection objConn = new SqlConnection(strConnString);
                SqlCommand cmd = default(SqlCommand);

                cmd = new SqlCommand(query, objConn);




                objConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                List<string> list = new List<string>();
                while ((reader.Read()))
                {
                    list.Add(reader[0].ToString());
                }
                List<string> kpiList = list.Distinct().ToList();

                //If type = SeriesChartType.StackedColumn Or type = SeriesChartType.Column Then
                foreach (object kpi in kpiList)
                {
                    
                    chart.Series.Add(kpi.ToString());
                }
                //End If

                reader.Close();
                reader = cmd.ExecuteReader();

                if (type == SeriesChartType.StackedColumn | type == SeriesChartType.Column)
                {

                    while ((reader.Read()))
                    {
                        chart.Series[reader[0].ToString().Trim()].Points.AddXY(reader.GetString(2), reader.GetDecimal(1));
                        //chart.Series(1).Points.AddXY(reader.GetString(0), reader.GetDecimal(2))
                        chart.Series[reader[0].ToString().Trim()].LegendText = reader[0].ToString().Trim();
                        chart.Series[reader[0].ToString().Trim()].ChartType = type;

                    }


                    foreach (Series seri in chart.Series)
                    {
                        for (int point = 0; point <= seri.Points.Count - 1; point++)
                        {
                            seri.Points[point].Url = "#";
                        }
                    }
                    chart.Legends.Add(new Legend("Amount"));
                }




                //chart.Titles.Add("Total Settlement in 2010")

                chart.Legends[0].Position.Auto = false;
                chart.Legends[0].Position = new ElementPosition(78, 5, 30, 20);

                //InflowChart.Legends.Item(0).Docking = Docking.Bottom
                chart.Titles.Add(title);


                chart.Legends[0].Title = "Legend";




                //chart.Series(0)("PixelPointWidth") = "60"
                //InflowChart.Series(1)("PixelPointWidth") = "60"

                chart.Series[0].ToolTip = "#VALY{C0}";
                chart.Series[1].ToolTip = "#VALY{C0}";


                chart.ChartAreas[0].AxisY.LabelStyle.Format = "C0";
                reader.Close();
                objConn.Close();

            }
            catch (Exception ex)
            {
            }
        }

        private void loadPieChart(string query, Chart chart)
        {
            //get data by KPI and load on pie chart

            try
            {
                SqlConnection objConn = new SqlConnection(strConnString);
                SqlCommand cmd = default(SqlCommand);

                cmd = new SqlCommand(query, objConn);

                objConn.Open();


                chart.Series.Add("ActualSale");
                chart.Series[0].ChartType = SeriesChartType.Pie;


                SqlDataAdapter adp = new SqlDataAdapter(query, objConn);
                DataTable dtb = new DataTable();
                adp.Fill(dtb);
                chart.DataSource = dtb;
                chart.Series[0].XValueMember = "KPI";
                chart.Series[0].YValueMembers = "Actual";
                chart.DataBind();
                chart.Legends.Add(new Legend("KPI"));
                chart.Series[0].ToolTip = "#PERCENT{P0}";
                chart.Series[0].Label = "#PERCENT{P0}";
                chart.Series[0].LabelForeColor = Color.White;
                chart.Series[0].LegendText = "#VALX";
                foreach (Series seri in chart.Series)
                {
                    for (int point = 0; point <= seri.Points.Count - 1; point++)
                    {
                        seri.Points[point].Url = "DashboardViewerLvl2.aspx?Year=2003&KPI=#VALX";
                    }
                }





                chart.Legends[0].Title = "Legend";
                chart.Legends[0].LegendStyle = LegendStyle.Column;

                chart.ChartAreas[0].AxisX.Interval = 1;

                chart.Legends[0].Position.Auto = false;
                chart.Legends[0].Position = new ElementPosition(82, 0, 25, 60);


            }
            catch (Exception ex)
            {
            }
        }

        private void loadLineChart(string query, SeriesChartType type, string title, Chart chart)
        {

            try
            {
                SqlConnection objConn = new SqlConnection(strConnString);
                SqlCommand cmd = default(SqlCommand);

                cmd = new SqlCommand(query, objConn);




                objConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                //Dim reader As SqlDataReader = cmd.ExecuteReader()
                chart.Series.Add("Benchmark");
                chart.Series.Add("ActualSale");
                chart.Series[0].ChartType = SeriesChartType.Line;
                chart.Series[1].ChartType = SeriesChartType.Line;



                if (type == SeriesChartType.Line)
                {
                    while ((reader.Read()))
                    {
                        chart.Series[0].Points.AddXY(reader.GetString(0), reader.GetDecimal(2));
                        chart.Series[1].Points.AddXY(reader.GetString(0), reader.GetDecimal(1));
                        //InflowChart.Series(1).Points.AddXY(reader.GetString(0), reader.GetDecimal(2))
                    }

                    chart.Series[0].BorderWidth = 2;
                    chart.Series[1]["PixelPointWidth"] = "20";
                }
                chart.Legends.Add(new Legend("KPI"));
                chart.Series[1].MarkerSize = 8;
                chart.Series[1].MarkerStyle = MarkerStyle.Circle;
                chart.Series[1].MarkerColor = Color.LightBlue;

                chart.Legends[0].Title = "Legend";
                chart.ChartAreas[0].AxisX.Interval = 1;
                chart.Titles.Add(title);
                
                chart.Legends[0].Position = new ElementPosition(73, 0, 30, 20);
                
                //reader.Close()
                objConn.Close();

            }
            catch (Exception ex)
            {
            }
        }

        private void loadQuarterChart(string query, Chart chart)
        {

            try
            {
                SqlConnection objConn = new SqlConnection(strConnString);
                SqlCommand cmd = default(SqlCommand);

                cmd = new SqlCommand(query, objConn);




                objConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                //Dim reader As SqlDataReader = cmd.ExecuteReader()

                chart.Series.Add("ActualSale");
                chart.Series[0].ChartType = SeriesChartType.Bar;





                while ((reader.Read()))
                {
                    chart.Series[0].Points.AddXY(reader.GetInt32(0), reader.GetDecimal(1));

                }

                chart.Series[0]["PixelPointWidth"] = "30";

                chart.Legends.Add(new Legend("KPI"));


                chart.Legends[0].Title = "Legend";
                chart.ChartAreas[0].AxisX.Interval = 1;

                chart.Legends[0].Position.Auto = false;
                chart.Legends[0].Position = new ElementPosition(73, 0, 30, 20);
                //reader.Close()
                objConn.Close();

            }
            catch (Exception ex)
            {
            }
        }
    }
}
