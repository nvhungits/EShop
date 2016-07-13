<%@ Page Title="I N T E L L I V U E - View Dashboard" Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="DashboardViewerFour.aspx.cs" Inherits="Sourcecode_Intellivue.Interfaces.Dashboard.DasboardMng.DashboardViewerFour" %>
<%@ Import Namespace="obout_ASPTreeView_2_NET" %>
<%@ Register TagPrefix="oem" Namespace="OboutInc.EasyMenu_Pro" Assembly="obout_EasyMenu_Pro" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<script type="text/javascript">
						
			function changeChartType(strTypeID, strLevel)
			{

			    document.getElementById("<%=hdfTypeLV2.ClientID %>").value = strTypeID;
			    document.getElementById("<%=btnLV2.ClientID %>").click();
                 
			}
			
			function changeChartType3d(strLevel,strChecked)
			{
			     		
			        if (strChecked == "true")
			            document.getElementById("<%=rdbFlat2.ClientID %>").checked = false;
                    else
                        document.getElementById("<%=rdb3d2.ClientID %>").checked = false;
                    document.getElementById("<%=btnLV2.ClientID %>").click();
               
			}		
			
    </script>

<script type="text/javascript" src="../../../Interfaces/Dashboard/dasboardmng/tree2/script/ob_tree_2038.js"></script>
    <script type="text/javascript" src="../../../Interfaces/Dashboard/dasboardmng/tree2/script/ob_mdn_2038.js"></script>
    <script type="text/javascript" src="../../../Interfaces/Dashboard/dasboardmng/tree2/script/ob_events_2038.js"></script>



	<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <asp:HiddenField ID="hdfTypeLV1" runat="server" />
        <asp:HiddenField ID="hdfTypeLV2" runat="server" />
        <asp:HiddenField ID="hdfTypeLV3" runat="server" />
        <asp:HiddenField ID="hdfTypeLV4" runat="server" />
        <asp:HiddenField ID="hdfType3dLV1" runat="server" />
        <asp:HiddenField ID="hdfType3dLV2" runat="server" />
        <asp:HiddenField ID="hdfType3dLV3" runat="server" />
        <asp:HiddenField ID="hdfType3dLV4" runat="server" />
        <div style="display: none;">
            <asp:Button ID="btnLV2" runat="server" OnClick="btnLV2_Click"/>
            <asp:Button ID="btnLV3" runat="server"/>
            <asp:Button ID="btnLV4" runat="server"/>
        </div> 
         
    
		<table border="0" width="975px" id="table1" cellspacing="0" cellpadding="0" height="804">
			
			<tr>
				
<td valign="top" width="975px" style="margin-top:-10px;padding-top:-10px; height: 801px;">
                    

