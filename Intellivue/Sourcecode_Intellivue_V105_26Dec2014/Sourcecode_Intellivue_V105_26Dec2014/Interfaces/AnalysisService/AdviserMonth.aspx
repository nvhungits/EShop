<%@ Page Language="C#" Title="I N T E L L I V U E - Adviser By Product Mont" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true" CodeBehind="AdviserMonth.aspx.cs" Inherits="Sourcecode_Intellivue.Interfaces.AnalysisService.AdviserMonth" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
 <script type="text/javascript">
/*************************************************************************/
//Generate KPI based on Category
function generateKPI()
{
 var e =document.getElementById("<%=Category.ClientID %>")
   var GroupKPI = e.options[e.selectedIndex].value  
   var url = '../AJAX/GetKPIMonth.aspx'
   
   //Remove the & symbol for easily to transfer to GetKPIMonth
   var content = 'Category=' + GroupKPI.replace(/&/,"#")
   loadXMLDoc(url,'CategoryChange()',content)
}



//Get KPI from GetKPIMonth.aspx (AJAX)
function CategoryChange()
{
    if (xmlhttp.readyState==4)
 	{
 		 if (xmlhttp.status==200)
 		 {
 		 	 str = xmlhttp.responseText;
  			 var kpi = document.getElementById('KPI_Display')
  			 kpi.innerHTML = str
		}
	}		 
}

//Get InvestmentOption from GetInvestmentOptionMonth.aspx (AJAX)
function generateInvestmentOption()
{
  var e =document.getElementById("<%=Product.ClientID %>")
   var Product = e.options[e.selectedIndex].value  
   var url = '../AJAX/GetInvestmentOptionMonth.aspx'
   
   //Remove the & symbol for easily to transfer to GetKPIMonth
   var content = 'Product=' + Product.replace(/&/,"#")
   loadXMLDoc(url,'ProductChange()',content)
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
  			 var InvOption = document.getElementById('InvestmentOption_Display')
  			 InvOption.innerHTML = str
		}
	}		 
}



//Function happens when submit button is clicked
function ViewReport_onclick()
{
    var GroupKPI = document.getElementById("<%=Category.ClientID %>")
    var KPI = document.getElementById("<%=KPI.ClientID %>");
    var Product = document.getElementById("<%=Product.ClientID %>");
    var InvestmentOption = document.getElementById("<%=InvestmentOption.ClientID %>");
    var Year = document.getElementById("<%=Year.ClientID %>");
    var Month = document.getElementById("<%=Month.ClientID %>");
    
    var frame = document.getElementById("ReportViewer1");
    frame.src = "ReportPage.aspx?KeyName=AdviserMonth&ParameterNames=GroupKPI~KPI~Product~InvestmentOption~Year~Month&ParameterValues=" + GroupKPI.value.replace(/&/,"%") + "~" + KPI.value.replace(/&/,"%") + "~" + Product.value.replace(/&/,"%") + "~" + InvestmentOption.value.replace(/&/,"%") + "~" + Year.value.replace(/&/,"%") + "~" + Month.value.replace(/&/,"%");

}
/*******************************************************************************/
function ReportViewer1_onblur() {

}

</script>
<div class="page_navigation " style="margin-top:38px;">
            <asp:SiteMapPath ID="SiteMapPath2" runat="server" PathDirection="RootToCurrent" PathSeparatorStyle-Font-Bold="true" PathSeparator="&nbsp; >> &nbsp;" PathSeparatorStyle-Font-Size="12px" PathSeparatorStyle-ForeColor="#b6d0c2">
            </asp:SiteMapPath>
            </div>
  
<input type="hidden" name="txtAction" id="txtAction" class="lbNormal" />
    	
		<table border="0" id="table8"  style=""  cellspacing="0" cellpadding="0" height="859" width="100%">
			<tr bgcolor="#A3C4B4">
				<td width="904" colspan="2" valign="top">
            <table border="0" style=" width:100%; border-bottom: 1px solid black; background-color: #A3C4B4" id="table9">
                <tr>
                    <td style="height: 41px; width: 34%;" valign="top">
                        <table width="100%" id="table10" bgcolor="#A3C4B4">
                            <tr>
                                <td class="lbNormal" style="width: 134px; height: 23px;">
                                    Category</td>
                                <td style="height: 23px">
                                
                                    <select id="Category" runat="server" class="lbNormal" name="Category" onchange="javascript:generateKPI()">
                                        
                                    </select>
                                     
                                       
                                        
                                    </td>
                            </tr>
                            <tr>
                                <td class="lbNormal" style="width: 134px">
								Product
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
                    <td style="height: 41px" valign="top" width="39%">
                        <table width="99%" id="table11" bgcolor="#A3C4B4">
                            <tr>
                                <td class="lbNormal" style="width: 116px; "> KPI</td>
                                <td style="height: 23px">
                                    <div id="KPI_Display">
                                        <select id="KPI" class="lbNormal" name="KPI" runat="server" enableviewstate="true">
                                            <option value="[All]">All</option>
                                        </select>
                                          
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbNormal" style="width: 116px; ">
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
                                <td class="lbNormal" style="width: 116px">
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
                    <td style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px; border-left: black 1px solid;
                        padding-top: 10px; height: 41px; width: 16%;" valign="top" bgcolor="#A3C4B4">
                        <table  id="table12" bgcolor="#A3C4B4">
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
			
			<tr>
				
				<td  valign="top" width="100%">
     				<iframe id="ReportViewer1" width="100%" height="800px" marginwidth="1" marginheight="1" name="ReportViewer1" border="0" frameborder="0" language="javascript" onblur="return ReportViewer1_onblur()">
   				    </iframe>
     			</td>
			</tr>
			
		</table>
	
       
</asp:Content>
