using Microsoft.EntityFrameworkCore;
using Repository.EF;
using Repository.Interfaces;

namespace Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContextProject _dbContext;

        public GenericRepository(DbContextProject dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(TEntity entity)
        {

            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public TEntity GetById(int id)
        {
            var entity = _dbContext.Set<TEntity>().Find(id);  
            if(entity != null)
               return entity;
           
            return null;
        }

        public void Update(int id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
