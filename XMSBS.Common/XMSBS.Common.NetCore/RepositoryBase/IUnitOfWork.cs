using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XMSBS.Common.NetCore.RepositoryBase
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
