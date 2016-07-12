using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_test.Models
{
    class sysTable
    {
        public String Sys_Id { 
            set; 
            get; 
        }
        public DateTime Created { set; get; }
        public DateTime Updated { set; get; }
        public User Created_By { 
            set; get; 
        }
        public User Updated_By { 
            set; get; 
        }
    }
}
