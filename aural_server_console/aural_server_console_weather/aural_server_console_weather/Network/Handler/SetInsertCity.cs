using aural_library.Model.Api;
using aural_library.Model.Database.Weather;
using RestSharp;
using System;

namespace aural_server_console_weather.Network.Handler
{
    public class SetInsertCity
    {
        private RestClient restClient;
        private RestRequest restRequest;
        private CityModel cityModel;

        public SetInsertCity(string urls)
        {
            restClient = new NetworkInitializer().GetNetworkConfig(urls);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
        }

        public void ConvertToObject(GetWeatherDataModel.City city)
        {
            cityModel = new CityModel()
            {
                CityAPIId = city.id,
                CityName = city.name,
                Country = city.country,
                Latitude = city.coord.lat,
                Longitude = city.coord.lon,
                Population = city.population,
                Timezone = city.timezone
            };
        }

        public BaseApiModel.BaseApi Execute()
        {
            BaseApiModel.BaseApi BaseApi = new BaseApiModel.BaseApi();

            restRequest.AddJsonBody(cityModel);
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
