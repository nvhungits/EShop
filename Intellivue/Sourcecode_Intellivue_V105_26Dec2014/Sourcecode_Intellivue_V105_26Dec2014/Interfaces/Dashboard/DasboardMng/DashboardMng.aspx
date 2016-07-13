<%@ Page Title="I N T E L L I V U E - View Dashboard"  Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="DashboardMng.aspx.cs" Inherits="Sourcecode_Intellivue.Interfaces.Dashboard.DasboardMng.DashboardMng" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Import Namespace="obout_ASPTreeView_2_NET" %>
<%@ Register TagPrefix="oem" Namespace="OboutInc.EasyMenu_Pro" Assembly="obout_EasyMenu_Pro" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
    
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script type="text/javascript">
     var lastAddedTabIndex = 1;
     var strTemp = "ctl00_ContentPlaceHolder1_" // using widget != 1 --npkhoi
			function SelectTab(itemID)
			{
			    // show the tab container
			    var divTab
			    if (itemID==1)
			        divTab = document.getElementById("widget" + itemID);
			    else {			        
			        divTab = document.getElementById(strTemp + "widget" + itemID);
				}				   
				    
				divTab.style.display = "";
				
				// make the other containers invisible
				for (index=1;index<=lastAddedTabIndex;index++) {
				    var divTab
				    if (index == 1)
				        var divTab = document.getElementById("widget" + index);
				    else
				        var divTab = document.getElementById(strTemp + "widget" + index);
					if (divTab != null && index != itemID)
						divTab.style.display = "none";
				}
				
				// select the menu item
				ob_em_SelectItem("menuitem" + itemID);

				var selectedTab = document.getElementById("<%=hdfSelectedTab.ClientID %>");
				selectedTab.value = itemID

				document.getElementById("<%=btnDrawChart.ClientID %>").click();
			}
			function AddTab()
			{
			    document.getElementById("<%=hdfWidget.ClientID%>").value = document.getElementById("<%=hdfWidget.ClientID%>").value + 1;
			        
			    //alert(document.getElementById("<%=hdfWidget.ClientID%>").value);
			    if (lastAddedTabIndex == 3) {
			        var divAddWidget = document.getElementById("divAddWidget");
				    divAddWidget.style.display = "none";
			    }
			    if (lastAddedTabIndex <= 3 ) {
				    // add new menu item
				    lastAddedTabIndex++;
				    var htmlTabContent = "<table cellpadding=\"0\" cellspacing=\"0\"><tr><td width=\"100%\" class=\"itemText\">Widget " + lastAddedTabIndex + "</td></tr></table>";
				    ob_em_EasymenuTabStrip.AddItem("menuitem" + lastAddedTabIndex, "MenuItem", htmlTabContent, "", "", "", "SelectTab(" + lastAddedTabIndex + ")"); 
    				
 				    var divTab = document.getElementById("widget" + itemID);
				    divTab.id = "widget" + lastAddedTabIndex;
				    divTab.style.display = "";
				    
				}
				
			}
			function getDimension() {
			    var temp = ob_t2_list_checked();
			    document.getElementById("<%=hdfPara.ClientID %>").value = temp; 
			}
			
			function getSecondLevel(strhdfLV2Value) {
			    var btnlv2 = document.getElementById("<%=btnLV2.ClientID %>");
			    var hdfLV2Value = document.getElementById("<%=hdfLV2Value.ClientID %>"); 
			    hdfLV2Value.value = strhdfLV2Value; 
			    btnlv2.click();
			}
			
			function getThirdLevel(strhdfLV3Value) {

			    var hdfLV3Value = document.getElementById("<%=hdfLV3Value.ClientID %>");
			    var btnlv3 = document.getElementById("<%=btnLV3.ClientID %>");
			    hdfLV3Value.value = strhdfLV3Value;
			    btnlv3.click();
			}
			function getFourLevel(strhdfLV4Value) {

			    var hdfLV4Value = document.getElementById("<%=hdfLV4Value.ClientID %>");
			    var btnlv4 = document.getElementById("<%=btnLV4.ClientID %>");
			    hdfLV4Value.value = strhdfLV4Value;
			    btnlv4.click();
			}
			
			function changeChartType(strTypeID, strLevel)
			{
			    if(strLevel == 1)
			    {
			        document.getElementById("<%=hdfTypeLV1.ClientID %>").value = strTypeID;
			        document.getElementById("<%=btnLV2.ClientID %>").click();
			    }
			    else if (strLevel == 2)
			    {
			        document.getElementById("<%=hdfTypeLV2.ClientID %>").value = strTypeID;
			        document.getElementById("<%=btnLV2.ClientID %>").click();
                }
			    else if(strLevel == 3)
			    {
			        document.getElementById("<%=hdfTypeLV3.ClientID %>").value = strTypeID;
			        document.getElementById("<%=btnLV3.ClientID %>").click();			    
			    }
			    else if(strLevel == 4)
			    {
			        document.getElementById("<%=hdfTypeLV4.ClientID %>").value = strTypeID;
			        document.getElementById("<%=btnLV4.ClientID %>").click();			    
			    }
			}
			
			function changeChartType3d(strLevel,strChecked)
			{
			    if(strLevel == 1)
			    {
			        if (strChecked == "true")
			            document.getElementById("<%=rdbFlat1.ClientID %>").checked = false;
                    else
                        document.getElementById("<%=rdb3d1.ClientID %>").checked = false;
                    document.getElementById("<%=btnLV2.ClientID %>").click();
			    }
			    else if (strLevel == 2)
			    {			
			        if (strChecked == "true")
			            document.getElementById("<%=rdbFlat2.ClientID %>").checked = false;
                    else
                        document.getElementById("<%=rdb3d2.ClientID %>").checked = false;
                    document.getElementById("<%=btnLV2.ClientID %>").click();
                }
			    else if(strLevel == 3)
			    {
			        if (strChecked == "true")
			            document.getElementById("<%=rdbFlat3.ClientID %>").checked = false;
                    else
                        document.getElementById("<%=rdb3d3.ClientID %>").checked = false;
                    document.getElementById("<%=btnLV3.ClientID %>").click();			    
			    }
			    else if(strLevel == 4)
			    {
			        if (strChecked == "true")
			            document.getElementById("<%=rdbFlat4.ClientID %>").checked = false;
                    else
                        document.getElementById("<%=rdb3d4.ClientID %>").checked = false;
                    document.getElementById("<%=btnLV4.ClientID %>").click();			    
			    }
			    
			     
			}
			
			
    </script>
    
