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
    
    public partial class plan
    {
        public int id { get; set; }
        public int id_sxr { get; set; }
        public string preventivne_strategije { get; set; }
        public string strategije_odgovora { get; set; }
        public string strategije_oporavka { get; set; }
        public string testiran { get; set; }
        public string napomena_k { get; set; }
        public string napomena_m { get; set; }
    
        public virtual servisxrizik servisxrizik { get; set; }
    }
}
