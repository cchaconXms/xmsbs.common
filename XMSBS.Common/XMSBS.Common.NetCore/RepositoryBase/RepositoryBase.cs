using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMSBS.Common.NetCore.RepositoryBase
{
    public abstract class RepositoryBase<TEntity, IDT, CT> :
        IRepository<TEntity, IDT> where TEntity : EFTBase<IDT> where CT : DbContext

    {
        protected CT Context;

        public RepositoryBase(CT context)
        {
            Context = context;
        }

        public virtual void Delete(IDT id)
        {
            var entity = Context.Set<TEntity>().Find(id);
            Context.Set<TEntity>().Remove(entity);
            
        }

        public virtual void DeleteRange(IEnumerable<IDT> ids)
        {
            var entities = Context.Set<TEntity>().Where(p => ids.Any(q => p.Id.Equals(q)));
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public virtual async Task DeleteAsync(IDT id)
        {
            var entity = await Context.Set<TEntity>().FindAsync(id);

            Context.Set<TEntity>().Remove(entity);
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<IDT> ids)
        {
            var entities = await Context.Set<TEntity>().Where(p => ids.Any(q => p.Id.Equals(q))).ToListAsync();
            Context.Set<TEntity>().RemoveRange(entities);
        }


        public virtual TEntity Find(IDT id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public virtual async Task<TEntity> FindAsync(IDT id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public virtual void Insert(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public virtual void Update(TEntity entity)
        {
            var entityDB = Context.Set<TEntity>().Find(entity.Id);

            Context.Entry(entityDB).CurrentValues.SetValues(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            var entityDB = await Context.Set<TEntity>().FindAsync(entity.Id);

            Context.Entry(entityDB).CurrentValues.SetValues(entity);
            
        }

         
    }
}
