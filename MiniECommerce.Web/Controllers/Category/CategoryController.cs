using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Web.Models;

namespace MiniECommerce.Web.Controllers.Category
{
    public class CategoryController : BaseController
    {
        public CategoryController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<IActionResult> Index()
        {
            var client = GetHttpClient();
            var response = await client.GetAsync("categories");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<CategoryListViewModel>>();
                return View(result);
            }
            return View(new List<CategoryListViewModel>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateViewModel category)
        {
            if (!ModelState.IsValid)
                return View(category);

            var client = GetHttpClient();
            var response = await client.PostAsJsonAsync("categories", category);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            
            ModelState.AddModelError("", "Kategori oluşturulurken bir hata oluştu.");
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"categories/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<CategoryUpdateViewModel>();
                return View(result);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryUpdateViewModel category)
        {
            if (!ModelState.IsValid)
                return View(category);

            var client = GetHttpClient();
            var response = await client.PutAsJsonAsync($"categories/{category.Id}", category);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Kategori güncellenirken bir hata oluştu.");
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var client = GetHttpClient();
            var response = await client.DeleteAsync($"categories/{id}");
            return RedirectToAction("Index");
        }
    }
}