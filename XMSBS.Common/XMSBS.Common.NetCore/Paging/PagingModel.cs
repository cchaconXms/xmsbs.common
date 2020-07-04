using System;
using System.Collections.Generic;
using System.Text;

namespace XMSBS.Common.NetCore.Paging
{
    public class PagingModel
    {
        public int? Rows { get; set; }

        public int? Pages { get; set; }

        public int? Page { get; set; }

        public int? Take { get; set; }

    }
}
