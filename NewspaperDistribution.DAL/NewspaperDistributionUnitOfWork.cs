using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewspaperDistribution.DAL.Interfaces;
using NewspaperDistribution.DAL.Repositories;
using NewspaperDistribution.Domain.Models;

namespace NewspaperDistribution.DAL
{
    public class NewspaperDistributionUnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IRepository<int, NewspaperModel> _newspaperRepository;
        private IRepository<int, PostalOfficeModel> postalOfficeRepository;
        private IRepository<int, PrintingHouseModel> _printingHouseRepository;

        public IRepository<int, NewspaperModel> NewspaperRepository =>
            _newspaperRepository ?? (_newspaperRepository = new NewspaperRepository(_context));

        public IRepository<int, PostalOfficeModel> PostalOfficeRepository =>
            postalOfficeRepository ?? (postalOfficeRepository = new PostalOfficeRepository(_context));

        public IRepository<int, PrintingHouseModel> PrintingHouseRepository =>
            _printingHouseRepository ?? (_printingHouseRepository = new PrintingHouseRepository(_context));

        public NewspaperDistributionUnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task RejectChanges()
        {
            foreach (var entry in _context.ChangeTracker.Entries()
                .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }

            return Task.CompletedTask;
        }
    }
}
