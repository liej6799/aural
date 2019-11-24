using aural_server_console_weather.Timer;
using FluentScheduler;
using System;
using System.Threading;

namespace aural_server_console_weather
{
    class Startup
    {
        static ManualResetEvent _quitEvent = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            Console.CancelKeyPress += (sender, eArgs) => {
                _quitEvent.Set();
                eArgs.Cancel = true;
            };

            // Check is Aural File Exists


            JobManager.Initialize(new RegistryInitializer());

            _quitEvent.WaitOne();
        }
    }
}
