using _DbEntities.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _DbEntities.Repository.Concreate
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        private EFUnitOfWork efunitwork;
        public EFRepository(DbContext dbContext)
        {
           
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
            efunitwork = new EFUnitOfWork(_dbContext);
        }
        public void Delete(int id)
        {
            _dbSet.Remove(GetById(id));
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).FirstOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public int Insert(T entity)
        {
            _dbSet.Add(entity);
           return efunitwork.SaveChanges();
        }



        public void Updete(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            efunitwork.SaveChanges();
        }
    }
    }
