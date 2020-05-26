using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NewspaperDistribution.Domain.Models;

namespace NewspaperDistribution.BLL.Interfaces
{
    public interface IPrintingHouseService
    {
        Task<IEnumerable<PrintingHouseModel>> GetAllAsync();
        Task<IEnumerable<PrintingHouseModel>> GetAsync(Expression<Func<PrintingHouseModel, bool>> expression);
        Task CreateAsync(PrintingHouseModel model);
    }
}
