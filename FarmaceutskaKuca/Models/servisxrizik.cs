//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FarmaceutskaKuca.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class servisxrizik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public servisxrizik()
        {
            this.plan = new HashSet<plan>();
        }
    
        public int id { get; set; }
        public int id_s { get; set; }
        public int id_r { get; set; }
        public string procenat { get; set; }
        public string naziv { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<plan> plan { get; set; }
        public virtual rizik rizik { get; set; }
        public virtual servis servis { get; set; }
    }
}