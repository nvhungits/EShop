// ============================================================================ '
// =         Copyright (c) 2006. MMSOFT Co., Ltd. All Rights Reserved.        = '
// =                                                                          = '
// =  Permission to use, copy, modify, and distribute this software and its   = '
// =  documentation for any purpose, without fee, and without a written       = '
// =  agreement, is here by granted, provided that the above copyright notice,= '
// =  this paragraph and the following two paragraphs appear in all copies,   = '
// =  modifications, and distributions.  Created by:                          = '
// =                                                                          = '
// =                        M.M.S.O.F.T.W.A.R.E                              = '
// =                                                                          = '
// =  MM Software Co., Ltd, 384 Hoang Dieu Street, Ward 6                     = '
// =  District 4, Ho Chi Minh City, Viet Nam.                                 = '
// =  For technical information, contact mmsoftvn@mmsofts.com                 = '
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
//using Microsoft.VisualBasic;
//using System;
using System.Collections;
//using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
//
using Sourcecode_Intellivue.lib;
namespace Sourcecode_Intellivue.Interfaces.Administrator
{
 
    public partial class pgUserReportRight : System.Web.UI.Page
    {

        SqlConnection connect = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
        GlobalClass an;
        string userId_edit = "";
        string username_edit = "";
        string user_edit_command = "";
        string user_name = "";

        string user_role = "";
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //If Session("username").ToString().ToLower() <> "admin" Then
            //    Response.Redirect("~/Default.aspx")
            //End If
            user_role = Session["role"].ToString();
            if (Session["role"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else if (user_role == "Admin")
            {
                userId_edit = (string)Session["userId_edit"];
                user_edit_command = (string)Session["user_info_command"];
                username_edit = (string)Session["username_edit"];
            }
            else
            {
                userId_edit = (string)Session["userId"];
                user_edit_command = "edit";
                username_edit = (string)Session["username"];
            }

            //If Session("active") = "True" Then
            //    chkActive.Checked = True
            //End If

            // Dim Active As String = Session("Active_edit")


            if (!Page.IsPostBack)
            {
                loadRole();
                if (user_edit_command == "edit")
                {
                    loadUserinfo();
                }
                //If Active.Equals("True") Then
                //    'chkActive.Checked = True
                //Else
                //    'chkActive.Checked = False
                //End If

            }
            txtPassword.TextMode = TextBoxMode.Password;
            //btnBack.Attributes.Add("onClick", "javascript:history.back(); return false;")
        }

        protected void btnSubmit_Click(object sender, System.EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select ReportId,ReportName from tblReport", connect);
            string accessControl = "";
            //try
            //{
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string reportID = reader[0].ToString();
                    //Get value base on radio check
                    string reportRight = Request[reportID];
                    string reportIDCheck = reportID + "1";
                    string reportCheckRight = Request.Form[reportIDCheck];

                    if (reportRight == null)
                    {
                        reportRight = "F";
                    }

                    accessControl = accessControl + reportID + "-" + reportRight + ",";
                }
                reader.Close();
                connect.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
            accessControl = accessControl.Substring(0, accessControl.Length - 1);


            if ((!(checkUserExist())) | (user_edit_command == "edit"))
            {
                //insert user info to database
                updateUserInfo();

                //update user access right to database

                updateDatabase(accessControl);

                if (user_role != "Admin")
                {
                    Response.Redirect("~/Interfaces/pgHomePage.aspx");
                }
                else
                {
                    Response.Redirect("UserMaintenance.aspx");
                }


            }
            else
            {
                string scriptKey = "UniqueKeyForThisScript";
                string javaScript = "<script type='text/javascript'>alert('Username is Exist.Please try another!');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), scriptKey, javaScript);
            }
        }

