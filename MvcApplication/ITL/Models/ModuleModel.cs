using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ITL.Models
{
    public class ModuleModel:Module
    {
        private List<ModuleModel> module_list = new List<ModuleModel>();
        private ConnectDB con = new ConnectDB("ITLDB","Module");
        private SqlDataReader sqlr;
        public List<ModuleModel> getAll()
        {
            try
            {
                this.con.sqlcmd.Connection.Open();
                this.sqlr = this.con.sqlcmd.ExecuteReader();
                while (this.sqlr.Read())
                {
                    ModuleModel module = new ModuleModel();
                    int i = 0;
                    module.SysId = this.sqlr.GetString(i); i++;
                    module.Title = this.sqlr.GetString(i); i++;
                    module.TableRef = this.sqlr.GetString(i); i++;
                    module.Name = this.sqlr.GetString(i); i++;
                    module.Roles = this.sqlr.GetString(i); i++;
                    module.Hint = this.sqlr.GetString(i); i++;
                    module.Image = this.sqlr.GetString(i); i++;
                    module.Created = this.sqlr.GetDateTime(i); i++;
                    module.Updated = this.sqlr.GetDateTime(i); i++;
                    module.Active = this.sqlr.GetInt32(i); i++;
                    module.ApplicationMenuId = this.sqlr.GetString(i); i++;
                    module.Action = this.sqlr.GetString(i); i++;
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

        public List<ModuleModel> getByApplicationMenuId(String ID)
        {
            IEnumerable<ModuleModel> module = from m in this.getAll() where m.ApplicationMenuId == ID && m.Active == 1 select m;
            return module.ToList(); ;
        }
    }
}