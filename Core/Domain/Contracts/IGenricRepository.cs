using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IGenricRepository<TEntity,Tkey>  where TEntity : Base<Tkey>
    {

        public Task<IEnumerable<TEntity>> GetAllAsync (bool AsNoTraking = false);

        public Task<TEntity?> GetbyIdAsync(Tkey Id); 

       

   public  Task  Add(TEntity entity);

    public    void Delete(TEntity entity);


      public  void Update(TEntity entity);


        #region Specifications

        public Task<IEnumerable<TEntity>> GetAllAsync(ISpecfications<TEntity, Tkey> specfications);


        public Task<TEntity?> GetbyIdAsync(ISpecfications<TEntity, Tkey> specfications);


        public Task<int> CountAsync(ISpecfications <TEntity,Tkey> specfications);
        #endregion
    }
}
