<%@ Page Title="I N T E L L I V U E - Adviser Funding Outflow" Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="AdviserOutflowReport.aspx.cs" Inherits="Sourcecode_Intellivue.Interfaces.StandardReports.AdviserOutflowReport" %>
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
//Function to generate Options for Adviser of Select Object
function generateAdviser(DealerGroup)
{

   var elements = document.getElementsByName("DealerGroup-" + DealerGroup);
   
   var adviserObj = document.getElementById("<%=Adviser.ClientID %>");
   
   //Clear Options before insert
   clearOptions(adviserObj)
   
   //Insert Default Options
   createOptions(adviserObj,"0 - All Adviser","0")
   adviserObj.selectedIndex = 0
   
   for(i=0;i<elements.length;i++)
   {
        if (elements[i].id != "0")
        {
            createOptions(adviserObj,elements[i].value,elements[i].id)
        }
   }  
}

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
//Function to generate Options for GroupLevel for 3 level of Select Object --npkhoi 
function generateGroupLevel(lv)
{
    var group = new Array('InvestmentOption','Product','Adviser','DealerGroup','AdviserState')
    var GroupLevel2 = document.getElementById("<%= GroupLevel2.ClientID%>")
    var GroupLevel1 = document.getElementById("<%= GroupLevel1.ClientID%>")
    var GroupLevel3 = document.getElementById("<%= GroupLevel3.ClientID%>")
    var GroupLevel4 = document.getElementById("<%= GroupLevel4.ClientID%>")
    
   
    if(lv==2)
    {
            clearOptions(GroupLevel2)  ;
          createOptions(GroupLevel2,"None","0");
          GroupLevel2.selectedIndex = 0;
          
    }        
    else if(lv==3)
    {
             
          //Clear Options before inserting
        clearOptions(GroupLevel3)
         //Insert Default Options
        createOptions(GroupLevel3,"None","0")
        GroupLevel3.selectedIndex = 0          
    }
    else if(lv==4)
    {
         //Clear Options before inserting
    clearOptions(GroupLevel4)
    
    //Insert Default Options
    createOptions(GroupLevel4,"None","0")
    GroupLevel4.selectedIndex = 0
    }    
    
    for(i=0;i<group.length;i++)
    {
        if(lv==2)
        {
            if (GroupLevel1.value != i + 1)
            {
                createOptions(GroupLevel2,group[i],i+1)
            }       
        }
        else if(lv==3)
        {
            if (GroupLevel2.value != i + 1 && GroupLevel1.value != i+1)
            {
                createOptions(GroupLevel3,group[i],i+1)
            }
        }   
        else if(lv==4)  
        {
            if (GroupLevel2.value != i + 1 && GroupLevel1.value != i+1 
                && GroupLevel3.value != i + 1)
            {
                createOptions(GroupLevel4,group[i],i+1)
            }
        }
           
        
    }
    if (GroupLevel2.value==0)
    {
        //Clear Options before inserting
        clearOptions(GroupLevel3)
        
        //Insert Default Options
        createOptions(GroupLevel3,"None","0")
        GroupLevel3.selectedIndex = 0
    }
    if (GroupLevel3.value==0)
    {
        //Clear Options before inserting
        clearOptions(GroupLevel4)
        
        //Insert Default Options
        createOptions(GroupLevel4,"None","0")
        GroupLevel4.selectedIndex = 0
    }
    //function to generate TopN Select Object
    generateTopN()
}

