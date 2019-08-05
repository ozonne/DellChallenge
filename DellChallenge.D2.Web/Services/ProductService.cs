using System.Collections.Generic;
using System.Text.RegularExpressions;
using DellChallenge.D2.Web.Models;
using Newtonsoft.Json;
using RestSharp;

namespace DellChallenge.D2.Web.Services
{
    public class ProductService : IProductService
    {
        public ProductModel Add(NewProductModel newProduct)
        {
            var apiClient = new RestClient("http://localhost:2534/api");
            var apiRequest = new RestRequest("products", Method.POST, DataFormat.Json);
            apiRequest.AddJsonBody(newProduct);
            var apiResponse = apiClient.Execute<ProductModel>(apiRequest);
            return apiResponse.Data;
        }

        public ProductModel Update(ProductModel product)
        {
            var apiClient = new RestClient("http://localhost:2534/api");
            var apiRequest = new RestRequest("products/" + product.Id, Method.PUT, DataFormat.None);
            apiRequest.AddParameter("application/json", '"' + JsonConvert.SerializeObject(product).Replace("\"", "\\\"") + '"', ParameterType.RequestBody);
            var apiResponse = apiClient.Execute<ProductModel>(apiRequest);
            return apiResponse.Data;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            
            var apiClient = new RestClient("http://localhost:2534/api");
            var apiRequest = new RestRequest("products", Method.GET, DataFormat.Json);
            var apiResponse = apiClient.Execute<List<ProductModel>>(apiRequest);
            return apiResponse.Data;
        }

        public ProductModel Get(string id)
        {

            var apiClient = new RestClient("http://localhost:2534/api");
            var apiRequest = new RestRequest("products/" + id, Method.GET, DataFormat.Json);
            var apiResponse = apiClient.Execute<ProductModel>(apiRequest);
            return apiResponse.Data;
        }

        public bool Delete(string id)
        {
            var apiClient = new RestClient("http://localhost:2534/api");
            var apiRequest = new RestRequest("products/" + id, Method.DELETE, DataFormat.None);
            var apiResponse = apiClient.Execute(apiRequest);
            if (apiResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return false;
            }
            return true;
        }
    }
}
