using Buienradar_Tracker.Models;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Buienradar_Tracker.Services
{
    public class WeatherDataReader
    {
        private string _sourceUrl = "http://xml.buienradar.nl/";

        public WeatherData ReadData()
        {
            var document = XDocument.Load(_sourceUrl);
            var stations = document.Descendants("weerstation");

            var weatherStations = new List<WeatherStation>();

            foreach (var station in stations)
            {
                weatherStations.Add(new WeatherStation()
                {
                    Code = station.Element("stationcode")?.Value,
                    Name = station.Element("stationnaam")?.Value.Substring(11),
                    Region = station.Element("stationnaam")?.Attribute("regio")?.Value,
                    Latitude = station.Element("lat")?.Value,
                    Longitude = station.Element("lon")?.Value,
                    MeasurementDate = station.Element("datum")?.Value,
                    Humidity = station.Element("luchtvochtigheid")?.Value,
                    GroundTemperatureDegreesCentigrade = station.Element("temperatuurGC")?.Value,
                    WindSpeedMetresPerSecond = station.Element("windsnelheidMS")?.Value,
                    WindSpeedBeaufort = station.Element("windsnelheidBF")?.Value,
                    WindDirectionDegrees = station.Element("windrichtingGR")?.Value,
                    WindDirectionCompass = station.Element("windrichting")?.Value,
                    AirPressure = station.Element("luchtdruk")?.Value,
                    VisionDistanceMetres = station.Element("zichtmeters")?.Value,
                    GustsMetresPerSecond = station.Element("windstotenMS")?.Value,
                    RainMillimetresPerHour = station.Element("regenMMPU")?.Value,
                    WeatherIconUrl = station.Element("icoonactueel")?.Value,
                    WeatherIconDescription = station.Element("icoonactueel")?.Attribute("zin")?.Value,
                    WindChillDegreesCentigrade = station.Element("temperatuur10cm")?.Value,
                    StationUrl = station.Element("url")?.Value,
                    LatitudeDegrees = station.Element("latGraden")?.Value,
                    LongitudeDegrees = station.Element("lonGraden")?.Value
                });
            }
            
            return new WeatherData() { Stations = weatherStations };
        }
    }
}