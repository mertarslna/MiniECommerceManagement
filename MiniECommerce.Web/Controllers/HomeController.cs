using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Web.Models;

namespace MiniECommerce.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<IActionResult> Index()
        {
            // Eğer giriş yapılmamışsa login sayfasına yönlendir (veya Home/Index'teki isAuthenticated kontrolüne güven)
            if (!Request.Cookies.ContainsKey("JwtToken"))
            {
                return View();
            }

            var client = GetHttpClient();
            
            // İstatistikleri çek
            // Not: API'de özel bir stats endpoint'i yoksa her listeden count alıyoruz.
            var categoriesResponse = await client.GetAsync("categories");
            var productsResponse = await client.GetAsync("products");
            var ordersResponse = await client.GetAsync("orders");

            if (categoriesResponse.IsSuccessStatusCode)
            {
                var categories = await categoriesResponse.Content.ReadFromJsonAsync<List<CategoryListViewModel>>();
                ViewBag.CategoryCount = categories?.Count ?? 0;
            }

            if (productsResponse.IsSuccessStatusCode)
            {
                var products = await productsResponse.Content.ReadFromJsonAsync<List<ProductListViewModel>>();
                ViewBag.ProductCount = products?.Count ?? 0;
            }

            if (ordersResponse.IsSuccessStatusCode)
            {
                var orders = await ordersResponse.Content.ReadFromJsonAsync<List<OrderListViewModel>>();
                ViewBag.OrderCount = orders?.Count ?? 0;
                
                // Toplam satış için basit bir simülasyon veya API desteği varsa gerçek değer
                // Şimdilik API'den dönen sipariş sayısına göre bir şeyler gösterebiliriz.
            }

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}