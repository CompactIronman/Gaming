﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeeklyGamingBASIC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WeeklyGamingTGEntities : DbContext
    {
        public WeeklyGamingTGEntities()
            : base("name=WeeklyGamingTGEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Game_Members> Game_Members { get; set; }
        public virtual DbSet<Game_Providers> Game_Providers { get; set; }
        public virtual DbSet<Members> Members { get; set; }
    }
}
