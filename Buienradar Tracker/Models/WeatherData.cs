using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Buienradar_Tracker.Models
{
    public class WeatherData
    {
        public IEnumerable<WeatherStation> Stations { get; set; }
        public string Average
        {
            get
            {
                double total = 0.0;
                int count = 0;

                foreach (var station in Stations)
                {
                    if (station.GroundTemperatureDegreesCentigrade != "-")
                    {
                        total += double.Parse(station.GroundTemperatureDegreesCentigrade, CultureInfo.InvariantCulture);
                        count++;
                    }
                }

                if (count != 0)
                {
                    return string.Format(new CultureInfo("en-GB"), "{0:N1}", total / count);
                }

                return "0.0";
            }
        }
        public IEnumerable<WeatherStation> HighestTemperatures
        {
            get
            {
                return Stations
                    .OrderByDescending(s => s.GroundTemperatureDegreesCentigrade, new AlphaNumericComparator<string>())
                    .Where(s => s.GroundTemperatureDegreesCentigrade != "-")
                    .Take(3);
            }
        }
    }
}