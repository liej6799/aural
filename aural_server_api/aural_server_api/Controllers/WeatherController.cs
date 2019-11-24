using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aural_library.Model.Api;
using aural_server_api.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace aural_server_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : Controller
    {
        private readonly WeatherDatabaseContext weatherDatabaseContext;
        public WeatherController(WeatherDatabaseContext _weatherDatabaseContext)
        {
            weatherDatabaseContext = _weatherDatabaseContext;
        }
        [HttpPost("CheckAvailability")]
        public ActionResult<BaseApiModel.BaseApi> CheckAvailability()
        {           
            return new BaseApiModel.BaseApi()
            {
                isSuccess = true,
                description = "Weather Service is Online."
            };
        }

        [HttpPost("SetInsertWeatherData")]
        public ActionResult<BaseApiModel.BaseApi> SetInsertWeatherData(GetWeatherDataModel.RootObject getWeatherDataModel)
        {
            if (ModelState.IsValid)
            {
                //_weatherDatabase.SetInsertUpdateCity(getWeatherDataModel.city);
            }

            return new BaseApiModel.BaseApi()
            {
                isSuccess = true,
                description = "Weather Service is Online."
            };
        }


    }
}