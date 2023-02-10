using Microsoft.AspNetCore.Mvc;
using NetworkInterceptor_POC.Models;
using System.Diagnostics;

namespace NetworkInterceptor_POC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var headers = this.Request.Headers;
            if (headers != null && headers.ContainsKey("testId"))
            {
                headers.TryGetValue("testId", out var testIds);
            }

            return View();
        }


        [HttpPost]
        public JsonResult TestHeaderInterception()
        {
            var headers = this.Request.Headers;
            if (headers != null && headers.ContainsKey("testId"))
            {
                headers.TryGetValue("testId", out var testIds);
                return Json(testIds.FirstOrDefault());
            }

            return Json(new { header = String.Empty });
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