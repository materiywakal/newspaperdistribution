using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NewspaperDistribution.UI.ViewModels;

namespace NewspaperDistribution.UI.Controllers
{
    public class HomeController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
