﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class mydbEntities : DbContext
    {
        public mydbEntities()
            : base("name=mydbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<incident> incident { get; set; }
        public virtual DbSet<kategorija> kategorija { get; set; }
        public virtual DbSet<korisnik> korisnik { get; set; }
        public virtual DbSet<tip> tip { get; set; }
        public virtual DbSet<edukacija> edukacija { get; set; }
        public virtual DbSet<korisnikxedukacija> korisnikxedukacija { get; set; }
        public virtual DbSet<baza_znanja> baza_znanja { get; set; }
        public virtual DbSet<plan> plan { get; set; }
        public virtual DbSet<rizik> rizik { get; set; }
        public virtual DbSet<servis> servis { get; set; }
        public virtual DbSet<servisxrizik> servisxrizik { get; set; }
        public virtual DbSet<mjesec> mjesec { get; set; }
        public virtual DbSet<dostupnost> dostupnost { get; set; }
        public virtual DbSet<korisnikxxedukacija> korisnikxxedukacija { get; set; }
    }
}
