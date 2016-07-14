using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ITL.Models
{
    public class User:sysmodel
    {
        public String Name {set; get;}
        public String Gender { set; get; }
        public String Email{set; get;}
        public String UserID { set; get; }
        public String Password { set; get; }
        public String Company { set; get; }
        public String Location { set; get; }
        public String Department { set; get; }

        public IEnumerable<User> getAllUser()
        {
            string con = ConfigurationManager.ConnectionStrings["ITLDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(con);
            var userList = new List<User>();
            try
            {
                connection.Open();

                SqlCommand cmdStr = new SqlCommand("Select * from User", connection);
                SqlDataReader dr = cmdStr.ExecuteReader();
                dr.Read();
                Console.WriteLine("Connected");
                userList.Add(new User { SysId = "1", Name = "A" });//dr[1].ToString() });
                userList.Add(new User { SysId = "2", Name = "B" });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message in UserItem: "+ex.Message);
            }

            return userList.ToList();
        }
    }
}