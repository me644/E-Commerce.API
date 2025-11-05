using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ISpecfications<TEnity, Tkey> where TEnity : Base<Tkey>
    {


        public Expression<Func<TEnity, bool>> _Criteria { get; }

        public Expression<Func<TEnity, object>> OrderBy { get; }

        public Expression<Func<TEnity, object>> OrderByDesc { get; }



        //  make list of exepression bec i can not make where T: is what
        public List<Expression<Func<TEnity, object>>> IncludeExpressions { get; }



        public int Skip { get; }

        public int Take { get; }

        public bool IsPaginated { get; }

       
    }
}