//Function happens when submit button is clicked
//This function view Adviser Outflow Report
function ViewAdviserOutflowReport_onclick()
{
    var DateFrom = document.getElementById("<%= DateFrom.ClientID%>");
    var strDateFrom = toYYYYMMDD(DateFrom.value);
    var DateTo = document.getElementById("<%= DateTo.ClientID%>");
    strDateTo = toYYYYMMDD(DateTo.value);
    var DealerGroup = document.getElementById("<%= DealerGroup.ClientID%>");
    var Adviser = document.getElementById("<%= Adviser.ClientID%>");
    var Product = document.getElementById("<%=Product.ClientID%>");
    var InvestmentOption = document.getElementById("<%=InvestmentOption.ClientID%>");    
    var GroupLevel1 = document.getElementById("<%=GroupLevel1.ClientID%>");
    var GroupLevel2 = document.getElementById("<%=GroupLevel2.ClientID%>");
    var GroupLevel3 = document.getElementById("<%=GroupLevel3.ClientID%>");
    var GroupLevel4 = document.getElementById("<%=GroupLevel4.ClientID%>");
    var AdviserState = document.getElementById("<%=AdviserState.ClientID%>");
    var TopN = document.getElementById("<%=TopN.ClientID%>");
    var UserID = document.getElementById("username") ; 
        
    var frame = document.getElementById("ReportViewer1");
    frame.src = "ReportPage.aspx?KeyName=AdviserOutflowReport&ParameterNames=DateFrom~DateTo~DealerGroup~Adviser~Product~" +
    "InvestmentOption~GroupLevel1~GroupLevel2~GroupLevel3~GroupLevel4~AdviserState~TopN~UserID&ParameterValues=" + strDateFrom + "~" + strDateTo + "~" + DealerGroup.value + "~" + Adviser.value 
    + "~" + Product.value + "~" + InvestmentOption.value + "~" + GroupLevel1.value + "~" + GroupLevel2.value + "~" + GroupLevel3.value + "~" + GroupLevel4.value + "~" + AdviserState.value + "~" + TopN.value + "~" + UserID.value;
    
    // document.form1.txtAction.value = "AdviserOutflow"
    // document.form1.submit()
}


/*************************************************************************/
//Begin VTHIEP Functions
//Javascript written by VTHIEP 03-08-2006//
/*
//Function to generate Options for TopN of Select Object
function generateTopN()
{
    var GroupLevel2 = document.getElementById("GroupLevel2")
    var TopNObj = document.getElementById("TopN")
   
    //Clear Options before inserting
    clearOptions(TopNObj)
    //Insert Default Options
    createOptions(TopNObj,"0 - All Records","0")
    createOptions.selectedIndex = 0  
    if (GroupLevel2.value == 0)
    {         
        createOptions(TopNObj,"5 - Top 5","5")
        createOptions(TopNObj,"10 - Top 10","10")
        createOptions(TopNObj,"20 - Top 20","20")
    }
}

//Function happens when submit button is clicked
function ViewReport_onclick()
{
    var DateFrom = document.getElementById("DateFrom");
    var strDateFrom = toYYYYMMDD(DateFrom.value);
    var DateTo = document.getElementById("DateTo");
    var strDateTo = toYYYYMMDD(DateTo.value);
    var DealerGroup = document.getElementById("DealerGroup");
    var Adviser = document.getElementById("Adviser");
    var Product = document.getElementById("Product");
    var InvestmentOption = document.getElementById("InvestmentOption");
    var GroupLevel1 = document.getElementById("GroupLevel1");
    var GroupLevel2 = document.getElementById("GroupLevel2");
    var GroupLevel3 = document.getElementById("GroupLevel3");
    var GroupLevel4 = document.getElementById("GroupLevel4");
    var AdviserState = document.getElementById("AdviserState");
    var TopN = document.getElementById("TopN");
    var UserID = document.getElementById("username") ; 
        
    var frame = document.getElementById("ReportViewer1");
    frame.src = "ReportPage.aspx?KeyName=AdviserOutflowReport&ParameterNames=DateFrom~DateTo~DealerGroup~Adviser~Product~" +
    "InvestmentOption~GroupLevel1~GroupLevel2~GroupLevel3~GroupLevel4~AdviserState~TopN~UserID&ParameterValues=" + strDateFrom + "~" + strDateTo + "~" + DealerGroup.value + "~" + Adviser.value 
    + "~" + Product.value + "~" + InvestmentOption.value + "~" + GroupLevel1.value + "~" + GroupLevel2.value + "~" + GroupLevel3.value + "~" + GroupLevel4.value + "~" + AdviserState.value + "~" + TopN.value + "~" + UserID.value;
    
    // document.form1.txtAction.value = "AdviserOutflow"
    // document.form1.submit()
}


//End VTHIEP Functions
/*******************************************************************************/



