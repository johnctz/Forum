using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Forum.Services
{
    public interface ICommonRepository
    {
        Task Add<T>(T param) where T : class;
        Task<T> Find<T>(Expression<Func<T, bool>> expression) where T : class;
        IEnumerable<T> FindAll<T>(Expression<Func<T, bool>> expression) where T : class;
        Task<T> Get<T>(Guid id) where T : class;
        Task<IList<T>> GetAll<T>() where T : class;
        IEnumerable<T> GetAllEnumerable<T>() where T : class;
        IQueryable<T> GetAllQueryable<T>() where T : class;
        Task<bool> IsExist<T>(Expression<Func<T, bool>> expression) where T : class;
        Task<bool> IsExist<T>(Guid id) where T : class;
        Task<bool> SaveAsync();
        void Update<T>(T param) where T : class;
    }
}