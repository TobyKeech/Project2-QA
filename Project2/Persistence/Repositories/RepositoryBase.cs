using Microsoft.EntityFrameworkCore;
using Project2.EF;
using Project2.Persistence.Repositories.Contracts;
using System.Linq.Expressions;

namespace Project2.Persistence.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
        //T is used such as Movie or whatever as its being injected and used in other places(can be copied and injected in other places)
    {
        protected EstateContext _repositoryContext { get; set; }
        public RepositoryBase(EstateContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

        }
        public IQueryable<T> FindAll() => _repositoryContext.Set<T>().AsNoTracking(); //Returns a new query where the entities returned will not be cached in the DbContext or ObjectContext.
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            var allEntities = _repositoryContext.Set<T>().AsNoTracking();
            var entities = allEntities.Where(expression);
            return entities;
        }
        public T FindById(int id)
        {
            return _repositoryContext.Set<T>().SingleOrDefault(predicate => predicate.Id == id);
        }
        public T Create(T entity)
        {
            _repositoryContext.Set<T>().Add(entity);
            _repositoryContext.SaveChanges();
            return entity;
        }
        public T Update(T entity)
        {
            _repositoryContext.Set<T>().Update(entity);
            _repositoryContext.SaveChanges();
            return entity;
        }
        public void Delete(T entity)
        {
            _repositoryContext.ChangeTracker.Clear();
            _repositoryContext.Set<T>().Remove(entity);
            _repositoryContext.SaveChanges();
            //_repositoryContext.Dispose();
        }

        public void SaveChanges()
        {

        }

        //CRUD functionality held in here and can be injected to other
    }
}
