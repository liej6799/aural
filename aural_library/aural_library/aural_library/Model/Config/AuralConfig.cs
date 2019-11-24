using System;
using System.Collections.Generic;
using System.Text;

namespace aural_library.Model.Config
{
    public class AuralConfig
    {
        public API API { get; set; }
        public UserConfig UserConfig { get; set; }
    }

    public class API
    {
        public OpenWeatherAPI OpenWeatherAPI { get; set; }
        public AuralAPI AuralAPI { get; set; }
    }

    public class OpenWeatherAPI
    {
        public string APIKey { get; set; }
        public string BaseOpenWeatherAPI { get; set; }
        public string ForecastOpenWeatherAPI { get; set; }
    }

    public class UserConfig
    {
        public Location Location { get; set; }
    }

    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class AuralAPI
    {
        public string Server { get; set; }
        public string DebugVS { get; set; }
        public string LocalVM { get; set; }
    }
}