</script>

 
<input type="hidden" name="txtAction" id="txtAction" class="lbNormal" />
<input type="hidden" id="username" value="<%=Session["username"].ToString().ToUpper()%>" />    
 <div class="page_navigation " style="margin-top:38px;">
                    <asp:SiteMapPath ID="SiteMapPath2" runat="server" PathDirection="RootToCurrent" PathSeparatorStyle-Font-Bold="true" PathSeparator="&nbsp; >> &nbsp;" PathSeparatorStyle-Font-Size="12px" PathSeparatorStyle-ForeColor="#b6d0c2">
                    </asp:SiteMapPath>
                    </div>         
<table border="0"" width="100%" id="table11" height="auto" cellspacing="0" cellpadding="0">
	<tr>
		<td valign="top" height="145" style="width: 100%" colspan="2">
        <table width="100%" border="0" style="background-color:#A3C4B4;padding:5px;background-color:#A3C4B4;border-bottom:1px Black Solid; " id="table12">
           <tr>
            <td width="45%" height="141" valign="top" bgcolor="#A3C4B4">
                <table width="100%" id="table13">
                    <tr>
                        <td class="lbNormal" style="width: 77px">
                            Date From</td>
                        <td>
                        <input id="DateFrom" name="DateFrom"  type="text" runat="server" style="width:120px" class="lbNormal" />
                            <img alt="Choose Date From" runat="server" src="../../Images/Datetime.gif" onclick="displayDatePicker('ctl00_ContentPlaceHolder1_DateFrom', false, 'dmy', '/');" id="Img2" style="cursor:pointer;"/></td>
                    </tr>
                    <tr>
                        <td style="width: 77px;" class="lbNormal">
                            Dealer Group</td>
                        <td>
                            <select name="DealerGroup" id="DealerGroup" runat="server" class="lbNormal" onchange="javascript:generateAdviser(this.value);" enableviewstate="true">
                            
                            </select>
                            <%
                              //Load all the Adviser and AdviserGroup

                                
	                                string sql = "EXEC sp_getAdviser";
	                                try {
		                                this.objData.ConnectData();
		                                this.objData.ExeReader(sql);


		                                while (this.objData.dataRead.Read()) {

			                                Response.Write("<input type=\"hidden\" name=\"DealerGroup-" + this.objData.dataRead.GetValue(2).ToString() + "\" value=\"" + this.objData.dataRead.GetString(0) + "\" id=\"" + this.objData.dataRead.GetValue(1).ToString() + "\" >");
		                                }
	                                } catch (Exception ex) {
		                                //Response.Write(ex.Message)
		                                ASPNET_MessageBox(ex.Message);
	                                } finally {
		                                this.objData.CloseData();

	                                }
                                
                            %>     
                         
                          
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 77px;" class="lbNormal">
                            Product</td>
                        <td>
                            
                             <select id="Product" name="Product" runat="server" class="lbNormal" onchange="javascript:generateInvestmentOption(this.value)">
                                
                            </select>
                            <%
                                //Load all the Adviser and AdviserGroup 

                                
                                    sql = "EXEC sp_getAllInvestmentOption";
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
                        <td style="width: 77px;" class="lbNormal">
                            Adviser State</td>
                        <td>
                            <select id="AdviserState" runat="server" class="lbNormal" name="D1">
                               
                            </select></td>
                    </tr>
                    <tr>
                        <td class="lbNormal" style="width: 77px">
                            Group By</td>
                        <td>
                            <select id="GroupLevel1" runat="server" class="lbNormal" onchange="javascript:generateGroupLevel(2)" name="D2">
                                <option value="1">InvestmentOption</option>
                                <option value="2">Product</option>
                                <option value="3" selected="selected">Adviser</option>
                                <option value="4">DealerGroup</option>
                                <option value="5">AdviserState</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td class="lbNormal" style="width: 77px">
                            Group By</td>
                        <td>
                            <select id="GroupLevel3" runat="server" class="lbNormal" onchange="javascript:generateGroupLevel(4)" name="D3">
                                <option value="0" selected="selected">None</option>
                               
                            </select>
                             
                        </td>
                    </tr>
                </table>
            </td>
            <td width="40%" valign="top" bgcolor="#A3C4B4">
                <table width="100%" id="table14">
                    <tr>
                        <td class="lbNormal" style="width: 91px">
                            Date To</td>
                        <td>
                            <input id="DateTo" name="DateTo" type="text" runat="server" style="width: 120px" class="lbNormal" />
                            <img alt="Choose Date To" runat="server" src="../../Images/Datetime.gif" onclick="displayDatePicker('ctl00_ContentPlaceHolder1_DateTo', false, 'dmy', '/');" id="Img1" style="cursor:pointer" /></td>
                    </tr>
                    <tr>
                        <td style="width: 91px;" class="lbNormal">
                            Adviser</td>
                        <td>
                           
                         <select id="Adviser" class="lbNormal" name="Adviser" runat="server" enableviewstate="true">
                            <option value="0">0 - All Adviser</option>
                         </select>
                            
                            
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 91px;" class="lbNormal">
                            Investment Option</td>
                        <td>
                            <select id="InvestmentOption" name="InvestmentOption" runat="server" class="lbNormal">
                                <option value="0">0 - All InvestmentOptions</option>                                         
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 91px;" class="lbNormal">
                            TopN</td>
                        <td >
                            <select id="TopN" runat="server" name="TopN" class="lbNormal">
                                <option value="0" selected="selected">0 - All Records</option>
                                <option value="5">5 - Top 5</option>
                                <option value="10">10 - Top 10</option>
                                <option value="20">20 - Top 20</option>
                            </select></td>
                    </tr>
                    <tr>
                        <td class="lbNormal" style="width: 91px">
                            Group By</td>
                        <td>
                            <select id="GroupLevel2" class="lbNormal" runat="server" onchange="javascript:generateGroupLevel(3)" name="D4">
                                <option value="0" selected="selected">None</option>
                                <option value="1">InvestmentOption</option>
                                <option value="2">Product</option>
                                <option value="4">DealerGroup</option>
                                <option value="5">AdviserState</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td class="lbNormal" style="width: 91px">
                            Group By</td>
                        <td>
                            <select id="GroupLevel4" class="lbNormal" runat="server" name="D5">
                                <option value="0" selected="selected">None</option>
                            </select>
                        </td>
                    </tr>
                </table>
            </td>
            
            <td width="15%" valign="top" bgcolor="#A3C4B4" style="border-left:1px Black Solid;padding:10px;">
                <table  id="table15">
                    <tr>
                        
                        
                        <td class="new_button">
                            <input id="ViewReport"  type="button" value="View Report" style="width:100px;background:none;border:none;" class="new_button"  onclick="javascript:ViewAdviserOutflowReport_onclick()" />                      
                            </td>
                    </tr>
                </table>
            </td>
           </tr>
        </table>    
   				  </td>
				</tr>
				<tr>					
					<td valign="top" height="632" width="100%">
					<iframe id="ReportViewer1" Width="100%" style="height:auto; min-height:771px;" name="ReportViewer1" border="0px" marginwidth="-10px" marginheight="-10px" frameborder="0px" scrolling="yes">
                      </iframe>
       
    				</td>
				</tr>
		  </table>	
</asp:Content>
