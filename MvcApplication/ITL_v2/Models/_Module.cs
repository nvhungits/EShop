using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITL_v2.Models
{
    public class _Module:Module
    {
        private List<_Module> module_list = new List<_Module>();
        private ConnectionSQL con = new ConnectionSQL("ITLDB","Module");
        public List<_Module> getAll()
        {
            try
            {
                this.con.sqlcmd.Connection.Open();
                this.con.sqlr = this.con.sqlcmd.ExecuteReader();
                while (this.con.sqlr.Read())
                {
                    _Module module = new _Module();
                    int i = 0;
                    module.SysId = this.con.sqlr.GetString(i); i++;
                    module.Title = this.con.sqlr.GetString(i); i++;
                    module.TableRef = this.con.sqlr.GetString(i); i++;
                    module.Name = this.con.sqlr.GetString(i); i++;
                    module.Roles = this.con.sqlr.GetString(i); i++;
                    module.Hint = this.con.sqlr.GetString(i); i++;
                    module.ImageClass = this.con.sqlr.GetString(i); i++;
                    module.Created = this.con.sqlr.GetDateTime(i); i++;
                    module.Updated = this.con.sqlr.GetDateTime(i); i++;
                    module.Active = this.con.sqlr.GetInt32(i); i++;
                    module.ApplicationMenuId = this.con.sqlr.GetString(i); i++;
                    module.Action = this.con.sqlr.GetString(i); i++;
                    module.Controller = this.con.sqlr.GetString(i); i++;
                    //add to list
                    module_list.Add(module);
                }
            }
            catch (Exception e)
            {
                System.Console.Out.WriteLine("Error ITL: " + e.Message);
            }
            finally
            {
                con.Close();
            }
            return module_list;
        }

        public List<_Module> getByApplicationMenuID(String ID)
        {
            IEnumerable<_Module> m_list = from m in this.getAll()
                                          where m.ApplicationMenuId == ID && m.Active == 1
                                          select m;
            return m_list.ToList();
        }
    }
}