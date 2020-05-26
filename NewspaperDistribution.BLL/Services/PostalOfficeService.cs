using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NewspaperDistribution.BLL.Interfaces;
using NewspaperDistribution.DAL.Interfaces;
using NewspaperDistribution.Domain.Models;

namespace NewspaperDistribution.BLL.Services
{
    public class PostalOfficeService : IPostalOfficeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<int, PostalOfficeModel> _repository;

        public PostalOfficeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.PostalOfficeRepository;
        }

        public async Task<IEnumerable<PostalOfficeModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<PostalOfficeModel>> GetAsync(Expression<Func<PostalOfficeModel, bool>> expression)
        {
            return await _repository.GetAsync(expression);
        }

        public async Task CreateAsync(PostalOfficeModel model)
        {
            await _repository.CreateAsync(model);
            await _unitOfWork.SaveAsync();
        }
    }
}