<script type="text/C#" language="javascript">
    function dispEmp( AdviserID)
    {
	    if (document.getElementById)
	    {
	        document.getElementById("EmployeeDetails").src = "AdviserDetails.aspx?AdviserID=" + AdviserID;
	    }
    }
</script>


    
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
        </asp:ScriptManager>
        <asp:HiddenField ID="hdfWidget" runat="server" Value="1" />
        <asp:HiddenField ID="hdfPara" runat="server" />
        <asp:HiddenField ID="hdfSelectedTab" runat="server" Value="1" />
        <asp:HiddenField ID="hdfLV2Value" runat="server" />
        <asp:HiddenField ID="hdfYear" runat="server" />
        <asp:HiddenField ID="hdfLV3Value" runat="server" />
        <asp:HiddenField ID="hdfLV4Value" runat="server" />
        <asp:HiddenField ID="hdfDimension" runat="server" />
        <asp:HiddenField ID="hdfTypeLV1" runat="server" />
        <asp:HiddenField ID="hdfTypeLV2" runat="server" />
        <asp:HiddenField ID="hdfTypeLV3" runat="server" />
        <asp:HiddenField ID="hdfTypeLV4" runat="server" />
        <asp:HiddenField ID="hdfType3dLV1" runat="server" />
        <asp:HiddenField ID="hdfType3dLV2" runat="server" />
        <asp:HiddenField ID="hdfType3dLV3" runat="server" />
        <asp:HiddenField ID="hdfType3dLV4" runat="server" />
        <div style="display: none;">
            <asp:Button ID="btnLV2" runat="server" OnClick="btnLV2_Click" />
            <asp:Button ID="btnLV3" runat="server" OnClick="btnLV3_Click"/>
            <asp:Button ID="btnLV4" runat="server" OnClick="btnLV4_Click"/>
        </div>
    <div class="page_navigation " style="margin-top:38px;">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server" PathDirection="RootToCurrent" PathSeparatorStyle-Font-Bold="true" PathSeparator="&nbsp; >> &nbsp;" PathSeparatorStyle-Font-Size="12px" PathSeparatorStyle-ForeColor="#b6d0c2">
            </asp:SiteMapPath>
        </div>
        
    
    <div>
        <div class="page_heading">Dashboard Management</div>
        
        <table width="100%" border="0" cellspacing="0" cellpadding="0" id="TABLE3">
                    <tr>
                        <td height="10" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td width="38%" valign="top">
                            <table width="350" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <table width="350" border="0" cellspacing="0" cellpadding="0">
                                            
                                            <tr>
                                                <td style="background-color:#a1c3b1;padding-left: 10px; padding-right: 10px;">

                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="">
                                                        <tr>
                                                            <td height="79" >
                                                                <table width="100%" border="0" cellspacing="5" cellpadding="5">
                                                                    <tr>
                                                                        <td width="15%" style="height: 34px">
                                                                            Name</td>
                                                                        <td width="60%" style="height: 34px">
                                                                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox><label style="font-family: Tahoma;
                                                                                color: Red">&nbsp;(*)</label>
                                                                        </td>
                                                                        
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td style="padding-bottom: 10px; padding-top: 10px; font-size: 12pt; font-family: Tahoma;">
                                                                <div id="divAddWidget">
                                                                    <a href="javascript:AddTab()" style="font-size: 10pt; font-family: Tahoma">Add 
                                                                    New Widget</a><br />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 20px">
                                                                <oem:EasyMenu SelectedItemId="menuitem1" ID="EasymenuTabStrip" runat="server" ShowEvent="Always"
                                                                    StyleFolder="../../../Css/TabStrip1" Position="Horizontal" Width="300">
                                                                    <Components>
                                                                        <oem:MenuItem OnClientClick="SelectTab('1')" ID="menuitem1">
                                                                            <table cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td width="100%" class="itemText">
                                                                                        Widget 1
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </oem:MenuItem>
                                                                    </Components>
                                                                </oem:EasyMenu>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border: 1px solid #acb4b6">
                                                                    <tr>
                                                                        <td bgcolor="#eeeeee" align="center" valign="middle" id="divContent" style="height: 350px;
                                                                            vertical-align: top">
                                                                            <!-- Widget 1 -->
                                                                            <div id="widget1" style="padding-top: 10px;">
                                                                                <div style="float: left; width: 100%; height: 30px;" align="center">
                                                                                    <label style="font-family: Tahoma; color: Red">
                                                                                        &nbsp;All fields are mandatory</label>
                                                                                </div>
                                                                                <div style="float: left; width: 20%; height: 30px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;From
                                                                                </div>
                                                                                <div style="float: left; width: 20%; height: 30px;" align="left">
                                                                                    <asp:DropDownList ID="ddlFrom1" runat="server">
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                <div style="float: left; width: 10%; height: 30px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;To
                                                                                </div>
                                                                                <div style="float: left; width: 40%; height: 30px;" align="left">
                                                                                    <asp:DropDownList ID="ddlTo1" runat="server">
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                <div style="float: left; width: 20%; height: 60px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;Category
                                                                                </div>
                                                                                <div style="float: right; width: 80%; height: 60px;" align="left">
                                                                                    <asp:RadioButtonList ID="rblCategory1" runat="server" AutoPostBack="true" BorderColor="Black"
                                                                                        BorderStyle="Solid" BorderWidth="1px" BackColor="White" Width="230px" 
                                                                                        CellSpacing="5" onselectedindexchanged="rblCategory1_SelectedIndexChanged">
                                                                                        <asp:ListItem Text="Inflow" Value="INFL" />
                                                                                        <asp:ListItem Text="Outflow" Value="OUTFL" />
                                                                                    </asp:RadioButtonList>
                                                                                </div>
                                                                                <div style="float: left; width: 20%; height: 30px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;Type
                                                                                </div>
                                                                                <div style="float: right; width: 80%; height: 30px" align="left">
                                                                                    <asp:RadioButtonList ID="rblType1" runat="server" RepeatDirection="Horizontal" Width="192px">
                                                                                        <asp:ListItem Text="Sale Week" Value="W" Selected="true" />
                                                                                        <asp:ListItem Text="Sale Month" Value="M" />
                                                                                    </asp:RadioButtonList>
                                                                                </div>
                                                                                <div style="float: left; width: 20%; height: 90px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;Measure
                                                                                </div>
                                                                                <div style="float: right; width: 80%; height: 90px;" align="left">
                                                                                    <asp:RadioButtonList ID="rblMeasure1" runat="server" AutoPostBack="false" BorderColor="Black"
                                                                                        BorderStyle="Solid" BorderWidth="1px" BackColor="White" Width="230px" CellSpacing="5">
                                                                                        <asp:ListItem Text="Amount" Value="12" Selected="true" />
                                                                                        <asp:ListItem Text="Units" Value="13" />
                                                                                        <asp:ListItem Text="FUM" Value="15" />
                                                                                    </asp:RadioButtonList>
                                                                                </div>
                                                                                <div style="float: left; height: 120px; width: 20%; height: 120px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;KPI
                                                                                </div>
                                                                                <div style="float: right; width: 80%; height: 120px;" align="left">
                                                                                    <asp:UpdatePanel ID="udpKPI1" runat="server" RenderMode="Inline">
                                                                                        <ContentTemplate>
                                                                                            <asp:CheckBoxList ID="cblKPI1" AutoPostBack="false" TextAlign="Right" runat="server"
                                                                                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" BackColor="White" Width="230px"
                                                                                                CellSpacing="5">
                                                                                            </asp:CheckBoxList>
                                                                                        </ContentTemplate>
                                                                                        <Triggers>
                                                                                            <asp:AsyncPostBackTrigger ControlID="rblCategory1" EventName="SelectedIndexChanged" />
                                                                                        </Triggers>
                                                                                    </asp:UpdatePanel>
                                                                                </div>
                                                                                <div style="float: left; width: 100%; padding-left: 10px; padding-top: 30px;" align="left">
                                                                                    <asp:Literal ID="TreeViewWidget1" EnableViewState="false" runat="server" />
                                                                                </div>
                                                                            </div>
                                                                            <!-- Widget 2 -->
                                                                            <div id="widget2" style="padding-top: 10px; display: none" runat="server">
                                                                                <div style="float: left; width: 100%; height: 30px;" align="center">
                                                                                    <label style="font-family: Tahoma; color: Red">
                                                                                        &nbsp;All fields are mandatory</label>
                                                                                </div>
                                                                                <div style="float: left; width: 20%; height: 30px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;From
                                                                                </div>
                                                                                <div style="float: left; width: 20%; height: 30px;" align="left">
                                                                                    <asp:DropDownList ID="ddlFrom2" runat="server">
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                <div style="float: left; width: 10%; height: 30px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;To
                                                                                </div>
                                                                                <div style="float: left; width: 40%; height: 30px;" align="left">
                                                                                    <asp:DropDownList ID="ddlTo2" runat="server">
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                <div style="float: left; width: 20%; height: 60px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;Category
                                                                                </div>
                                                                                <div style="float: right; width: 80%; height: 60px;" align="left">
                                                                                    <asp:RadioButtonList ID="rblCategory2" runat="server" AutoPostBack="true" BorderColor="Black"
                                                                                        BorderStyle="Solid" BorderWidth="1px" BackColor="White" Width="230px" CellSpacing="5" OnSelectedIndexChanged="rblCategory2_SelectedIndexChanged">
                                                                                        <asp:ListItem Text="Inflow" Value="INFL" />
                                                                                        <asp:ListItem Text="Outflow" Value="OUTFL" />
                                                                                    </asp:RadioButtonList>
                                                                                </div>
                                                                                <div style="float: left; width: 20%; height: 30px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;Type
                                                                                </div>
                                                                                <div style="float: right; width: 80%; height: 30px" align="left">
                                                                                    <asp:RadioButtonList ID="rblType2" runat="server" RepeatDirection="Horizontal" Width="192px">
                                                                                        <asp:ListItem Text="Sale Week" Value="W" Selected="true" />
                                                                                        <asp:ListItem Text="Sale Month" Value="M" />
                                                                                    </asp:RadioButtonList>
                                                                                </div>
                                                                                <div style="float: left; width: 20%; height: 90px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;Measure
                                                                                </div>
                                                                                <div style="float: right; width: 80%; height: 90px;" align="left">
                                                                                    <asp:RadioButtonList ID="rblMeasure2" runat="server" AutoPostBack="false" BorderColor="Black"
                                                                                        BorderStyle="Solid" BorderWidth="1px" BackColor="White" Width="230px" CellSpacing="5">
                                                                                        <asp:ListItem Text="Amount" Value="12" Selected="true" />
                                                                                        <asp:ListItem Text="Units" Value="13" />
                                                                                        <asp:ListItem Text="FUM" Value="15" />
                                                                                    </asp:RadioButtonList>
                                                                                </div>
                                                                                <div style="float: left; height: 120px; width: 20%; height: 120px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;KPI
                                                                                </div>
                                                                                <div style="float: right; width: 80%; height: 120px;" align="left">
                                                                                    <asp:UpdatePanel ID="udpKPI2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                                                                        <ContentTemplate>
                                                                                            <asp:CheckBoxList ID="cblKPI2" AutoPostBack="false" TextAlign="Right" runat="server"
                                                                                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" BackColor="White" Width="230px"
                                                                                                CellSpacing="5">
                                                                                            </asp:CheckBoxList>
                                                                                        </ContentTemplate>
                                                                                        <Triggers>
                                                                                            <asp:AsyncPostBackTrigger ControlID="rblCategory2" EventName="SelectedIndexChanged" />
                                                                                        </Triggers>
                                                                                    </asp:UpdatePanel>
                                                                                </div>
                                                                                <div style="float: left; width: 100%; padding-left: 10px; padding-top: 30px;" align="left">
                                                                                    <asp:Literal ID="TreeViewWidget2" EnableViewState="false" runat="server" />
                                                                                </div>
                                                                            </div>
                                                                            <!-- Widget 3 -->
                                                                            <div id="widget3" style="padding-top: 10px; display: none">
                                                                                <div style="float: left; width: 100%; height: 30px;" align="center">
                                                                                    <label style="font-family: Tahoma; color: Red">
                                                                                        &nbsp;All fields are mandatory</label>
                                                                                </div>
                                                                                <div style="float: left; width: 20%; height: 30px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;From
                                                                                </div>
                                                                                <div style="float: left; width: 20%; height: 30px;" align="left">
                                                                                    <asp:DropDownList ID="ddlFrom3" runat="server">
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                <div style="float: left; width: 10%; height: 30px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;To
                                                                                </div>
                                                                                <div style="float: left; width: 40%; height: 30px;" align="left">
                                                                                    <asp:DropDownList ID="ddlTo3" runat="server">
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                <div style="float: left; width: 20%; height: 60px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;Category
                                                                                </div>
                                                                                <div style="float: right; width: 80%; height: 60px;" align="left">
                                                                                    <asp:RadioButtonList ID="rblCategory3" runat="server" AutoPostBack="true" BorderColor="Black"
                                                                                        BorderStyle="Solid" BorderWidth="1px" BackColor="White" Width="230px" CellSpacing="5" onselectedindexchanged="rblCategory3_SelectedIndexChanged">
                                                                                        <asp:ListItem Text="Inflow" Value="INFL" />
                                                                                        <asp:ListItem Text="Outflow" Value="OUTFL" />
                                                                                    </asp:RadioButtonList>
                                                                                </div>
                                                                                <div style="float: left; width: 20%; height: 30px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;Type
                                                                                </div>
                                                                                <div style="float: right; width: 80%; height: 30px" align="left">
                                                                                    <asp:RadioButtonList ID="rblType3" runat="server" RepeatDirection="Horizontal" Width="192px">
                                                                                        <asp:ListItem Text="Sale Week" Value="W" Selected="true" />
                                                                                        <asp:ListItem Text="Sale Month" Value="M" />
                                                                                    </asp:RadioButtonList>
                                                                                </div>
                                                                                <div style="float: left; width: 20%; height: 90px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;Measure
                                                                                </div>
                                                                                <div style="float: right; width: 80%; height: 90px;" align="left">
                                                                                    <asp:RadioButtonList ID="rblMeasure3" runat="server" AutoPostBack="false" BorderColor="Black"
                                                                                        BorderStyle="Solid" BorderWidth="1px" BackColor="White" Width="230px" CellSpacing="5">
                                                                                        <asp:ListItem Text="Amount" Value="12" Selected="true" />
                                                                                        <asp:ListItem Text="Units" Value="13" />
                                                                                        <asp:ListItem Text="FUM" Value="15" />
                                                                                    </asp:RadioButtonList>
                                                                                </div>
                                                                                <div style="float: left; height: 120px; width: 20%; height: 120px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;KPI
                                                                                </div>
                                                                                <div style="float: right; width: 80%; height: 120px;" align="left">
                                                                                    <asp:UpdatePanel ID="udpKPI3" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                                                                        <ContentTemplate>
                                                                                            <asp:CheckBoxList ID="cblKPI3" AutoPostBack="false" TextAlign="Right" runat="server"
                                                                                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" BackColor="White" Width="230px"
                                                                                                CellSpacing="5">
                                                                                            </asp:CheckBoxList>
                                                                                        </ContentTemplate>
                                                                                        <Triggers>
                                                                                            <asp:AsyncPostBackTrigger ControlID="rblCategory3" EventName="SelectedIndexChanged" />
                                                                                        </Triggers>
                                                                                    </asp:UpdatePanel>
                                                                                </div>
                                                                                <div style="float: left; width: 100%; padding-left: 10px; padding-top: 30px;" align="left">
                                                                                    <asp:Literal ID="TreeViewWidget3" EnableViewState="false" runat="server" />
                                                                                </div>
                                                                            </div>
                                                                            <!-- Widget 4 -->
                                                                            <div id="widget4" style="padding-top: 10px; display: none">
                                                                                <div style="float: left; width: 100%; height: 30px;" align="center">
                                                                                    <label style="font-family: Tahoma; color: Red">
                                                                                        &nbsp;All fields are mandatory</label>
                                                                                </div>
                                                                                <div style="float: left; width: 20%; height: 30px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;From
                                                                                </div>
                                                                                <div style="float: left; width: 20%; height: 30px;" align="left">
                                                                                    <asp:DropDownList ID="ddlFrom4" runat="server">
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                <div style="float: left; width: 10%; height: 30px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;To
                                                                                </div>
                                                                                <div style="float: left; width: 40%; height: 30px;" align="left">
                                                                                    <asp:DropDownList ID="ddlTo4" runat="server">
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                <div style="float: left; width: 20%; height: 60px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;Category
                                                                                </div>
                                                                                <div style="float: right; width: 80%; height: 60px;" align="left">
                                                                                    <asp:RadioButtonList ID="rblCategory4" runat="server" AutoPostBack="true" BorderColor="Black"
                                                                                        BorderStyle="Solid" BorderWidth="1px" BackColor="White" Width="230px" CellSpacing="5" onselectedindexchanged="rblCategory4_SelectedIndexChanged">
                                                                                        <asp:ListItem Text="Inflow" Value="INFL" />
                                                                                        <asp:ListItem Text="Outflow" Value="OUTFL" />
                                                                                    </asp:RadioButtonList>
                                                                                </div>
                                                                                <div style="float: left; width: 20%; height: 30px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;Type
                                                                                </div>
                                                                                <div style="float: right; width: 80%; height: 30px" align="left">
                                                                                    <asp:RadioButtonList ID="rblType4" runat="server" RepeatDirection="Horizontal" Width="192px">
                                                                                        <asp:ListItem Text="Sale Week" Value="W" Selected="true" />
                                                                                        <asp:ListItem Text="Sale Month" Value="M" />
                                                                                    </asp:RadioButtonList>
                                                                                </div>
                                                                                <div style="float: left; width: 20%; height: 90px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;Measure
                                                                                </div>
                                                                                <div style="float: right; width: 80%; height: 90px;" align="left">
                                                                                    <asp:RadioButtonList ID="rblMeasure4" runat="server" AutoPostBack="false" BorderColor="Black"
                                                                                        BorderStyle="Solid" BorderWidth="1px" BackColor="White" Width="230px" CellSpacing="5">
                                                                                        <asp:ListItem Text="Amount" Value="12" Selected="true" />
                                                                                        <asp:ListItem Text="Units" Value="13" />
                                                                                        <asp:ListItem Text="FUM" Value="15" />
                                                                                    </asp:RadioButtonList>
                                                                                </div>
                                                                                <div style="float: left; height: 120px; width: 20%; height: 120px;" align="left">
                                                                                    &nbsp;&nbsp;&nbsp;KPI
                                                                                </div>
                                                                                <div style="float: right; width: 80%; height: 120px;" align="left">
                                                                                    <asp:UpdatePanel ID="udpKPI4" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                                                                        <ContentTemplate>
                                                                                            <asp:CheckBoxList ID="cblKPI4" AutoPostBack="false" TextAlign="Right" runat="server"
                                                                                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" BackColor="White" Width="230px"
                                                                                                CellSpacing="5">
                                                                                            </asp:CheckBoxList>
                                                                                        </ContentTemplate>
                                                                                        <Triggers>
                                                                                            <asp:AsyncPostBackTrigger ControlID="rblCategory4" EventName="SelectedIndexChanged" />
                                                                                        </Triggers>
                                                                                    </asp:UpdatePanel>
                                                                                </div>
                                                                                <div style="float: left; width: 100%; padding-left: 10px; padding-top: 30px;" align="left">
                                                                                    <asp:Literal ID="TreeViewWidget4" EnableViewState="false" runat="server" />
                                                                                </div>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border: 1px solid #acb4b6">
                                                        <tr>
                                                            <td bgcolor="#b8e0d7">
                                                                <table width="100%" border="0" cellspacing="5" cellpadding="5">
                                                                    <tr>
                                                                        <td style="padding-top: 10px; padding-bottom: 10px;" colspan="2" align="center">
                                                                            <asp:UpdatePanel ID="udpError" runat="server" RenderMode="Inline">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblError" runat="server" Font-Names="Tahoma" ForeColor="red"></asp:Label>
                                                                                </ContentTemplate>
                                                                                <Triggers>
                                                                                    <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                                                                                </Triggers>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding-top: 10px; padding-bottom: 10px;" colspan="2" align="center">
                                                                            <asp:UpdatePanel ID="udpDrawChart" runat="server" RenderMode="Inline">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblDrawChart" runat="server" Font-Names="Tahoma" ForeColor="red"></asp:Label>
                                                                                </ContentTemplate>
                                                                                <Triggers>
                                                                                    <asp:AsyncPostBackTrigger ControlID="btnDrawChart" EventName="Click" />
                                                                                </Triggers>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        
                                                                        <td style="height: 31px;text-align:center;">
                                                                            <asp:Button CssClass="new_button" ID="btnSave" runat="server" 
                                                                                OnClientClick="return getDimension();" Text="Save" style="margin-right:35px;" 
                                                                                onclick="btnSave_Click" />
                                                                            
                                                                            <asp:Button ID="btnDrawChart" CssClass="new_button" runat="server" 
                                                                                Text="Preview" OnClientClick="return getDimension();" 
                                                                                onclick="btnDrawChart_Click" />
                                                                            
                                                                            </td>
                                                                    </tr>
                                                            
                                                                    
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <p>
                                                        </p>
                                                </td>
                                            </tr>
                                           
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <p>
                                &nbsp;</p>
                        </td>
                        <td width="62%" valign="top" style="padding-left: 20px">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="233" >
                                        <asp:SqlDataSource ID="sdsDashboardList" runat="server"
                                            SelectCommand="prc_DashboardManagement_GetDashboardList" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="DASH_ID" Type="int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <asp:UpdatePanel ID="udpGridView" runat="server" RenderMode="Inline">
                                            <ContentTemplate>
                                                <asp:GridView CssClass="color_table" ID="grvDashboardList" runat="server" 
                                                    AutoGenerateColumns="false" DataKeyNames="DASH_ID"
                                                    DataSourceID="sdsDashboardList" EnableViewState="false" AllowPaging="True" PageSize="5"
                                                    Width="90%" BorderColor="#b9d6c2" HeaderStyle-BackColor="#c2eacf" HeaderStyle-Height="16px"
                                                    AlternatingRowStyle-BackColor="white" BackColor="#b8e0d7" 
                                                   OnRowEditing="grvDashboardList_RowEditing">
                                                    <Columns>
                                                        <asp:BoundField DataField="ROW" ReadOnly="True" HeaderText="No">
                                                            <ItemStyle HorizontalAlign="right" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Dashboard Name">
                                                            <ItemTemplate>
                                                                &nbsp;<asp:Label runat="server" Text='<%# Bind("DASH_NAME") %>' ID="lblDashName"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerSettings PageButtonCount="100" />
                                                    <HeaderStyle BackColor="#ebebeb" />
                                                    <PagerStyle BackColor="White" CssClass="test" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="100%" height="45" style="">
                                                    <div class="page_title" >DASHBOARD NAME</div>
                                                    <div id="Layer2">
                                                        <a href="#"></a>
                                                    </div>
                                                </td>
                                                
                                            </tr>
                                            <tr>
                                                <td valign="top" background="">
                                                    <table width="100%" border="0" cellspacing="5" cellpadding="5">
                                                        <tr> <td width="100%" colspan="7" align="center">
                                                                <span class="levelLabelSpan">Level 1</span>
                                                                <input type="radio" id="rdb3d1" onclick="changeChartType3d('1','true');" name="3D"
                                                                    runat="server" style="width: 18px" />
                                                                3D
                                                                <input type="radio" id="rdbFlat1" onclick="changeChartType3d('1','false');" name="Flat1"
                                                                    runat="server" style="width: 48px" />
                                                                Flat &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                            </td></tr>
                                                        <tr>
                                                           <td width="8%">
                                                                <img src="Images/dashboard mng/ico1.gif" width="44" height="29" onclick="changeChartType('10','1');" /></td>
                                                            <td width="8%">
                                                                <img src="Images/dashboard mng/ico2.gif" width="45" height="29" onclick="changeChartType('6','1');" /></td>
                                                            <td width="8%">
                                                                <img src="Images/dashboard mng/ico3.gif" width="45" height="29" onclick="changeChartType('17','1');" /></td>
                                                            <td width="8%">
                                                                <img src="Images/dashboard mng/icoBar.gif" width="45" height="29" onclick="changeChartType('7','1');" /></td>
                                                            <td width="8%">
                                                                <img src="Images/dashboard mng/icoDoughnut.gif" width="45" height="29" onclick="changeChartType('18','1');" /></td>                                                                               
                                                            <td width="8%">
                                                                <img src="Images/dashboard mng/icoFunnel.gif" width="45" height="29" onclick="changeChartType('35','1');" /></td>
                                                           
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td colspan="7" style="height: 250px">
                                                                <p>
                                                                    &nbsp;</p>
                                                                <asp:UpdatePanel ID="udpChart1" runat="server" RenderMode="inline">
                                                                    <ContentTemplate>
                                                                        <%--<DCWC:Chart ID="Chart1" runat="server" BackColor="WhiteSmoke" BackGradientEndColor="White"
                                                                            BackGradientType="DiagonalLeft" BorderLineColor="26, 59, 105" BorderLineStyle="Solid"
                                                                            Palette="Dundas" Width="500px">
                                                                            <BorderSkin FrameBackColor="194, 219, 202" PageColor="AliceBlue" SkinStyle="FrameThin1" />
                                                                         <!-- <Legends>
                                                                                <DCWC:Legend Name="Default">
                                                                                </DCWC:Legend> 
                                                                            </Legends> -->
                                                                            <ChartAreas>
                                                                                <DCWC:ChartArea Name="Default">
                                                                                </DCWC:ChartArea>
                                                                            </ChartAreas>
                                                                        </DCWC:Chart>--%>
                                                                        
                                                                        <asp:Chart ID="Chart1" runat="server"  BackGradientEndColor="White"
                                                                            BackGradientType="DiagonalLeft" BorderLineColor="26, 59, 105" BorderLineStyle="Solid"
                                                                             Width="500px">
                                                                            
                                                                            <Legends>
                                                                                <asp:Legend Name="Default"></asp:Legend>
                                                                            </Legends>
                                                                            <ChartAreas>
                                                                                <asp:ChartArea Name="Default">
                                                                                </asp:ChartArea>
                                                                            </ChartAreas>
                                                                            
                                                                        </asp:Chart>
                                                                        
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="btnDrawChart" EventName="Click" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="7">
                                                                &nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <img src="Images/dashboard mng/level1.gif" width="21" height="55" /></td>
                                            </tr>
                                            <tr>
                                                <%--<td height="58" background="Images/dashboard mng/bg10.gif">
                                                    &nbsp;</td>--%>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="557" height="19" >
                                                    &nbsp;</td>
                                                <td width="21">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td valign="top" background="">
                                                    <table width="100%" border="0" cellspacing="5" cellpadding="5">
                                                        <tr> <td width="100%" colspan="7" align="center">
                                                                <span class="levelLabelSpan">Level 2</span>
                                                               <input type="radio" id="rdb3d2" onclick="changeChartType3d('2','true');" name="3D2"
                                                                    runat="server" style="width: 18px" />
                                                                3D
                                                                <input type="radio" id="rdbFlat2" onclick="changeChartType3d('2','false');" name="Flat2"
                                                                    runat="server" style="width: 48px" />
                                                                Flat
                                                            </td></tr>
                                                        <tr>
                                                            <td width="11%">
                                                                <img src="Images/dashboard mng/ico1.gif" width="44" height="29" onclick="changeChartType('10','2');" /></td>
                                                            <td width="11%">
                                                                <img src="Images/dashboard mng/ico2.gif" width="45" height="29" onclick="changeChartType('6','2');" /></td>
                                                            <td width="11%">
                                                                <img src="Images/dashboard mng/ico3.gif" width="45" height="29" onclick="changeChartType('17','2');" /></td>
                                                            <td width="8%">
                                                                <img src="Images/dashboard mng/icoBar.gif" width="45" height="29" onclick="changeChartType('7','2');" /></td>
                                                            <td width="8%">
                                                                <img src="Images/dashboard mng/icoDoughnut.gif" width="45" height="29" onclick="changeChartType('18','2');" /></td>                                                                               
                                                            <td width="8%">
                                                                <img src="Images/dashboard mng/icoFunnel.gif" width="45" height="29" onclick="changeChartType('35','2');" /></td>
                                                                
                                                            
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td colspan="7" style="height: 250px">
                                                                <p>
                                                                    &nbsp;</p>
                                                                <asp:UpdatePanel ID="updChart2" runat="server" RenderMode="inline">
                                                                    <ContentTemplate>
                                                                        <%--<DCWC:Chart ID="Chart2" runat="server" BackColor="WhiteSmoke" BackGradientEndColor="White"
                                                                            BackGradientType="DiagonalLeft" BorderLineColor="26, 59, 105" BorderLineStyle="Solid"
                                                                            Palette="Dundas" Width="500px">
                                                                            <BorderSkin FrameBackColor="194, 219, 202" PageColor="AliceBlue" SkinStyle="FrameThin1" />
                                                                           <!-- <Legends>
                                                                                <DCWC:Legend Name="Default">
                                                                                </DCWC:Legend>
                                                                            </Legends> -->
                                                                            <ChartAreas>
                                                                                <DCWC:ChartArea Name="Default">
                                                                                </DCWC:ChartArea>
                                                                            </ChartAreas>
                                                                        </DCWC:Chart>--%>
                                                                        
                                                                        <asp:Chart ID="Chart2" runat="server"  BackGradientEndColor="White"
                                                                            BackGradientType="DiagonalLeft" BorderLineColor="26, 59, 105" BorderLineStyle="Solid"
                                                                             Width="500px">
                                                                            
                                                                            <Legends>
                                                                                <asp:Legend Name="Default"></asp:Legend>
                                                                            </Legends>
                                                                            <ChartAreas>
                                                                                <asp:ChartArea Name="Default">
                                                                                </asp:ChartArea>
                                                                            </ChartAreas>
                                                                            
                                                                        </asp:Chart>
                                                                        
                                                                         <!-- <asp:Label ID="lblChart2" runat="server" Visible="false"></asp:Label> -->
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="btnLV2" EventName="Click" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="7">
                                                                &nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <img src="Images/dashboard mng/level2.gif" width="21" height="55" /></td>
                                            </tr>
                                            <tr>
                                                <%--<td height="58" background="Images/dashboard mng/bg10.gif">
                                                    &nbsp;</td>--%>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr style="display:none;">
                                    <td valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="557" height="19" >
                                                    &nbsp;</td>
                                                <td width="21">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td valign="top" background="">
                                                    <table width="100%" border="0" cellspacing="5" cellpadding="5">
                                                        <tr> <td width="100%" colspan="7" align="center">
                                                                <span class="levelLabelSpan">Level 3</span>
                                                               <input type="radio" id="rdb3d3" onclick="changeChartType3d('3','true');" name="3D3"
                                                                    runat="server" style="width: 18px" />
                                                                3D
                                                                <input type="radio" id="rdbFlat3" onclick="changeChartType3d('3','false');" name="Flat3"
                                                                    runat="server" style="width: 48px" />
                                                                Flat
                                                            </td>
                                                        </tr> 
                                                        <tr>
                                                            <td width="11%">
                                                                <img src="Images/dashboard mng/ico1.gif" width="44" height="29" onclick="changeChartType('10','3');" /></td>
                                                            <td width="11%">
                                                                <img src="Images/dashboard mng/ico2.gif" width="45" height="29" onclick="changeChartType('6','3');" /></td>
                                                            <td width="11%">
                                                                <img src="Images/dashboard mng/ico3.gif" width="45" height="29" onclick="changeChartType('17','3');" /></td>
                                                            <td width="8%">
                                                                <img src="Images/dashboard mng/icoBar.gif" width="45" height="29" onclick="changeChartType('7','3');" /></td>
                                                            <td width="8%">
                                                                <img src="Images/dashboard mng/icoDoughnut.gif" width="45" height="29" onclick="changeChartType('18','3');" /></td>                                                                               
                                                            <td width="8%">
                                                                <img src="Images/dashboard mng/icoFunnel.gif" width="45" height="29" onclick="changeChartType('35','3');" /></td>
                                                                
                                                            
                                                        </tr>
                                                                                                                                       
                                                        <tr>
                                                            <td colspan="7" style="height: 250px">
                                                                <p>
                                                                    &nbsp;</p>
                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="inline">
                                                                    <ContentTemplate>
                                                                        <asp:Chart ID="Chart3" runat="server"  BackGradientEndColor="White"
                                                                            BackGradientType="DiagonalLeft" BorderLineColor="26, 59, 105" BorderLineStyle="Solid"
                                                                             Width="500px">
                                                                            
                                                                            <Legends>
                                                                                <asp:Legend Name="Default"></asp:Legend>
                                                                            </Legends>
                                                                            <ChartAreas>
                                                                                <asp:ChartArea Name="Default">
                                                                                </asp:ChartArea>
                                                                            </ChartAreas>
                                                                            
                                                                        </asp:Chart>
                                                                       <!-- <asp:Label ID="lblChart3" runat="server" Visible="false"></asp:Label> -->
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                     <asp:AsyncPostBackTrigger ControlID="btnLV3" EventName="Click" /> 
                                                           
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <img src="Images/dashboard mng/level3.gif" width="21" height="55" /></td>
                                            </tr>
                                            <tr>
                                                <td height="58" background="Images/dashboard mng/bg10.gif">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr style="display:none;">
                                    <td valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="557" height="19" >
                                                    &nbsp;</td>
                                                <td width="21">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td valign="top" >
                                                    <table width="100%" border="0" cellspacing="5" cellpadding="5">
                                                        <tr> <td width="100%" colspan="7" align="center">
                                                                
                                                               <span class="levelLabelSpan">Level 4</span>
                                                                <input type="radio" id="rdb3d4" onclick="changeChartType3d('4','true');" name="3D4"
                                                                    runat="server" style="width: 18px" />
                                                                3D
                                                                <input type="radio" id="rdbFlat4" onclick="changeChartType3d('4','false');" name="Flat4"
                                                                    runat="server" style="width: 48px" />
                                                                Flat
                                                            </td>
                                                        </tr> 
                                                        <tr>
                                                            <td width="11%">
                                                                <img src="Images/dashboard mng/ico1.gif" width="44" height="29" onclick="changeChartType('10','4');" /></td>
                                                            <td width="11%">
                                                                <img src="Images/dashboard mng/ico2.gif" width="45" height="29" onclick="changeChartType('6','4');" /></td>
                                                            <td width="11%">
                                                                <img src="Images/dashboard mng/ico3.gif" width="45" height="29" onclick="changeChartType('17','4');" /></td>
                                                                  <td width="8%">
                                                                <img src="Images/dashboard mng/icoBar.gif" width="45" height="29" onclick="changeChartType('7','4');" /></td>
                                                            <td width="8%">
                                                                <img src="Images/dashboard mng/icoDoughnut.gif" width="45" height="29" onclick="changeChartType('18','4');" /></td>                                                                               
                                                            <td width="8%">
                                                                <img src="Images/dashboard mng/icoFunnel.gif" width="45" height="29" onclick="changeChartType('35','4');" /></td>
                                                                
                                                            
                                                        </tr>
                                                                                      
                                                           
                                                        <tr>
                                                            <td colspan="7" style="height: 250px">
                                                                <p>
                                                                    &nbsp;</p>
                                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="inline">
                                                                    <ContentTemplate>
                                                                        <asp:Chart ID="Chart4" runat="server"  BackGradientEndColor="White"
                                                                            BackGradientType="DiagonalLeft" BorderLineColor="26, 59, 105" BorderLineStyle="Solid"
                                                                             Width="500px">
                                                                            
                                                                            <Legends>
                                                                                <asp:Legend Name="Default"></asp:Legend>
                                                                            </Legends>
                                                                            <ChartAreas>
                                                                                <asp:ChartArea Name="Default">
                                                                                </asp:ChartArea>
                                                                            </ChartAreas>
                                                                            
                                                                        </asp:Chart>
                                                                        <!-- <asp:Label ID="lblChart4" runat="server" Visible="false"></asp:Label> -->
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="btnLV4" EventName="Click" /> 

                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <img src="Images/dashboard mng/level4.gif" width="21" height="55" /></td>
                                            </tr>
                                            <tr>
                                                <td height="19" background="Images/dashboard mng/bg12.gif">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
    </div>        

       <!-- <div style="position: relative; width: 100px; height: 639px; z-index: 7; left: 0px;
            top: 103px" id="layer7">
        </div>-->
      

    <!--

  <script language="javascript">
            var AdviserID = document.getElementById("txtBestAdviser");
            document.getElementById("EmployeeDetails").src = "AdviserDetails.aspx?AdviserID="+AdviserID.value;
        </script>-->

</asp:Content>
