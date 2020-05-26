using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewspaperDistribution.BLL.Interfaces;
using NewspaperDistribution.UI.ViewModels;

namespace NewspaperDistribution.UI.Controllers
{
    public class NewspaperController : Controller
    {
        private readonly INewspaperService _newspaperService;
        private readonly IMapper _mapper;

        public NewspaperController(INewspaperService newspaperService, IMapper mapper)
        {
            _newspaperService = newspaperService;
            _mapper = mapper;
        }

        public async Task<IActionResult> ShowAll()
        {
            var viewModels = new List<NewspaperViewModel>();
            foreach (var model in await _newspaperService.GetAllAsync())
            {
                viewModels.Add(_mapper.Map<NewspaperViewModel>(model));
            }

            return View(viewModels);
        }

        public async Task<IActionResult> Show(int id)
        {
            var viewModel =
                _mapper.Map<NewspaperViewModel>((await _newspaperService.GetAsync(o => o.NewspaperId == id)).First());

            var printingHouses = new List<PrintingHouseViewModel>();
            foreach (var printingHouse in await _newspaperService.GetPrintingHousesOfNewspaper(viewModel.NewspaperId))
            {
                printingHouses.Add(_mapper.Map<PrintingHouseViewModel>(printingHouse));
            }

            var postalOffices = new List<PostalOfficeViewModel>();
            foreach (var postalOffice in await _newspaperService.GetPrintingHousesOfNewspaper(viewModel.NewspaperId))
            {
                
            }

            ViewBag.PrintingHouses = printingHouses;
            ViewBag.PostalOffices = 1;

            return View(viewModel);
        }
    }
}
