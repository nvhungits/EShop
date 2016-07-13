<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="AdviserWeek.aspx.cs" Inherits="Sourcecode_Intellivue.Interfaces.AnalysisService.AdviserWeek" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <!--
// ============================================================================ '
// =         Copyright (c) 2006. MMSOFT Co., Ltd. All Rights Reserved.        = '
// =                                                                          = '
// =  Permission to use, copy, modify, and distribute this software and its   = '
// =  documentation for any purpose, without fee, and without a written       = '
// =  agreement, is here by granted, provided that the above copyright notice,= '
// =  this paragraph and the following two paragraphs appear in all copies,   = '
// =  modifications, and distributions.  Created by:                          = '
// =                                                                          = '
// =                        M.M..S.O.F.T.W.A.R.E                              = '
// =                                                                          = '
// =  MM Software Co., Ltd, 35 Tan Vinh Street, Ward 4                        = '
// =  District 4, Ho Chi Minh City, Viet Nam.                                 = '
// =  For technical information, contact mmsoftvn@gmail.com                   = '
// =                                                                          = '
// =  IN NO EVENT SHALL REGENTS BE LIABLE TO ANY PARTY FOR DIRECT, INDIRECT,  = '
// =  SPECIAL, INCIDENTAL, OR CONSEQUENTIAL DAMAGES, INCLUDING LOST PROFITS,  = '
// =  ARISING OUT OF THE USE OF THIS SOFTWARE AND ITS DOCUMENTATION, EVEN IF  = '
// =  REGENTS HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.             = '
// =                                                                          = '
// =  REGENTS SPECIFICALLY DISCLAIMS ANY WARRANTIES, INCLUDING, BUT NOT       = '
// =  LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A = '
// =  PARTICULAR PURPOSE. THE SOFTWARE AND ACCOMPANYING DOCUMENTATION, IF     = '
// =  ANY, PROVIDED HEREUNDER IS PROVIDED "AS IS". REGENTS HAS NO OBLIGATION  = '
// =  TO PROVIDE MAINTENANCE, SUPPORT, UPDATES, ENHANCEMENTS, OR              = '
// =  MODIFICATIONS.                                                          = '
// ============================================================================ '
-->


 <script type="text/javascript">
/*************************************************************************/
//Generate KPI based on Category
function generateKPI()
{
   var e =document.getElementById("<%=Category.ClientID %>")
   var GroupKPI = e.options[e.selectedIndex].value  
   
   var url = '../AJAX/GetKPIWeek.aspx' 
   
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
  
   var url = '../AJAX/GetInvestmentOptionWeek.aspx'
   
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
    var Week = document.getElementById("<%=Week.ClientID %>");
    
    var frame = document.getElementById("ReportViewer1");
    frame.src = "ReportPage.aspx?KeyName=AdviserWeek&ParameterNames=GroupKPI~KPI~Product~InvestmentOption~Year~Week&ParameterValues=" + GroupKPI.value.replace(/&/,"%") + "~" + KPI.value.replace(/&/,"%") + "~" + Product.value.replace(/&/,"%") + "~" + InvestmentOption.value.replace(/&/,"%") + "~" + Year.value.replace(/&/,"%") + "~" + Week.value.replace(/&/,"%");

}
/*******************************************************************************/
</script>

<div class="page_navigation " style="margin-top:38px;">
            <asp:SiteMapPath ID="SiteMapPath2" runat="server" PathDirection="RootToCurrent" PathSeparatorStyle-Font-Bold="true" PathSeparator="&nbsp; >> &nbsp;" PathSeparatorStyle-Font-Size="12px" PathSeparatorStyle-ForeColor="#b6d0c2">
            </asp:SiteMapPath>
            </div>
		<table border="0" width="100%" id="table1"  cellspacing="0" cellpadding="0" height="817">
			<tr>
				<td valign="top" style="height: 69px" width="1004" colspan="2">
            <table border="0" style=" width:100%; border-bottom: 1px solid black; background-color: #A3C4B4" id="table2">
                <tr>
                    <td valign="top" bgcolor="#A3C4B4" style="height: 41px; width: 38%;">
                        <table width="377" cellspacing="0" cellpadding="0" id="table3" style="height: 72px">
                            <tr>
                                <td class="lbNormal" style="width: 134px; height: 23px;">
                                    Category</td>
                                <td style="height: 23px; width: 244px;">
                                
                                    <select id="Category" runat="server" class="lbNormal" name="Category" onchange="javascript:generateKPI()">
                                        
                                    </select>
                                     
                                       
                                        
                              </td>
                            </tr>
                            <tr>
                                <td class="lbNormal" style="width: 134px">
								Product
                              </td>
                                <td style="width: 244px">
                                   <select id="Product" runat="server" class="lbNormal" name="Product" onchange="javascript:generateInvestmentOption()">
                                        
                                  </select> 
                                    
                                    
                              </td>
                            </tr>
                            <tr>
                                <td class="lbNormal" style="width: 134px">
                                    Year</td>
                                <td style="width: 244px">
                                <select id="Year" runat="server" class="lbNormal" name="Year">
                                        
                                </select> 
                                </td>
                            </tr>
                        </table>
                  </td>
                    <td valign="top" bgcolor="#A3C4B4" style="height: 41px; width: 41%;">
                        <table width="102%" id="table4">
                            <tr>
                                <td class="lbNormal" style="width: 124px; "> KPI</td>
                                <td style="height: 23px; width: 285px;">
                                    <div id="KPI_Display">
                                        <select id="KPI" class="lbNormal" name="KPI" runat="server" enableviewstate="true">
                                            <option value="[All]">All</option>
                                        </select>
                                          
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbNormal" style="width: 124px; ">
                                    Investment Option</td>
                                <td class="lbNormal" style="width: 285px">
                                    <div id="InvestmentOption_Display">
                                        <select id="InvestmentOption" class="lbNormal" name="InvestmentOption" runat="server" enableviewstate="true" style="width: 233px">
                                                <option value="[All]">All</option>
                                        </select>
                                        
                                        
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbNormal" style="width: 124px">
                                    Week</td>
                                <td class="lbNormal" style="width: 285px">
                                <div id="Week_Display">
                                        <select id="Week" class="lbNormal" name="Week" runat="server" enableviewstate="true">
                                                <option value="[All]">All</option>
                                        </select>
                                 </div>
                                </td>
                            </tr>
                        </table>
                  </td>
                    <td width="20%" valign="top" bgcolor="#A3C4B4" style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px; border-left: black 1px solid;
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
			
			<tr>
				
				<td valign="top" width="100%">                     
                     <iframe id="ReportViewer1" width="100%" height="1000" name="reportviewer1" border="0" marginwidth="-10px" marginheight="-5px" frameborder="0px" scrolling="auto">
                    </iframe>
				</td>
			</tr>
			
		</table>
	
</asp:Content>

