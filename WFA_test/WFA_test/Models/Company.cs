using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_test.Models
{
    class Company:sysTable
    {
        public String Name { set; get; }
        public String Street { set; get; }
        public String City { set; get; }
        public String State_Province { set; get; }
        public String Zip { set; get; }
        public String Phone { set; get; }
        public String Fax_Phone { set; get; }
        public bool Active { set; get; }
    }
}
