﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyCoffeeWebApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyCoffeeWebAppEntities : DbContext
    {
        public MyCoffeeWebAppEntities()
            : base("name=MyCoffeeWebAppEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<COLLECT_MONEY> COLLECT_MONEY { get; set; }
        public virtual DbSet<DATE> DATEs { get; set; }
        public virtual DbSet<MENU> MENUs { get; set; }
        public virtual DbSet<SPENDING_MONEY> SPENDING_MONEY { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
