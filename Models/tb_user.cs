//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment_3_ASP.NET_MVC_CRUD.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_user()
        {
            this.tb_booking = new HashSet<tb_booking>();
        }
    
        public int u_ic { get; set; }
        public string u_pass { get; set; }
        public string u_name { get; set; }
        public string u_address { get; set; }
        public string u_phone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_booking> tb_booking { get; set; }
    }
}