using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace API.DataAccess.Queries
{
    public interface IGenericQueries<T> where T : class
    {
        Task Add(T entity);
        Task<IEnumerable<TDto>> GetAll<TDto>(IConfigurationProvider configurationProvider);
        Task<T> GetOne(int id);
    }
}