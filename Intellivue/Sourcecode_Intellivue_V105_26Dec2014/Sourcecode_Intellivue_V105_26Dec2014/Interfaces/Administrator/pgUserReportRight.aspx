<%@ Page Title="I N T E L L I V U E - Authorisation" Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="pgUserReportRight.aspx.cs" Inherits="Sourcecode_Intellivue.Interfaces.Administrator.pgUserReportRight" %>

<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        $(document).ready(function() {
            $(".ar_header").click(function() {

                $header = $(this);
                $content = $header.next();
                //$headerText = $header.find("span");
                $content.slideToggle(500, function() {
//                    $header.find("span").text(function() {
//                        return $content.is(":visible") ? "Collapse" : "Expand";
//                    });
                    if ($content.is(":visible")) {
                        $header.find('img').attr('src', '../../Images/DragonCapital/collapse_icon.png');
                    }
                    else {
                        $header.find('img').attr('src', '../../Images/DragonCapital/expand_icon.png');
                    }
                    
                });
            });
        });



        function validate() {
            if (document.getElementById('<%= txtEmail.ClientID %>').value.match(/^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/)) {
                return true;
            }
            else {
                alert("Email format: abc@xyz.com");
                return false;
            }
        }

        function checkall(field, checkfield) {
            //alert(checkfield.checked)
            if (checkfield.checked == false) {

                for (i = 0; i < field.length; i++) {
                    //field[i].checked = false;
                    field[i].disabled = true;
                    field[i].checked = false;
                }

                //test
                //for (i = 0; i < field.length; i++) { alert("Status " + field[i].value + " is: " + field[i].checked); }
            }
            else {
                field[0].checked = true;
                for (i = 0; i < field.length; i++) {
                    //field[i].checked = false;
                    field[i].disabled = false;
                }

                //test
                // for (i = 0; i < field.length; i++) { alert("Status " + field[i].value + " is: " + field[i].checked); }

            }

        }

        function checkpageaccess(field, checkfield) {
            alert(checkfield.checked)
            if (checkfield.checked == false) {

                for (i = 0; i < field.length; i++) {
                    //field[i].checked = false;
                    field[i].disabled = true;
                }
            }
            else {


                for (i = 0; i < field.length; i++) {
                    //field[i].checked = false;
                    field[i].disabled = false;
                }


            }

        }

    </script>


    <div class="page_navigation " style="margin-top:38px;">
            <asp:SiteMapPath ID="SiteMapPath2" runat="server" PathDirection="RootToCurrent" PathSeparatorStyle-Font-Bold="true" PathSeparator="&nbsp; >> &nbsp;" PathSeparatorStyle-Font-Size="12px" PathSeparatorStyle-ForeColor="#b6d0c2">
            </asp:SiteMapPath>
    </div>
    
    <div class="page_heading">User Personal Detail</div>
    
    <div style="float: left; width: 40%;">
        <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false" runat="server" />
        <table id="profile_left" cellpadding="10px">
            <tr>
                <td>
                    <span class="user_detail_label">First Name:</span>
                </td>
                <td>
                    <asp:TextBox class="styled border" ID="txtFirstName" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="user_detail_label">Last Name:</span>
                </td>
                <td>
                    <asp:TextBox class="styled border" ID="txtLastName" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="user_detail_label">Address:</span>
                </td>
                <td>
                    <asp:TextBox class="styled border" ID="txtAddress" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="user_detail_label">Email Address:</span>
                </td>
                <td>
                    <asp:TextBox class="styled border" ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator  ID="RegularExpressionValidator1" Display="None"
                        runat="server" ErrorMessage="Email format: abc@xyz.com" ControlToValidate="txtEmail"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator Display="None" ControlToValidate="txtEmail" ID="reqtxtEmail" runat="server" ErrorMessage="Please fill in Email Address"></asp:RequiredFieldValidator>
                </td>
                <td>
                <%//----%>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="user_detail_label">Telephone:</span>
                </td>
                <td>
                    <asp:TextBox class="styled border" ID="txtTelephone" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="user_detail_label">Mobile:</span>
                </td>
                <td>
                    <asp:TextBox class="styled border" ID="txtMobile" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="user_detail_label">Personal ID:</span>
                </td>
                <td>
                    <asp:TextBox class="styled border" ID="txtUsername" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator Style="text-align: left;" ID="reqtxtUsername" Display="None"
                        runat="server" ErrorMessage="Please fill in Provider ID" ControlToValidate="txtUsername"></asp:RequiredFieldValidator>
                </td>
                
            </tr>
            <%if (Session["user_info_command"].ToString() == "create")
              { %>
            <tr>
                <td>
                    <span class="user_detail_label">Password:</span>
                </td>
                <td>
                    <asp:TextBox class="styled border" ID="txtPassword" Text="password"
                         runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator Display="None" Style="text-align: left;" ID="reqtxtPassword"
                        runat="server" ErrorMessage="Please enter password" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                </td>
                <td >
                    <%//----%>
                </td>
            </tr>
            <% }%>
            <tr>
                <td>
                    <span class="user_detail_label">Role:</span>
                </td>
                <td colspan="2">
                    <div class="maintenance-dropdownlist-container">
                    <asp:DropDownList class="dropdown" ID="ddlRoles" runat="server">
                       
                        
                    </asp:DropDownList>
                    </div>
                    
                   
                </td>
            </tr>
            <tr>
                <td><label for="chkActive">
                            Active</label>
                </td>
                <td colspan="2">
                    <div class="logincheckbox" style="">
                        <asp:CheckBox ID="chkActive" runat="server" Text="" />
                        
                    </div>
                </td>
            </tr>
            <%if ((Session["user_info_command"].ToString() == "edit") || (Session["role"].ToString() != "Admin"))
              {%>
            <tr>
                <td style="padding-right: 20px;">
                    <asp:Button class="styled button" Visible="false" ID="btnChangePassword" 
                        runat="server" Text="Change Password" onclick="btnChangePassword_Click" />
                </td>
                <td colspan="2">
                    <asp:Button class="styled button" Visible="false" 
                        OnClientClick="alert('Password is changed to default : password');" 
                        ID="btnResetPassword" runat="server" Text="Reset Password" 
                        onclick="btnResetPassword_Click" />
                </td>
            </tr>
            <% }%>
            <tr>
                <td>
                    <asp:Button OnClientClick="return validate()" class="styled button new_button" 
                        ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" />
                </td>
                <td colspan="2">
                    
                    <input type="button" onclick="history.go(-1);" class="styled button new_button" value="Back" />
                </td>
            </tr>
        </table>
    </div>
    <div style="float: left; width: 50%; margin-left: 20px; margin-top:10px;">
    <div class="AccessRight">
        <div class="ar_header"><img src="../../Images/DragonCapital/collapse_icon.png" />
            <div class="report_tab_header">
                <b>Reporting Service</b>
            </div>
        </div>
        <div class="ar_content" style="display:block;" >
        
        <table id="" cellpadding="5" class="color_table roleuser" cellspacing="0" >
            <thead>
                <tr style="height: 50px;">
                    <td>
                        <strong>List Report Access Right:</strong>
                    </td>
                    <td>
                    </td>
                    <td>
                        Read
                    </td>
                    <td>
                        Print
                    </td>
                    <td>
                        Export
                    </td>
                </tr>
            </thead>
            <tbody>
                <%  
                              
                    SqlConnection objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
                    SqlCommand cmd = new SqlCommand("Select ReportId,ReportName from tblReport where SUBSTRING(ReportID,1,1)='R'", objConn);
                    SqlDataReader reader;
                    //try
                    //{
                        objConn.Open();
                        reader  = cmd.ExecuteReader();
                        while( reader.Read())
                        {
                            Response.Write("<tr><div style=''><div style='float:left;width:200px;'><td>" + reader[1].ToString() + "</td></div>");
                            if ( (string)Session["user_info_command"] == "edit" || (string)Session["role"] == "Employee")
                            {
                                string reportRight = GetUserAccessRight(reader[0].ToString());
                    
                    
                %>
                <td class="checktable">
                   
                    <input type="checkbox" id="chk+<%Response.Write(reader[0].ToString()); %>"
                     name="<%Response.Write(reader[0].ToString()+1); %>"
                        value="F" <% if( reportRight != "F"){
             Response.Write("checked"); 
             } %> onclick="this.value=checkall(this.form.<%Response.Write(reader[0]); %>,this.form.<%Response.Write( ( reader[0].ToString()+1)); %>);">
                    <label for="chk+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" id="a+<%Response.Write(reader[0].ToString()); %>" name="<%Response.Write(reader[0]); %>"
                        value="R" <% if ( reportRight == "R" ){
            Response.Write("checked"); 
            }else if ( reportRight == "F"){
            Response.Write("disabled");
            } %> />
                    <label for="a+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" id="a2+<%Response.Write(reader[0]); %>" name="<%Response.Write(reader[0]); %>"
                        value="P" <% if( reportRight == "P"){
            Response.Write("checked");
            }else if (reportRight == "F")
            {
            Response.Write("disabled");
            }
             %> />
                    <label for="a2+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" id="a1+<%Response.Write(reader[0]); %>" name="<%Response.Write(reader[0]); %>"
                        value="E" <% if ( reportRight == "E" ){
            Response.Write("checked");
            }else if( reportRight == "F")
            {
            Response.Write("disabled");
            } %> />
                    <label for="a1+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <%
                            }else if((string)Session["role"] != "Employee")
                            {
                %>
                <td class="checktable">
                    <input type="checkbox" id="chk1+<%Response.Write(reader[0].ToString()+1); %>" name="<%Response.Write(reader[0].ToString()+1); %>"
                        value="F" onclick="this.value=checkall(this.form.<%Response.Write(reader[0]); %>,this.form.<%Response.Write(reader[0].ToString()+1); %>);">
                    <label for="chk1+<%Response.Write(reader[0].ToString()+1); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" disabled name="<%Response.Write(reader[0]); %>" id="b1+<%Response.Write(reader[0]); %>"
                        value="R" />
                    <label for="b1+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" id="b2+<%Response.Write(reader[0]); %>" disabled name="<%Response.Write(reader[0]); %>"
                        value="P" />
                    <label for="b2+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" id="b3+<%Response.Write(reader[0]); %>" disabled name="<%Response.Write(reader[0]); %>"
                        value="E" />
                    <label for="b3+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
        </div>
        <%                  }else
                            {%>
        <td class="checktable">
            <input type="checkbox" id="chk2+<%Response.Write(reader[0].ToString()+1); %>" disabled name="<%Response.Write(reader[0].ToString()+1); %>"
                value="F" onclick="this.value=checkall(this.form.<%Response.Write(reader[0]); %>,this.form.<%Response.Write(reader[0].ToString()+1); %>);">
            <label for="chk2+<%Response.Write(reader[0].ToString()+1); %>">
            </label>
        </td>
        <td class="checktable">
            <input type="radio" id="c3+<%Response.Write(reader[0]); %>" disabled="disabled" name="<%Response.Write(reader[0]); %>"
                value="F" />
            <label for="c3+<%Response.Write(reader[0]); %>">
            </label>
        </td>
        <td class="checktable">
            <input type="radio" id="c1+<%Response.Write(reader[0]); %>" disabled="disabled" name="<%Response.Write(reader[0]); %>"
                value="R" />
            <label for="c1+<%Response.Write(reader[0]); %>">
            </label>
        </td>
        <td class="checktable">
            <input type="radio" id="c2+<%Response.Write(reader[0]); %>" disabled="disabled" name="<%Response.Write(reader[0]); %>"
                value="W" />
            <label for="c2+<%Response.Write(reader[0]); %>">
            </label>
        </td>
        </div>
        <%
                            } 
                        
        %>
        <% 
                            Response.Write("</tr>");
                        }
                        reader.Close();
                        objConn.Close();
        
                    //}catch(Exception  ex)
                    //{
                    //    Console.WriteLine(ex);
                    //}
 
        %>
        </tbody> </table> 
        </div>
    </div>
    
    <!--Analysis service-->
    <div class="AccessRight">
        <div class="ar_header"><img src="../../Images/DragonCapital/expand_icon.png" /><b>Analysis Service</b></div>
        <div class="ar_content" >
        
        <table id="Table1" cellpadding="5" class="color_table roleuser" cellspacing="0" >
            <thead>
                <tr style="height: 50px;">
                    <td>
                        <strong>List Report Access Right:</strong>
                    </td>
                    <td>
                    </td>
                    <td>
                        Read
                    </td>
                    <td>
                        Print
                    </td>
                    <td>
                        Export
                    </td>
                </tr>
            </thead>
            <tbody>
                <%  
                              
                    objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
                    cmd = new SqlCommand("Select ReportId,ReportName from tblReport where SUBSTRING(ReportID,1,1)='A'", objConn);
                    //try
                    //{
                        objConn.Open();
                        reader = cmd.ExecuteReader();
                        while( reader.Read())
                        {
                            Response.Write("<tr><div style=''><div style='float:left;width:200px;'><td>" + reader[1] + "</td></div>");
                            if ( Session["user_info_command"].ToString() == "edit" || Session["role"].ToString() == "Employee" )
                            {
                                string reportRight = GetUserAccessRight(reader[0].ToString());
                %>
                <td class="checktable">
                   
                    <input type="checkbox" id="Checkbox1" name="<%Response.Write(reader[0].ToString()+1); %>"
                        value="F" <% if (reportRight != "F"){
             Response.Write("checked"); 
             } %> onclick="this.value=checkall(this.form.<%Response.Write(reader[0]); %>,this.form.<%Response.Write(reader[0].ToString()+1); %>);">
                    <label for="chk+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" id="a+<%Response.Write(reader[0]); %>" name="<%Response.Write(reader[0]); %>"
                        value="R" <% if( reportRight == "R" ){ 
            Response.Write("checked"); 
            } else if( reportRight == "F")
            {
            Response.Write("disabled");
            } %> />
                    <label for="a+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" id="a2+<%Response.Write(reader[0]); %>" name="<%Response.Write(reader[0]); %>"
                        value="P" <% if (reportRight == "P")
                        {
            Response.Write("checked");
            } else if (reportRight == "F")
            {
            Response.Write("disabled");
            }
            %> />
                    <label for="a2+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" id="a1+<%Response.Write(reader[0]); %>" name="<%Response.Write(reader[0]); %>"
                        value="E" <% if (reportRight == "E"){
            Response.Write("checked");
            } else if( reportRight == "F")
            {
            Response.Write("disabled");
            }
             %> />
                    <label for="a1+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <%
                            }
                            else if (Session["role"].ToString() != "Employee")
                            {
                %>
                <td class="checktable">
                    <input type="checkbox" id="chk1+<%Response.Write(reader[0].ToString()+1); %>" name="<%Response.Write(reader[0].ToString()+1); %>"
                        value="F" onclick="this.value=checkall(this.form.<%Response.Write(reader[0]); %>,this.form.<%Response.Write(reader[0].ToString()+1); %>);">
                    <label for="chk1+<%Response.Write(reader[0].ToString()+1); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" disabled name="<%Response.Write(reader[0]); %>" id="b1+<%Response.Write(reader[0]); %>"
                        value="R" />
                    <label for="b1+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" id="b2+<%Response.Write(reader[0]); %>" disabled name="<%Response.Write(reader[0]); %>"
                        value="P" />
                    <label for="b2+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" id="b3+<%Response.Write(reader[0]); %>" disabled name="<%Response.Write(reader[0]); %>"
                        value="E" />
                    <label for="b3+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
        </div>
                <%          }else
                            {%>
        <td class="checktable">
            <input type="checkbox" id="Checkbox2" disabled name="<%Response.Write(reader[0].ToString()+1); %>"
                value="F" onclick="this.value=checkall(this.form.<%Response.Write(reader[0]); %>,this.form.<%Response.Write(reader[0].ToString()+1); %>);">
            <label for="chk2+<%Response.Write(reader[0].ToString()+1); %>">
            </label>
        </td>
        <td class="checktable">
            <input type="radio" id="Radio1" disabled="disabled" name="<%Response.Write(reader[0]); %>"
                value="F" />
            <label for="c3+<%Response.Write(reader[0]); %>">
            </label>
        </td>
        <td class="checktable">
            <input type="radio" id="Radio2" disabled="disabled" name="<%Response.Write(reader[0]); %>"
                value="R" />
            <label for="c1+<%Response.Write(reader[0]); %>">
            </label>
        </td>
        <td class="checktable">
            <input type="radio" id="Radio3" disabled="disabled" name="<%Response.Write(reader[0]); %>"
                value="W" />
            <label for="c2+<%Response.Write(reader[0]); %>">
            </label>
        </td>
        </div>
        <%
                            }
                        
        %>
        <% 
                            Response.Write("</tr>");
                        }
                        reader.Close();
                        objConn.Close();
                    //}
                    //catch(Exception ex)
                    //{
                     //   Console.WriteLine(ex);
                    //}
        %>
        </tbody> </table> 
        </div>
        </div>
        
    <!-- Dashboard Access -->
    <div class="AccessRight">
        <div class="ar_header"><img src="../../Images/DragonCapital/expand_icon.png" /><b>Dashboard</b></div>
        <div class="ar_content" >
        
        <table id="Table2" cellpadding="5" class="color_table roleuser" cellspacing="0" >
            <thead>
                <tr style="height: 50px;">
                    <td>
                        <strong>List Dashboard Access Right:</strong>
                    </td>
                    <td>
                    </td>
                    <td>
                        Read
                    </td>
                    <td>
                        Print
                    </td>
                    <td>
                        Export
                    </td>
                </tr>
            </thead>
            <tbody>
                <%  
                              
                    objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
                    cmd = new SqlCommand("Select ReportId,ReportName from tblReport where SUBSTRING(ReportID,1,1)='D'", objConn);
                    //try
                    //{
                        objConn.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Response.Write("<tr><div style=''><div style='float:left;width:200px;'><td>" + reader[1] + "</td></div>");
                            if (Session["user_info_command"].ToString() == "edit" || Session["role"].ToString() == "Employee" )
                            {
                               string reportRight = GetUserAccessRight(reader[0].ToString());
                   
                %>
                <td class="checktable">
                   
                    <input type="checkbox" id="Checkbox3" name="<%Response.Write(reader[0].ToString()+1); %>"
                        value="F" <% if (reportRight != "F"){
             Response.Write("checked"); 
             } %> onclick="this.value=checkall(this.form.<%Response.Write(reader[0]); %>,this.form.<%Response.Write(reader[0].ToString()+1); %>);">
                    <label for="chk+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" id="Radio4" name="<%Response.Write(reader[0]); %>"
                        value="R" <% if ( reportRight == "R" )
                        {
            Response.Write("checked");
            }
            else if (reportRight == "F")
            {
            Response.Write("disabled");
            }
             %> />
                    <label for="a+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" id="a2+<%Response.Write(reader[0]); %>" name="<%Response.Write(reader[0]); %>"
                        value="P" <% if( reportRight == "P")
                        {
            Response.Write("checked");
            }else if (reportRight == "F")
            {
            Response.Write("disabled");
            }
             %> />
                    <label for="a2+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" id="a1+<%Response.Write(reader[0]); %>" name="<%Response.Write(reader[0]); %>"
                        value="E" <% if( reportRight == "E"){
            Response.Write("checked");
            }else if (reportRight == "F")
            {
            Response.Write("disabled");
            }
            %> />
                    <label for="a1+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <%
                            }
                            else if (Session["role"].ToString() != "Employee")
                            {
                %>
                <td class="checktable">
                    <input type="checkbox" id="chk1+<%Response.Write(reader[0].ToString()+1); %>" name="<%Response.Write(reader[0].ToString()+1); %>"
                        value="F" onclick="this.value=checkall(this.form.<%Response.Write(reader[0]); %>,this.form.<%Response.Write(reader[0].ToString()+1); %>);">
                    <label for="chk1+<%Response.Write(reader[0].ToString()+1); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" disabled name="<%Response.Write(reader[0]); %>" id="b1+<%Response.Write(reader[0]); %>"
                        value="R" />
                    <label for="b1+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" id="b2+<%Response.Write(reader[0]); %>" disabled name="<%Response.Write(reader[0]); %>"
                        value="P" />
                    <label for="b2+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" id="b3+<%Response.Write(reader[0]); %>" disabled name="<%Response.Write(reader[0]); %>"
                        value="E" />
                    <label for="b3+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
        </div>
                <%          } else
                            {%>
        <td class="checktable">
            <input type="checkbox" id="Checkbox4" disabled name="<%Response.Write(reader[0].ToString()+1); %>"
                value="F" onclick="this.value=checkall(this.form.<%Response.Write(reader[0]); %>,this.form.<%Response.Write(reader[0].ToString()+1); %>);">
            <label for="chk2+<%Response.Write(reader[0].ToString()+1); %>">
            </label>
        </td>
        <td class="checktable">
            <input type="radio" id="Radio5" disabled="disabled" name="<%Response.Write(reader[0]); %>"
                value="F" />
            <label for="c3+<%Response.Write(reader[0]); %>">
            </label>
        </td>
        <td class="checktable">
            <input type="radio" id="Radio6" disabled="disabled" name="<%Response.Write(reader[0]); %>"
                value="R" />
            <label for="c1+<%Response.Write(reader[0]); %>">
            </label>
        </td>
        <td class="checktable">
            <input type="radio" id="Radio7" disabled="disabled" name="<%Response.Write(reader[0]); %>"
                value="W" />
            <label for="c2+<%Response.Write(reader[0]); %>">
            </label>
        </td>
        </div>
        <%
                            }
                        
        %>
        <% 
                            Response.Write("</tr>");
                        }
                        reader.Close();
                        objConn.Close();
        
                    //}catch(Exception ex)
                    //{
                    //    Console.WriteLine(ex);
                    //}
        %>
        </tbody> </table> 
        </div>
    </div>
    
    <!-- Cube Access -->
    <div class="AccessRight">
        <div class="ar_header"><img src="../../Images/DragonCapital/expand_icon.png" /><b>Cube</b></div>
        <div class="ar_content" >
        
        <table id="Table3" cellpadding="5" class="color_table roleuser" cellspacing="0" >
            <thead>
                <tr style="height: 50px;">
                    <td>
                        <strong>List Cube Access Right:</strong>
                    </td>
                    <td>
                    </td>
                    <td>
                        Read
                    </td>
                    <td>
                        Print
                    </td>
                    <td>
                        Export
                    </td>
                </tr>
            </thead>
            <tbody>
                <%  
                              
                    objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
                    cmd = new SqlCommand("Select ReportId,ReportName from tblReport where SUBSTRING(ReportID,1,1)='C'", objConn);
                    //try
                    //{
                        objConn.Open();
                        reader = cmd.ExecuteReader();
                        while( reader.Read())
                        {
                            Response.Write("<tr><div style=''><div style='float:left;width:200px;'><td>" + reader[1] + "</td></div>");
                            if (Session["user_info_command"].ToString() == "edit" || Session["role"].ToString() == "Employee")
                            {
                        
                    
                                string reportRight = GetUserAccessRight(reader[0].ToString());
                    
                    
                %>
                <td class="checktable">
                   
                    <input type="checkbox" id="Checkbox5" name="<%Response.Write(reader[0].ToString()+1); %>"
                        value="F" <% if ( reportRight != "F")
                        {
             Response.Write("checked") ;
             } %> onclick="this.value=checkall(this.form.<%Response.Write(reader[0]); %>,this.form.<%Response.Write(reader[0].ToString()+1); %>);">
                    <label for="chk+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" id="Radio8" name="<%Response.Write(reader[0]); %>"
                        value="R" <% if( reportRight == "R" ){ 
            Response.Write("checked"); 
            }else if (reportRight == "F")
            {
            Response.Write("disabled");
            }
             %> />
                    <label for="a+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" id="Radio9" name="<%Response.Write(reader[0]); %>"
                        value="P" <% if ( reportRight == "P" ){
            Response.Write("checked");
            }else if ( reportRight == "F")
            {
            Response.Write("disabled");
            } %> />
                    <label for="a2+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" id="a1+<%Response.Write(reader[0]); %>" name="<%Response.Write(reader[0]); %>"
                        value="E" <% if (reportRight == "E"){
                                        Response.Write("checked");
                                        } else if (reportRight == "F")
                                        {
                                            Response.Write("disabled");
                                        }
                                  %> />
                    <label for="a1+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <%
                            }else if (Session["role"].ToString() != "Employee" )
                            {
                %>
                <td class="checktable">
                    <input type="checkbox" id="chk1+<%Response.Write(reader[0].ToString()+1); %>" name="<%Response.Write(reader[0].ToString()+1); %>"
                        value="F" onclick="this.value=checkall(this.form.<%Response.Write(reader[0]); %>,this.form.<%Response.Write(reader[0].ToString()+1); %>);">
                    <label for="chk1+<%Response.Write(reader[0].ToString()+1); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" disabled name="<%Response.Write(reader[0]); %>" id="b1+<%Response.Write(reader[0]); %>"
                        value="R" />
                    <label for="b1+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" id="b2+<%Response.Write(reader[0]); %>" disabled name="<%Response.Write(reader[0]); %>"
                        value="P" />
                    <label for="b2+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
                <td class="checktable">
                    <input type="radio" id="b3+<%Response.Write(reader[0]); %>" disabled name="<%Response.Write(reader[0]); %>"
                        value="E" />
                    <label for="b3+<%Response.Write(reader[0]); %>">
                    </label>
                </td>
        </div>
                <%          }else
                            {%>
        <td class="checktable">
            <input type="checkbox" id="Checkbox6" disabled name="<%Response.Write(reader[0].ToString()+1); %>"
                value="F" onclick="this.value=checkall(this.form.<%Response.Write(reader[0]); %>,this.form.<%Response.Write(reader[0].ToString()+1); %>);">
            <label for="chk2+<%Response.Write(reader[0].ToString()+1); %>">
            </label>
        </td>
        <td class="checktable">
            <input type="radio" id="Radio10" disabled="disabled" name="<%Response.Write(reader[0]); %>"
                value="F" />
            <label for="c3+<%Response.Write(reader[0]); %>">
            </label>
        </td>
        <td class="checktable">
            <input type="radio" id="Radio11" disabled="disabled" name="<%Response.Write(reader[0]); %>"
                value="R" />
            <label for="c1+<%Response.Write(reader[0]); %>">
            </label>
        </td>
        <td class="checktable">
            <input type="radio" id="Radio12" disabled="disabled" name="<%Response.Write(reader[0]); %>"
                value="W" />
            <label for="c2+<%Response.Write(reader[0]); %>">
            </label>
        </td>
        </div>
        <%
                            }   
                        
        %>
        <% 
                            Response.Write("</tr>");
                        }
                        reader.Close();
                        objConn.Close();
                    //}catch(Exception ex)
                    //{
                    //    Console.WriteLine(ex);
                    //}

        %>
        </tbody> </table> 
        </div>
    </div>
    <!--End Access right -->
    
    </div>
    <div style="clear: both; padding-top: 50px;">
    </div>
</asp:Content>