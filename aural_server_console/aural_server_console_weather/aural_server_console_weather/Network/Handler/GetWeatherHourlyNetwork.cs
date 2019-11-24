using aural_library.Model.Api;
using aural_server_console_weather.Job;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace aural_server_console_weather.Network.Handler
{
    public class GetWeatherHourlyNetwork
    {
        private RestClient restClient;
        private RestRequest restRequest;
        public GetWeatherHourlyNetwork(string urls)
        {
            restClient = new NetworkInitializer().GetNetworkConfig(urls);
            restRequest = new RestRequest(Method.POST);
        }

        public GetWeatherDataModel.Base Execute()
        {
            GetWeatherDataModel.Base getWeatherData = new GetWeatherDataModel.Base();
            BaseApiModel.BaseApi BaseApi = new BaseApiModel.BaseApi();

            IRestResponse<GetWeatherDataModel.RootObject> response = restClient.Execute<GetWeatherDataModel.RootObject>(restRequest);

            if (response.ErrorException != null)
            {
                string message = "Error retrieving response.  Check inner details for more info.";
                var exception = new ApplicationException(message, response.ErrorException);
                BaseApi.description = message + exception;
                BaseApi.isSuccess = false;
            }
            else
            {
                BaseApi.description = "Success calling OpenWeatherAPI at ";
                BaseApi.isSuccess = true;

                getWeatherData.GetWeatherDataModel = response.Data;
                getWeatherData.BaseApi = BaseApi;
            }



            return getWeatherData;
        }

    }
}
