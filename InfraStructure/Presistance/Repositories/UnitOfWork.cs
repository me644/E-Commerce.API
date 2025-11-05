using Domain.Contracts;
using Domain.Entites;
using Presentation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Repositories
{


    public class UnitOfWork : IUnitOfWork
    {

        private readonly StoreDbContext store;
        private  Dictionary<string, object> _repositories;
        public UnitOfWork(StoreDbContext _store)
        {

            store= _store;
          _repositories=new Dictionary<string, object>();
        }

        public IGenricRepository<TEnity, T> GetRepository<TEnity,T>() where TEnity : Base<T>
        {
            var key=typeof(TEnity).Name;
            if (!_repositories.ContainsKey(key))
            {
                _repositories[key] = new GenricRepository<TEnity, T>(store);
                
            }
            return  (IGenricRepository<TEnity, T>) _repositories[key];
        }

        public Task<int> SaveChnges()
        {

         return   store.SaveChangesAsync();
        }
    }
}
