using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NewspaperDistribution.DAL.Interfaces
{
    public interface IRepository<in TId, TDomain> where TDomain : class
    {
        Task<IEnumerable<TDomain>> GetAllAsync();
        Task<IEnumerable<TDomain>> GetAsync(Expression<Func<TDomain, bool>> filter);
        Task CreateAsync(TDomain item);
        Task UpdateAsync(TDomain item);
        Task DeleteAsync(TDomain item);
        Task DeleteAsync(TId id);
    }
}
