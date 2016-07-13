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

<%@ Page Language="VB" AutoEventWireup="false" CodeFile="pgInterfaceConfig.aspx.vb" Inherits="Interfaces_System_Config_pgInterfaceConfi" %>

<%@ Register Src="../../UserControls/wcLogout.ascx" TagName="wcLogout" TagPrefix="uc2" %>

<%@ Register Src="../../UserControls/wcTopMenu.ascx" TagName="wcTopMenu" TagPrefix="uc1" %>

<%@ Register Src="~/UserControls/wcLeftMenu.ascx" TagName="wcLeftMenu" TagPrefix="uc3" %>
<html>

<head runat="server">
<meta name="ProgId" content="SharePoint.WebPartPage.Document">
<meta name="WebPartPageExpansion" content="full">
<meta http-equiv="Content-Language" content="en-us">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
<meta http-equiv="Page-Enter" content="blendTrans(Duration=1.0)"/>
<link href=../../Css/style.css rel="stylesheet" type="text/css">
<script type=text/javascript src="../../Javascript/backtothehtml.js"></script>
<title>I N T E L L I V U E - Content Management</title>
</head>

<body topmargin="0" leftmargin="0" marginwidth="0" marginheight="0">
<form enctype="multipart/form-data" runat="server">
<div style="position: absolute; width: 100px; height: 639px; z-index: 7; left: 0px; top: 103px" id="layer5">
<%--<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0" width="239" height="699" id="FinalMovie" align="middle">
	<param name="allowScriptAccess" value="sameDomain" />
	<param name="movie" value="../../Menu/FinalMenu.swf" />
	<param name="quality" value="high" />
	<PARAM NAME=scale VALUE=noborder>
	<PARAM NAME=wmode VALUE=transparent>
	<param name="bgcolor" value="#ffffff" />
<embed src="../../Menu/FinalMenu.swf" quality="high" scale="noborder" wmode="transparent" bgcolor="#ffffff" width="239" height="699" name="FinalMovie" align="middle" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />
</object>--%>

<uc3:wcLeftMenu ID="wcLeftMenu1" runat="server" />

</div>
<table border="0" width="1003" height="860" cellspacing="0" cellpadding="0">
	<tr>
		<td height="61" width="226" valign="middle">
      <p align="center"><img src="../../Images/Vista_01.gif" width="226" height="61"></td>
		<td height="61" width="551" valign="top"><img src="../../Images/Vista_02.gif" width="551" height="61"></td>
		<td width="196" align="right" valign="top" background="../../Images/Vista_03.gif" class="toprightbanner">
			<a href="../pgUnderConstruction.aspx" class="top" >HELP</a> | <a href="../pgUnderConstruction.aspx" class="top" >SITE MAP</a> | <a href="../pgUnderConstruction.aspx" class="top">CONTACT</a>&nbsp;&nbsp;</td>
	    <td width="31" align="right" valign="top" bgcolor="#BCD7C4" class="toprightbanner">&nbsp;</td>
	    <td width="4" align="right" valign="top" bgcolor="#BCD7C4" class="toprightbanner">&nbsp;</td>
	</tr>
	
	<tr>
		<td valign="top" colspan="5" bgcolor="#4C7169" style="height: 4px"></td>
	</tr>
	<tr>
		<td height="38" colspan="3"  valign="top" background="../../Images/bg_top_menu.gif" bgcolor="#A3C4B4"><div style="position: absolute; width: 100px; height: 17px; z-index: 5; left: 1px; top: 64px" id="layer7">
          <uc1:wcTopMenu ID="WcTopMenu1" runat="server" />
        </div></td>
	    <td height="38" align="right" valign="top" bgcolor="#A3C4B4">&nbsp;</td>
	    <td height="35" valign="top" bgcolor="#A3C4B4" align="right">&nbsp;</td>
	</tr>
	<tr>
		<td height="700" valign="top" colspan="4">
		<div style="position: absolute; width: 424px; height: 24px; z-index: 2; left: 200px; top: 168px" id="layer2">
            <strong><span style="font-size: 10pt; font-family: Tahoma"></span></strong>
                <table style="width: 416px">
                    <tr>
                        <td style="width: 96px; height: 51px;">
                            <strong><span style="font-size: 10pt; font-family: Tahoma">Logo Image:</span></strong>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                        </td>
                        <td style="width: 292px; height: 51px;">
                            <asp:FileUpload ID="upLogo" runat="server" /><asp:Button ID="cmdUploadLogo" runat="server"
                Text="Upload" Height="22px" style="font-size:9pt" /></td>
                    </tr>
                    <tr>
                        <td style="width: 96px; height: 70px;">
                            <strong><span style="font-size: 10pt; font-family: Tahoma">Banner Image: &nbsp; &nbsp;
                            </span>                            </strong>
