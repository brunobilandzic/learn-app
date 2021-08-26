using System.Collections.Generic;
using System.Threading.Tasks;
using API.DataLayer.EfCode.DbSetup;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess.Queries
{
    

    public class GenericQueries<T> : IGenericQueries<T> where T : class
    {
        private readonly LearnAppDbContext _context;
        public GenericQueries(LearnAppDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetOne(int id)
        {
            return await _context.Set<T>()
                .FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>()
                .ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>()
                .AddAsync(entity);
        }
    }
}