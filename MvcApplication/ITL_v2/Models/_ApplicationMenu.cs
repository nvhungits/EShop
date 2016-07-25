using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITL_v2.Models
{
    public class _ApplicationMenu:ApplicationMenu
    {
        private List<_ApplicationMenu> applicationmenu_List = new List<_ApplicationMenu>();
        private ConnectionSQL con = new ConnectionSQL("ITLDB", "ApplicationMenu");
        public List<_ApplicationMenu> getALl()
        {
            try
            {
                this.con.sqlcmd.Connection.Open();
                this.con.sqlr = this.con.sqlcmd.ExecuteReader();
                while (this.con.sqlr.Read())
                {
                    _ApplicationMenu application_menu = new _ApplicationMenu();
                    application_menu.SysId = this.con.sqlr.GetString(0);
                    application_menu.Title = this.con.sqlr.GetString(1);
                    application_menu.Name = this.con.sqlr.GetString(2);
                    application_menu.Hint = this.con.sqlr.GetString(3);
                    application_menu.Desciption = this.con.sqlr.GetString(4);
                    application_menu.OrderSQ = this.con.sqlr.GetInt32(5);
                    application_menu.Roles = this.con.sqlr.GetString(6);
                    application_menu.Category = this.con.sqlr.GetString(7);
                    application_menu.Created = this.con.sqlr.GetDateTime(8);
                    application_menu.Updated = this.con.sqlr.GetDateTime(9);
                    application_menu.Active = this.con.sqlr.GetInt32(10);
                    application_menu.Controller = this.con.sqlr.GetString(11);
                    application_menu.ImageClass = this.con.sqlr.GetString(12);
                    //add to list
                    this.applicationmenu_List.Add(application_menu);
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
            return applicationmenu_List;
        }
    }
}