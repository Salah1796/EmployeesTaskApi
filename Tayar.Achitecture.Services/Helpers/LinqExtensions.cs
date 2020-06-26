﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tayar.Achitecture.Services.Helpers
{
    public static class LinqExtensions
    {

        public static IQueryable<T> OrderByPropertyName<T>(this IQueryable<T> q, string SortField, bool Ascending)
        {
            //(p=>p.SortField) p>>Employee , Job
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, SortField);
            var exp = Expression.Lambda(prop, param);

            string method = Ascending ? "OrderBy" : "OrderByDescending";
            Type[] types = new Type[] { q.ElementType, exp.Body.Type };
            var rs = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
            return q.Provider.CreateQuery<T>(rs);
        }


    }
}