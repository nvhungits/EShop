using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ITL.Models
{
    public class ApplicationMenuModel:ApplicationMenu
    {
        List<ApplicationMenuModel> application_menu_list = new List<ApplicationMenuModel>();
        ConnectDB con = new ConnectDB("ITLDB");
        public List<ApplicationMenuModel> getAll()
        {
            SqlCommand sqlcmd = con.ConnectToTable("ApplicationMenu");
            SqlDataReader sqlr = sqlcmd.ExecuteReader();
            while (sqlr.Read())
            {
                ApplicationMenuModel application_menu = new ApplicationMenuModel();
                try
                {
                    application_menu.SysId = sqlr.GetString(0);
                    application_menu.Title = sqlr.GetString(1);
                    application_menu.Name = sqlr.GetString(2);
                    application_menu.Hint = sqlr.GetString(3);
                    application_menu.Desciption = sqlr.GetString(4);
                    application_menu.OrderSQ = sqlr.GetInt32(5);
                    application_menu.Roles = sqlr.GetString(6);
                    application_menu.Category = sqlr.GetString(7);
                    application_menu.Created = sqlr.GetDateTime(8);
                    application_menu.Updated = sqlr.GetDateTime(9);
                    application_menu.Active = sqlr.GetInt32(10);
                    application_menu.Controller = sqlr.GetString(11);
                    //add
                    application_menu_list.Add(application_menu);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            sqlcmd.Connection.Close();
            return application_menu_list;
        }
    }
}