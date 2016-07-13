<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="pgChangePassword.aspx.cs" Inherits="Sourcecode_Intellivue.Interfaces.Administrator.pgChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        
        <div class="screen-title">
            Change Password</div>
        <div class="subtitle">
        </div>
        <br />
        <div class="form-container">
            <table id="changepassword_table" class="content_table"  align="center" width="60%" cellpadding="10px">
                <tr>
                    <td>
                        New Password:
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="txtPassword" Text="" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                    <td style="text-align: left;">
                        <asp:Label ID="txtPasswordValidation" style="color:Red; font-size:14px; font-weight:normal" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Confirm Password:
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="txtPasswordCheck" Text="" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                    <td style="text-align: left;">
                        <asp:Label ID="txtConfirmPasswordValidation" style="color:Red; font-size:14px; font-weight:normal" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2"  style="text-align: left;">
                        <asp:Button ID="BtnSubmit" class="styled button" runat="server" Text="Submit" 
                            onclick="BtnSubmit_Click" />
                    </td>
                </tr>
            </table>
            <%--<div style="clear: both">--%>            <%--</div>
    <div>
        <span class="user_detail_label">Confirm Password:</span><asp:TextBox ID="txtPasswordCheck"
            Text="" TextMode="Password" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
            ControlToValidate="txtPasswordCheck"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="No Match"
            ControlToValidate="txtPasswordCheck" ControlToCompare="txtPassword"></asp:CompareValidator>
    </div>--%>
            <%--</div>
    <div>
        <span class="user_detail_label">Confirm Password:</span><asp:TextBox ID="txtPasswordCheck"
            Text="" TextMode="Password" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
            ControlToValidate="txtPasswordCheck"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="No Match"
            ControlToValidate="txtPasswordCheck" ControlToCompare="txtPassword"></asp:CompareValidator>
    </div>--%>
        </div>
        </div>
    </center>
</asp:Content>
