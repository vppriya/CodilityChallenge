using Newtonsoft.Json;
using RestSharp;

namespace PetStoreAcceptanceTests
{
    public abstract class ApiTestBase
    {
        protected RestClient Client { get; private set; }
        private readonly string _baseUrl = "https://petstore.swagger.io/v2/";
        private const string ApiKey = "special-key";

        protected RestRequest CreateRequest(string endpoint,Method method)
        {
            var request = new RestRequest($"{_baseUrl}{endpoint}",method);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("api_key", ApiKey); // Add the API key to the request header
            return request;
        }

        protected async Task<RestResponse<TResponse>> PostRequestAsync<TRequest, TResponse>(string endpoint, TRequest payload)
        {
            var request = CreateRequest(endpoint, Method.Post);
            var jsonPayload = JsonConvert.SerializeObject(payload);
            request.AddJsonBody(jsonPayload);
            var response = await Client.ExecuteAsync<TResponse>(request);
            return response;
        }

        protected async Task<RestResponse> DeleteRequestAsync(string endpoint)
        {
            var request = CreateRequest(endpoint, Method.Delete);
            var response = await Client.ExecuteAsync(request);
            return response;
        }

        protected void CreateClient()
        {
            Client = new RestClient();
        }
    }
}

   