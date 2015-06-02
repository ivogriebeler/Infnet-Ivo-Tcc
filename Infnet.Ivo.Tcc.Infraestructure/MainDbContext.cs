using Infnet.Ivo.Tcc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ivo.Tcc.Infraestructure
{
    public class MainDbContext : DbContext, IDbContext
    {
        public MainDbContext() : this(false) { }

        public MainDbContext(bool DropCreateDatabaseAlways = false)
            : base("MainDbContext")
        {
            if (DropCreateDatabaseAlways)
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<MainDbContext>());
            }
            else
            {
                Database.SetInitializer(new CreateDatabaseIfNotExists<MainDbContext>());
            }
        }
        
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Organizacao> Organizacoes { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        //Usando Fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Exercicio>().HasKey(p => p.Id);
            modelBuilder.Entity<Exercicio>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            modelBuilder.Entity<Organizacao>().HasKey(p => p.Id);
            modelBuilder.Entity<Organizacao>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            modelBuilder.Entity<Serie>().HasKey(p => p.Id);
            modelBuilder.Entity<Serie>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            modelBuilder.Entity<Usuario>().HasKey(p => p.Id);
            modelBuilder.Entity<Usuario>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        public new void Dispose()
        {
            this.Dispose(true);
        }
    }
}
