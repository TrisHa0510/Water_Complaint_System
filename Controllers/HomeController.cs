using Microsoft.AspNetCore.Mvc;
using WaterComplaintSystem.Models;
using System.Diagnostics;

namespace WaterComplaintSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Practical 2, 3, 13: Index with time-based greeting and ViewData/ViewBag
        public IActionResult Index()
        {
            // Practical 3: Time-based greeting
            int hour = DateTime.Now.Hour;
            string greeting;
            string imageUrl;

            if (hour < 12)
            {
                greeting = "Good Morning!";
                imageUrl = "/images/morning.jpg";
            }
            else if (hour < 17)
            {
                greeting = "Good Afternoon!";
                imageUrl = "/images/afternoon.jpg";
            }
            else
            {
                greeting = "Good Evening!";
                imageUrl = "/images/evening.jpg";
            }

            // Practical 13: ViewData, ViewBag, TempData
            ViewData["Greeting"] = greeting;
            ViewData["ImageUrl"] = imageUrl;
            ViewBag.CurrentTime = DateTime.Now.ToString("hh:mm tt");
            ViewBag.SystemName = "Water Complaint Management System";

            TempData["WelcomeMessage"] = "Welcome to Municipal Water Complaint Portal";

            return View();
        }

        // Practical 2: Custom view demonstration
        public ViewResult MyView()
        {
            return View();
        }

        // Practical 4: Welcome page for navigation
        public IActionResult Welcome()
        {
            return View();
        }

        // Practical 5: Countries table with Bootstrap
        public IActionResult Countries()
        {
            return View();
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
