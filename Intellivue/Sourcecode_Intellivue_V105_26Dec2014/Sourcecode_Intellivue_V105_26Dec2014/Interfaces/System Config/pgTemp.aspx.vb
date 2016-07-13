
Partial Class Interfaces_System_Config_pgTemp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("username").ToString().ToLower() <> "intellivue" Then
            Response.Redirect("~/Default.aspx")
        ElseIf Request.QueryString("red") = 1 Then
            Response.Redirect("~/Interfaces/pgUnderConstruction.aspx")
        ElseIf Request.QueryString("red") = 2 Then
            Response.Redirect("~/Interfaces/Dashboard/AjaxManageDashboard.aspx")
        ElseIf Request.QueryString("red") = 3 Then
            Response.Redirect("~/Interfaces/pgUnderConstruction.aspx")
        ElseIf Request.QueryString("red") = 4 Then
            Response.Redirect("~/Interfaces/pgUnderConstruction.aspx")
        ElseIf Request.QueryString("red") = 5 Then
            Response.Redirect("~/Interfaces/pgUnderConstruction.aspx")
        ElseIf Request.QueryString("red") = 6 Then
            Response.Redirect("~/Interfaces/pgUnderConstruction.aspx")
        ElseIf Request.QueryString("red") = 7 Then
            Response.Redirect("~/Interfaces/pgUnderConstruction.aspx")
        ElseIf Request.QueryString("red") = 8 Then
            Response.Redirect("~/Interfaces/Dashboard/pgViewDashboard.aspx")
        ElseIf Request.QueryString("red") = 9 Then
            Response.Redirect("~/Interfaces/Standard Reports/AdviserFumReport.aspx")
        ElseIf Request.QueryString("red") = 10 Then
            Response.Redirect("~/Interfaces/Standard Reports/AdviserInflowReport.aspx")
        ElseIf Request.QueryString("red") = 11 Then
            Response.Redirect("~/Interfaces/Standard Reports/AdviserNetflowReport.aspx")
        ElseIf Request.QueryString("red") = 12 Then
            Response.Redirect("~/Interfaces/Standard Reports/AdviserOutflowReport.aspx")
        ElseIf Request.QueryString("red") = 13 Then
            Response.Redirect("~/Interfaces/Standard Reports/FumReport.aspx")
        ElseIf Request.QueryString("red") = 14 Then
            Response.Redirect("~/Interfaces/Standard Reports/FundsFlowByAccountReport.aspx")
        ElseIf Request.QueryString("red") = 15 Then
            Response.Redirect("~/Interfaces/Standard Reports/FundsFlowByProduct.aspx")
        ElseIf Request.QueryString("red") = 16 Then
            Response.Redirect("~/Interfaces/Standard Reports/InvestmentOptionTransactionReport.aspx")
        ElseIf Request.QueryString("red") = 17 Then
            Response.Redirect("~/Interfaces/Standard Reports/InvestorSummary.aspx")
        ElseIf Request.QueryString("red") = 18 Then
            Response.Redirect("~/Interfaces/pgUnderConstruction.aspx")
        ElseIf Request.QueryString("red") = 19 Then
            Response.Redirect("~/Interfaces/pgUnderConstruction.aspx")
        ElseIf Request.QueryString("red") = 20 Then
            Response.Redirect("~/Interfaces/pgUnderConstruction.aspx")
        ElseIf Request.QueryString("red") = 21 Then
            Response.Redirect("~/Interfaces/Analysis Service/AdviserWeek.aspx")
        ElseIf Request.QueryString("red") = 22 Then
            Response.Redirect("~/Interfaces/Analysis Service/AdviserMonth.aspx")
        ElseIf Request.QueryString("red") = 23 Then
            Response.Redirect("~/Interfaces/Analysis Service/FumByProductByDate.aspx")
        ElseIf Request.QueryString("red") = 24 Then
            Response.Redirect("~/Interfaces/pgUnderConstruction.aspx")
        ElseIf Request.QueryString("red") = 25 Then
            Response.Redirect("~/Interfaces/pgUnderConstruction.aspx")
        ElseIf Request.QueryString("red") = 26 Then
            Response.Redirect("~/Interfaces/pgUnderConstruction.aspx")
        ElseIf Request.QueryString("red") = 27 Then
            Response.Redirect("~/Interfaces/pgUnderConstruction.aspx")
        ElseIf Request.QueryString("red") = 28 Then
            Response.Redirect("~/Interfaces/System Config/pgInterfaceConfig.aspx")
        ElseIf Request.QueryString("red") = 29 Then
            Response.Redirect("~/Interfaces/pgUnderConstruction.aspx")
        ElseIf Request.QueryString("red") = 30 Then
            Response.Redirect("~/Interfaces/pgUnderConstruction.aspx")
        ElseIf Request.QueryString("red") = 31 Then
            Response.Redirect("~/Interfaces/Analysis Service/FumByDateByProduct.aspx")
        End If
    End Sub
End Class
