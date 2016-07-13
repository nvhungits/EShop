<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportPage.aspx.cs" Inherits="Sourcecode_Intellivue.Interfaces.AnalysisService.ReportPage" %>



<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Page-Enter" content="blendTrans(Duration=1.0)"/>
    <title>Untitled Page</title>
    <style type="text/css">
        html,body,form {
            height:100%;
        }
        .h100 {
            height:100%;
        }
    </style>
</head>
<body >
    <form id="form1" runat="server">
    <div align="center" class="h100" >
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="False" BackColor="#77A399"
            EnableViewState="true" ProcessingMode="Remote" SizeToReportContent="False" Width="100%" Height="100%" style="left: 0px; position: absolute; top: 0px;" >
        </rsweb:ReportViewer>
        &nbsp;</div>
    </form>
</body>
</html>