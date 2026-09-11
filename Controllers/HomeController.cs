// Author: Jakari Spann
// HomeController.cs - Handles HTTP GET and POST requests for the Future Value Calculator

using FutureValue.Models;
using Microsoft.AspNetCore.Mvc;

namespace FutureValue.Controllers
{
    // HomeController inherits from Controller to gain access to MVC helper methods and ViewBag
    public class HomeController : Controller
    {
        // HttpGet handles the initial page load; sets FV to 0 so the output field starts blank
        [HttpGet]
        public IActionResult Index()
        {
            // Initialize the displayed future value to 0 on first visit (no calculation yet)
            ViewBag.FV = 0;
            return View();
        }

        // HttpPost handles the form submission; model binding automatically maps form fields to FutureValueModel
        [HttpPost]
        public IActionResult Index(FutureValueModel model)
        {
            // ModelState.IsValid is true only when all Required and Range validation attributes pass
            if (ModelState.IsValid)
            {
                // Call the model's calculation method and store the result in ViewBag to display in the view
                ViewBag.FV = model.CalculateFutureValue();
            }
            else
            {
                // If validation fails, reset the future value so a stale result is not displayed
                ViewBag.FV = 0;
            }

            // Return the same view, passing the model back so the form retains the user's input
            return View(model);
        }
    }
}
