<%@ Page Title="I N T E L L I V U E - Adviser Funding Outflow" Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="FumReport.aspx.cs" Inherits="Sourcecode_Intellivue.Interfaces.StandardReports.FumReport" %>
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

//Function to generate Options for InvestmentOption of Select Object
function generateInvestmentOption(Product)
{
   var elements = document.getElementsByName("Product-" + Product)
   var investmentOptionObj = document.getElementById("<%=InvestmentOption.ClientID%>")
   
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
//This function view FUM Report
function ViewFumReport_onclick()
{
    var Product = document.getElementById("<%=Product.ClientID%>");
    var InvestmentOption = document.getElementById("<%=InvestmentOption.ClientID%>");   
    var Date = document.getElementById("<%=MyDate.ClientID %>");
    strDate = toYYYYMMDD(Date.value);
    var UserID = document.getElementById("username") ; 
        
    var frame = document.getElementById("ReportViewer1");
    frame.src = "ReportPage.aspx?KeyName=FumReport&ParameterNames=Product~" +
    "InvestmentOption~Date~UserID&ParameterValues=" + Product.value + "~" + InvestmentOption.value + "~" + strDate + "~" + UserID.value;
       
     //document.form1.txtAction.value = "Fum"
     //document.form1.submit()
}


</script>


<input type="hidden" name="txtAction" id="txtAction" class="lbNormal" />
<input type="hidden" id="username" value ="<%=Session["username"].ToString().ToUpper() %>" />
 <div class="page_navigation " style="margin-top:38px;">
                    <asp:SiteMapPath ID="SiteMapPath2" runat="server" PathDirection="RootToCurrent" PathSeparatorStyle-Font-Bold="true" PathSeparator="&nbsp; >> &nbsp;" PathSeparatorStyle-Font-Size="12px" PathSeparatorStyle-ForeColor="#b6d0c2">
                    </asp:SiteMapPath>
                    </div>        
    
<table border="0"  width="100%" id="table7" cellspacing="0" cellpadding="0" style="height: 812px">
			<tr>
				<td valign="top" height="55" colspan="2">
    <table width="100%" border="0" style="background-color:#A3C4B4;padding:5px;background-color:#A3C4B4;border-bottom-style:Solid; border-bottom-color:black;border-bottom:1px;"  id="table9" cellspacing="0" cellpadding="0">
        <tr>
            <td width="45%" valign="top" bgcolor="#A3C4B4">
                <table width="100%" id="table10">
                    <tr>
                        <td class="lbNormal" style="width: 77px">
                            Product</td>
                        <td>
                            
                             <select id="Product" name="Product" runat="server" class="lbNormal" onchange="javascript:generateInvestmentOption(this.value)">
                                
                            </select>
                            <%
                                //Load all the Adviser and AdviserGroup 

                                
                                    string sql = "EXEC sp_getAllInvestmentOption";
                                    try
                                    {
                                        this.objData.ConnectData();
                                        this.objData.ExeReader(sql);


                                        while (this.objData.dataRead.Read())
                                        {
                                            Response.Write("<input type=\"hidden\" name=\"Product-" + this.objData.dataRead.GetValue(2).ToString() + "\" value=\"" + this.objData.dataRead.GetString(0) + "\" id=\"" + this.objData.dataRead.GetValue(1).ToString() + "\" >");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        //Response.Write(ex.Message)
                                        ASPNET_MessageBox(ex.Message);
                                    }
                                    finally
                                    {
                                        this.objData.CloseData();
                                    }
                                
                            %>  
                        </td>    
                    </tr>
                    <tr>
                        <td class="lbNormal" style="width: 77px">
                            Date</td>
                        <td>
                        <input id="MyDate" name="Date"  type="text" runat="server" style="width: 120px" class="lbNormal" />
                            <img alt="Choose Date" runat="server" src="../../Images/Datetime.gif" onclick="displayDatePicker('ctl00_ContentPlaceHolder1_MyDate', false, 'dmy', '/');" id="Img1" style="cursor:pointer;"/></td>
                    </tr>
                </table>
            </td>
            <td width="40%" valign="top" bgcolor="#A3C4B4">
                <table width="100%" id="table11">
                    <tr>
                        <td style="width: 91px;" class="lbNormal">
                            Investment Option</td>
                        <td>
                            <select id="InvestmentOption" name="InvestmentOption" runat="server" class="lbNormal">
                                <option value="0">0 - All InvestmentOptions</option>                                         
                            </select>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="15%" valign="top" bgcolor="#A3C4B4" style="border-left:1px black Solid;padding:10px;">
                <table id="table12">
                    <tr>
                        
                        
                        <td class="new_button">
                            <input id="ViewReport"  type="button" value="View Report" style="width:100px;background:none;border:none;" class="new_button"  onclick="javascript:ViewFumReport_onclick()" />                      
                            </td>
                    </tr>
                </table>
            </td>
            
        </tr>
    </table>
        		</td>
			</tr>
			<tr>
				
				<td align="left" valign="top">
    	<iframe id="ReportViewer1" Width="100%" style="height:auto; min-height:771px;" name="ReportViewer1" border="0px" marginwidth="-10px" marginheight="-10px" frameborder="0px" scrolling="auto">
                      </iframe>
      
        </td>
			</tr>
			
		</table>
	
	 
</asp:Content>
