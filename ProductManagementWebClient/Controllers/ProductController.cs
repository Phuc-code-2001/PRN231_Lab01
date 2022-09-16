using BusinessObjects.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ProductManagementWebClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _client;
        private readonly string ProductApiUrl;

        public ProductController()
        {
            _client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(contentType);

            ProductApiUrl = "https://localhost:44342/api/products";

        }

        public IActionResult Index()
        {

            var response = _client.GetAsync(ProductApiUrl).Result;
            if (!response.IsSuccessStatusCode) return StatusCode(500, response.Content.ReadAsStringAsync().Result);
            string rawData = response.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            List<Product> products = JsonSerializer.Deserialize<List<Product>>(rawData, options);
            return View(products);
        }

        
    }
}
