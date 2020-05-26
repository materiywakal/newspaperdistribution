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
    public class NewspaperRepository : IRepository<int, NewspaperModel>
    {
        private readonly DatabaseContext _db;

        public NewspaperRepository(DatabaseContext context)
        {
            _db = context;
        }
        
        public async Task<IEnumerable<NewspaperModel>> GetAllAsync()
        {
            return await _db.Newspapers.ToListAsync();
        }

        public async Task<IEnumerable<NewspaperModel>> GetAsync(Expression<Func<NewspaperModel, bool>> filter)
        {
            return await _db.Newspapers.Where(filter).ToListAsync();
        }

        public async Task CreateAsync(NewspaperModel item)
        {
            await _db.Newspapers.AddAsync(item);
        }

        public async Task UpdateAsync(NewspaperModel item)
        {
            _db.Attach(item);
            _db.Entry(item).State = EntityState.Modified;
        }

        public async Task DeleteAsync(NewspaperModel item)
        {
            _db.Newspapers.Remove(item);
        }

        public async Task DeleteAsync(int id)
        {
            _db.Newspapers.Remove((await GetAsync(o => o.NewspaperId == id)).First());
        }
    }
}
