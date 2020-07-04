using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XMSBS.Common.NetCore.RepositoryBase
{
    public interface IRepository<TEntity, IDT> where TEntity : EFTBase<IDT>
    {
        void Insert(TEntity entity);
        Task InsertAsync(TEntity entity);

        void Delete(IDT id);
        Task DeleteAsync(IDT id);

        void DeleteRange(IEnumerable<IDT> ids);
        Task DeleteRangeAsync(IEnumerable<IDT> ids);


        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);

        TEntity Find(IDT id);
        Task<TEntity> FindAsync(IDT id);

    }
}
