using Store.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifications
{
    public class BaseSpecification<T, Tkey> : ISpecification<T, Tkey> where T : BaseEntity<Tkey>

    {
        public Expression<Func<T, bool>> Criteria { get ; set ; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get ; set; }
        public Expression<Func<T, object>> OrderByDesc { get; set ; }
        public int Skip { get; set ; }
        public int Take { get ; set ; }
        public bool IsPaginationEnabled { get ; set; }

        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<T, bool>> criteriaEx)
        {
            Criteria = criteriaEx;
        }
        public void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy=orderByExpression;
        }
        public void AddOrderByDesc(Expression<Func<T, object>> orderByDesExpression)
        {
            OrderByDesc = orderByDesExpression;
        }

        public void ApllyPagination(int skip, int take)
        {
            IsPaginationEnabled = true;
            Skip = skip;
            Take = take;
        }



    }
}
