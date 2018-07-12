using Forum.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Forum.Services
{
    public class CommonRepository : ICommonRepository
    {
        private ApplicationDbContext _context;

        public CommonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task Add<T>(T param) where T : class
        {
            await _context.Set<T>().AddAsync(param);
        }

        public virtual async Task<T> Get<T>(Guid id) where T : class
        {
            return await _context.FindAsync<T>(id);
        }

        public virtual async Task<IList<T>> GetAll<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual IEnumerable<T> GetAllEnumerable<T>() where T : class
        {
            return _context.Set<T>();
        }
        public virtual IQueryable<T> GetAllQueryable<T>() where T : class
        {
            return _context.Set<T>();
        }
        
        public virtual void Update<T>(T param) where T : class
        {
            _context.Entry(param).State = EntityState.Modified;
        }

        public virtual async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<bool> IsExist<T>(Guid id) where T : class
        {
            return await _context.Set<T>().FindAsync(id) != null ? true : false;
        }
        public async Task<bool> IsExist<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return await _context.Set<T>().AnyAsync(expression);
        }
        public async Task<T> Find<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }
        public IEnumerable<T> FindAll<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return _context.Set<T>().Where(expression);
        }
        
    }
}
