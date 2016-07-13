<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wcTopMenu.ascx.cs" Inherits="Sourcecode_Intellivue.UserControls.wcTopMenu" %>
<asp:Menu ID="mnuMain" runat="server" Font-Bold="True" Font-Names="Tahoma"
    Font-Size="10pt" ForeColor="Ivory" Orientation="Horizontal" Width="800px" Height="36px"  StaticEnableDefaultPopOutImage="false" 
        DynamicEnableDefaultPopOutImage="true">
    <Items>
        <asp:MenuItem ImageUrl="~/Images/b_home.gif" NavigateUrl="~/Interfaces/pgAdministration.aspx" ></asp:MenuItem>
        <asp:MenuItem ImageUrl="~/Images/b_analysis.gif" NavigateUrl="~/Interfaces/AnalysisService/AdviserWeek.aspx">
            <asp:MenuItem Text="   Adviser By Product Week &amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;" Value="Sales Week" ImageUrl="~/Images/analysis_icon_s.gif" NavigateUrl="~/Interfaces/AnalysisService/AdviserWeek.aspx">
            </asp:MenuItem>
            <asp:MenuItem ImageUrl="~/Images/analysis_icon_s.gif" Text="   Adviser By Product Month" Value="Sales Month" NavigateUrl="~/Interfaces/AnalysisService/AdviserMonth.aspx">
            </asp:MenuItem>
            <asp:MenuItem ImageUrl="~/Images/analysis_icon_s.gif" Text="   FUM By Product By Date" Value="FUM" NavigateUrl="~/Interfaces/AnalysisService/FumByProductByDate.aspx"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/Images/analysis_icon_s.gif" NavigateUrl="~/Interfaces/AnalysisService/FumByDateByProduct.aspx"
                Text="   FUM By Date By Product" Value="   FUM By Date By Product"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/Images/analysis_icon_s.gif" Text="   Customer" Value="Customer" NavigateUrl="~/Interfaces/pgUnderConstruction.aspx">
            </asp:MenuItem>
            <asp:MenuItem ImageUrl="~/Images/analysis_icon_s.gif" NavigateUrl="~/Interfaces/pgUnderConstruction.aspx"
                Text="   Sales Week (Pivot table)" Value="   Sales Week (Pivot table)"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/Images/analysis_icon_s.gif" NavigateUrl="~/Interfaces/pgUnderConstruction.aspx"
                Text="   Sales Month (Pivot table)" Value="   Sales Month (Pivot table)"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/Images/analysis_icon_s.gif" NavigateUrl="~/Interfaces/pgUnderConstruction.aspx"
                Text="   FUM (Pivot table)" Value="   FUM (Pivot table)"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem ImageUrl="~/Images/b_report.gif" NavigateUrl="~/Interfaces/StandardReports/AdviserFumReport.aspx">
            <asp:MenuItem Text="   Standard Reports      " Value="Standard Reports    " ImageUrl="~/Images/report_icon_s.gif">
                <asp:MenuItem Text="   Adviser Funding FUM" Value="Adviser FUM" ImageUrl="~/Images/report_icon_s.gif" NavigateUrl="~/Interfaces/StandardReports/AdviserFumReport.aspx"></asp:MenuItem>
                <asp:MenuItem Text="   Adviser Funding Inflow" Value="Adviser Inflow" ImageUrl="~/Images/report_icon_s.gif" NavigateUrl="~/Interfaces/StandardReports/AdviserInflowReport.aspx"></asp:MenuItem>
                <asp:MenuItem Text="   Adviser Funding Netflow" Value="Adviser Netflow" ImageUrl="~/Images/report_icon_s.gif" NavigateUrl="~/Interfaces/StandardReports/AdviserNetflowReport.aspx"></asp:MenuItem>
                <asp:MenuItem Text="   Adviser Funding Outflow" Value="Adviser Outflow" ImageUrl="~/Images/report_icon_s.gif" NavigateUrl="~/Interfaces/StandardReports/AdviserOutflowReport.aspx"></asp:MenuItem>
                <asp:MenuItem Text="   Funds Under Management" Value="FUM Report" ImageUrl="~/Images/report_icon_s.gif" NavigateUrl="~/Interfaces/StandardReports/FumReport.aspx"></asp:MenuItem>
                <asp:MenuItem Text="   Funds Flow By Account" Value="Funds Flow By Account" ImageUrl="~/Images/report_icon_s.gif" NavigateUrl="~/Interfaces/StandardReports/FundsFlowByAccountReport.aspx"></asp:MenuItem>
                <asp:MenuItem Text="   Funds Flow By Product" Value="Funds Flow By Product" ImageUrl="~/Images/report_icon_s.gif" NavigateUrl="~/Interfaces/StandardReports/FundsFlowByProduct.aspx"></asp:MenuItem>
                <asp:MenuItem Text="   Inv Option Transaction" Value="Inv Option Transaction Report" ImageUrl="~/Images/report_icon_s.gif" NavigateUrl="~/Interfaces/StandardReports/InvestmentOptionTransactionReport.aspx">
                </asp:MenuItem>
                <asp:MenuItem Text="   Investor Summary (by option) " Value="Investor Summary (by option)" ImageUrl="~/Images/report_icon_s.gif" NavigateUrl="~/Interfaces/pgUnderConstruction.aspx">
                </asp:MenuItem>
                <asp:MenuItem Text="   Investor Summary" Value="Investor Summary" ImageUrl="~/Images/report_icon_s.gif" NavigateUrl="~/Interfaces/StandardReports/InvestorSummary.aspx"></asp:MenuItem>
                <asp:MenuItem Text="   Transactions Report" Value="Transactions Reports" ImageUrl="~/Images/report_icon_s.gif" NavigateUrl="~/Interfaces/pgUnderConstruction.aspx"></asp:MenuItem>
            </asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem ImageUrl="~/Images/b_dash.gif" NavigateUrl="~/Interfaces/Dashboard/pgViewDashboard.aspx">
            <asp:MenuItem ImageUrl="~/Images/Dashboard_Icon_s.gif" NavigateUrl="~/Interfaces/Dashboard/dasboardmng/dashboardmng.aspx"
                   Text="    Dashboard Management" Value="    Manage Dashboard"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/Images/Dashboard_Icon_s.gif" NavigateUrl="~/Interfaces/Dashboard/dasboardmng/DashboardViewer.aspx"
                    Text="    Dashboard Viewer" Value="    Dashboard Viewer"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/Images/Dashboard_Icon_s.gif" NavigateUrl="~/Interfaces/Dashboard/DashboardDefaultViewer.aspx"
                    Text="    Dashboard Default Viewer" Value="    Dashboard Default Viewer"></asp:MenuItem>
                    
        </asp:MenuItem>
        <asp:MenuItem ImageUrl="~/Images/b_admin.gif" NavigateUrl="~/Interfaces/pgAdministration.aspx">
        <asp:MenuItem ImageUrl="~/Images/admin_icon_s.gif" Text="    Authorization" Value="    Alert Management" NavigateUrl="~/Interfaces/Administrator/UserMaintenance.aspx">
            </asp:MenuItem>
            <asp:MenuItem ImageUrl="~/Images/admin_icon_s.gif" Text="    Alert Management" Value="    Alert Management" NavigateUrl="~/Interfaces/pgUnderConstruction.aspx">
            </asp:MenuItem>
            <asp:MenuItem Text="    Manage Data Warehouse process " Value="Managing Data Warehousing process" ImageUrl="~/Images/admin_icon_s.gif" NavigateUrl="~/Interfaces/pgUnderConstruction.aspx">
            </asp:MenuItem>
            <asp:MenuItem Text="    Distributing" Value="Distributing" ImageUrl="~/Images/admin_icon_s.gif" NavigateUrl="~/Interfaces/pgUnderConstruction.aspx"></asp:MenuItem>
            <asp:MenuItem Text="    Scheduling" Value="Scheduling" ImageUrl="~/Images/admin_icon_s.gif" NavigateUrl="~/Interfaces/pgUnderConstruction.aspx"></asp:MenuItem>
            <asp:MenuItem ImageUrl="~/Images/admin_icon_s.gif" NavigateUrl="~/Interfaces/System Config/pgInterfaceConfig.aspx"
                Text="    Content Management" Value="System Configuration"></asp:MenuItem>
            <asp:MenuItem Text="    Workflow Management" Value="Workflow Management" ImageUrl="~/Images/admin_icon_s.gif" NavigateUrl="~/Interfaces/pgUnderConstruction.aspx"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem ImageUrl="~/Images/b_cube.jpg" NavigateUrl="~/Interfaces/CubeBrowser/CubeBrowse.aspx">
            <asp:MenuItem ImageUrl="~/Images/analysis_icon_s.gif" Text="   Cube Management" Value="Cube Management" NavigateUrl="~/Interfaces/CubeBrowser/CubeBrowse.aspx">
            </asp:MenuItem>
            <asp:MenuItem ImageUrl="~/Images/analysis_icon_s.gif" Text="   Cube Viewer" Value="Cube Viewer" NavigateUrl="~/Interfaces/CubeBrowser/CubeViewer.aspx">
            </asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem ImageUrl="~/Images/b_logout.gif" NavigateUrl="~/Interfaces/pgTemp.aspx?out=1">
        </asp:MenuItem>
    </Items>
    <DynamicHoverStyle BackColor="#A4C1BA" ForeColor="Yellow" />
    <DynamicMenuStyle BackColor="#A4C1BA" />
    <StaticHoverStyle BackColor="#A4C1BA" />
</asp:Menu>