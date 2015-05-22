using Infnet.Ivo.Tcc.Domain.Repositories;
using Infnet.Ivo.Tcc.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ivo.Tcc.Infraestructure.EfUnitOfWork
{
    public class EfUnitOfWork : IEfUnitOfWork
    {
        private readonly IDbContext dbContext;

        public EfUnitOfWork(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private IExercicioRepository exercicioRepository;
        public IExercicioRepository ExercicioRepository
        {
            get
            {
                return exercicioRepository ?? (exercicioRepository = new ExercicioRepository(dbContext));
            }
        }

        private IOrganizacaoRepository organizacaoRepository;
        public IOrganizacaoRepository OrganizacaoRepository
        {
            get
            {
                return organizacaoRepository ?? (organizacaoRepository = new OrganizacaoRepository(dbContext));
            }
        }

        private ISerieRepository serieRepository;
        public ISerieRepository SerieRepository
        {
            get
            {
                return serieRepository ?? (serieRepository = new SerieRepository(dbContext));
            }
        }

        private IUsuarioRepository usuarioRepository;
        public IUsuarioRepository UsuarioRepository
        {
            get
            {
                return usuarioRepository ?? (usuarioRepository = new UsuarioRepository(dbContext));
            }
        }

        //Conferir se é melhor aqui ou no EfRepository
        //public void Commit()
        //{
        //    this.dbContext.SaveChanges();
        //}

        //Conferir, pois deixando apenas aqui deu erro. Tive que colocar no EfRepository também.
        public void Dispose()
        {
            this.dbContext.Dispose();
        }
    }
}
