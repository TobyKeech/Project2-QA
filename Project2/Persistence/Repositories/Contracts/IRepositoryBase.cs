using System.Linq.Expressions;

namespace Project2.Persistence.Repositories.Contracts
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T FindById(int id);
        T Create(T entity);
        T Update(T entity);
        void Delete(T entity);

        //interface structure being used here to be implemented in other classes
    }
}
