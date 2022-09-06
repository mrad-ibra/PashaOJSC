using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace ProductStockApi.Response
{
    public class ProductList
    {
        public class ProductsList
        {
            string url;
            public ProductsList()
            {
                url = "https://localhost:44381/api/v1/products";
            }
            public List<Product> GetProducts()
            {
                HttpClient client = new HttpClient();
                var products = new List<Product>();
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    products = JsonConvert.DeserializeObject<List<Product>>(result);
                }
                return products;
            }
        }
    }
}
