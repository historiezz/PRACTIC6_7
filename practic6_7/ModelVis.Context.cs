﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace practic6_7
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class practicEntities : DbContext
    {
        private static practicEntities _context;
        public practicEntities()
            : base("name=practicEntities")
        {
        }
        public static practicEntities GetContext()
        {
            if(_context == null)
                _context = new practicEntities();
            return _context;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<artist> artist { get; set; }
        public virtual DbSet<cityorg> cityorg { get; set; }
        public virtual DbSet<hall> hall { get; set; }
        public virtual DbSet<razmer> razmer { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<vistavki> vistavki { get; set; }
        public virtual DbSet<vladelec> vladelec { get; set; }
        public virtual DbSet<work> work { get; set; }
    }
}
