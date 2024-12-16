using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GigGuide.Data.Repository.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> All();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}
