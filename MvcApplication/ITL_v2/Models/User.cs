//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ITL_v2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public string SysId { get; set; }
        public string Name { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
        public Nullable<int> Active { get; set; }
    }
}