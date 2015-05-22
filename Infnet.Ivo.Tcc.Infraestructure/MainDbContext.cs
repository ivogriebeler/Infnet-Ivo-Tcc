using Infnet.Ivo.Tcc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ivo.Tcc.Infraestructure
{
    public class MainDbContext : DbContext, IDbContext
    {
        public MainDbContext()
            : base("MainDbContext")
        {
        }

        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Organizacao> Organizacoes { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public new void Dispose()
        {
            this.Dispose(true);
        }
    }
}
