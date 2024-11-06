﻿using Microsoft.EntityFrameworkCore;
using Store.Core.Entity;
using Store.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository
{
   public static class SpecificationEvalouter<T,Tkey> where T:BaseEntity<Tkey>
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery,ISpecification<T,Tkey> spec)
        {
            var Query = inputQuery;

            if(spec.Criteria is not null)
            {
                Query = Query.Where(spec.Criteria);
            }
            if(spec.OrderBy is not null)
            {
                Query = Query.OrderBy(spec.OrderBy);
            }
            if(spec.OrderByDesc is not null)
            {
                Query=Query.OrderByDescending(spec.OrderByDesc);
            }

            if (spec.IsPaginationEnabled)
            {
                Query = Query.Skip(spec.Skip).Take(spec.Take);
            }
            Query = spec.Includes.Aggregate(Query, (CurrentQuery, incluseExpression) => CurrentQuery.Include(incluseExpression));


            return Query;
        }
    }
}
