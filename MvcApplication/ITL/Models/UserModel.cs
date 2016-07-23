using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ITL.Models
{
    public class UserModel:User
    {
        private List<UserModel> user_list = new List<UserModel>();
        private ConnectDB con = new ConnectDB("ITLDB","[User]");
        private SqlDataReader sqlr;
        public List<UserModel> getAll()
        {
            try
            {
                this.con.sqlcmd.Connection.Open();
                this.sqlr = this.con.sqlcmd.ExecuteReader();
                while (this.sqlr.Read())
                {
                    UserModel user = new UserModel();
                    int i = 0;
                    user.SysId = this.sqlr.GetString(i); i++;
                    user.Name = this.sqlr.GetString(i); i++;
                    user.UserID = this.sqlr.GetString(i); i++;
                    user.Password = this.sqlr.GetString(i); i++;
                    user.Email = this.sqlr.GetString(i); i++;
                    user.Gender = this.sqlr.GetString(i); i++;
                    user.Company = this.sqlr.GetString(i); i++;
                    user.Location = this.sqlr.GetString(i); i++;
                    user.Department = this.sqlr.GetString(i); i++;
                    user.Created = this.sqlr.GetDateTime(i); i++;
                    user.Updated = this.sqlr.GetDateTime(i); i++;
                    user.Active = this.sqlr.GetInt32(i); i++;
                    //add to list
                    user_list.Add(user);
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
       
            return user_list;
        }
    }
}