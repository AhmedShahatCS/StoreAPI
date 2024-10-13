using Microsoft.EntityFrameworkCore;
using Store.Core.Entity;
using Store.Core.Repository.Contract;
using Store.Repository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Repository
{
   
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDbContext _context;

        public GenericRepository(StoreDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TEntity entity)
        {
           await _context.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity); 
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            if (typeof(TEntity) == typeof(Product))
             {
                return (IEnumerable<TEntity>) await _context.Products.Include(p => p.Brand).Include(p => p.Type).ToListAsync();

            }
           return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            if (typeof(TEntity) == typeof(Product))
            {
                return  await _context.Products.Include(p => p.Brand)
                                               .Include(p => p.Type)
                                               .FirstOrDefaultAsync(p=>p.Id==id as int?) as TEntity;

            }
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }
    }
}
