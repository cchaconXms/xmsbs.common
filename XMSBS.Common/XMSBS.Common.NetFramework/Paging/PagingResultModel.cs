using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace XMSBS.Common.Paging
{
    public class PagingResultModel<T>
    {
        public PagingModel Paging { get; set; }

        public IList<T> Result { get; set; }

        public PagingResultModel(IList<T> list, PagingModel pagingModel) 
        {
            this.Paging = pagingModel;
            this.Result = list;
        }
    }
}
