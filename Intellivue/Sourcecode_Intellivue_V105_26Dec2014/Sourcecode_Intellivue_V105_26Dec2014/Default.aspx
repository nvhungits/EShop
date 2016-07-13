<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Sourcecode_Intellivue._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html >
<head id="Head1" runat="server">
<meta http-equiv="Content-Language" content="en-us"/>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252"/>
<meta http-equiv="Page-Enter" content="blendTrans(Duration=1.0)"/>
<title>I N T E L L I V U E - Login Page</title>
</head>


<body topmargin="0" leftmargin="0" style="background:url(images/Login01.gif)">
<style type="text/css">
    table.center
    {
         margin-left:auto; 
    margin-right:auto;
    }
</style>
<form id="frmLogin" runat="server">
<div style="margin:0 auto;">
<table border="0" width="1004" height="625" cellspacing="0" cellpadding="0" class="center">
	<tr>
		<td height="30" width="1004" colspan="4" valign="top">
		</td>
	</tr>
	<tr>
		<td height="577" width="130" valign="top" rowspan="4" background="images/Login09.gif">
		</td>
		<td height="165" width="302" valign="top">
			<img src="images/Login03.gif" width="302" height="165" alt=""></td>
		<td height="165" width="455" background="images/Login05.gif" style="position:relative;">
		<div style="position: absolute; width: 358px; height: 100px; z-index: 101; left: 40px; top:30px" id="layer1">
			<p align="center">
			<img border="0" src="Interfaces/System%20Config/MiddleBanner.jpg" width="370" height="67" id="IMG1"></div>
		<p align="center">&nbsp;&nbsp;</td>
		<td height="577" width="117" valign="top" rowspan="4" background="images/Login06.gif">
            a
		</td>
	</tr>
	<tr>
		<td height="18"  valign="top">
			<img src="images/Login07.gif" width="302" height="18" alt=""></td>
		<td height="18"  valign="top" style="position:relative;">            
            <div style="position: absolute; height: 21px; z-index: 103; right: 5px; " id="layer3" >
            &nbsp;<strong style="color: #ffffd5">SC_01_001</strong></div>
        </td>
	</tr>
	<tr>
		<td height="394" width="302" valign="top">
		    <div style="position:relative;">
		        <div style="position:absolute;">
		            <img border="0" src="Interfaces/System%20Config/Login10.gif" width="302" height="394"/>
		        </div>
			    <div style="position:absolute;top:40px;left:11px;">
			    <img border="0" src="Interfaces/System%20Config/Photo.jpg" width="273" height="282"/>
			    </div>
			</div>
	    </td>
			
		<td height="394" width="455" valign="top" background="images/Login11.jpg">
			<table width="447" height="329" cellspacing="0" cellpadding="0">
				<tr>
					<td valign="top" height="28" colspan="3">&nbsp;
						</td>
				</tr>
				<tr>
					<td valign="top" width="22" height="26">&nbsp;
						</td>
					<td valign="bottom" colspan="2" width="415" height="26">
						<b><font color="#FFFFFF" face="Tahoma" size="2">Please 
						enter username and password to log in the IntelliVue</font></b></td>
				</tr>
				<tr>
					<td valign="top" width="22" height="19">&nbsp;
						</td>
					<td valign="top" width="411" height="19" colspan="2">
						<hr color="#FFFFFF" noshade align="left" width="98%">
					</td>
				</tr>
				<tr>
					<td valign="top" width="22" height="42">&nbsp;
						</td>
					<td valign="top" width="411" height="42" colspan="2">
						&nbsp;<asp:Label ID="lblAlert" runat="server" Font-Bold="True" Font-Names="Tahoma"
                            Font-Size="8pt" ForeColor="#FFFFC0"></asp:Label></td>
				</tr>
				<tr>
					<td valign="top" width="22" height="29">&nbsp;
						</td>
					<td valign="top" width="143" height="29" style="vertical-align:inherit;">
						<p style="margin:0px;" align="right"><b>
						<font face="Tahoma" color="#FFFFFF" size="2">Username&nbsp; </font></b></td>
					<td valign="top" width="282" height="29" style="vertical-align:inherit;">
                        <asp:TextBox ID="txtUsername" runat="server" Font-Names="Tahoma" Width="152px"></asp:TextBox></td>
				</tr>
				<tr>
					<td valign="top" width="22" style="height: 22px">&nbsp;
						</td>
					<td valign="middle" width="143" style="height: 29px; vertical-align:inherit;" >
						<p style="margin:0px;" align="right"><b>
						<font face="Tahoma" color="#FFFFFF" size="2">Password&nbsp;</font></b></td>
					<td valign="top" width="282" style="height: 29px;vertical-align:inherit;">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="152px"></asp:TextBox></td>
				</tr>
				<tr>
					<td valign="top" width="22" style="height: 30px">&nbsp;
						</td>
					<td valign="top" width="143" style="height: 30px">&nbsp;
						</td>
					<td valign="middle" width="282" style="height: 30px">
                        <asp:Button ID="cmdLogin" runat="server" Text="Login" Width="64px" 
                            onclick="cmdLogin_Click" /></td>
				</tr>
				<tr>
					<td valign="top" width="22" height="50">&nbsp;
						</td>
					<td valign="middle" width="425" colspan="2" height="50">
						<p align="center"><b>
						<font face="Tahoma" color="#FFFFFF" size="2">If you 
						forgot password please <a href="Interfaces/Administrator/pgChangePassword.aspx" style="color:white">click here</a></font></b> </td>
				</tr>
				<tr>
					<td valign="top" width="22" height="29">&nbsp;
						</td>
					<td valign="middle" width="425" colspan="2" height="29">
						<hr color="#FFFFFF" noshade width="96%" align="left">
					</td>
				</tr>
				<tr>
					<td valign="middle" width="447" colspan="3">
						<p align="center">
						<font face="Tahoma" color="#FFFFFF" size="2"><b>
						<a href="Interfaces/pgUnderConstruction.aspx" style="color: white">Login Help</a></b></font></td>
				</tr>
			</table>
			<div style="width:100%;position:relative;">
			    <div style="z-index: 104; right: 25px; width: 55px; position: absolute; top: 10px;right:25px;height: 20px">
                <span style="font-size: 10pt; color: #ffffff; font-family: Arial"><strong>v 2.8.0.0</strong></span></div>
			</div>
			
		</td>
	</tr>
	<tr>
		<td height="34" width="302" valign="top">
			<img src="images/Login12.gif" width="302" height="35" alt=""></td>
		<td height="34" width="455" valign="top">
			<img src="images/Login13.gif" width="455" height="35" alt=""></td>
	</tr>
</table>
</div>
<div style="position: absolute; width: 278px; height: 295px; z-index: 102; left: 268px; top: 245px" id="layer2">
	<p align="center">
	</div>
</form>

</body>

</html>
