<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="DashboardDefaultViewer.aspx.cs" Inherits="Sourcecode_Intellivue.Interfaces.Dashboard.DashboardDefaultViewer" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <div class="page_navigation" style="margin-top:38px;">
            <asp:SiteMapPath ID="SiteMapPath2" runat="server" PathDirection="RootToCurrent" PathSeparatorStyle-Font-Bold="true" PathSeparator="&nbsp; >> &nbsp;" PathSeparatorStyle-Font-Size="12px" PathSeparatorStyle-ForeColor="#b6d0c2">
            </asp:SiteMapPath>
        </div>
       
    <div class="page_heading">Dashboard Viewer</div>
    
    <div style="margin-left:20px;margin-bottom:30px;">
    
    <div style="margin-top:20px;float:left;">
    <asp:Chart ID="InflowChart" runat="server" Height="300" Width="450" >
        
        <Series>
           
        </Series>
        <ChartAreas>
        <asp:ChartArea Name="ChartArea1">
            <position Y="10" Height="92" Width="100" X="2"></position>
			<axisy LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
				<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
				<MajorGrid LineColor="64, 64, 64, 64" />
			</axisy>
			<axisx LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
				<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
				<MajorGrid LineColor="64, 64, 64, 64" />
			</axisx>
        </asp:ChartArea>
        </ChartAreas>
        
    </asp:Chart>
    </div>
   
    <div style="margin-top:20px;float:left;margin-left:30px;">
    <asp:Chart ID="OutflowChart" runat="server" Height="300" Width="450">
        
        <Series>
            
        </Series>
        <ChartAreas>
        <asp:ChartArea Name="ChartArea1">
            <position Y="10" Height="92" Width="100" X="2"></position>
	        <axisy LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
		        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
		        <MajorGrid LineColor="64, 64, 64, 64" />
	        </axisy>
	        <axisx LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
		        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
		        <MajorGrid LineColor="64, 64, 64, 64" />
	        </axisx>
        </asp:ChartArea>
        </ChartAreas>
       
    </asp:Chart>
    </div>
    <div style="clear:both;"></div>
    <div style="margin-top:20px;">
        <div style="margin-top:20px;float:left;">
        <asp:Chart ID="FUMChart" runat="server" Height="300" Width="450">
            
            <Series>
                
            </Series>
            <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <position Y="10" Height="92" Width="100" X="2"></position>
	            <axisy LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
		            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
		            <MajorGrid LineColor="64, 64, 64, 64" />
	            </axisy>
	            <axisx LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
		            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
		            <MajorGrid LineColor="64, 64, 64, 64" />
	            </axisx>
            </asp:ChartArea>
            </ChartAreas>
            
        </asp:Chart>
        </div>
        
        <div style="margin-top:20px;float:left;margin-left:30px;">
        <asp:Chart ID="CombinationChart" runat="server" Height="300" Width="450">
            
            <Series>
                
            </Series>
            <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <position Y="10" Height="92" Width="100" X="2"></position>
	            <axisy LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
		            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
		            <MajorGrid LineColor="64, 64, 64, 64" />
	            </axisy>
	            <axisx LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
		            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
		            <MajorGrid LineColor="64, 64, 64, 64" />
	            </axisx>
            </asp:ChartArea>
            </ChartAreas>
            
        </asp:Chart>
        </div>
    </div>
    <div style="clear:both;"></div>
    </div>
</asp:Content>
