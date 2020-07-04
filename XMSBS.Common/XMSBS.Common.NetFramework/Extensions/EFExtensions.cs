using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XMSBS.Common.Paging;

namespace XMSBS.Common.Extensions
{
    public static class EFExtensions
    {
        public static async Task<IQueryable<TEntity>> addPagingAsync<TEntity>(this IQueryable<TEntity> query, PagingModel pagingModel)
        {
            var elementosPorPagina = 15;
            var paginaInicial = 1;

            if (!pagingModel.ElementosPorPagina.HasValue || pagingModel.ElementosPorPagina.Value == 0)
            {
                pagingModel.ElementosPorPagina = elementosPorPagina;
            }

            if (!pagingModel.TotalElementos.HasValue || pagingModel.TotalElementos.Value == 0)
            {
                pagingModel.TotalElementos = await query.CountAsync();
            }

            if (!pagingModel.PaginaRequerida.HasValue || pagingModel.PaginaRequerida.Value == 0)
            {
                pagingModel.PaginaRequerida = paginaInicial;
            }

            if (!pagingModel.CantidadPaginas.HasValue || pagingModel.CantidadPaginas.Value == 0)
            {
                var modulo = pagingModel.TotalElementos % pagingModel.ElementosPorPagina;
                pagingModel.CantidadPaginas = (pagingModel.TotalElementos - modulo) / pagingModel.ElementosPorPagina;
            }

            int skip = (pagingModel.PaginaRequerida == paginaInicial) ? 0 : pagingModel.ElementosPorPagina.Value * (pagingModel.PaginaRequerida.Value -1) ;

            return query.Skip(skip).Take(pagingModel.ElementosPorPagina.Value);
            
        }

        public static IQueryable<TEntity> addPaging<TEntity>(this IQueryable<TEntity> query, PagingModel pagingModel)
        {
            var elementosPorPagina = 15;
            var paginaInicial = 1;

            if (!pagingModel.ElementosPorPagina.HasValue || pagingModel.ElementosPorPagina.Value == 0)
            {
                pagingModel.ElementosPorPagina = elementosPorPagina;
            }

            if (!pagingModel.TotalElementos.HasValue || pagingModel.TotalElementos.Value == 0)
            {
                pagingModel.TotalElementos = query.Count();
            }

            if (!pagingModel.PaginaRequerida.HasValue || pagingModel.PaginaRequerida.Value == 0)
            {
                pagingModel.PaginaRequerida = paginaInicial;
            }

            if (!pagingModel.CantidadPaginas.HasValue || pagingModel.CantidadPaginas.Value == 0)
            {
                var modulo = pagingModel.TotalElementos % pagingModel.ElementosPorPagina;
                pagingModel.CantidadPaginas = (pagingModel.TotalElementos - modulo) / pagingModel.ElementosPorPagina;
            }

            int skip = (pagingModel.PaginaRequerida == paginaInicial) ? 0 : pagingModel.ElementosPorPagina.Value * (pagingModel.PaginaRequerida.Value - 1);

            return query.Skip(skip).Take(pagingModel.ElementosPorPagina.Value);

        }

        public static async Task<IEnumerable<T>> ExceptList<T, TKey>(this IQueryable<T> items, IQueryable<T> other,
                                                                            Func<T, TKey> getKey)
        {
            return await (from item in items
                          join otherItem in other on getKey(item)
                          equals getKey(otherItem) into tempItems
                          from temp in tempItems.DefaultIfEmpty()
                          where ReferenceEquals(null, temp) || temp.Equals(default(T))
                          select item).ToListAsync();
        }
    }
}
