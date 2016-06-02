using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITLNow.Models
{
    public class dbObject
    {
        public int Id { set; get; }
        public string name { set; get; }
        public string label { set; get; }
        public bool active { set; get; }
    }
}