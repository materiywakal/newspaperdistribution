using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NewspaperDistribution.Domain.Models;

namespace NewspaperDistribution.BLL.Interfaces
{
    public interface INewspaperService
    {
        Task<IEnumerable<NewspaperModel>> GetAllAsync();
        Task<IEnumerable<NewspaperModel>> GetAsync(Expression<Func<NewspaperModel, bool>> expression);
        Task CreateAsync(NewspaperModel model);
        Task<IEnumerable<PrintingHouseModel>> GetPrintingHousesOfNewspaper(int newspaperId);
    }
}
