using ContosoUniversity.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Data.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T>
        where T: class,new()
    {
        private readonly ContosoContext _context;

        public EntityBaseRepository(ContosoContext context)
        {
            _context = context;
        }
        public virtual async  Task AddAsync(T entity)
        {
            var dbEntityEntry = _context.Entry<T>(entity);
            await _context.Set<T>().AddAsync(entity);
        }

        public virtual IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }

        public virtual async  Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountsAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public void Delete(T entity)
        {
            var entry = _context.Entry<T>(entity);
            entry.State = EntityState.Deleted;
        }

        public void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            var entities = _context.Set<T>().Where(predicate);
            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = EntityState.Deleted;
            }
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public virtual  IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var prop in includeProperties)
            {
                query = query.Include(prop);
            }
            return query.FirstOrDefault(predicate);
        }

        public void Update(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }
    }
}
