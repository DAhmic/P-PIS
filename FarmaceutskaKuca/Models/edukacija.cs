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
    
    public partial class edukacija
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public edukacija()
        {
            this.korisnikxedukacija = new HashSet<korisnikxedukacija>();
            this.korisnikxxedukacija = new HashSet<korisnikxxedukacija>();
        }
    
        public int id { get; set; }
        public string naziv { get; set; }
        public string opis { get; set; }
        public string kategorija { get; set; }
        public string trajanje { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<korisnikxedukacija> korisnikxedukacija { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<korisnikxxedukacija> korisnikxxedukacija { get; set; }
    }
}
