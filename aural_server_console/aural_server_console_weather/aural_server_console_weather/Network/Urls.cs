using aural_library.Logic;
using aural_library.Model.Config;
using Flurl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace aural_server_console_weather.Network
{
    public class Urls
    {
        private string BaseParameters;
        private string BaseURL;

        private static string APIKey;
        private static string ForecastOpenWeatherAPI;
        private static double Latitude;
        private static double Longitude;

        private AuralConfig auralConfig;

        public Urls()
        {
            BaseParameters = "api/weather";
            auralConfig = JsonConvert.DeserializeObject<AuralConfig>(File.ReadAllText
            (new FileHandler().GetAuralConfigLocation()));
            if (auralConfig.API.AuralAPI.Server == "DebugVS")
            {
                BaseURL = auralConfig.API.AuralAPI.DebugVS;
            }
            else if (auralConfig.API.AuralAPI.Server == "LocalVM")
            {
                BaseURL = auralConfig.API.AuralAPI.LocalVM;
            }
        }

        public string GetWeatherData()
        {
            APIKey = auralConfig.API.OpenWeatherAPI.APIKey;
            ForecastOpenWeatherAPI = auralConfig.API.OpenWeatherAPI.BaseOpenWeatherAPI + auralConfig.API.OpenWeatherAPI.ForecastOpenWeatherAPI;
            Latitude = auralConfig.UserConfig.Location.Latitude;
            Longitude = auralConfig.UserConfig.Location.Longitude;

            return ForecastOpenWeatherAPI
                .SetQueryParams(new
                {
                    lat = Latitude,
                    lon = Longitude,
                    appid = APIKey
                });
        }

        public string CheckAvailability()
        {
            string checkAvailability = "checkAvailability";

            return BaseURL
                .AppendPathSegment(BaseParameters)
                .AppendPathSegment(checkAvailability);

        }
        public string SetInsertWeatherData()
        {
            string setInsertWeatherData = "SetInsertWeatherData";
            return BaseURL
                .AppendPathSegment(BaseParameters)
                .AppendPathSegment(setInsertWeatherData);
        }
    }
}
