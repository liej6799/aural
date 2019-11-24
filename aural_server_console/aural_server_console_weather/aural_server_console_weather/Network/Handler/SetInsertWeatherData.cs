using aural_library.Model.Api;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace aural_server_console_weather.Network.Handler
{
    public class SetInsertWeatherData
    {
        private RestClient restClient;
        private RestRequest restRequest;
        public SetInsertWeatherData(string urls)
        {
            restClient = new NetworkInitializer().GetNetworkConfig(urls);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
        }

        public BaseApiModel.BaseApi Execute(GetWeatherDataModel.RootObject getWeatherDataModel)
        {
            BaseApiModel.BaseApi BaseApi = new BaseApiModel.BaseApi();

            restRequest.AddJsonBody(getWeatherDataModel);
            IRestResponse<BaseApiModel.BaseApi> response = restClient.Execute<BaseApiModel.BaseApi>(restRequest);     

            if (response.ErrorException != null)
            {
                string message = "Error retrieving response.  Check inner details for more info.";
                var exception = new ApplicationException(message, response.ErrorException);
                BaseApi.description = message + exception;
                BaseApi.isSuccess = false;
            }
            else
            {
                BaseApi = response.Data;
            }

            return BaseApi;
        }
    }
}
