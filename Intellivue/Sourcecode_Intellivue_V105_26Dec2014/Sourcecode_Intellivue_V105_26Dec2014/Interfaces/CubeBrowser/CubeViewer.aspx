<%@ Page  Title="I N T E L L I V U E - Cube Viewer" Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="CubeViewer.aspx.cs" Inherits="Sourcecode_Intellivue.Interfaces.CubeViewer"  %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="page_navigation " style="margin-top:38px;">
            <asp:SiteMapPath ID="SiteMapPath2" runat="server" PathDirection="RootToCurrent" PathSeparatorStyle-Font-Bold="true" PathSeparator="&nbsp; >> &nbsp;" PathSeparatorStyle-Font-Size="12px" PathSeparatorStyle-ForeColor="#b6d0c2">
            </asp:SiteMapPath>
        </div>
    <div  class="search_criteria_bar">
        <div class="search_criteria_leftcolumn">
            <div class="search_criteria_firstcolumn">
                <div>
                    <span >Export To</span>
                    <div>
                     <dx:ASPxComboBox ID="listExportFormat" runat="server" Style="vertical-align: middle"
                                    SelectedIndex="0" ValueType="System.String" Width="80px">
                                    <Items>
                                        <dx:ListEditItem Text="Pdf" Value="0" />
                                        <dx:ListEditItem Text="Excel" Value="1" />
                                        <dx:ListEditItem Text="Mht" Value="2" />
                                        <dx:ListEditItem Text="Rtf" Value="3" />
                                        <dx:ListEditItem Text="Text" Value="4" />
                                        <dx:ListEditItem Text="Html" Value="5" />
                                        <dx:ListEditItem Text="CSV" Value="6" />
                                    </Items>
                                </dx:ASPxComboBox>
               
                    </div>
                    <dx:ASPxPivotGridExporter ID="ASPxPivotGridExporter1" runat="server">
                    </dx:ASPxPivotGridExporter>
                    <div>
                        
                        <asp:Button ID="buttonSaveAs" runat="server" Text="Save" CssClass="new_button" 
                            ToolTip="Export and save" onclick="buttonSaveAs_Click" />
      
                        <asp:Button ID="buttonOpen" runat="server" Text="Open" CssClass="new_button" 
                            ToolTip="Export and open" onclick="buttonOpen_Click" />
                    </div>
                </div>
                
                
            </div>
            
            <div class="search_criteria_secondcolumn">
            <div>
                <div>
                    <asp:DropDownList ID="ddlCubeName" runat="server" Width="150px">
                    <asp:ListItem Value="0" Text="- - - -"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div>
                    <asp:Button ID="btnLoadCube" CssClass="new_button" runat="server" Text="Load" 
                        onclick="btnLoadCube_Click" />
                </div>
                
                </div>
            </div>
            
        </div>
        
        <div style="clear:both;"></div>
        <div style="width:100%;font-weight: bold;padding-left:10px;">
                    <span>Export Options:</span>
                    <div> 
                    </div>
                    <table style="margin-left:20px;">
                        <tr>
                            <td>
                                <asp:CheckBox ID="checkPrintHeadersOnEveryPage" runat="server" Text="Print headers on every page" />
                            </td>
                            <td>
                                <asp:CheckBox ID="checkPrintFilterHeaders" runat="server" Text="Print filter headers" Checked="True" />
                            </td>
                            <td>
                                <asp:CheckBox ID="checkPrintColumnHeaders" runat="server" Text="Print column headers" Checked="True" />
                            </td>
                            <td>
                                <asp:CheckBox ID="checkPrintRowHeaders" runat="server" Text="Print row headers" Checked="True" />
                            </td>
                            <td>
                                <asp:CheckBox ID="checkPrintDataHeaders" runat="server" Text="Print data headers" Checked="True" />
                            </td>
                        </tr>
                        
                    </table>
            </div>
    </div>
    

    
        <div>
    
    
    <div class="page_heading">Cube Viewer</div>
    
    <div style="margin:40px 0px;">
    
            <dx:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server"  Visible="false" 
                     
                     Width="100%">
                     
        <Fields>
            <dx:PivotGridField ID="fieldAccountName1" AreaIndex="0" Caption="Account Name" 
                FieldName="[Account].[Account Name].[Account Name]">
            </dx:PivotGridField>
            <dx:PivotGridField ID="fieldAdviserName1" AreaIndex="1" Caption="Adviser Name" 
                FieldName="[Adviser].[Adviser Name].[Adviser Name]" 
                DisplayFolder="Adviser">
            </dx:PivotGridField>
            <dx:PivotGridField ID="fieldKPIName1" AreaIndex="2" Caption="KPI Name"
                FieldName="[KPI].[KPI Name].[KPI Name]">
            </dx:PivotGridField>
            <dx:PivotGridField ValueStyle-CssClass="test" ID="fieldDate2" AreaIndex="3" 
                Caption="Date" 
                FieldName="[Month].[Year - Half Year - Quarter - Month - Date].[Date]" >
            </dx:PivotGridField>
            <dx:PivotGridField ID="fieldProductName1" AreaIndex="4" Caption="Product Name" 
                FieldName="[Product].[Product Name].[Product Name]" 
                DisplayFolder="Product">
            </dx:PivotGridField>
            <dx:PivotGridField ID="fieldAmount1" Area="DataArea" AreaIndex="0" 
                Caption="Amount" FieldName="[Measures].[Amount]" 
                DisplayFolder="Sales Month">
            </dx:PivotGridField>
            <dx:PivotGridField ID="fieldUnits1" Area="DataArea" AreaIndex="1" 
                Caption="Units" FieldName="[Measures].[Units]" DisplayFolder="Sales Month">
            </dx:PivotGridField>
            <dx:PivotGridField ID="fieldABOTD1" Area="DataArea" AreaIndex="2" 
                Caption="ABOTD" FieldName="[Measures].[ABOTD]" DisplayFolder="Sales Month">
            </dx:PivotGridField>
            <dx:PivotGridField ID="fieldFUM1" Area="DataArea" AreaIndex="3" Caption="FUM" 
                FieldName="[Measures].[FUM]" DisplayFolder="Sales Month">
            </dx:PivotGridField>
        </Fields>
        <OptionsView ShowRowGrandTotals="False"  />
        <Groups>
            <dx:PivotGridWebGroup Caption="Year - Half Year - Quarter - Month - Date" 
                Hierarchy="[Month].[Year - Half Year - Quarter - Month - Date]" />
        </Groups>
        
    </dx:ASPxPivotGrid>
    </div>
    </div>
    
</asp:Content>

