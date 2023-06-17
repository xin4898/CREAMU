using creamMUProductFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace creamMUProductFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CreamUDBContext econtext;


        public HomeController(ILogger<HomeController> logger,CreamUDBContext tec)
        {
            _logger = logger;
            econtext = tec;
        }

        //output variable
        [HttpGet]
        public IActionResult Index()
        {
            //table data to list
            var table = econtext.Employees.ToList();
            return View(table);
        }
      

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}