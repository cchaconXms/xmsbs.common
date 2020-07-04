using System;
using System.Collections.Generic;
using System.Text;
using XMSBS.Common.NetCore.RepositoryBase;

namespace XMSBS.Common.NetCore.LogicBase
{
    public partial class LogicBase<TUOW> where TUOW : IUnitOfWork
    {
        protected TUOW UOW { get; set; }

        public LogicBase(TUOW uow)
        {
            UOW = uow;
        }
    }
    
    public partial class LogicBase<TUOW, TUOWII>
        where TUOW : IUnitOfWork
        where TUOWII : IUnitOfWork
    {
        protected TUOW UOW { get; set; }

        protected TUOWII UOWII { get; set; }

        public LogicBase(TUOW uow, TUOWII uowii)
        {
            this.UOW = uow;
            this.UOWII = uowii;
        }
    }
}
