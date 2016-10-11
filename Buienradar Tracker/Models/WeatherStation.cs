namespace Buienradar_Tracker.Models
{
    public class WeatherStation
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string MeasurementDate { get; set; }
        public string Humidity { get; set; }
        public string GroundTemperatureDegreesCentigrade { get; set; }
        public string WindSpeedMetresPerSecond { get; set; }
        public string WindSpeedBeaufort { get; set; }
        public string WindDirectionDegrees { get; set; } //North is 0
        public string WindDirectionCompass { get; set; }
        public string AirPressure { get; set; }
        public string VisionDistanceMetres { get; set; }
        public string GustsMetresPerSecond { get; set; }
        public string RainMillimetresPerHour { get; set; }
        public string WeatherIconUrl { get; set; }
        public string WeatherIconDescription { get; set; }
        public string WindChillDegreesCentigrade { get; set; }
        public string StationUrl { get; set; }
        public string LatitudeDegrees { get; set; }
        public string LongitudeDegrees { get; set; }
    }
}