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

        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<T, bool>> criteriaEx)
        {
            Criteria = criteriaEx;
        }



    }
}
