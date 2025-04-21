using Microsoft.AspNetCore.Mvc;

using P.Models;

namespace P.Controllers
{
    public class ProjectsController : Controller
    {
        // For now, we'll use mock data (hardcoded list)
        private static List<Project> _projects = new()
        {
            new Project
            {
                Id = 1,
                Title = "Weather App",
                Description = "An app that displays current weather data from OpenWeather API.",
                ImageUrl = "/images/weather.png", // You can add a real image later
                GitHubLink = "https://github.com/yourusername/weather-app"
            },
            new Project
            {
                Id = 2,
                Title = "To-Do List",
                Description = "A basic to-do list built with ASP.NET Core MVC.",
                ImageUrl = "/images/todo.png",
                GitHubLink = "https://github.com/yourusername/todo-list"
            }
        };

        // GET: /Projects
        public IActionResult Index()
        {
            return View(_projects);
        }

        // GET: /Projects/Details/{id}
        public IActionResult Details(int id)
        {
            var project = _projects.FirstOrDefault(p => p.Id == id);
            if (project == null)
                return NotFound();

            return View(project);
        }
    }
}

