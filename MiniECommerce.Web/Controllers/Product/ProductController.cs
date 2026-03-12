using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniECommerce.Web.Models;

namespace MiniECommerce.Web.Controllers.Product
{
    public class ProductController : BaseController
    {
        public ProductController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<IActionResult> Index()
        {
            var client = GetHttpClient();
            var response = await client.GetAsync("products");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<ProductListViewModel>>();
                return View(result);
            }
            return View(new List<ProductListViewModel>());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await PopulateCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel product)
        {
            if (!ModelState.IsValid)
            {
                await PopulateCategories();
                return View(product);
            }

            var client = GetHttpClient();
            var response = await client.PostAsJsonAsync("products", product);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Ürün oluşturulurken bir hata oluştu.");
            await PopulateCategories();
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"products/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ProductUpdateViewModel>();
                await PopulateCategories();
                return View(result);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductUpdateViewModel product)
        {
            if (!ModelState.IsValid)
            {
                await PopulateCategories();
                return View(product);
            }

            var client = GetHttpClient();
            var response = await client.PutAsJsonAsync($"products/{product.Id}", product);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Ürün güncellenirken bir hata oluştu.");
            await PopulateCategories();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var client = GetHttpClient();
            var response = await client.DeleteAsync($"products/{id}");
            return RedirectToAction("Index");
        }

        private async Task PopulateCategories()
        {
            var client = GetHttpClient();
            var response = await client.GetAsync("categories");
            if (response.IsSuccessStatusCode)
            {
                var categories = await response.Content.ReadFromJsonAsync<List<CategoryListViewModel>>();
                ViewBag.Categories = new SelectList(categories, "Id", "Name");
            }
            else
            {
                ViewBag.Categories = new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
    }
}
