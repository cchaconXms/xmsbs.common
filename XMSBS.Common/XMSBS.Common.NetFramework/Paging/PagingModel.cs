using System;
using System.Collections.Generic;
using System.Text;

namespace XMSBS.Common.Paging
{
    public class PagingModel
    {
        public int? TotalElementos { get; set; }
        public int? CantidadPaginas { get; set; }
        public int? PaginaRequerida { get; set; }
        public int? ElementosPorPagina { get; set; }

    }
}
