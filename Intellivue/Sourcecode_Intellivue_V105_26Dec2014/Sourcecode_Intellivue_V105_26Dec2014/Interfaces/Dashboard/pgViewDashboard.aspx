<%@ Page Title="I N T E L L I V U E - View Dashboard" Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="pgViewDashboard.aspx.cs" Inherits="Sourcecode_Intellivue.Interfaces.Dashboard.pgViewDashboard" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<script language="javascript" type="text/javascript">

    function refreshPage() {
        var url = "AjaxCode.aspx";

        //set data for list Year
        content = "mode=generateListDashboard&object=listDashboard";

        loadXMLDoc(url, 'setControlValue(\'divDashboard\')', content);
    }

    function changeDashboard() {
        var strSelectedDashboard = document.getElementById("listDashboard").options(document.getElementById("listDashboard").selectedIndex).value;

        if (strSelectedDashboard = "multiChart") {
            var url = "showMultiDashboard.aspx";

            var frame = document.getElementById("KPIChart1");
            frame.src = url;
        }
        else {
        }
    }

    function setControlValue(ControlName) {
        if (xmlhttp.readyState == 4) {
            if (xmlhttp.status == 200) {
                var str = xmlhttp.responseText;
                var dashboard = document.getElementById(ControlName);
                dashboard.innerHTML = str;
            }
        }
    }
    function Text1_onclick() {

    }

</script>


    
		<table border="0" width="975px" id="table1" cellspacing="0" cellpadding="0" height="804px">
			<tr >
			 
				<td valign="top" colspan="2" style=" height:50px;" >
				<div  id="divDashboard" style="margin-bottom:0px;vertical-align:middle;background-color:#A3C4B4; padding-top:5px;height:50px;padding-left:20%; ">
		         
    	        </div>
		        </td>
			</tr>
			<tr>
				<td valign="top" style="width: 26px; height: 616px">    
    			</td>
				<td valign="top" width="100%" style="margin-top:-10px;padding-top:-10px">
                    <div id ="divReport" style="margin:0px 0px 0px 0px;padding: 0px 0px 0px 0px;">
                        <iframe  scrolling="no" style="position:relative;top:0px;left:0px;border: 0px none; width: 100%;height:auto;margin:0px 0px 0px 0px;padding: 0px 0px 0px 0px;" name="KPIChart1" id="KPIChart1" runat="server" enableviewstate="true" frameborder="0" marginwidth="-10px" marginheight="-12px" >     </iframe>
                    </div>
                </td>
			</tr>
			
	  </table>
	
       
 
    
<% 
    if ( Page.IsPostBack)
    {
        System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"JavaScript\">");
        System.Web.HttpContext.Current.Response.Write("     refreshPage();");
        System.Web.HttpContext.Current.Response.Write("</SCRIPT>");
    }
%>
</asp:Content>
