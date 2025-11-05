using Domain.Contracts;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Presentation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Presistance
{
    public class GenricRepository<TEntity, TKey>(StoreDbContext _Store) : IGenricRepository<TEntity, TKey>  where TEntity : Base<TKey>
    {




        public async Task<IEnumerable<TEntity>> GetAllAsync(bool AsNoTraking = false)


        => AsNoTraking ? await _Store.Set<TEntity>().AsNoTracking().ToListAsync() :
          await  _Store.Set<TEntity>().ToListAsync();

        public async Task Add(TEntity entity)
        {
            await  _Store.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
          _Store.Set<TEntity>().Remove(entity);
        }

        public async Task<TEntity?> GetbyIdAsync(TKey Id) =>   await _Store.Set<TEntity>().FindAsync(Id);
       
        public void Update(TEntity entity)
        {
            _Store.Set<TEntity>().Update(entity);
        }




        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecfications<TEntity, TKey> specfications)
        {
          return  await SpecificationEvaluator.createQuery(_Store.Set<TEntity>(), specfications).ToListAsync();
        }


        public async Task<TEntity?> GetbyIdAsync(ISpecfications<TEntity, TKey> specfications)
        {
            return await SpecificationEvaluator.createQuery(_Store.Set<TEntity>(), specfications).FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(ISpecfications<TEntity, TKey> specfications)
        {
           


            return await SpecificationEvaluator.createQuery(_Store.Set<TEntity>(),specfications).CountAsync();
        }
    }
}
