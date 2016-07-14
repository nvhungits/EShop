using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITL.Models
{
    public class sysmodel
    {
        public String SysId { set; get; }
        public DateTime Updated { set; get; }
        public DateTime Created { set; get; }
        public bool Active { set; get; }
    }
}