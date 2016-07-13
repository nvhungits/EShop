//============================================================================ '
//=         Copyright (c) 2006. MMSOFT Co., Ltd. All Rights Reserved.        = '
//=                                                                          = '
//=  Permission to use, copy, modify, and distribute this software and its   = '
//=  documentation for any purpose, without fee, and without a written       = '
//=  agreement, is here by granted, provided that the above copyright notice,= '
//=  this paragraph and the following two paragraphs appear in all copies,   = '
//=  modifications, and distributions.  Created by:                          = '
//=                                                                          = '
//=                        M.M..S.O.F.T.W.A.R.E                              = '
//=                                                                          = '
//=  MM Software Co., Ltd, 384 Hoang Dieu Street, Ward 4                        = '
//=  District 4, Ho Chi Minh City, Viet Nam.                                 = '
//=  For technical information, contact mmsoftvn@gmail.com                   = '
//=                                                                          = '
//=  IN NO EVENT SHALL REGENTS BE LIABLE TO ANY PARTY FOR DIRECT, INDIRECT,  = '
//=  SPECIAL, INCIDENTAL, OR CONSEQUENTIAL DAMAGES, INCLUDING LOST PROFITS,  = '
//=  ARISING OUT OF THE USE OF THIS SOFTWARE AND ITS DOCUMENTATION, EVEN IF  = '
//=  REGENTS HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.             = '
//=                                                                          = '
//=  REGENTS SPECIFICALLY DISCLAIMS ANY WARRANTIES, INCLUDING, BUT NOT       = '
//=  LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A = '
//=  PARTICULAR PURPOSE. THE SOFTWARE AND ACCOMPANYING DOCUMENTATION, IF     = '
//=  ANY, PROVIDED HEREUNDER IS PROVIDED "AS IS". REGENTS HAS NO OBLIGATION  = '
//=  TO PROVIDE MAINTENANCE, SUPPORT, UPDATES, ENHANCEMENTS, OR              = '
//=  MODIFICATIONS.                                                          = '
//============================================================================ '

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Data.SqlClient;

using Sourcecode_Intellivue.lib;



namespace Sourcecode_Intellivue
{
    public partial class _Default : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["log"] == "0")
            {
                Session["username"] = "";
                Session.Clear();
                Session.Abandon();
                Response.Redirect("Default.aspx");
            }
        }

        protected void cmdLogin_Click(object sender, EventArgs e)
        {
            Response.Cookies["Provider ID"].Value = txtUsername.Text.Trim();
            Response.Cookies["Email Address"].Value = "natu@mmsofts.com";
            loginAuthorisation(txtUsername.Text, txtPassword.Text, "natu@mmsofts.com");
        }

        private void loginAuthorisation(string id, string password, string email)
        {
            using (MD5 md5Hash = MD5.Create())
            {

                string hash = GlobalClass.getMD5Hash(md5Hash, password);

                Console.WriteLine("The MD5 hash of " + password + " is: " + hash + ".");

                Console.WriteLine("Verifying the hash...");

                if (GlobalClass.VerifyMd5Hash(md5Hash, password, hash))
                {
                    Console.WriteLine("The hashes are the same.");
                }
                else
                {
                    Console.WriteLine("The hashes are not same.");
                }
                string check = "";
                string role = "";
                int userID = 0;
                string pageAccess = "";

                //compare with user database

                try
                {
                    string commandstring = "Select A.ProviderId,C.RoleName,B.AuthorisationAccessRight,A.UserId, A.Email from tblUser A left join tblAuthorization B on A.UserId=B.UserId join tblRole C on A.RoleId=C.RoleId where A.ProviderId='" + id + "' and A.Password='" + hash + "' and A.Email='" + email + "' and A.Active='1'";
                    SqlCommand cmd = new SqlCommand(commandstring, connect);

                    connect.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while ((reader.Read()))
                        {
                            check = reader[0].ToString();
                            role = reader[1].ToString();
                            pageAccess = reader[2].ToString();
                            userID = int.Parse(reader[3].ToString());

                        }
                    }
                    reader.Close();
                    connect.Close();

                    Response.Write("Done");

                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }

                //Response.Write(string.e);

                if (!string.IsNullOrEmpty(check))
                {
                    Session["username"] = check;
                    Session["role"] = role;
                    Session["userId"] = userID;
                    //Response.Write("<script>window.alert('" + role + "');</script>");
                    if (role.Equals("Admin") | role.Equals("Manager") | role.Equals("Employee"))
                    {
                        SetPageAccessArr(pageAccess);
                        Response.Redirect("Interfaces/pgHomePage.aspx");
                        //ElseIf role.Equals("Provider Admin") Then
                        //    SetPageAccessArr(pageAccess)
                        //    Session("userId_edit") = userID
                        //    Response.Redirect("MOGOCheck/Dashboard.aspx")
                        //ElseIf role.Equals("Provider User") Then
                        //    Session("userId_edit") = userID
                        //    Session("user_info_command") = "edit"
                        //    Response.Redirect("MOGOCheck/Dashboard.aspx")
                        //Else
                        //lblAlert.Text = "You typed wrong username or password. Please try again..."
                    }
                }
            }
        }

        private void SetPageAccessArr(string listAccess)
        {
            int i = 0;
            string[] accessPages = listAccess.Split(',');
            int length = accessPages.Length;
            string[,] arrAccessControl = new string[length, 2];
            foreach (string accessPage in accessPages)
            {
                
                string[] arrPageAndRight = accessPage.Split('-');

                arrAccessControl[i, 0] = arrPageAndRight[0];
                arrAccessControl[i, 1] = arrPageAndRight[1];
                i = i + 1;
            }
            Session["accessright"] = arrAccessControl;
            Console.WriteLine();
        }


    }
}
