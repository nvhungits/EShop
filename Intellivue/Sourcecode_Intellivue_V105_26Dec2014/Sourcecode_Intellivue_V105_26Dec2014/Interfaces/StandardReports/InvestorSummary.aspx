<%@ Page Title="I N T E L L I V U E - Investor Summary Report" Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="InvestorSummary.aspx.cs" Inherits="Sourcecode_Intellivue.Interfaces.StandardReports.InvestorSummary" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
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
//Function happens when submit button is clicked
//This function view InvestorSummary Report
function ViewInvestorSummaryReport_onclick()
{
    var UserID = document.getElementById("username") ; 
    var InvestmentOption = document.getElementById("<%=InvestmentOption.ClientID%>");
    var UnitPriceType = document.getElementById("<%=UnitPriceType.ClientID%>");
    var Date = document.getElementById("<%=MyDate.ClientID%>");
    var strDate = toYYYYMMDD(Date.value);
    var GroupBy = document.getElementById("<%=GroupBy.ClientID%>");
     
    var frame = document.getElementById("ReportViewer1");
    frame.src = "ReportPage.aspx?KeyName=InvestorSummary&ParameterNames=UserID~InvestmentOption~UnitPriceType~Date~GroupBy&ParameterValues=" + 
    UserID.value + "~" + InvestmentOption.value + "~" + UnitPriceType.value + "~"+ strDate + "~" + GroupBy.value;
       
    //document.frmMain.txtAction.value = "InvestorSummary"
    //document.frmMain.submit()
}

/*************************************************************************/
/*
//Function to generate Options for InvestmentOption of Select Object
function generateInvestmentOption(Product)
{
   var elements = document.getElementsByName("Product-" + Product)
   var investmentOptionObj = document.getElementById("InvestmentOption")
   
   //Clear Options before insert
   clearOptions(investmentOptionObj)
   
   //Insert Default Options
   createOptions(investmentOptionObj,"0 - All InvestmentOptions","0")
   investmentOptionObj.selectedIndex = 0
   
   for(i=0;i<elements.length;i++)
   {
        createOptions(investmentOptionObj,elements[i].value,elements[i].id)
   }
}

//Function happens when submit button is clicked
function ViewReport_onclick()
{
    var UserID = document.getElementById("username") ; 
    var InvestmentOption = document.getElementById("InvestmentOption");
    var UnitPriceType = document.getElementById("UnitPriceType");
    var Date = document.getElementById("Date");
    var strDate = toYYYYMMDD(Date.value);
    var GroupBy = document.getElementById("GroupBy");
     
    var frame = document.getElementById("ReportViewer1");
    frame.src = "ReportPage.aspx?KeyName=InvestorSummary&ParameterNames=UserID~InvestmentOption~UnitPriceType~Date~GroupBy&ParameterValues=" + 
    UserID.value + "~" + InvestmentOption.value + "~" + UnitPriceType.value + "~"+ strDate + "~" + GroupBy.value;
       
    //document.frmMain.txtAction.value = "InvestorSummary"
    //document.frmMain.submit()
}
*/
/*******************************************************************************/
</script>

<input type="hidden" id="username" value ="<%=Session["username"].ToString().ToUpper() %>" />
<div class="page_navigation " style="margin-top:38px;">
                    <asp:SiteMapPath ID="SiteMapPath2" runat="server" PathDirection="RootToCurrent" PathSeparatorStyle-Font-Bold="true" PathSeparator="&nbsp; >> &nbsp;" PathSeparatorStyle-Font-Size="12px" PathSeparatorStyle-ForeColor="#b6d0c2">
                    </asp:SiteMapPath>
                    </div>   
                    		
<table border="0"  style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                width:100%; padding-top: 5px; border-bottom: black 1px solid; background-color: #A3C4B4;" id="table8">
                <tr>
                    <td width="45%" valign="top" bgcolor="#A3C4B4" style="height: 41px">
                        <table width="100%" id="table9">
                            <tr>
                                <td class="lbNormal" style="width: 134px; height: 23px;">Investment Option</td>
                                <td style="height: 23px">
                                
                                    <select id="InvestmentOption" runat="server" class="lbNormal" name="InvestmentOption">
                                        <option selected="selected" value="0">0 - All Products</option>
                                    </select>
                                        
                              </td>
                            </tr>
                            <tr>
                                <td class="lbNormal" style="width: 134px">
                                    Unit Price Type</td>
                                <td>
                                <select id="UnitPriceType" runat="server" class="lbNormal" name="UnitPriceType">
                                    <option selected="selected" value="R">Redemption Price</option>
                                    <option value="N">MID Price</option>
                                </select>    
                                </td>
                            </tr>
                        </table>
                  </td>
                    <td width="40%" valign="top" bgcolor="#A3C4B4" style="height: 41px">
                        <table width="100%" id="table10">
                            <tr>
                                <td class="lbNormal" style="width: 94px; height: 23px;"> Date</td>
                                <td style="height: 23px">
                                    <input id="MyDate" runat="server" class="lbNormal" name="Date" style="width: 120px"
                                        type="text" tabindex="2" />
                                    <img id="Img2" runat="server" alt="" onclick="displayDatePicker('ctl00_ContentPlaceHolder1_MyDate', false, 'dmy', '/');"
                                        src="../../Images/Datetime.gif" style="cursor: pointer" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbNormal" style="width: 94px; height: 23px">Group By
                                </td>
                                <td style="height: 23px">
                                <select id="GroupBy" runat="server" class="lbNormal" name="GroupBy">
                                    <option selected="selected" value="P">Product</option>
                                    <option value="I">Investment Option</option>
                                </select>
                                <input type="hidden" name="txtAction" id = "txtAction" />
                                </td>
                            </tr>
                        </table>
                  </td>
                    <td width="15%" valign="top" bgcolor="#A3C4B4" style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px; border-left: black 1px solid;
                        padding-top: 10px; height: 41px">
                        <table id="table11">
                            <tr>

                                <td class="new_button">
                                    <input id="ViewReport"  type="button" value="View Report" style="width:100px;background:none;border:none;" class="new_button"  onclick="javascript:ViewInvestorSummaryReport_onclick()" />
                                </td>
                            </tr>
                        </table>
                  </td>
                </tr>                
            </table>
<table border="0" width="100%" id="table1" height="736" cellspacing="0" cellpadding="0">
			<tr>				
				<td width="100%" align="left" valign="top" style="height: 669px">
				<iframe id="ReportViewer1" align="center" Width="100%" style=" height:auto; min-height:771px;" name="ReportViewer1" border="0px" marginwidth="-10px" marginheight="-10px" frameborder="0px" scrolling="auto">
                </iframe>
     	
        </td>
			</tr>
			
		</table>
</asp:Content>