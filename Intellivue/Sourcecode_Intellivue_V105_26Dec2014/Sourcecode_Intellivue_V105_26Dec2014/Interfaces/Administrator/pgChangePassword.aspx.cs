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

    public partial class pgChangePassword : System.Web.UI.Page
    {
        string userId_edit = "";

        GlobalClass an;


        SqlConnection connect = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
        protected void BtnSubmit_Click(object sender, System.EventArgs e)
        {
            txtConfirmPasswordValidation.Text = "";
            txtPasswordValidation.Text = "";


            if (txtPassword.Text == txtPasswordCheck.Text & txtPassword.Text.Length >= 5)
            {
                string query = "spu_ResetPassword";
                string resetpassword = txtPassword.Text;
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
                string scriptKey = "UniqueKeyForThisScript";
                string javaScript = "<script type='text/javascript'>alert('Password changed!');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), scriptKey, javaScript);
                Response.Redirect("UserMaintenance.aspx");
            }
            else if (txtPassword.Text.Length < 5)
            {
                txtPasswordValidation.Text = "Invalid";
            }
            else if (txtPassword.Text != txtPasswordCheck.Text)
            {
                txtConfirmPasswordValidation.Text = "Not Match";
            }
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            userId_edit = (Session["userId_edit"]!=null)?Session["userId_edit"].ToString():"";
        }

 
        //public Interfaces_Administrator_pgChangePassword()
        //{
        //    Load += Page_Load;
        //}
    }
}
