using Domain.Contracts;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specifications
{
    public abstract  class BaseSpecification<TEnity,Tkey>: ISpecfications<TEnity, Tkey> where TEnity : Base<Tkey>
    {


        public Expression<Func<TEnity, bool>> _Criteria { get; private set; }


        public List<Expression<Func<TEnity, object>>> IncludeExpressions { get; } = [];

        public Expression<Func<TEnity, object>> OrderBy { get; private set; }

        public Expression<Func<TEnity, object>> OrderByDesc { get; private set; }

       

        public BaseSpecification(Expression<Func<TEnity, bool>> Criteria)
        {
         _Criteria= Criteria;

        }


        public void AddOrderBy(Expression<Func<TEnity, object>> expression) { OrderBy = expression; }



        public void AddOrderByDec(Expression<Func<TEnity, object>> expression) { OrderByDesc = expression; }



        public void AddIncludes(Expression<Func<TEnity, object>>IncludeExpression)
        {
            IncludeExpressions.Add(IncludeExpression);

        }

        #region Paginated
        public int Skip { get; private set; }

        public int Take { get; private set; }

        public bool IsPaginated { get; private set; }
      
        protected   void ApplyPagination(int PageIndex,int PageSize)
        {

            if (PageIndex <= 0 || PageSize <= 0)
            {
                IsPaginated = false;
            }
            IsPaginated = true;

            Take = PageSize;
            Skip = (PageIndex - 1) * PageSize;


    }

    #endregion


}
}
