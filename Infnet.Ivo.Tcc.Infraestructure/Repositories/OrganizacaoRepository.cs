using Infnet.Ivo.Tcc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ivo.Tcc.Infraestructure.Repositories
{
    class OrganizacaoRepository : EfRepository<Organizacao, Guid>, Infnet.Ivo.Tcc.Domain.Repositories.IOrganizacaoRepository
    {
        public OrganizacaoRepository(IDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
