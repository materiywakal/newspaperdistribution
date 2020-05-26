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
    public class PostalOfficeRepository : IRepository<int, PostalOfficeModel>
    {
        private readonly DatabaseContext _db;

        public PostalOfficeRepository(DatabaseContext context)
        {
            _db = context;
        }

        public async Task<IEnumerable<PostalOfficeModel>> GetAllAsync()
        {
            return await _db.PostalOffices.ToListAsync();
        }

        public async Task<IEnumerable<PostalOfficeModel>> GetAsync(Expression<Func<PostalOfficeModel, bool>> filter)
        {
            return await _db.PostalOffices.Where(filter).ToListAsync();
        }

        public async Task CreateAsync(PostalOfficeModel item)
        {
            await _db.PostalOffices.AddAsync(item);
        }

        public async Task UpdateAsync(PostalOfficeModel item)
        {
            _db.Attach(item);
            _db.Entry(item).State = EntityState.Modified;
        }

        public async Task DeleteAsync(PostalOfficeModel item)
        {
            _db.PostalOffices.Remove(item);
        }

        public async Task DeleteAsync(int id)
        {
            _db.PostalOffices.Remove((await GetAsync(o => o.PostalOfficeId == id)).First());
        }
    }
}
