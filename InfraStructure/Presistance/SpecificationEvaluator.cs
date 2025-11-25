using Domain.Contracts;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance
{
    public static class SpecificationEvaluator
    {


        public static IQueryable<TEntity> createQuery<TEntity, TKey>(IQueryable<TEntity> inputQuery, ISpecfications<TEntity, TKey> specfications) where TEntity : Base<TKey>
        {


            var query = inputQuery;
            if (specfications._Criteria is not null) { query = query.Where(specfications._Criteria); }
          //  specfications.Total=query.Count();
            
            if(specfications.OrderBy is not null)
            {                                                                                    
              query=  query.OrderBy(specfications.OrderBy);

            }

            if (specfications.OrderByDesc is not null)
            {
                query=  query.OrderBy(specfications.OrderByDesc);

            }


            if(specfications.IsPaginated is true)
            {
                query = query.Skip(specfications.Skip).Take(specfications.Take);
            }

            if (specfications.IncludeExpressions.Count() > 0 && specfications.IncludeExpressions is not null)
            {


                foreach (var exe in specfications.IncludeExpressions)
                {

                    query = query.Include(exe);

                }

            }


            return query;
        }
    }
}
    