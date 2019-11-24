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
                new SetInsertWeatherData(new Urls().SetInsertWeatherData()).Execute(new GetWeatherHourlyNetwork(new Urls().GetWeatherData()).Execute().GetWeatherDataModel);
            }
            else
            {
                Console.WriteLine("Services is not online.");
            }

            
        }
    }
}
