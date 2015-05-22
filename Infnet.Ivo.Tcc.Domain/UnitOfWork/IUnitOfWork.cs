using Infnet.Ivo.Tcc.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ivo.Tcc.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void commit();

        IExercicioRepository ExercicioRepository { get; }

        IOrganizacaoRepository OrganizacaoRepository { get; }

        ISerieRepository SerieRepository { get; }

        IUsuarioRepository UsuarioRepository { get; }
    }
}
