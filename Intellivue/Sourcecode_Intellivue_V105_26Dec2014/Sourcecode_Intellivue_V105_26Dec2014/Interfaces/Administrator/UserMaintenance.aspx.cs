
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
//
using Sourcecode_Intellivue.lib;
namespace Sourcecode_Intellivue.Interfaces.Administrator
{

    public partial class UserMaintenance : System.Web.UI.Page
    {

        SqlConnection connect = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Session["role"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["role"].ToString() != "Admin")
            {
                btnAddUser.Visible = false;
                string strscript = "<script>alert('You are not authorization for this page!');window.location.href='../pgHomePage.aspx'</script>";
                if (!ClientScript.IsClientScriptBlockRegistered("clientscript"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "clientscript", strscript);
                }
                //Response.Redirect("~/Interfaces/pgAdministration.aspx")
            }
            else
            {
                loadgrid();
            }

            if (!Page.IsPostBack)
            {
                loadRole();
            }
        }


        private void loadgrid()
        {
            try
            {
                string query = "";
                if (ddlRoles.SelectedValue == "0")
                {
                    query = "Select A.UserId,A.ProviderId,A.FirstName,A.LastName,A.Email,A.Active from tblUser A";
                }
                else
                {
                    query = "Select A.UserId,A.ProviderId,A.FirstName,A.LastName,A.Email,A.Active from tblUser A where A.RoleId='" + ddlRoles.SelectedValue + "'";
                }

                connect.Open();
                SqlDataAdapter dataadap = new SqlDataAdapter(query, connect);
                DataSet dataset = new DataSet();
                dataadap.Fill(dataset, "UserInfo");
                //gridUserList.DataSource = dataset.Tables("UserInfo").DefaultView
                //gridUserList.DataBind()
                userList.DataSource = dataset.Tables["UserInfo"].DefaultView;
                userList.DataBind();



                connect.Close();

                //createPagingControl(dataset.Tables("UserInfo").Rows.Count)

            }
            catch (Exception ex)
            {
            }
        }


        protected void GridView1_RowDeleted(object sender, System.Web.UI.WebControls.GridViewDeletedEventArgs e)
        {
        }

        //Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridUserList.RowEditing
        //    Dim row As GridViewRow = gridUserList.Rows(e.NewEditIndex)
        //    Dim username As String = row.Cells(2).Text
        //    Dim userID As String = row.Cells(1).Text
        //    Session("userId_edit") = userID
        //    Session("username_edit") = username
        //    Session("user_info_command") = "edit"
        //    Response.Redirect("pgUserReportRight.aspx")
        //End Sub

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            ImageButton btn =(ImageButton) sender;
            string username = btn.CommandName;
            string userId = btn.CommandArgument;
            string active = btn.ToolTip;

            Session["userId_edit"] = userId;
            Session["username_edit"] = username;
            Session["active"] = active;
            getAUser(userId);
            Session["user_info_command"] = "edit";
            Response.Redirect("pgUserReportRight.aspx");
        }

        public void getAUser(string user_id)
        {
            string sqlcmd = "Select * from tblUser Where UserId = " + user_id;
            // Dim sqlcmd As String = "Select * from tblDwUser Where ID = '1'"
            SqlCommand cmd = new SqlCommand(sqlcmd, connect);
            string active = "False";
            string role = "";
            //try
            //{
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    active = reader[10].ToString();
                    role = reader[3].ToString();
                }
                reader.Close();
                connect.Close();

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
            Session["Active_edit"] = active;
            Session["Role_edit"] = role;
        }



        protected void btnAddUser_Click(object sender, System.EventArgs e)
        {
            Session["user_info_command"] = "create";
            Response.Redirect("pgUserReportRight.aspx");
        }

        protected void deleteUserTable(string userId)
        {

            //try
            //{
                SqlCommand cmd = new SqlCommand("update tblUser set active='0' where UserId='" + userId + "'", connect);

                connect.Open();
                cmd.ExecuteNonQuery();

                connect.Close();

            //}
            //catch (Exception ex)
            //{
            //}
        }

        protected void deleteAuthorizeTable(string userId)
        {

            //try
            //{
                SqlCommand cmd = new SqlCommand("delete from tblAuthorization where UserID='" + userId + "'", connect);

                connect.Open();
                cmd.ExecuteNonQuery();

                connect.Close();

            //}
            //catch (Exception ex)
            //{
            //}
        }



        //Protected Sub gridUserList_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridUserList.RowDeleting
        //    Dim row As GridViewRow = gridUserList.Rows(e.RowIndex)
        //    Dim userID As String = row.Cells(1).Text

        //    deleteUserTable(userID)
        //    'deleteAuthorizeTable(userID)
        //End Sub

        //Protected Sub PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridUserList.PageIndexChanging
        //    gridUserList.PageIndex = e.NewPageIndex
        //    loadgrid()
        //End Sub


        //Private Sub PopulatePager(ByVal recordCount As Integer, ByVal currentPage As Integer)
        //    Dim dblPageCount As Double = gridUserList.PageSize
        //    Dim pageCount As Integer = CType(Math.Ceiling(dblPageCount), Integer)
        //    Dim pages As New List(Of ListItem)
        //    If (pageCount > 0) Then
        //        pages.Add(New ListItem("First", "1", (currentPage > 1)))
        //        Dim i As Integer = 1
        //        Do While (i <= pageCount)
        //            pages.Add(New ListItem(i.ToString, i.ToString, (i <> currentPage)))
        //            i = (i + 1)
        //        Loop
        //        pages.Add(New ListItem("Last", pageCount.ToString, (currentPage < pageCount)))
        //    End If
        //    gridUserList.DataSource = pages
        //    gridUserList.DataBind()
        //End Sub

        protected void btnAddProvider_Click(object sender, System.EventArgs e)
        {
            Session["user_info_command"] = "create";
            Response.Redirect("~/MOGOCheck/Register.aspx");
        }




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

        protected void ddlRoles_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            loadgrid();
        }

        private void createPagingControl(int RowCount)
        {
            int pgCount = RowCount / 5 + RowCount % 5;

            // Display Next>> button
            if (pgCount - 1 > Convert.ToInt16(txtHidden.Value))
            {
                lnkBtnNext.Visible = true;
            }
            else
            {
                lnkBtnNext.Visible = false;
            }

            // Display <<Prev button
            if ((Convert.ToInt16(txtHidden.Value)) > 1)
            {
                lnkBtnPrev.Visible = true;
            }
            else
            {
                lnkBtnPrev.Visible = false;
            }
        }

        protected void lnkBtnPrev_Click(object sender, System.EventArgs e)
        {
            txtHidden.Value = Convert.ToString(Convert.ToInt16(txtHidden.Value) - 1);
            loadgrid();
        }

        protected void lnkBtnNext_Click(object sender, System.EventArgs e)
        {
            txtHidden.Value = Convert.ToString(Convert.ToInt16(txtHidden.Value) + 1);
            loadgrid();
        }



        //public Interfaces_Administrator_UserMaintenance()
        //{
        //    Load += Page_Load;
        //}
    }
}
