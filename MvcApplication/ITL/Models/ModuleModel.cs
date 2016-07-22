using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ITL.Models
{
    public class ModuleModel:Module
    {
        List<ModuleModel> module_list = new List<ModuleModel>();
        ConnectDB con = new ConnectDB("ITLDB");
        public List<ModuleModel> getAll()
        {
            SqlCommand sqlcmd = con.ConnectToTable("Module");
            SqlDataReader sqlr = sqlcmd.ExecuteReader();
            while (sqlr.Read())
            {
                ModuleModel module = new ModuleModel();
                try
                {
                    module.SysId = sqlr.GetString(0);
                    module.Title = sqlr.GetString(1);
                    module.TableRef = sqlr.GetString(2);
                    module.Name = sqlr.GetString(3);
                    module.Roles = sqlr.GetString(4);
                    module.Hint = sqlr.GetString(5);
                    module.Image = sqlr.GetString(6);
                    module.Created = sqlr.GetDateTime(7);
                    module.Updated = sqlr.GetDateTime(8);
                    module.Active = sqlr.GetInt32(9);
                    module.ApplicationMenuId = sqlr.GetString(10);
                    module.Action = sqlr.GetString(11);
                    //add
                    module_list.Add(module);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            sqlcmd.Connection.Close();
            return module_list;
        }

        public List<ModuleModel> getByApplicationMenuId(String ID)
        {
            IEnumerable<ModuleModel> module = from m in this.getAll() where m.ApplicationMenuId == ID select m;
            return module.ToList(); ;
        }
    }
}