&nbsp;                        </td>
                        <td style="width: 292px; height: 70px;">
                            <asp:FileUpload ID="upBanner" runat="server" /><asp:Button ID="cmdUploadBanner" runat="server"
                Text="Upload" Height="22px" style="font-size:9pt;"/></td>
                    </tr>
                    <tr>
                        <td style="width: 96px"><strong><span style="font-size: 10pt; font-family: Tahoma">Login Image:</span></strong>
            &nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;                        </td>
                        <td style="width: 292px">
                            <asp:FileUpload ID="upImage" runat="server" /><asp:Button ID="cmdUploadImage" runat="server"
                Text="Upload" Height="22px" style="font-size:9pt" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                <asp:Label ID="lblWarning" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="10pt" ForeColor="#CC6600"></asp:Label></td>
                    </tr>
                </table>
          </div>
              
            <div style="position: absolute; visibility:hidden; width: 776px; height: 32px; z-index: 5; left: 202px; top: 356px" id="Div2">
                <span style="font-size: 10pt; font-family: Tahoma"><strong>Key:</strong> &nbsp;</span><asp:DropDownList
                    ID="cboKey" runat="server" AutoPostBack="True" TabIndex="10">
                    <asp:ListItem>-- Select a key --</asp:ListItem>
                </asp:DropDownList><span style="font-size: 10pt; font-family: Tahoma">&nbsp;<strong>
                    Value:</strong> </span>
                <asp:TextBox ID="txtSourceValue" runat="server"></asp:TextBox><span style="font-size: 10pt;
                    font-family: Tahoma">
                    <asp:Button ID="cmdModify" runat="server" Text="Modify" /></span><asp:Button ID="cmdDelete"
                        runat="server" Text="Delete" /></div>
            <div style="position: absolute; visibility:hidden; width: 528px; height: 24px; z-index: 4; left: 202px; top: 385px" id="Div3">
                <span style="font-size: 10pt; font-family: Tahoma"><strong>New Key:</strong> </span>
                <asp:TextBox ID="txtNewKey" runat="server"></asp:TextBox><span style="font-size: 10pt;
                    font-family: Tahoma">&nbsp; <strong>New Value:</strong> </span>
                <asp:TextBox ID="txtNewValue" runat="server"></asp:TextBox>
                <asp:Button ID="cmdAddNew" runat="server" Text="  Add  " /></div><div style="position: absolute; visibility:hidden; width: 393px; height: 24px; z-index: 2; left: 202px; top: 417px" id="Div4">
    <asp:Label ID="lblAlert" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="10pt"
        ForeColor="#CC6600"></asp:Label>
                    </div>
		<div style="position: absolute; visibility:hidden; width: 394px; height: 24px; z-index: 4; left: 202px; top: 335px" id="Div5">
            <strong><span style="font-size: 10pt; font-family: Tahoma">Configure the web connections.....</span></strong></div>
            <div style="position: absolute; width: 440px; height: 24px; z-index: 3; left: 200px; top: 142px" id="Div6">
                <strong><span style="font-size: 10pt; font-family: Tahoma">&nbsp;Configure the web images.....</span></strong></div>      </td>
	</tr>
	<tr>
		<td height="69" valign="top" colspan="4">
		            	<!-- Begin Footer -->
		                <table cellspacing="0" cellpadding="0" width="1002" height="72" border="0">
				            <tr>
					            <td valign="top" background="../../Images/Copyright.jpg" width="366" rowspan="2">					            </td>
					            <td background="../../Images/fence.jpg" width="19" rowspan="2">					            </td>
					            <td background="../../Images/MiddleBottom.jpg" valign="middle">
						            &nbsp;&nbsp; <b><font face="Tahoma" size="2">Quick Link:</font></b></td>
					            <td width="117" background="../../Images/RightBottom.jpg" rowspan="2">
						            <p align="center">
						            <a href="#top" class="top"><font face="Times New Roman" color="#77A399" size="2">&#9650;</font><font color="#77A399"><b><font size="2" face="Tahoma"> 
						            TOP</font></b></font></a></td>
				            </tr>
				            <tr>
					            <td height="46" valign="top">
						            &nbsp;&nbsp;&nbsp;<select style="font-family: Tahoma; font-size: 10pt; font-weight: bold" size="1" tabindex="1" name="cboQuicklink">
							            <option selected value="----Pentafin----">
								              ----Pentafin----							            </option>
						            </select></td>
				            </tr>
            </table>
                        <!-- End Footer -->	  </td>
	</tr>
</table>
    <div style="position: absolute; width: 73px; height: 16px; z-index: 9; left: 905px; top: 69px" id="layer6" class="idcolor">
		<b><font face="Tahoma" size="2">SC_06_007</font></b></div>
<!-- Start the left menu -->
<!-- End the left menu -->
</form>

</body>

</html>