using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Web.Models;

namespace MiniECommerce.Web.Controllers.Order
{
    public class OrderController : BaseController
    {
        public OrderController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<IActionResult> Index()
        {
            var client = GetHttpClient();
            var response = await client.GetAsync("orders");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<OrderListViewModel>>();
                return View(result);
            }
            return View(new List<OrderListViewModel>());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var client = GetHttpClient();
            var response = await client.DeleteAsync($"orders/{id}");
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Details(int id)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"orders/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<OrderDetailViewModel>();
                return View(result);
            }
            return RedirectToAction("Index");
        }
    }
}