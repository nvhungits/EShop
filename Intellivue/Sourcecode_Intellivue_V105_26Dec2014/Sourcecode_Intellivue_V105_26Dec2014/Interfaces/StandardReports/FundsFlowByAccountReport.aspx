<%@ Page Title="I N T E L L I V U E - Funds Flow By Account Report" Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="FundsFlowByAccountReport.aspx.cs" Inherits="Sourcecode_Intellivue.Interfaces.StandardReports.FundsFlowByAccountReport" %>
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

<script type="text/javascript" language="javascript">

//Function happens when submit button is clicked
//This function view FundsFlowByAccount Report
function ViewFundsFlowByAccountReport_onclick()
{
    var UserID = document.getElementById("username") ; 
    var InvestmentOption = document.getElementById("<%=InvestmentOption.ClientID%>");    
    var UnitPriceType = document.getElementById("<%=UnitPriceType.ClientID%>");
    var DateFrom = document.getElementById("<%= DateFrom.ClientID%>");
    var strDateFrom = toYYYYMMDD(DateFrom.value);
    var DateTo = document.getElementById("<%= DateTo.ClientID%>");
    var strDateTo = toYYYYMMDD(DateTo.value);
     
    var frame = document.getElementById("ReportViewer1");
    frame.src = "ReportPage.aspx?KeyName=FundsFlowByAccount&ParameterNames=UserID~InvestmentOption~UnitPriceType~DateFrom~DateTo&ParameterValues=" + 
    UserID.value + "~" + InvestmentOption.value + "~" + UnitPriceType.value + "~"+ strDateFrom + "~" + strDateTo;
       
    //document.form1.txtAction.value = "FundsFlowByAccount"
    //document.form1.submit()
}

//Begin VTHIEP Functions
//Javascript written by VTHIEP 03-08-2006//

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
        if (elements[i].id != "0")
        {
            createOptions(investmentOptionObj,elements[i].value,elements[i].id)
        }    
   }
}

//Function happens when submit button is clicked
function ViewReport_onclick()
{
    var UserID = document.getElementById("username") ; 
    var InvestmentOption = document.getElementById("InvestmentOption");
    var UnitPriceType = document.getElementById("UnitPriceType");
    var DateFrom = document.getElementById("DateFrom");
    var strDateFrom = toYYYYMMDD(DateFrom.value);
    var DateTo = document.getElementById("DateTo");
    var strDateTo = toYYYYMMDD(DateTo.value);
     
    var frame = document.getElementById("ReportViewer1");
    frame.src = "ReportPage.aspx?KeyName=FundsFlowByAccount&ParameterNames=UserID~InvestmentOption~UnitPriceType~DateFrom~DateTo&ParameterValues=" + 
    UserID.value + "~" + InvestmentOption.value + "~" + UnitPriceType.value + "~"+ strDateFrom + "~" + strDateTo;
       
    //document.form1.txtAction.value = "FundsFlowByAccount"
    //document.form1.submit()
}
*/
</script>
<input type="hidden" name="txtAction" id="Hidden1" class="lbNormal" />
<input type="hidden" id="username" value="<%=Session["username"].ToString().ToUpper()%>" />
<div class="page_navigation " style="margin-top:38px;">
                    <asp:SiteMapPath ID="SiteMapPath2" runat="server" PathDirection="RootToCurrent" PathSeparatorStyle-Font-Bold="true" PathSeparator="&nbsp; >> &nbsp;" PathSeparatorStyle-Font-Size="12px" PathSeparatorStyle-ForeColor="#b6d0c2">
                    </asp:SiteMapPath>
                    </div>   
                      
<table  width="100%" border="0" cellspacing="0" style="background-color:#A3C4B4;padding:5px;background-color:#A3C4B4;border-bottom:1px Black Solid;" id="table2">
        <tr>
            <td valign="top" bgcolor="#A3C4B4" style="width: 33%">
                <table width="100%" id="table3">
                    <tr>
                        <td class="lbNormal" style="width: 104px; height: 20px;">
                            Date From</td>
                        <td style="height: 21px">
                            &nbsp;<input id="DateFrom" name="DateFrom"  type="text" runat="server" style="width: 120px" class="lbNormal" size="20" />
                            <img alt="Choose Date" runat="server" src="../../Images/Datetime.gif" onclick="displayDatePicker('ctl00_ContentPlaceHolder1_DateFrom', false, 'dmy', '/');" id="Img1" style="cursor:pointer;"/>
                      </td>    
                    </tr>
                    <tr>
                        <td class="lbNormal" style="width: 104px; height: 21px;">
                            Investment Options</td>
                        <td style="height: 21px">
                            <select id="InvestmentOption" name="InvestmentOption" runat="server" class="lbNormal"></select></td>
                    </tr>
                </table>
          </td>
            <td valign="top" bgcolor="#A3C4B4" style="width: 34%">
                <table width="100%" id="table4">
                    <tr>
                        <td style="width: 91px; height: 23px;" class="lbNormal">
                            Date To</td>
                        <td style="height: 23px; width: 195px;">
                            &nbsp;<input id="DateTo" name="DateTo"  type="text" runat="server" style="width: 120px" class="lbNormal" />
                            <img alt="Choose Date" runat="server" src="../../Images/Datetime.gif" onclick="displayDatePicker('ctl00_ContentPlaceHolder1_DateTo', false, 'dmy', '/');" id="Img2" style="cursor:pointer;"/></td>
                    </tr>
                </table><table width="100%" id="table5">
                    <tr>
                        <td style="width: 91px; height: 23px;" class="lbNormal">
                            Unit Price Type</td>
                        <td style="height: 23px; width: 195px;">
                            &nbsp;<select id="UnitPriceType" name="UnitPriceType" runat="server" class="lbNormal">
                            </select>
                        </td>
                    </tr>
                </table>
          </td>
            
            <td valign="top" bgcolor="#A3C4B4" style="border-left:1px Black Solid;padding:10px; width: 3%;">
                <table id="table6">
                    <tr>
                        <td class="new_button">
                            <input type="hidden" name="txtAction" id="txtAction" class="lbNormal" />
                            <input id="ViewReport"  type="button" value="View Report" style="width:100px;background:none;border:none;" class="new_button"  onclick="javascript:ViewFundsFlowByAccountReport_onclick()" />
                        </td>
                        
                        
                
                    </tr>
                </table>
          </td>
            
        </tr>
    </table>
        <table Width="100%" style=" height: 722px" border="0" cellpadding="0" cellspacing="0">
            <tr>                
                <td valign="top" height="651" style="width: 100%">
                <iframe id="ReportViewer1"  Width="100%" style="height:auto; min-height:771px;" name="ReportViewer1" border="0px" marginwidth="-10px" marginheight="-10px" frameborder="0px" scrolling="auto">
                  </iframe>
       
		    </td>
            </tr>
            
    </table>
  
</asp:Content>

