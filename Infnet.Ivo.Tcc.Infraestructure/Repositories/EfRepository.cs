using Infnet.Ivo.Tcc.Domain;
using Infnet.Ivo.Tcc.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ivo.Tcc.Infraestructure.Repositories
{
    public class EfRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity, new()
        where TKey : struct
    {
        private IDbSet<TEntity> dbSet;
        private readonly IDbContext dbContext;

        public EfRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<TEntity>();
        }

        public TEntity ObterPorId(TKey id)
        {
            return this.dbSet.Find(id);
        }

        public IQueryable<TEntity> ObterTodos()
        {
            return this.dbSet.AsQueryable();
        }

        public IQueryable<TEntity> Obter(Func<TEntity, bool> filtro)
        {
            return ObterTodos().Where(filtro).AsQueryable();
        }

        public void Atualizar(TEntity entity)
        {
            this.dbSet.Attach(entity);
            this.dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Adicionar(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public void Excluir(TEntity entity)
        {
            if (dbContext.Entry(entity).State == EntityState.Detached)
                dbSet.Attach(entity);

            dbSet.Remove(entity);
        }

        public void Excluir(TKey id)
        {
            var entity = ObterPorId(id);
            Excluir(entity);
        }

        //Conferir se é melhor aqui ou no EfUnitOfWork
        public void SalvarTodos()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {

        }
    }
}
