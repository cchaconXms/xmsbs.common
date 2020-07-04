using System;
using System.Collections.Generic;
using System.Text;
using XMSBS.Common.RepositoryBase;

namespace XMSBS.Common.LogicBase
{
    public abstract class LogicBase<TUOW> where TUOW : IUnitOfWork
    {
        public TUOW UOW { get; set; }

        public LogicBase(TUOW uow)
        {
            UOW = uow;
        }
    }
}
