using Infnet.Ivo.Tcc.Domain.Entities;
using Infnet.Ivo.Tcc.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ivo.Tcc.Infraestructure.Repositories
{
    public class UsuarioRepository : EfRepository<Usuario, Guid>, IUsuarioRepository
    {
        public UsuarioRepository(IDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
