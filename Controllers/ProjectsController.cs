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
                Title = "Xibalba",
                Description = "Roguelike action deck-builder based on the Mayan Book of the dead: the \"Popol Vuh\". ",
                ImageUrl = "/images/weather.png", // You can add a real image later
                GitHubLink = "https://github.com/yourusername/weather-app"
            },
            
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

