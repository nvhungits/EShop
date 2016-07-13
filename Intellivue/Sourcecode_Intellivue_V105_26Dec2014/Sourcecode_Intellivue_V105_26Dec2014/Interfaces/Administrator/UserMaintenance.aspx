<%@ Page Title="I N T E L L I V U E - User List" Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="UserMaintenance.aspx.cs" Inherits="Sourcecode_Intellivue.Interfaces.Administrator.UserMaintenance" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page_navigation " style="margin-top:38px;">
            <asp:SiteMapPath ID="SiteMapPath2" runat="server" PathDirection="RootToCurrent" PathSeparatorStyle-Font-Bold="true" PathSeparator="&nbsp; >> &nbsp;" PathSeparatorStyle-Font-Size="12px" PathSeparatorStyle-ForeColor="#b6d0c2">
            </asp:SiteMapPath>
    </div>
    <div  class="search_criteria_bar">
        <div class="search_criteria_leftcolumn">
             <div class="search_criteria_leftcolumn">
                <div class="search_criteria_firstcolumn">
                    <div>
            
            
            <asp:Button CssClass="new_button" ID="btnAddUser" class="styled button" 
                            style=" margin-top: -15;" runat="server" Text="Create" 
                            onclick="btnAddUser_Click" />
            </div>
            </div>
            </div>
        </div>

        <div style="clear:both;"></div>
    </div>
    
    
    
    
    <div class="page_heading">USER LIST</div>
    
    <style>
    .color_table td{
        
    }
    </style>
    <span style="color:#58727b;font-size:12px;font-weight:bold;padding-left:10px;">Role</span>
            
            <asp:DropDownList class="dropdown" CssClass="dropdown" style="margin-left: 20px; background-size: 214px 39px;" ID="ddlRoles" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRoles_SelectedIndexChanged">
                <asp:ListItem Value="0">All</asp:ListItem>
            </asp:DropDownList>
    <asp:Repeater ID="userList" runat="server">
        <HeaderTemplate>
            <table id="actable" class="color_table" width="100%" align="center" cellspacing="0px">
                <thead >
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        ID
                    </td>
                    <td>
                        Username
                    </td>
                    <td>
                        Firstname
                    </td>
                    <td>
                        Lastname
                    </td>
                    <td>
                        Email
                    </td>
                    <td>
                        Active
                    </td>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
        
            <tr>
                <td style="text-align:center">
                    
                    <asp:ImageButton ID="btnEdit" ImageUrl="../../Images/DragonCapital/edit_icon.png" CommandName='<%#DataBinder.Eval(Container.DataItem, "ProviderId")%>'
                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem, "UserId")%>' ToolTip='<%#DataBinder.Eval(Container.DataItem, "UserId") %>'
                                                runat="server" OnClick="btnEdit_Click" />
                </td>
                <td class="table_char_right">
                    <%#DataBinder.Eval(Container.DataItem, "UserId")%>
                </td>
                <td class="table_char_left">
                    <%#DataBinder.Eval(Container.DataItem, "ProviderId")%>
                </td>
                <td class="table_char_left">
                    <%#DataBinder.Eval(Container.DataItem, "firstname")%>
                </td>
                <td class="table_char_left">
                    <%#DataBinder.Eval(Container.DataItem, "lastname")%>
                </td>
                <td class="table_char_left">
                    <%#DataBinder.Eval(Container.DataItem, "email")%>
                </td>
                <td style="text-align:center">
                    <%#(bool)DataBinder.Eval(Container.DataItem, "active")?"<img src='../../Images/DragonCapital/tick_icon.png' />": ""%>
                </td>
            </tr>

        </ItemTemplate>
        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:LinkButton ID="lnkBtnPrev" runat="server" Font-Underline="False"
            OnClick="lnkBtnPrev_Click" Font-Bold="True" Visible="false"><< Prev </asp:LinkButton>
            <input id="txtHidden" style="width: 28px" type="hidden" value="1"
                runat="server" />
            <asp:LinkButton ID="lnkBtnNext" runat="server" Font-Underline="False"
                OnClick="lnkBtnNext_Click" Font-Bold="True" Visible="false">Next >></asp:LinkButton>
    <br />
  
    <div style="margin-top: 15px;display:inline;">
        <span>
        <asp:Button ID="btnAddProvider" class="styled button" style=" margin-top: -15;" 
            runat="server" Text="Create Provider" Visible="false" 
            onclick="btnAddProvider_Click" />
      
        
        </span>
    </div>
</asp:Content>