        private void updateDatabase(string accessControlString)
        {
            string query = "";
            if (user_edit_command == "edit")
            {
                query = "Update tblAuthorization Set AuthorisationAccessRight='" + accessControlString + "' where UserId='" + userId_edit + "'";
            }
            else
            {
                userId_edit = getUserId();
                query = "Insert into tblAuthorization (UserId,AuthorisationAccessRight) values('" + userId_edit + "','" + accessControlString + "')";
            }

            SqlCommand cmd = new SqlCommand(query, connect);
            //try
            //{
                connect.Open();
                cmd.ExecuteNonQuery();

                connect.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.Write(ex);
            //}
        }
        private void updateUserInfo()
        {


            string query = "";
            //set query string for create new user or edit'
            if (user_edit_command == "create")
            {
                query = "spu_InsertUserInfo";


            }
            else if (user_edit_command == "edit")
            {
                query = "spu_UpdateUserInfo";
            }

            SqlCommand cmd = new SqlCommand(query, connect);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter paraFirstName = cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar);
            SqlParameter paraLastName = cmd.Parameters.Add("@LastName", SqlDbType.NVarChar);
            SqlParameter paraAddress = cmd.Parameters.Add("@Address", SqlDbType.NVarChar);
            SqlParameter paraEmail = cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
            SqlParameter paraPhone = cmd.Parameters.Add("@Phone", SqlDbType.NVarChar);
            SqlParameter paraMobile = cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar);
            SqlParameter paraUsername = cmd.Parameters.Add("@Username", SqlDbType.NVarChar);
            SqlParameter paraPassword = cmd.Parameters.Add("@Password", SqlDbType.NVarChar);
            SqlParameter paraRole = cmd.Parameters.Add("@Role", SqlDbType.NVarChar);
            SqlParameter paraID = cmd.Parameters.Add("@Id", SqlDbType.NVarChar);
            SqlParameter paraActive = cmd.Parameters.Add("@Active", SqlDbType.Bit);

            paraFirstName.Value = txtFirstName.Text;
            paraLastName.Value = txtLastName.Text;
            paraAddress.Value = txtAddress.Text;
            paraEmail.Value = txtEmail.Text;
            paraPhone.Value = txtTelephone.Text.ToString();
            paraMobile.Value = txtMobile.Text.ToString();
            paraUsername.Value = txtUsername.Text;
            using (MD5 md5Hash = MD5.Create())
            {
                paraPassword.Value = GlobalClass.getMD5Hash(md5Hash, txtPassword.Text);
            }


            paraRole.Value = ddlRoles.SelectedValue;
            paraID.Value = userId_edit;
            paraActive.Value = chkActive.Checked;


