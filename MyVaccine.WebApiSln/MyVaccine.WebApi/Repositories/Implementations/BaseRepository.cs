using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;

namespace MyVaccine.WebApi.Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly MyVaccineAppDbContext _context;
        public BaseRepository(MyVaccineAppDbContext context)
        {
            _context = context;
        }

        public Task Add(T entity) 
        {
            throw new NotImplementedException();
        }

        public Task AddRange(List<T> entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRange(List<T> entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindByAsNoTracking(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            var entitySet = _context.Set<T>();
            return entitySet.AsQueryable();
           
        }

        public Task Patch(T entity)
        {
            throw new NotImplementedException();
        }

        public Task PatchRange(List<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRange(List<T> entity)
        {
            throw new NotImplementedException();
        }
    }
}
