using Store.Core;
using Store.Core.Entity;
using Store.Core.Repository.Contract;
using Store.Repository.Data.Contexts;
using Store.Repository.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;
        private Hashtable _repositories;

        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
            _repositories=new Hashtable();
        }
        public async Task<int> CompletAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IGenericRepository<TEntity, Tkey> Repository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                var Repository=new GenericRepository<TEntity, Tkey>(_context);
                _repositories.Add(type, Repository);
            }
            return _repositories[type] as IGenericRepository<TEntity, Tkey>;


        }
    }
}
