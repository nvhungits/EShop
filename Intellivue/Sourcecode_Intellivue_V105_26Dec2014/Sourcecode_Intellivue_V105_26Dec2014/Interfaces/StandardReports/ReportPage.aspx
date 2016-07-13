<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="ReportPage.aspx.cs" Inherits="Sourcecode_Intellivue.Interfaces.StandardReports.ReportPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>




<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="Page-Enter" content="blendTrans(Duration=1.0)"/>
    <title>Untitled Page</title>
    <style type="text/css">
        #cReportViewer1_ctl01 td:last-child
        {
            width:0%;
        }
    </style>
        <style type="text/css">
        html,body,form {
            height:100%;
        }
        .h100 {
            height:100%;
        }
    </style>

        <script type="text/javascript">
        //var chromeindex = navigator.userAgent.indexOf("Chrome");
        ////alert(chromeindex);
        //$(document).ready(function() {
        //    if (chromeindex>0) {
        //        $(".ms-report-viewer-control :nth-child(3) table").each(function(i, item) {
        //            $(item).css('display', 'inline-block');
        //        });
        //    }
        //});
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" class="h100">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="False" 
            BackColor="#A3C4B4" EnableViewState="True" ProcessingMode="Remote"  
        SizeToReportContent="False" Width="100%" 
            style="width:100%;margin-left:0px; margin-top:0px; text-align:center;" 
            ZoomMode="PageWidth">
        </rsweb:ReportViewer>
        
    </form>
</body>
</html>
