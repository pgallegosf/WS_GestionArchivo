﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OpeCar.GestionDocumental.Models.Infrastructure.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OpeCarEntities : DbContext
    {
        public OpeCarEntities()
            : base("name=OpeCarEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<AreaHist> AreaHist { get; set; }
        public DbSet<DocumentoHist> DocumentoHist { get; set; }
        public DbSet<SubAreaHist> SubAreaHist { get; set; }
        public DbSet<TipoArea> TipoArea { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<SubArea> SubArea { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Documento> Documento { get; set; }
        public DbSet<TipoSeccion> TipoSeccion { get; set; }
        public DbSet<Seccion> Seccion { get; set; }
        public DbSet<Enlace> Enlace { get; set; }
        public DbSet<Permiso> Permiso { get; set; }
    }
}
