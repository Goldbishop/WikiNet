//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wiki.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Roles
    {
        public Roles()
        {
            this.Users = new HashSet<UserRoles>();
        }
    
        public System.Guid id { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<UserRoles> Users { get; set; }
    }
}
