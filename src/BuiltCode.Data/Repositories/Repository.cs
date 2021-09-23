using BuiltCode.Domain.Core;
using BuiltCode.Domain.Core.Data;
using BuiltCode.Domain.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BuiltCode.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, IAggregateRoot
    {
        

        protected readonly AppDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(AppDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.AsNoTracking()
                              .ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking()
                              .Where(predicate)
                              .ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public virtual void Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public virtual async Task Remover(Guid id)
        {
            var original = await ObterPorId(id);
            DbSet.Remove(original);
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
