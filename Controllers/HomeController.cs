using CascadingDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CascadingDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly EFCodeDBContext _context;

        public HomeController(EFCodeDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var countries = _context.Countries.ToList();
            return View(countries);
        }

        [HttpGet]
        public IActionResult GetCountries()
        {
            var countries = _context.Countries.ToList();
            return Json(new SelectList(countries, "CountryId", "CountryName"));
        }

        [HttpGet]
        public IActionResult GetStates(int countryId)
        {
            var states = _context.States.Where(x => x.CountryId == countryId).ToList();
            return Json(new SelectList(states, "StateId", "StateName"));
        }

        [HttpGet]
        public IActionResult GetCities(int stateId)
        {
            var cities = _context.Cities.Where(x => x.StateId == stateId).ToList();
            return Json(new SelectList(cities, "CityId", "CityName"));
        }
    }
}