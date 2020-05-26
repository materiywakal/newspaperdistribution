using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NewspaperDistribution.BLL.Interfaces;
using NewspaperDistribution.DAL.Interfaces;
using NewspaperDistribution.Domain.Models;

namespace NewspaperDistribution.BLL.Services
{
    public class PrintingHouseService : IPrintingHouseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<int, PrintingHouseModel> _repository;

        public PrintingHouseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.PrintingHouseRepository;
        }

        public async Task<IEnumerable<PrintingHouseModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<PrintingHouseModel>> GetAsync(Expression<Func<PrintingHouseModel, bool>> expression)
        {
            return await _repository.GetAsync(expression);
        }

        public async Task CreateAsync(PrintingHouseModel model)
        {
            await _repository.CreateAsync(model);
            await _unitOfWork.SaveAsync();
        }
    }
}
