<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wcLogout.ascx.cs" Inherits="Sourcecode_Intellivue.UserControls.wcLogout" %>
<asp:Menu ID="Menu1" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="10pt"
    ForeColor="White" Height="24px" Width="80px">
    <DynamicHoverStyle ForeColor="#FFFFC0" />
    <Items>
        <asp:MenuItem ImageUrl="~/Images/Color_Logout1.gif" NavigateUrl="~/Interfaces/pgTemp.aspx?out=1"

            Text="  Log out" ToolTip="Click here to log out the Intellivue system" Value="Log out">
        </asp:MenuItem>
    </Items>
    <StaticHoverStyle ForeColor="White" />
</asp:Menu>