            //try
            //{
                string a = connect.State.ToString();
                if (a == "Open")
                {
                    connect.Close();
                }
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}


        }

        private void loadUserinfo()
        {
            txtPassword.TextMode = TextBoxMode.Password;
            string roleID = "";
            string checkactive = "";
            SqlCommand cmd = new SqlCommand("Select * From tblUser Where UserId='" + userId_edit + "'", connect);
            //try
            //{
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtFirstName.Text = reader[4].ToString();
                    txtLastName.Text = reader[5].ToString();
                    txtAddress.Text = reader[6].ToString();
                    txtEmail.Text = reader[7].ToString();
                    txtTelephone.Text = reader[8].ToString();
                    txtMobile.Text = reader[9].ToString();
                    txtUsername.Text = reader[1].ToString();
                    roleID = reader[3].ToString();
                    chkActive.Checked = Convert.ToBoolean(reader[10]);
                    //checkactive = reader(10)
                    //txtPassword.Attributes.Add("value", reader(1))
                    //txtPassword.Attributes.Add("a", reader(1))

                }
                connect.Close();

            //}
            //catch (Exception ex)
            //{
            //}
            int roleindex = 0;

            foreach (ListItem item in ddlRoles.Items)
            {
                if (item.Value == roleID)
                {
                    break; // TODO: might not be correct. Was : Exit For
                }
                roleindex = roleindex + 1;
            }
            ddlRoles.SelectedIndex = roleindex;
            string role = Session["role"].ToString();
            if (role != "Admin")
            {
                ddlRoles.Enabled = false;
                btnResetPassword.Visible = false;
                chkActive.Enabled = false;
            }
            if (role == "Admin")
            {
                int mode_role =Session["Role_edit"].ToString()!=""? Convert.ToInt16(Session["Role_edit"].ToString()):0;
                ddlRoles.SelectedIndex = mode_role - 1;
            }

        }

        public string GetUserAccessRight(string check)
        {

            string[,] arrUserRight = SetUserPageAccessArr();
            //Session("accessright") '

            if (arrUserRight == null)
            {
                return "noaccess";

            }


            for (int i = 0; i <= arrUserRight.GetUpperBound(0); i++)
            {
                if (check == arrUserRight[i, 0])
                {
                    return arrUserRight[i, 1];
                }

            }
            return "F";
        }

        private string[,] SetUserPageAccessArr()
        {
            string listAccess = "";
            string commandstring = "select * from tblAuthorization where UserID='" + userId_edit + "'";
            SqlCommand cmd = new SqlCommand(commandstring, connect);
            if (connect.State.ToString() == "Open")
            {
                connect.Close();
            }

            connect.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while ((reader.Read()))
                {
                    listAccess = reader[2].ToString();
                }
            }
            reader.Close();
            connect.Close();

            if (string.IsNullOrEmpty(listAccess))
            {

                return null;
            }


            int i = 0;
            string[] accessPages = listAccess.Split(',');
            int length = accessPages.Length;
            string[,] arrAccessControl = new string[length + 1, length + 1];
            foreach (string accessPage in accessPages)
            {
                //accessPage = accessPage_loopVariable;
                string[] arrPageAndRight = accessPage.Split('-');

                arrAccessControl[i, 0] = arrPageAndRight[0];
                arrAccessControl[i, 1] = arrPageAndRight[1];
                i = i + 1;
            }

            return arrAccessControl;

        }

        //Private Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String

        //    ' Convert the input string to a byte array and compute the hash. 
        //    Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

        //    ' Create a new Stringbuilder to collect the bytes 
        //    ' and create a string. 
        //    Dim sBuilder As New StringBuilder()

        //    ' Loop through each byte of the hashed data  
        //    ' and format each one as a hexadecimal string. 
        //    Dim i As Integer
        //    For i = 0 To data.Length - 1
        //        sBuilder.Append(data(i).ToString("x2"))
        //    Next i

        //    ' Return the hexadecimal string. 
        //    Return sBuilder.ToString()

        //End Function 'GetMd5Hash

        //Private Function VerifyMd5Hash(ByVal md5Hash As MD5, ByVal input As String, ByVal hash As String) As Boolean
        //    ' Hash the input. 
        //    Dim hashOfInput As String = GetMd5Hash(md5Hash, input)

        //    ' Create a StringComparer an compare the hashes. 
        //    Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        //    If 0 = comparer.Compare(hashOfInput, hash) Then
        //        Return True
        //    Else
        //        Return False
        //    End If

        //End Function


        private void loadRole()
        {
            //try
            //{
                string commandstring = "select * from tblRole";
                SqlCommand cmd = new SqlCommand(commandstring, connect);
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while ((reader.Read()))
                    {
                        ddlRoles.Items.Add(new ListItem(reader[1].ToString(), reader[0].ToString()));
                    }
                }

                connect.Close();


            //}
            //catch (Exception ex)
            //{
            //}

        }

        protected void btnResetPassword_Click(object sender, System.EventArgs e)
        {
            string query = "spu_ResetPassword";
            string resetpassword = "password";
            SqlCommand cmd = new SqlCommand(query, connect);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter paraPassword = cmd.Parameters.Add("@Password", SqlDbType.NVarChar);

            SqlParameter paraID = cmd.Parameters.Add("@Id", SqlDbType.NVarChar);

            using (MD5 md5Hash = MD5.Create())
            {
                paraPassword.Value = GlobalClass.getMD5Hash(md5Hash, resetpassword);
            }
            paraID.Value = userId_edit;

            try
            {
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            //Dim scriptKey As String = "UniqueKeyForThisScript"
            //Dim javaScript As String = "<script type='text/javascript'>alert('Password reseted. Default : password');</script>"
            //ClientScript.RegisterStartupScript(Me.GetType(), scriptKey, javaScript)
        }
        public bool EmailAddressCheck(string emailAddress)
        {
            bool functionReturnValue = false;

            string pattern = "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";
            Match emailAddressMatch = Regex.Match(emailAddress, pattern);
            if (emailAddressMatch.Success)
            {
                functionReturnValue = true;
            }
            else
            {
                functionReturnValue = false;
            }
            return functionReturnValue;

        }

        public bool checkUserExist()
        {
            //check if username is exist before create new user
            string query = "spu_CheckUserExist";
            SqlCommand cmd = new SqlCommand(query, connect);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //create parameter

            SqlParameter paraUserName = cmd.Parameters.Add("@Value", SqlDbType.NVarChar);
            SqlParameter paraEmail = cmd.Parameters.Add("@email", SqlDbType.NVarChar);

            paraUserName.Value = txtUsername.Text;
            paraEmail.Value = txtEmail.Text;


            try
            {
                if (connect.State.ToString() == "Open")
                {
                    connect.Close();
                }

                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    connect.Close();
                    return true;
                }

                connect.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }

        protected void btnChangePassword_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("pgChangePassword.aspx");
        }

        public string getUserId()
        {
            string query = "Select UserId from tblUser where ProviderId='" + txtUsername.Text + "' and email='" + txtEmail.Text + "'";
            string userID = "";

            SqlCommand cmd = new SqlCommand(query, connect);
            try
            {
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while ((reader.Read()))
                {
                    userID = reader[0].ToString();
                }

                connect.Close();
                return userID;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return "f";
        }



        //public Interfaces_Administrator_pgUserReportRight()
        //{
        //    Load += Page_Load;
        //}
    }
}
