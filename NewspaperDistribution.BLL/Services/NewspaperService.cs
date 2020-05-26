using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NewspaperDistribution.BLL.Interfaces;
using NewspaperDistribution.DAL.Interfaces;
using NewspaperDistribution.Domain.Models;

namespace NewspaperDistribution.BLL.Services
{
    public class NewspaperService : INewspaperService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<int, NewspaperModel> _repository;

        public NewspaperService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.NewspaperRepository;
        }

        public async Task<IEnumerable<NewspaperModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<NewspaperModel>> GetAsync(Expression<Func<NewspaperModel, bool>> expression)
        {
            return await _repository.GetAsync(expression);
        }

        public async Task CreateAsync(NewspaperModel model)
        {
            await _repository.CreateAsync(model);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PrintingHouseModel>> GetPrintingHousesOfNewspaper(int newspaperId)
        {
            return await _unitOfWork.PrintingHouseRepository.GetAsync(o =>
                o.NewspaperPrintingHouseRelation.Exists(e => e.NewspaperId == newspaperId));
        }

        public async Task<IEnumerable<PostalOfficeModel>> 
    }
}
