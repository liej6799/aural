using aural_library.Model.Api;
using aural_server_console_weather.Network;
using aural_server_console_weather.Network.Handler;
using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Text;

namespace aural_server_console_weather.Job
{
    public class GetWeather : IJob
    {
        public void Execute()
        {
            if (new CheckAvailability(new Urls().CheckAvailability()).Execute().isSuccess)
            {
                GetWeatherDataModel.Base getWeatherDataModelBase = new GetWeatherHourlyNetwork(new Urls().GetWeatherData()).Execute();
                SetInsertCity setInsertCity = new SetInsertCity(new Urls().SetInsertCity());

                setInsertCity.ConvertToObject(getWeatherDataModelBase.GetWeatherDataModel.city);
                setInsertCity.Execute();
            }
            else
            {
                Console.WriteLine("Services is not online.");
            }

            
        }
    }
}
