﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Models
{
    using CommonPortable.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class faindmiService_dbEntities : DbContext
    {
        public faindmiService_dbEntities()
            : base("name=faindmiService_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Relation> Relations { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Usr> Usrs { get; set; }
    }
}
