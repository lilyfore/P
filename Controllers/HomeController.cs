using Microsoft.AspNetCore.Mvc;
using P.Models;
using P.Services;
using System.Diagnostics;


namespace P.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmailService _emailService;
        public HomeController(ILogger<HomeController> logger, EmailService emailService)
        {
            _logger = logger;
             _emailService = emailService;
        }

        

        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> SubmitContact(string name, string email, string message)
        {
            await _emailService.SendEmailAsync(name, email, message);

            ViewData["Name"] = name;
            ViewData["Email"] = email;
            ViewData["Message"] = message;

            return View("ContactConfirmation");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }


}