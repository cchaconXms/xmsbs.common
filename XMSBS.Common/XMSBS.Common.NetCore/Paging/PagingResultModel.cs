using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace XMSBS.Common.NetCore.Paging
{
    public class PagingResultModel<T>
    {
        public PagingModel Paging { get; set; }

        public string NextPage { get; set; }

        public string FirstPage { get; set; }

        public string PrevPage { get; set; }

        public string LastPage { get; set; }

        public IEnumerable<T> Result { get; set; }

        public PagingResultModel(IEnumerable<T> list, PagingModel pagingModel)
        {
            this.Paging = pagingModel;
            this.Result = list;
        }

        public PagingResultModel(IEnumerable<T> list, PagingModel pagingModel, string query)
        {
            this.Paging = pagingModel;
            this.Result = list;
            this.setNextAndLast(query);
        }

        private string updateQueryValue(string query, string key, int? nuevoValor)
        {
            string str1 = key + "=";
            string replacement = str1 + nuevoValor.ToString();
            if (query.Contains(str1))
            {
                string pattern = str1 + "[0-9]*";
                Regex regex = new Regex(pattern);
                query = Regex.Replace(query, pattern, replacement);
            }
            else
            {
                string str2 = string.IsNullOrEmpty(query) ? "?" : "&";
                query += string.Format("{0}{1}={2}", (object) str2, (object) key, (object) nuevoValor);
            }

            return query;
        }

        private void setNextAndLast(string query)
        {
            query = this.updateQueryValue(query, "rows", this.Paging.Rows);
            query = this.updateQueryValue(query, "pages", this.Paging.Pages);
            query = this.updateQueryValue(query, "take", this.Paging.Take);
            int? pages = this.Paging.Pages;
            int num1 = 1;
            int? nullable1;
            string str1;
            if (pages.GetValueOrDefault() > num1 & pages.HasValue)
            {
                int? page = this.Paging.Page;
                int? nullable2 = page.HasValue ? new int?(page.GetValueOrDefault() - 1) : new int?();
                nullable1 = this.Paging.Pages;
                if (nullable2.GetValueOrDefault() <= nullable1.GetValueOrDefault() &
                    (nullable2.HasValue & nullable1.HasValue))
                {
                    string query1 = query;
                    nullable1 = this.Paging.Page;
                    int? nuevoValor = nullable1.HasValue ? new int?(nullable1.GetValueOrDefault() + 1) : new int?();
                    str1 = this.updateQueryValue(query1, "page", nuevoValor);
                    goto label_4;
                }
            }

            str1 = (string) null;
            label_4:
            this.NextPage = str1;
            nullable1 = this.Paging.Page;
            string str2;
            if (nullable1.Value != 1)
            {
                string query1 = query;
                nullable1 = this.Paging.Page;
                int? nuevoValor = nullable1.HasValue ? new int?(nullable1.GetValueOrDefault() - 1) : new int?();
                str2 = this.updateQueryValue(query1, "page", nuevoValor);
            }
            else
                str2 = (string) null;

            this.PrevPage = str2;
            nullable1 = this.Paging.Pages;
            int num2 = 1;
            this.LastPage = nullable1.GetValueOrDefault() > num2 & nullable1.HasValue
                ? this.updateQueryValue(query, "page", this.Paging.Pages)
                : (string) null;
            nullable1 = this.Paging.Pages;
            int num3 = 1;
            this.FirstPage = nullable1.GetValueOrDefault() > num3 & nullable1.HasValue
                ? this.updateQueryValue(query, "page", new int?(1))
                : (string) null;
        }
    }
}