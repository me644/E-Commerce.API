using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUnitOfWork
    {
        public Task<int> SaveChnges();

        public IGenricRepository<TEnity,T> GetRepository<TEnity,T>() where TEnity : Base<T>;
       

    }
}
