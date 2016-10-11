using Buienradar_Tracker.Models;
using Buienradar_Tracker.Services;
using System.Web.Mvc;

namespace Buienradar_Tracker.Controllers
{
    public class HomeController : Controller
    {
        private WeatherDataReader _weatherDataReader = new WeatherDataReader();

        public ActionResult Index()
        {
            WeatherData weatherData = _weatherDataReader.ReadData();

            return View(weatherData);
        }
    }
}