<table width="975px" border="0" cellpadding="0" cellspacing="0" height="100%">
          <tr>
            <td width="100%" background="Images/dashboard mng/bg1.gif" style="height: 43px">&nbsp;</td>
          </tr>
          <tr>
            <td valign="top" background="Images/dashboard mng/bg2.gif" style="padding-left:20px; padding-right:20px">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" id="TABLE3">
                  <tr>
                    <td width="100%" valign="top" style="padding-left:20px; padding-right: 20px;">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <br />
                            <tr>
                                  <td style="width: 18px;"><img src="Images/dashboard mng/top_left.gif"/></td>
                                  <td style="background-image: url(../../../Interfaces/Dashboard/dasboardmng/Images/dashboard%20mng/h_line_top.gif); width:100%"></td>
                                  <td style="width: 18px;"><img src="Images/dashboard mng/top_right.gif"/></td>
                            </tr> 
                            <tr>
                                  <td style="width: 18px; background-image: url(../../../Interfaces/Dashboard/dasboardmng/Images/dashboard%20mng/v_line_left.gif)"></td>
                                   <td style="width:100%">
                                        <div style="background-color: White; height:30px; width: 50%; float: left; text-align: left; font-family:Tahoma; font-size: large; color:#76a08a">
                                           
                                           <input type=button value="Back" onClick="history.go(-1)">
                                        </div>
                                   
                                        <div style="background-color: White; height:30px; width: 50%; float: left; text-align: right;">
                                           <img src="Images/dashboard mng/dashboard.gif"/>
                                        </div>
                                    </td>
                                  <td style="width: 18px;  background-image: url(../../../Interfaces/Dashboard/dasboardmng/Images/dashboard%20mng/v_line_right.gif)"></td>
                            </tr> 
                           
                             <tr>
                                  <td style="width: 18px; background-image: url(../../../Interfaces/Dashboard/dasboardmng/Images/dashboard%20mng/v_line_left.gif)"></td>
                                   <td style="width:100%">
                                        <div style="height:50px; width: 100%; float: left; text-align: center; font-family:Tahoma; font-size: large; color:#76a08a">
                                            <asp:Label ID="lblDashboard" runat="server"></asp:Label>
                                            </div>
                                    </td>
                                  <td style="width: 18px;  background-image: url(../../../Interfaces/Dashboard/dasboardmng/Images/dashboard%20mng/v_line_right.gif)"></td>
                            </tr> 
                            
                            <tr>
                                <td style="width: 18px; background-image: url(../../../Interfaces/Dashboard/dasboardmng/Images/dashboard%20mng/v_line_left.gif)"></td>
                                <td style="width:100%">
                                <table>
                                    <tr>
                                        <td width="17%">&nbsp;</td>                                         
                                        <td width="11%"><img src="Images/dashboard mng/ico1.gif" width="44" height="29" onclick="changeChartType('10','2');" /></td>
                                        <td width="11%"><img src="Images/dashboard mng/ico2.gif" width="45" height="29" onclick="changeChartType('6','2');"/></td>
                                        <td width="11%"><img src="Images/dashboard mng/ico3.gif" width="45" height="29" onclick="changeChartType('17','2');"/></td>
                                        <td width="50%" colspan="4">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                            <input type="radio" id="rdb3d2" onclick="changeChartType3d('2','true');" name="3D" runat="server" style="width: 18px"/> 3D 
                                            <input type="radio" id="rdbFlat2" onclick="changeChartType3d('2','false');" name="Flat1" runat="server" style="width: 48px" /> Flat
                                    </tr>
                                </table>
                                    <div style="width: 100%; float: left; text-align:center">
                                       <asp:Chart ID="Chart" runat="server" BackColor="WhiteSmoke" BackGradientEndColor="White"
                                            BackGradientType="DiagonalLeft" BorderLineColor="26, 59, 105" BorderLineStyle="Solid"
                                             Palette="Berry" Width="800px" Height="500px">
                                            <BorderSkin BackColor="194, 219, 202"
                                                PageColor="AliceBlue" SkinStyle="FrameThin1" />
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
                                  
                                </td>
                                <td style="width: 18px;  background-image: url(../../../Interfaces/Dashboard/dasboardmng/Images/dashboard%20mng/v_line_right.gif)"></td>
                            </tr>
                            <tr>
                                  <td style="width: 18px; height: 19px;"><img src="Images/dashboard mng/bottom_left.gif"/></td>
                                  <td style="background-image: url(../../../Interfaces/Dashboard/dasboardmng/Images/dashboard%20mng/h_line_bottom.gif); width:100%; height: 19px;"></td>
                                  <td style="width: 18px; height: 19px;"><img src="Images/dashboard mng/bottom_right.gif"/></td>
                            </tr> 
                            
                        </table>
                        <br />
                    </td>
                  </tr>
                </table>
            </td>
          </tr>
          <tr>
            <td width="100%" height="28" background="Images/dashboard mng/bg3.gif">&nbsp;</td>
          </tr>
        </table>
   
</td>
   </tr>
          
	  </table>
        <div id="popupPie" style="left: 0px; position: absolute; top: -79px;">
            
        </div>
        
<div style="position: absolute; width: 100px; height: 639px; z-index: 7; left: 0px; top: 103px" id="layer7">
</div>
    
</asp:Content>
