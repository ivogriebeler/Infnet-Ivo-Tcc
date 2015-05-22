using Infnet.Ivo.Tcc.Domain.Entities;
using Infnet.Ivo.Tcc.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ivo.Tcc.Infraestructure.Repositories
{
    public class ExercicioRepository : EfRepository<Exercicio, Guid>, IExercicioRepository
    {
        public ExercicioRepository(IDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
