using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewspaperDistribution.DAL.Interfaces;
using NewspaperDistribution.Domain.Models;

namespace NewspaperDistribution.DAL.Repositories
{
    public class PrintingHouseRepository : IRepository<int, PrintingHouseModel>
    {
        private readonly DatabaseContext _db;

        public PrintingHouseRepository(DatabaseContext context)
        {
            _db = context;
        }

        public async Task<IEnumerable<PrintingHouseModel>> GetAllAsync()
        {
            return await _db.PrintingHouses.ToListAsync();
        }

        public async Task<IEnumerable<PrintingHouseModel>> GetAsync(Expression<Func<PrintingHouseModel, bool>> filter)
        {
            return await _db.PrintingHouses.Where(filter).ToListAsync();
        }

        public async Task CreateAsync(PrintingHouseModel item)
        {
            await _db.PrintingHouses.AddAsync(item);
        }

        public async Task UpdateAsync(PrintingHouseModel item)
        {
            _db.Attach(item);
            _db.Entry(item).State = EntityState.Modified;
        }

        public async Task DeleteAsync(PrintingHouseModel item)
        {
            _db.PrintingHouses.Remove(item);
        }

        public async Task DeleteAsync(int id)
        {
            _db.PrintingHouses.Remove((await GetAsync(o => o.PrintingHouseId == id)).First());
        }
    }
}
