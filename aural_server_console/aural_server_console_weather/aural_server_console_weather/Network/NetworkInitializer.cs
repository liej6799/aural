using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace aural_server_console_weather.Network
{
    class NetworkInitializer
    {
        public RestClient GetNetworkConfig(string urls)
        {
            var client = new RestClient(urls);

            return client;
        }
    }
}
