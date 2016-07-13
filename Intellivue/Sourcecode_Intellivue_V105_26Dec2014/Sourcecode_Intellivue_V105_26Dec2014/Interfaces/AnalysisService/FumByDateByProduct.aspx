<%@ Page Title="I N T E L L I V U E - FUM By Date By Product" Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="FumByDateByProduct.aspx.cs" Inherits="Sourcecode_Intellivue.Interfaces.AnalysisService.FumByDateByProduct" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

<script type="text/javascript">
/*************************************************************************/




//Get InvestmentOption from GetInvestmentOptionMonth.aspx (AJAX)
function generateInvestmentOption()
{
   var e =document.getElementById("<%=Product.ClientID %>")
   var Product = e.options[e.selectedIndex].value  
   var url = '../AJAX/GetInvOptFUM_ByProduct.aspx';
   
   //Remove the & symbol for easily to transfer to GetKPIMonth
   var content = 'Product=' + Product.replace(/&/,"#");
   loadXMLDoc(url,'ProductChange()',content);
   
}
//Get KPI from GetKPIMonth (AJAX)
function ProductChange()
{
    if (xmlhttp.readyState==4)
 	 {
 		 if (xmlhttp.status==200)
 		 {
 		 	 str = xmlhttp.responseText;
 		 	 //alert(str)
  			 var InvOption = document.getElementById('InvestmentOption_Display');
  			 InvOption.innerHTML = str;
		}
	}		 
}



//Function happens when submit button is clicked
function ViewReport_onclick()
{
    var Product = document.getElementById("<%=Product.ClientID %>");
    Product = Product.options[Product.selectedIndex].text;
    var InvestmentOption = document.getElementById("<%=InvestmentOption.ClientID %>");  //document.getElementById("<%=InvestmentOption.ClientID %>");
    InvestmentOption = InvestmentOption.options[InvestmentOption.selectedIndex].text;
    var Year = document.getElementById("<%=Year.ClientID %>");
    var Month = document.getElementById("<%=Month.ClientID %>");
    
    var frame = document.getElementById("ReportViewer1");
    frame.src = "ReportPage.aspx?KeyName=Fum_ByDate_ByProduct&ParameterNames=Product~InvestmentOption~Year~Month&ParameterValues=" + Product + "~" + InvestmentOption + "~" + Year.value.replace(/&/,"%") + "~" + Month.value.replace(/&/,"%");
}
/*******************************************************************************/
</script>

<div class="page_navigation " style="margin-top:38px;">
            <asp:SiteMapPath ID="SiteMapPath2" runat="server" PathDirection="RootToCurrent" PathSeparatorStyle-Font-Bold="true" PathSeparator="&nbsp; >> &nbsp;" PathSeparatorStyle-Font-Size="12px" PathSeparatorStyle-ForeColor="#b6d0c2">
            </asp:SiteMapPath>
            </div>
 
<input type="hidden" name="txtAction" id="txtAction" class="lbNormal" />
    
	
		<table border="0" width="100%" id="table1" style="" cellspacing="0" cellpadding="0" >
			<tr>
				<td valign="top" style="width: 100%; height: 51px" colspan="2">
            <table border="0" style="padding-right: 5px; padding-left: 5px; 
                width:100%; padding-top: 5px; border-bottom: black 1px solid; background-color: #A3C4B4" id="table2">
                <tr>
                    <td valign="top" bgcolor="#A3C4B4" style="height: 41px; width: 39%;">
                        <table width="100%" id="table3">
                            
                            <tr>
                                <td class="lbNormal" style="width: 134px">Product
                              </td>
                                <td>
                                   <select id="Product" runat="server" class="lbNormal" name="Product" onchange="javascript:generateInvestmentOption()">
                                        
                                  </select> 
                                    
                                    
                              </td>
                            </tr>
                            <tr>
                                <td class="lbNormal" style="width: 134px">
                                    Year</td>
                                <td>
                                <select id="Year" runat="server" class="lbNormal" name="Year">
                                        
                                </select> 
                                </td>
                            </tr>
                        </table>
                  </td>
                    <td width="40%" valign="top" bgcolor="#A3C4B4" style="height: 41px">
                        <table width="100%" id="table4">
                            
                            <tr>
                                <td class="lbNormal" style="width: 145px; ">
                                    Investment Option</td>
                                <td class="lbNormal">
                                    <div id="InvestmentOption_Display">
                                        <select id="InvestmentOption" class="lbNormal" name="InvestmentOption" runat="server" enableviewstate="true">
                                                <option value="[All]">All</option>
                                        </select>
                                        
                                        
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbNormal" style="width: 145px">
                                    Month</td>
                                <td class="lbNormal">
                                <div id="Month_Display">
                                        <select id="Month" class="lbNormal" name="Month" runat="server" enableviewstate="true">
                                                <option value="[All]">All</option>
                                        </select>
                                 </div>
                                </td>
                            </tr>
                        </table>
                  </td>
                    <td width="15%" valign="top" bgcolor="#A3C4B4" style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px; border-left: black 1px solid;
                        padding-top: 10px; height: 41px">
                        <table  id="table5">
                            <tr>
                                <td class="new_button">
                                    
                                   <input id="viewreport"  type="button" value="View Report" style="width:100px;background:none;border:none;" class="new_button"  onclick="javascript:ViewReport_onclick()" />                      
                                </td>
                            </tr>
                        </table>
                  </td>
                </tr>                
            </table>
     			</td>
			</tr>
		</table>
        
			<table border="0" width="100%" id="table8" height="auto" cellspacing="0" cellpadding="0">
				<tr>
				  <td width="100%"><iframe id="ReportViewer1" scrolling="auto" style="height:800px; width:100%" marginwidth="0" marginheight="0" name="I1" border="0" frameborder="0"> </iframe></td>
				</tr>
			
			</table>
	
</asp:Content>
