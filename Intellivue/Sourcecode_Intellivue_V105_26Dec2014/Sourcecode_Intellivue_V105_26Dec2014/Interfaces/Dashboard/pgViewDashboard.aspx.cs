using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sourcecode_Intellivue.Interfaces.Dashboard
{
    public partial class pgViewDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if ( Session["username"]!=null && Session["username"].ToString().ToLower() == "intellivue")
            {
                try
                {
                    //'con.Open()

                    //'If Not Page.IsPostBack Then

                    //'    Dim da As New SqlDataAdapter("SELECT * FROM tblDW_DASH WHERE IS_DELETED = 0", con)
                    //'    Dim ds As New DataSet
                    //'    da.Fill(ds)


                    //'    listDashboard.DataSource = ds
                    //'    listDashboard.DataTextField = "DASH_NAME"
                    //'    listDashboard.DataValueField = "DASH_ID"

                    //'    listDashboard.DataBind()

                    //'    Dim item As New ListItem("Select a dashboard", "0")
                    //'    listDashboard.Items.Insert(0, item)

                    //'    'rv.Visible = False
                    //'End If
                }
                catch(Exception ex)
                {
                }

                finally
                {
                    //'con.Close()
                }
            }else
            {
                Response.Redirect("~/Default.aspx");
            }

   
        }
    //Sub getBack()
    //    'If (chart1.ServerReport.IsDrillthroughReport) Then
    //    '    rv.PerformBack()
    //    '    getBack()
    //    'End If
    //End Sub

    //'Protected Sub listDashboard_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles listDashboard.SelectedIndexChanged
    //'    If (listDashboard.SelectedItem.Value <> "0") Then
    //'        Try
    //'            con.Open()

    //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    //''get list param
    //'Dim hash As New Hashtable()

    //'Dim da As New SqlDataAdapter("SELECT * FROM tblDW_DASH_CHART WHERE DASH_ID = " & listDashboard.SelectedItem.Value, con)
    //'Dim ds As New DataSet
    //'            da.Fill(ds)

    //'Dim KPICategory As String = ds.Tables(0).Rows(0).Item("KPI_CATG").ToString
    //'Dim ChartType As String = ds.Tables(0).Rows(0).Item("CHART_TYPE").ToString
    //'Dim paramNames() As String = ds.Tables(0).Rows(0).Item("PARAM_NAME").ToString.Split(";")
    //'Dim paramValues() As String = ds.Tables(0).Rows(0).Item("PARAM_VALUE").ToString.Split(";")
    //'            For i As Integer = 0 To paramNames.Length - 1
    //'                hash.Add(paramNames(i), paramValues(i))
    //'            Next

    //'Dim Year As String = hash("Year").ToString
    //'Dim BenchMark As String = hash("BenchMark").ToString
    //'Dim BenchMarkKPI As String = hash("BenchMarkKPI").ToString
    //''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    //'            getBack()

    //'Dim Param(3) As Microsoft.Reporting.WebForms.ReportParameter

    //'            rv.ServerReport.ReportServerUrl = New Uri(objConnection.fsReportServerConnection)
    //'            rv.ServerReport.ReportPath = "/ReportingService/KPICategoryChartYear" + ChartType

    //'            Param(0) = New Microsoft.Reporting.WebForms.ReportParameter("KPICategory", KPICategory)
    //'            Param(1) = New Microsoft.Reporting.WebForms.ReportParameter("Year", Year)
    //'            Param(2) = New Microsoft.Reporting.WebForms.ReportParameter("BenchMark", BenchMark)
    //'            Param(3) = New Microsoft.Reporting.WebForms.ReportParameter("BenchMarkKPI", BenchMarkKPI)
    //''Param(0) = New Microsoft.Reporting.WebForms.ReportParameter("", "")

    //'            rv.ShowParameterPrompts = False
    //'            rv.ServerReport.SetParameters(Param)

    //'            rv.Visible = True

    //'        Catch ex As Exception
    //'Dim mess = ex.Message

    //'        Finally
    //'            con.Close()
    //'        End Try
    //'    Else
    //'        rv.Visible = False
    //'    End If

    //'End Sub
    }
}
