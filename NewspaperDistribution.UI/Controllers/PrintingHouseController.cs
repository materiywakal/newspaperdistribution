using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewspaperDistribution.BLL.Interfaces;
using NewspaperDistribution.UI.ViewModels;

namespace NewspaperDistribution.UI.Controllers
{
    public class PrintingHouseController : Controller
    {
        private readonly IPrintingHouseService _printingHouseService;
        private readonly IMapper _mapper;

        public PrintingHouseController(IPrintingHouseService printingHouseService, IMapper mapper)
        {
            _printingHouseService = printingHouseService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Show()
        {
            var viewModels = new List<PrintingHouseViewModel>();
            foreach (var model in await _printingHouseService.GetAllAsync())
            {
                viewModels.Add(_mapper.Map<PrintingHouseViewModel>(model));
            }

            return View(viewModels);
        }
    }
}
