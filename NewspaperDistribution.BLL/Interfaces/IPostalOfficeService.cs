using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NewspaperDistribution.Domain.Models;

namespace NewspaperDistribution.BLL.Interfaces
{
    public interface IPostalOfficeService
    {
        Task<IEnumerable<PostalOfficeModel>> GetAllAsync();
        Task<IEnumerable<PostalOfficeModel>> GetAsync(Expression<Func<PostalOfficeModel, bool>> expression);
        Task CreateAsync(PostalOfficeModel model);
    }
}
