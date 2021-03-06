﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Biblioteca.Data
{
    public class BibliotecaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BibliotecaContext() : base("name=BibliotecaContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        public System.Data.Entity.DbSet<Biblioteca.Models.Libros> Libros { get; set; }

        public System.Data.Entity.DbSet<Biblioteca.Models.TipoLibro> TipoLibroes { get; set; }

        public System.Data.Entity.DbSet<Biblioteca.Models.TipoDocumento> TipoDocumentoes { get; set; }

        public System.Data.Entity.DbSet<Biblioteca.Models.Lector> Lectors { get; set; }

        public System.Data.Entity.DbSet<Biblioteca.Models.LibroPrestado> LibroPrestadoes { get; set; }
    }
}
