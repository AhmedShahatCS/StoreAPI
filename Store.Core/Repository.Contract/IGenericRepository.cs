using Store.Core.Entity;
using Store.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Repository.Contract
{
    public interface IGenericRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Tkey id);
        Task<IEnumerable<TEntity>> GetAllwithspecAsync(ISpecification<TEntity,Tkey> Spec);
        Task<TEntity> GetWithSpecAsync(ISpecification<TEntity, Tkey> Spec);
        Task AddAsync(TEntity entity);

        void Update(TEntity entity);
        void Delete(TEntity entity);

    }
}

