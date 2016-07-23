using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.SqlClient;

namespace ITL.Models
{
    public class ApplicationMenuModel:ApplicationMenu
    {
        private List<ApplicationMenuModel> application_menu_list = new List<ApplicationMenuModel>();
        private ConnectDB con = new ConnectDB("ITLDB","ApplicationMenu");
        private SqlDataReader sqlr;
        public List<ApplicationMenuModel> getAll()
        {
            try
            {
                this.con.sqlcmd.Connection.Open();
                this.sqlr = this.con.sqlcmd.ExecuteReader();
                while (this.sqlr.Read())
                {
                    ApplicationMenuModel application_menu = new ApplicationMenuModel();
                    application_menu.SysId = this.sqlr.GetString(0);
                    application_menu.Title = this.sqlr.GetString(1);
                    application_menu.Name = this.sqlr.GetString(2);
                    application_menu.Hint = this.sqlr.GetString(3);
                    application_menu.Desciption = this.sqlr.GetString(4);
                    application_menu.OrderSQ = this.sqlr.GetInt32(5);
                    application_menu.Roles = this.sqlr.GetString(6);
                    application_menu.Category = this.sqlr.GetString(7);
                    application_menu.Created = this.sqlr.GetDateTime(8);
                    application_menu.Updated = this.sqlr.GetDateTime(9);
                    application_menu.Active = this.sqlr.GetInt32(10);
                    application_menu.Controller = this.sqlr.GetString(11);
                    //add to list
                    this.application_menu_list.Add(application_menu);
                }
            }
            catch (Exception e)
            {
                System.Console.Out.WriteLine("Error ITL: " + e.Message);
            }
            finally
            {
                this.con.Close();
            }
            return this.application_menu_list;
        }       
    }
}