<%@ Page Title="I N T E L L I V U E - Funds Flow By Product Report" Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="FundsFlowByProduct.aspx.cs" Inherits="Sourcecode_Intellivue.Interfaces.StandardReports.FundsFlowByProduct" %>
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
//This function view FundsFlowByProduct Report
function ViewFundsFlowByProductReport_onclick()
{
    var UserID = document.getElementById("username") ; 
    var DateFrom = document.getElementById("<%= DateFrom.ClientID%>");
    var strDateFrom = toYYYYMMDD(DateFrom.value);
    var DateTo = document.getElementById("<%= DateTo.ClientID%>");
    var strDateTo = toYYYYMMDD(DateTo.value);
       
    var frame = document.getElementById("ReportViewer1");
    frame.src = "ReportPage.aspx?KeyName=FundsFlowByProduct&ParameterNames=UserID~DateFrom~DateTo&ParameterValues=" + 
    UserID.value + "~" + strDateFrom + "~" + strDateTo;
       
    //document.form1.txtAction.value = "FundsFlowByProduct"
    //document.form1.submit()
}
/*************************************************************************/
/*
//Function happens when submit button is clicked
function ViewReport_onclick()
{
    var UserID = document.getElementById("username") ; 
    var DateFrom = document.getElementById("DateFrom");
    var strDateFrom = toYYYYMMDD(DateFrom.value);
    var DateTo = document.getElementById("DateTo");
    var strDateTo = toYYYYMMDD(DateTo.value);
       
    var frame = document.getElementById("ReportViewer1");
    frame.src = "ReportPage.aspx?KeyName=FundsFlowByProduct&ParameterNames=UserID~DateFrom~DateTo&ParameterValues=" + 
    UserID.value + "~" + strDateFrom + "~" + strDateTo;
       
    //document.form1.txtAction.value = "FundsFlowByProduct"
    //document.form1.submit()
}
/*******************************************************************************/
</script>

<input type="hidden" id="username" value ="<%=Session["username"].ToString().ToUpper() %>" />       
<input type="hidden" name="txtAction" id="txtAction" class="lbNormal" />
<div class="page_navigation " style="margin-top:38px;">
                    <asp:SiteMapPath ID="SiteMapPath2" runat="server" PathDirection="RootToCurrent" PathSeparatorStyle-Font-Bold="true" PathSeparator="&nbsp; >> &nbsp;" PathSeparatorStyle-Font-Size="12px" PathSeparatorStyle-ForeColor="#b6d0c2">
                    </asp:SiteMapPath>
                    </div>   
    
		<table border="0" width="100%" id="table7" height="813" cellspacing="0" cellpadding="0">
			<tr>
				<td valign="top" width="100%" colspan="2" style="height: 39px">
            <table border="0" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; width:100%; 
                padding-top: 5px; border-bottom: black 1px solid; background-color: #A3C4B4; " id="table9">
                <tr>
                    <td valign="top" bgcolor="#A3C4B4" style="height: 28px; width: 41%;">
                        <table width="100%" id="table10">
                            <tr>
                                <td class="lbNormal" style="width: 134px; height: 23px;">
                                    Date From</td>
                                <td style="height: 23px">
                                    <input id="DateFrom" runat="server" class="lbNormal" name="DateFrom" style="width: 120px"
                                        type="text" tabindex="2" />
                                    <img id="Img1" runat="server" alt="" onclick="displayDatePicker('ctl00_ContentPlaceHolder1_DateFrom', false, 'dmy', '/');"
                                        src="../../Images/Datetime.gif" style="cursor: pointer" />
                              </td>
                            </tr>
                            
                        </table>
                  </td>
                    <td valign="top" bgcolor="#A3C4B4" style="height: 28px; width: 42%;">
                        <table width="100%" id="table11">
                            <tr>
                                <td class="lbNormal" style="width: 94px; height: 23px;"> Date To</td>
                                <td style="height: 23px">
                                    <input id="DateTo" runat="server" class="lbNormal" name="DateTo" style="width: 120px"
                                        type="text" tabindex="2" />
                                    <img id="Img2" runat="server" alt="" onclick="displayDatePicker('ctl00_ContentPlaceHolder1_DateTo', false, 'dmy', '/');"
                                        src="../../Images/Datetime.gif" style="cursor: pointer" />
                                </td>
                            </tr>
                            
                        </table>
                  </td>
                    <td valign="top" bgcolor="#A3C4B4" style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px; border-left: black 1px solid;
                        padding-top: 10px; height: 28px; width: 15%;">
                        <table  id="table12">
                            <tr>
                                
                                
                                <td class="new_button">
                                <input id="ViewReport"  type="button" value="View Report" style="width:100px;background:none;border:none;" class="new_button"  onclick="javascript:ViewFundsFlowByProductReport_onclick()" />
                                </td>
                            </tr>
                        </table>
                  </td>
                </tr>                
            </table>
     			</td>
			</tr>
			<tr>
				
				<td valign="top" width="100%" style="height: 517px">
				 <iframe id="ReportViewer1" Width="100%" style="height:auto; min-height:771px;" name="ReportViewer1" border="0px"  frameborder="0px" scrolling="auto">
                  </iframe>
   
    			</td>
			</tr>			
		</table>
	
</asp:Content>

