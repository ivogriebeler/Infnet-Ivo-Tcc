using Infnet.Ivo.Tcc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ivo.Tcc.Domain.Repositories
{
    public interface IRepository<TDomain, TKey> : IDisposable
        where TDomain : class, IDomain, new()
        where TKey : struct
    {
        IQueryable<TDomain> ObterTodos();

        IQueryable<TDomain> Obter(Func<TDomain, bool> filtro);

        TDomain ObterPorId(TKey id);

        void Adicionar(TDomain objeto);

        void Atualizar(TDomain objeto);

        void Excluir(TKey id);

        void SalvarTodos();
    }
}
