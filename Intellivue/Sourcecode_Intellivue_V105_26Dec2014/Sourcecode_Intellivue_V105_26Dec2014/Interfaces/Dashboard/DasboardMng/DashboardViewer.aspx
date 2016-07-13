<%@ Page Title="I N T E L L I V U E - View Dashboard" Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="DashboardViewer.aspx.cs" Inherits="Sourcecode_Intellivue.Interfaces.Dashboard.DasboardMng.DashboardViewer" %>

 
<%@ Import Namespace="obout_ASPTreeView_2_NET" %>
<%@ Register TagPrefix="oem" Namespace="OboutInc.EasyMenu_Pro" Assembly="obout_EasyMenu_Pro" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
    
        
    <script type="text/javascript" language="javascript">
    
    
    function test(kpi,year,strDimension,measure,saleType,dimension,dashID)
    {

       
        document.getElementById("<%=kpi.ClientID %>").value = kpi;
        document.getElementById("<%=year.ClientID %>").value = year;
        document.getElementById("<%=strDimension.ClientID %>").value = strDimension;
        document.getElementById("<%=strMesureID.ClientID %>").value = measure;
        document.getElementById("<%=strKindOfTimeChart.ClientID %>").value = saleType;
        document.getElementById("<%=strDimensionArr.ClientID %>").value = dimension;
        document.getElementById("<%=dashID.ClientID %>").value = dashID;
        
        setTimeout('document.getElementById("<%=btn5.ClientID %>").click()',3000);
    }
    </script>
   
   <script type="text/javascript">
						
			function changeChartType(strTypeID, strLevel)
			{
			     	if(strLevel==1)	
			     	{
			     	    document.getElementById("<%=hdfTypeLV1.ClientID %>").value = strTypeID;
			     	    document.getElementById("<%=btnLV1.ClientID%>").click();
			        }
			        else if(strLevel==2)
			        {
			            document.getElementById("<%=hdfTypeLV2.ClientID%>").value = strTypeID;
			            document.getElementById("<%=btnLV2.ClientID%>").click();
			        }
			        else if(strLevel==3)
			        {
			            document.getElementById("<%=hdfTypeLV3.ClientID%>").value = strTypeID;
			            document.getElementById("<%=btnLV3.ClientID%>").click();
			        }
                 
			}
			
			function changeChartType3d(strLevel,strChecked)
			{
			     	if(strLevel==1)	
			     	{	
			            if (strChecked == "true")
			                document.getElementById("<%=rdbFlat1.ClientID%>").checked = false;
                        else
                            document.getElementById("<%=rdb3d1.ClientID%>").checked = false;
                        document.getElementById("<%=btnLV1.ClientID%>").click();
			        }
			        else if (strLevel==2)
			        {
			            if(strChecked=="true")
			                document.getElementById("<%=rdbFlat2.ClientID%>").checked = false;
			            else
			                document.getElementById("<%=rdb3d2.ClientID%>").checked = false;
			            document.getElementById("<%=btnLV2.ClientID%>").click();
			        }

			}		
			
    </script>
   
        
	
	
	     <asp:HiddenField ID="hdfTypeLV1" runat="server" />
        <asp:HiddenField ID="hdfTypeLV2" runat="server" />
        <asp:HiddenField ID="hdfTypeLV3" runat="server" />
        <asp:HiddenField ID="hdfTypeLV4" runat="server" />
       <asp:HiddenField ID="hdfType3dLV1" runat="server" />
        <asp:HiddenField ID="hdfType3dLV2" runat="server" />
        <asp:HiddenField ID="hdfType3dLV3" runat="server" />
        <asp:HiddenField ID="hdfType3dLV4" runat="server" />
        
        <asp:HiddenField ID="kpi" runat="server" />
        <asp:HiddenField ID="year" runat="server" />
        <asp:HiddenField ID="strDimension" runat="server" />
        <asp:HiddenField ID="strMesureID" runat="server" />
        <asp:HiddenField ID="strKindOfTimeChart" runat="server" />
        <asp:HiddenField ID="strDimensionArr" runat="server" />
        <asp:HiddenField ID="dashID" runat="server" />
        <asp:HiddenField ID="dashName1" runat="server" />
        
        
         <div style="display: none;">
            
       <asp:Button ID="btnLV3" runat="server"/>
            <asp:Button ID="btnLV4" runat="server"/>
            
        </div>  
    <div class="page_navigation " style="margin-top:38px;">
            <asp:SiteMapPath ID="SiteMapPath2" runat="server" PathDirection="RootToCurrent" PathSeparatorStyle-Font-Bold="true" PathSeparator="&nbsp; >> &nbsp;" PathSeparatorStyle-Font-Size="12px" PathSeparatorStyle-ForeColor="#b6d0c2">
            </asp:SiteMapPath>
        </div>
        
        <div  class="search_criteria_bar">
        <div class="search_criteria_leftcolumn">
            <div class="search_criteria_firstcolumn">
                <div >
                    Select Dashboard&nbsp;
                <asp:DropDownList ID="ddlDashboardList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDashboardList_SelectedIndexChanged">
                    <asp:ListItem>--- Select a dashboard ---</asp:ListItem>
                </asp:DropDownList>
            </div>
                
                
            </div>
            
           
            
        </div>
        
        <div style="clear:both;"></div>

    </div>
    <div class="page_heading">Dashboard Viewer</div>
    
    <!-- begin content -->
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
    <div style="margin:40px 0px;">
        <div style="height:50px; width: 100%; float: left; text-align: center; font-family:Tahoma; font-size: large; color:#76a08a">
            <asp:Label ID="lblDashboard" runat="server"></asp:Label>
        </div>
    
      
        <div style="width: 50%; float: left;margin-left:-1px;border-right:1px solid #b6dcc8;">
            <div style="margin:0 30px;">
                
                <asp:Chart ID="Chart1" runat="server" BackGradientType="DiagonalLeft" 
                 Palette="Berry" 
                Width="440px">
                    
                    <ChartAreas>
                        <asp:ChartArea Name="Default">
                        </asp:ChartArea>
                    </ChartAreas>                 
                </asp:Chart>
            </div>
            <div>
                <table border="0" cellpadding="5" cellspacing="5" width="100%">
                    <tr>
                        <td width="11%">
                            <img height="29" onclick="changeChartType('10','1');" 
                                src="Images/dashboard%20mng/ico1.gif" width="44" /></td>
                        <td width="11%">
                            <img height="29" onclick="changeChartType('6','1');" 
                                src="Images/dashboard%20mng/ico2.gif" width="45" /></td>
                        <td width="11%">
                            <img height="29" onclick="changeChartType('17','1');" 
                                src="Images/dashboard%20mng/ico3.gif" width="45" /></td>
                        <td colspan="4" width="67%">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            <input ID="rdb3d1" runat="server" name="3D" 
                                onclick="changeChartType3d('1','true');" style="width: 18px" type="radio" /> 
                            3D
                            <input ID="rdbFlat1" runat="server" name="Flat1" 
                                onclick="changeChartType3d('1','false');" style="width: 48px" type="radio" /> 
                            Flat &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        
        <div style="width: 50%; float: left">
            <div style="margin:0 30px;">
                <asp:Chart ID="Chart2" runat="server"  Palette="Berry" 
                    Width="440px">
                    <Legends>
                        <asp:Legend Name="Default">
                        </asp:Legend>
                    </Legends>
                    <ChartAreas>
                        <asp:ChartArea Name="Default">
                        </asp:ChartArea>
                    </ChartAreas>                 
                </asp:Chart>
            </div>
            <div>
                <table border="0" cellpadding="5" cellspacing="5" width="100%">
                    <tr>
                        <td style="width:11%">
                            <img alt="" height="29" onclick="changeChartType('10','2');" 
                                src="Images/dashboard%20mng/ico1.gif" width="44" /></td>
                        <td style="width:11%">
                            <img alt="" height="29" onclick="changeChartType('6','2');" 
                                src="Images/dashboard%20mng/ico2.gif" width="45" /></td>
                        <td style="width:11%">
                            <img alt="" height="29" onclick="changeChartType('17','2');" 
                                src="Images/dashboard%20mng/ico3.gif" width="45" /></td>
                        <td colspan="4" style="width:67%">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            <input ID="rdb3d2" runat="server" name="3D" 
                                onclick="changeChartType3d('2','true');" style="width: 18px" type="radio" /> 
                            3D
                            <input ID="rdbFlat2" runat="server" name="Flat1" 
                                onclick="changeChartType3d('2','false');" style="width: 48px" type="radio" /> 
                            Flat
                        </td>
                       
                    </tr>
                </table>
            </div>
        </div>
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>	
        
        <div style="clear:both;"></div>
        <div style="margin-top:30px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="grdDashboardData" AllowPaging="true"  runat="server" 
                    CssClass="actable dashboard_table_text" Width="500" 
                    onselectedindexchanged="grdDashboardData_SelectedIndexChanged" OnPageIndexChanging="grdDashboardData_PageIndexChanging">
                                                    
                </asp:GridView>
            </ContentTemplate>
            </asp:UpdatePanel>
            
            
            	
        </div>
    
<span style="display:none">
                                    <asp:Button ID="btn5" runat="server" OnClick="btnLV5_Click"/>
                                    <asp:Button ID="btnLV1" runat="server" OnClick="btnLV1_Click"/>
                                    <asp:Button ID="btnLV2" runat="server" OnClick="btnLV2_Click"/>
                                    </span>
                                    
		
        <div id="popupPie" style="left: 0px; position: absolute; top: -79px;">
            
        </div>

	
    
      <script type="text/javascript" language="javascript">
          var AdviserID = document.getElementById("txtBestAdviser");
          if (AdviserID == null) {
              AdviserID = "200400";
          }
          else {
              AdviserID = document.getElementById("txtBestAdviser").value;
          }


          
          
        </script>
</asp:Content>