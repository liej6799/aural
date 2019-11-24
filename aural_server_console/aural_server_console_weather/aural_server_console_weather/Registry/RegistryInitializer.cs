
using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using aural_server_console_weather.Job;

namespace aural_server_console_weather.Timer
{
    public class RegistryInitializer : Registry
    {
        public RegistryInitializer()
        {
            Schedule<GetWeather>()
                    .NonReentrant()
                    .ToRunOnceAt(DateTime.Now.AddSeconds(3))
                    .AndEvery(2).Seconds();
        }
    }
}
