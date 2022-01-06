using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Consumer
{
    public class ApiClient
    {
        private readonly Uri BaseUri;

        public ApiClient(Uri baseUri)
        {
            this.BaseUri = baseUri;
        }

        public async Task<HttpResponseMessage> GetAllProducts()
        {
            using (var client = new HttpClient { BaseAddress = BaseUri })
            {
                try
                {
                    client.DefaultRequestHeaders.Add("Authorization", AuthorizationHeaderValue());
                    var response = await client.GetAsync($"/api/products");
                    return response;
                }
                catch (Exception ex)
                {
                    throw new Exception("There was a problem connecting to Provider API.", ex);
                }
            }
        }

        public async Task<HttpResponseMessage> GetProduct(int id)
        {
            using (var client = new HttpClient { BaseAddress = BaseUri })
            {
                try
                {
                    client.DefaultRequestHeaders.Add("Authorization", AuthorizationHeaderValue());
                    var response = await client.GetAsync($"/api/products/{id}");
                    return response;
                }
                catch (Exception ex)
                {
                    throw new Exception("There was a problem connecting to Provider API.", ex);
                }
            }
        }

        private string AuthorizationHeaderValue()
        {
            return $"Bearer {DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}";
        }
    }
}
