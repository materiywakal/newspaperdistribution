using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewspaperDistribution.Domain.Models;

namespace NewspaperDistribution.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<int, NewspaperModel> NewspaperRepository { get; }
        IRepository<int, PostalOfficeModel> PostalOfficeRepository { get; }
        IRepository<int, PrintingHouseModel> PrintingHouseRepository { get; }

        Task SaveAsync();
        Task RejectChanges();
    }
}
