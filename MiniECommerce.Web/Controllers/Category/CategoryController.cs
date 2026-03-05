using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Web.Models.Category;

public class CategoryController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CategoryController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    private HttpClient CreateClient() => _httpClientFactory.CreateClient("ApiClient");

    public async Task<IActionResult> Index()
    {
        var client = CreateClient();
        var values = await client.GetFromJsonAsync<List<CategoryListViewModel>>("api/categories");
        return View(values ?? []);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new CategoryCreateViewModel { Name = string.Empty });
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryCreateViewModel model)
    {
        var client = CreateClient();
        var response = await client.PostAsJsonAsync("api/categories", model);
        if (response.IsSuccessStatusCode) return RedirectToAction("Index");
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var client = CreateClient();

        var value = await client.GetFromJsonAsync<CategoryUpdateViewModel>($"api/categories/{id}");
        return View(value);
    }

    [HttpPost]
    public async Task<IActionResult> Update(CategoryUpdateViewModel model)
    {
        var client = CreateClient();
        var response = await client.PutAsJsonAsync("api/categories", model);
        if (response.IsSuccessStatusCode) return RedirectToAction("Index");
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var client = CreateClient();

        var response = await client.DeleteAsync($"api/categories/{id}");

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> ToggleStatus(int id)
    {
        var client = CreateClient();
        var category = await client.GetFromJsonAsync<CategoryUpdateViewModel>($"api/categories/{id}");
        if (category != null)
        {
            category.IsActive = !category.IsActive;
            await client.PutAsJsonAsync("api/categories", category);
        }
        return RedirectToAction("Index");
    }
}