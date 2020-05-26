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
    public class PostalOfficeController : Controller
    {
        private readonly IPostalOfficeService _postalOfficeService;
        private readonly IMapper _mapper;

        public PostalOfficeController(IPostalOfficeService postalOfficeService, IMapper mapper)
        {
            _postalOfficeService = postalOfficeService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Show()
        {
            var viewModels = new List<PostalOfficeViewModel>();
            foreach (var model in await _postalOfficeService.GetAllAsync())
            {
                viewModels.Add(_mapper.Map<PostalOfficeViewModel>(model));
            }

            return View(viewModels);
        }
    }
}
