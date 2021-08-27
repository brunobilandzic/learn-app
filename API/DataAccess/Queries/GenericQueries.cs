using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataLayer.EfCode.DbSetup;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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

        public async Task<IEnumerable<TDto>> GetAll<TDto>(IConfigurationProvider configurationProvider)
        {
            return await _context.Set<T>()
                .ProjectTo<TDto>(configurationProvider)
                .ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>()
                .AddAsync(entity);
        }
    }
}