<%@ Page Title="I N T E L L I V U E - Adviser Funding FUM" Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="AdviserFumReport.aspx.cs" Inherits="Sourcecode_Intellivue.Interfaces.StandardReports.AdviserFumReport" %>

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
//Begin VTHIEP Functions
//Javascript written by VTHIEP 03-08-2006//


//Function to generate Options for Adviser of Select Object
function generateAdviser(DealerGroup)
{

   var elements = document.getElementsByName("dealergroup-" + DealerGroup);
   
   var adviserObj = document.getElementById("<%=adviser.ClientID %>");
   
   //Clear Options before insert
   clearOptions(adviserObj)
   
   //Insert Default Options
   createOptions(adviserObj,"0 - All Adviser","0")
   adviserObj.selectedIndex = 0
   
   for(i=0;i<elements.length;i++)
   {
       if (elements[i].id != "0") {
           createOptions(adviserObj, elements[i].value, elements[i].id)
       }
       else 
       {
           document.getElementById("<%=loadAdviserAll.ClientID%>").click();
       }
       
      
   }  
}
//Function to generate Options for InvestmentOption of Select Object
function generateInvestmentOption(Product)
{
   var elements = document.getElementsByName("product-" + Product)
   var investmentOptionObj = document.getElementById("<%=investmentoption.ClientID%>")
   
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
    var GroupLevel2 = document.getElementById("<%= grouplevel2.ClientID%>")
    var GroupLevel1 = document.getElementById("<%= grouplevel1.ClientID%>")
    var GroupLevel3 = document.getElementById("<%= grouplevel3.ClientID%>")
    var GroupLevel4 = document.getElementById("<%= grouplevel4.ClientID%>")
    
   
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


//Update by LMTLOC - 2006-12-21
//Function happens when submit button is clicked
//This function view Adviser Fum Report
function ViewAdviserFumReport_onclick()
{
    var DealerGroup = document.getElementById("<%= dealergroup.ClientID%>");
    var Adviser = document.getElementById("<%= adviser.ClientID%>");
    var Product = document.getElementById("<%=product.ClientID%>");
    var InvestmentOption = document.getElementById("<%=investmentoption.ClientID%>");
    var AdviserState = document.getElementById("<%=adviserstate.ClientID%>");
    var EvaluationDate = document.getElementById("<%=evaluationdate.ClientID%>");
    strEvaluationDate = toYYYYMMDD(EvaluationDate.value);
    var GroupLevel1 = document.getElementById("<%=grouplevel1.ClientID%>");
    var GroupLevel2 = document.getElementById("<%=grouplevel2.ClientID%>");
    var GroupLevel3 = document.getElementById("<%=grouplevel3.ClientID%>");
    var GroupLevel4 = document.getElementById("<%=grouplevel4.ClientID%>");
    var TopN = document.getElementById("<%=topn.ClientID%>");
    var UserID = document.getElementById("username") ; 
    
    var frame = document.getElementById("reportviewer1");
    frame.src = "ReportPage.aspx?KeyName=AdviserFumReport&ParameterNames=DealerGroup~Adviser~Product~InvestmentOption~AdviserState~" +
    "EvaluationDate~GroupLevel1~GroupLevel2~GroupLevel3~GroupLevel4~TopN~UserID&ParameterValues=" + DealerGroup.value + "~" + Adviser.value + "~" + Product.value +
        "~" + InvestmentOption.value + "~" + AdviserState.value + "~" + strEvaluationDate + "~" + GroupLevel1.value + "~" + GroupLevel2.value + "~" +
        GroupLevel3.value + "~" + GroupLevel4.value + "~" + TopN.value + "~" + UserID.value;
    
    // document.form1.txtAction.value = "AdviserFum"
    // document.form1.submit()
}
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
//Update by LMTLOC - 2006-12-21
//Function happens when submit button is clicked
function ViewReport_onclick()
{
    var DealerGroup = document.getElementById("DealerGroup");
    var Adviser = document.getElementById("Adviser");
    var Product = document.getElementById("Product");
    var InvestmentOption = document.getElementById("InvestmentOption");
    var AdviserState = document.getElementById("AdviserState");
    var EvaluationDate = document.getElementById("EvaluationDate");
    strEvaluationDate = toYYYYMMDD(EvaluationDate.value);
    var GroupLevel1 = document.getElementById("GroupLevel1");
    var GroupLevel2 = document.getElementById("GroupLevel2");
    var GroupLevel3 = document.getElementById("GroupLevel3");
    var GroupLevel4 = document.getElementById("GroupLevel4");
    var TopN = document.getElementById("TopN");
    var UserID = document.getElementById("username") ; 
    
    var frame = document.getElementById("ReportViewer1");
    frame.src = "ReportPage.aspx?KeyName=AdviserFumReport&ParameterNames=DealerGroup~Adviser~Product~InvestmentOption~AdviserState~" +
    "EvaluationDate~GroupLevel1~GroupLevel2~GroupLevel3~GroupLevel4~TopN~UserID&ParameterValues=" + DealerGroup.value + "~" + Adviser.value + "~" + Product.value +
        "~" + InvestmentOption.value + "~" + AdviserState.value + "~" + strEvaluationDate + "~" + GroupLevel1.value + "~" + GroupLevel2.value + "~" +
        GroupLevel3.value + "~" + GroupLevel4.value + "~" + TopN.value + "~" + UserID.value;
    
    // document.form1.txtAction.value = "AdviserFum"
    // document.form1.submit()
}


//End VTHIEP Functions
/*******************************************************************************/

/*************************************************************************/
//Begin VTHIEP Functions
//Javascript written by VTHIEP 03-08-2006//


</script>

<input type="hidden" name="txtAction" id="txtAction" class="lbNormal" />
<input type="hidden" id="username" value="<%=Session["username"].ToString().ToUpper()%>" />

   <asp:ScriptManager ID="ScriptManager1" runat="server"  ></asp:ScriptManager>
    
<div class="page_navigation " style="margin-top:38px;">
            <asp:SiteMapPath ID="SiteMapPath2" runat="server" PathDirection="RootToCurrent" PathSeparatorStyle-Font-Bold="true" PathSeparator="&nbsp; >> &nbsp;" PathSeparatorStyle-Font-Size="12px" PathSeparatorStyle-ForeColor="#b6d0c2">
            </asp:SiteMapPath>
            </div>
            
<table width="100%" border="0" style="background-color:#A3C4B4;padding:5px;background-color:#A3C4B4;border-bottom:1px Black Solid;" id="table12">
    <tr>
        <td width="45%" valign="top" bgcolor="#A3C4B4">
                <table width="100%" id="table13">
                    <tr>
                        <td class="lbNormal" style="width: 77px">
                            Dealer group</td>
                        
                        <td>
                            <select name="dealergroup" id="dealergroup" runat="server" class="lbNormal" onchange="javascript:generateAdviser(this.value);" enableviewstate="true">
                            
                            </select>
                            <asp:Button ID="loadAdviserAll" style=" display:none;" runat="server" />
                            
                            <input type="hidden" name="dealergroup-0" id="0" value="0 - All Adviser" />
                            <%
                               //load all the adviser and advisergroup


	string sql = "exec sp_getadviser";
	try {
		this.objData.ConnectData();
		this.objData.ExeReader(sql);


		while (this.objData.dataRead.Read()) {

			Response.Write("<input type=\"hidden\" name=\"dealergroup-" + this.objData.dataRead.GetValue(2).ToString() + "\" value=\"" + this.objData.dataRead.GetString(0) + "\" id=\"" + this.objData.dataRead.GetValue(1).ToString() + "\" >");
		}
	} catch (Exception ex) {
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
                            <select id="product" name="product" runat="server" class="lbNormal" onchange="javascript:generateInvestmentOption(this.value)">
                                
                            </select>
                            <%
                               //load all the adviser and advisergroup 

                                {
	                                sql = "exec sp_getallinvestmentoption";
	                                try {
		                                this.objData.ConnectData();
		                                this.objData.ExeReader(sql);


		                                while (this.objData.dataRead.Read()) {
			                                Response.Write("<input type=\"hidden\" name=\"product-" + this.objData.dataRead.GetValue(2).ToString() + "\" value=\"" + this.objData.dataRead.GetString(0) + "\" id=\"" + this.objData.dataRead.GetValue(1).ToString() + "\" >");
		                                }
	                                } catch (Exception ex) {
		                                //response.write(ex.message)
		                                ASPNET_MessageBox(ex.Message);
	                                } finally {
		                                this.objData.CloseData();
	                                }
                                }
                            %>      
                         
                          
                        </td>
                    </tr>             
                    <tr>
                        <td style="width: 77px;" class="lbNormal">
                            Adviser State</td>
                        <td>
                            
                            <select id="adviserstate" runat="server" class="lbNormal" name="d1">
                               
                            </select>
                        </td>
                    </tr>
                    
                    
                    
                    <tr>
                        <td style="width: 77px;" class="lbNormal">
                            Group By</td>
                        <td>
                            <select id="grouplevel1" runat="server" class="lbNormal" onchange="javascript:generateGroupLevel(2)" name="d2">
                                <option value="1">investmentoption</option>
                                <option value="2">product</option>
                                <option value="3" selected="selected">adviser</option>
                                <option value="4">dealergroup</option>
                                <option value="5">adviserstate</option>
                            </select>
                        </td>
                    </tr>
                    
        
                    <tr>
                        <td class="lbNormal" style="width: 77px">
                            Group By</td>
                        <td>
                            <select id="grouplevel3" runat="server" class="lbNormal" onchange="javascript:generateGroupLevel(4)" name="d3">
                                <option value="0" selected="selected">none</option>
                               
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td class="lbNormal" style="width: 77px">
                            TopN</td>
                        <td>
                            <select id="topn" runat="server" name="topn" class="lbNormal">
                                <option value="0" selected="selected">0 - all 
								records</option>
                                <option value="5">5 - top 5</option>
                                <option value="10">10 - top 10</option>
                                <option value="20">20 - top 20</option>
                            </select>
                             
                        </td>
                    </tr>
                </table>
            </td>
            <td width="40%" valign="top" bgcolor="#A3C4B4">
                <table width="100%" id="table1">
                <tr>
                        <td class="lbNormal" style="width: 91px">
                            Adviser</td>
                        <td>
                            <select id="adviser" class="lbNormal" name="adviser" runat="server" enableviewstate="true">
                            <option value="0">0 - all adviser</option>
                            </select>    
                        </td>
                    </tr>
                    
                    
                    <tr>
                        <td style="width: 91px;" class="lbNormal">
                            Investment Option</td>
                        <td>
                           
                         <select id="investmentoption" name="investmentoption" runat="server" class="lbNormal">
                                <option value="0">0 - all investmentoptions</option>                                         
                            </select>
                            
                            
                        </td>
                    </tr>
                    
                    
                    
                    <tr>
                        <td style="width: 91px;" class="lbNormal">
                            Evaluation Date</td>
                        <td>
                            <input id="evaluationdate" name="evaluationdate" type="text" runat="server" style="width: 120px" class="lbNormal" />
                            <img alt="" runat="server" src="../../images/datetime.gif" onclick="displayDatePicker('ctl00_ContentPlaceHolder1_evaluationdate', false, 'dmy', '/');" id="img1" style="cursor:pointer;"/>
                        </td>
                    </tr>
                   
                    <tr>
                        <td style="width: 91px;" class="lbNormal">
                             Group By</td>
                        <td >
                            <select id="grouplevel2" class="lbNormal" runat="server" onchange="javascript:generateGroupLevel(3)" name="d4">
                                <option value="0" selected="selected">none</option>
                                <option value="1">investmentoption</option>
                                <option value="2">product</option>
                                <option value="4">dealergroup</option>
                                <option value="5">adviserstate</option>
                            </select>
                            </td>
                    </tr>
                    <!-- tes -->
                     
                    <tr>
                        <td class="lbNormal" style="width: 91px">
                            Group By</td>
                        <td>
                            <select id="grouplevel4" class="lbNormal" runat="server" name="d5">
                                <option value="0" selected="selected">none</option>
                            </select>
                        </td>
                    </tr>
                    
                    
                </table>
            </td>
            
            <td width="15%" valign="top" bgcolor="#A3C4B4" style="border-left:1px Black Solid;padding:10px;">
                <table width="100%" id="table17" bgcolor="#a3c4b4">
                    <tr>
                        <td class="new_button">
                            <input id="viewreport"  type="button" value="View Report" style="width:100px;background:none;border:none;" class="new_button"  onclick="javascript:ViewAdviserFumReport_onclick()" />                      
                            </td>
                
                    </tr>
                </table>
            </td>
           </tr>
       
        </table>
        
    <table width="100%" height="811" border="0" cellspacing="0" cellpadding="0">
	<tr>
		
		<td valign="top" width="100%" >
		  <iframe id="reportviewer1" width="100%" style=" vertical-align:middle;height:auto; min-height:771px; text-wrap:normal; overflow-x: scroll !important; overflow-y: scroll !important;" name="reportviewer1" border="0" marginwidth="-10px" marginheight="-5px" frameborder="0px" scrolling="yes">
             </iframe>
      
		</td>
	</tr>
</table>
    <!--  asdasd -->



    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" ></asp:Label>
					
</asp:Content>
