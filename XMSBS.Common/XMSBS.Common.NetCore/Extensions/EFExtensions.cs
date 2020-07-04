using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using XMSBS.Common.NetCore.Exceptions;
using XMSBS.Common.NetCore.Paging;

namespace XMSBS.Common.NetCore.Extensions
{
    public static class EFExtensions
    {
        public static async Task<IQueryable<TEntity>> AddPagingAsync<TEntity>(this IQueryable<TEntity> query,
            PagingModel pagingModel)
        {
            int num1 = 15;
            int num2 = 100;
            int paginaInicial = 1;
            int? nullable1 = pagingModel.Take;
            int num3 = num2;
            if (nullable1.GetValueOrDefault() > num3 & nullable1.HasValue)
                throw new PagingException(string.Format("el máximo de elementos por página es {0}", (object) num2));
            nullable1 = pagingModel.Take;
            if (nullable1.HasValue)
            {
                nullable1 = pagingModel.Take;
                if (nullable1.Value != 0)
                    goto label_5;
            }

            pagingModel.Take = new int?(num1);
            label_5:
            nullable1 = pagingModel.Rows;
            if (nullable1.HasValue)
            {
                nullable1 = pagingModel.Rows;
                if (nullable1.Value != 0)
                    goto label_9;
            }

            PagingModel pagingModel1 = pagingModel;
            pagingModel1.Rows = new int?(await query.CountAsync<TEntity>(new CancellationToken()));
            pagingModel1 = (PagingModel) null;
            label_9:
            nullable1 = pagingModel.Page;
            if (nullable1.HasValue)
            {
                nullable1 = pagingModel.Page;
                if (nullable1.Value != 0)
                    goto label_12;
            }

            pagingModel.Page = new int?(paginaInicial);
            label_12:
            nullable1 = pagingModel.Pages;
            if (nullable1.HasValue)
            {
                nullable1 = pagingModel.Pages;
                if (nullable1.Value != 0)
                    goto label_23;
            }

            nullable1 = pagingModel.Rows;
            int? nullable2 = pagingModel.Take;
            int? nullable3 = nullable1.HasValue & nullable2.HasValue
                ? new int?(nullable1.GetValueOrDefault() % nullable2.GetValueOrDefault())
                : new int?();
            PagingModel pagingModel2 = pagingModel;
            nullable2 = pagingModel.Rows;
            nullable1 = pagingModel.Take;
            int? nullable4;
            if (!(nullable2.GetValueOrDefault() >= nullable1.GetValueOrDefault() &
                  (nullable2.HasValue & nullable1.HasValue)))
            {
                nullable4 = new int?(1);
            }
            else
            {
                int? rows = pagingModel.Rows;
                int? nullable5 = nullable3;
                nullable1 = rows.HasValue & nullable5.HasValue
                    ? new int?(rows.GetValueOrDefault() - nullable5.GetValueOrDefault())
                    : new int?();
                nullable2 = pagingModel.Take;
                if (!(nullable1.HasValue & nullable2.HasValue))
                {
                    nullable5 = new int?();
                    nullable4 = nullable5;
                }
                else
                    nullable4 = new int?(nullable1.GetValueOrDefault() / nullable2.GetValueOrDefault());
            }

            pagingModel2.Pages = nullable4;
            PagingModel pagingModel3 = pagingModel;
            nullable2 = pagingModel3.Pages;
            nullable1 = nullable3;
            int num4 = 0;
            int num5 = nullable1.GetValueOrDefault() > num4 & nullable1.HasValue ? 1 : 0;
            int? nullable6;
            if (!nullable2.HasValue)
            {
                nullable1 = new int?();
                nullable6 = nullable1;
            }
            else
                nullable6 = new int?(nullable2.GetValueOrDefault() + num5);

            pagingModel3.Pages = nullable6;
            label_23:
            nullable2 = pagingModel.Page;
            int num6 = paginaInicial;
            int count1;
            if (!(nullable2.GetValueOrDefault() == num6 & nullable2.HasValue))
            {
                nullable2 = pagingModel.Take;
                int num7 = nullable2.Value;
                nullable2 = pagingModel.Page;
                int num8 = nullable2.Value - 1;
                count1 = num7 * num8;
            }
            else
                count1 = 0;

            IQueryable<TEntity> source = Queryable.Skip<TEntity>(query, count1);
            nullable2 = pagingModel.Take;
            int count2 = nullable2.Value;
            return source.Take<TEntity>(count2);
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