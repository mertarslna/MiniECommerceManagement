using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Business.Services.Interfaces;
using MiniECommerce.Entity.Entities;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    // Listeleme
    public IActionResult Index()
    {
        var categories = _categoryService.GetAll();
        return View(categories);
    }

    // Ekleme - GET
    public IActionResult Create() => View();

    // Ekleme - POST
    [HttpPost]
    public IActionResult Create(Category category)
    {
        _categoryService.Add(category);
        return RedirectToAction("Index");
    }

    // Güncelleme - GET
    public IActionResult Edit(int id)
    {
        var category = _categoryService.GetById(id);
        if (category == null) return NotFound();
        return View(category);
    }

    // Güncelleme - POST
    [HttpPost]
    public IActionResult Edit(Category category)
    {
        _categoryService.Update(category);
        return RedirectToAction("Index");
    }

    // Silme - GET
    public IActionResult Delete(int id)
    {
        var category = _categoryService.GetById(id);
        if (category == null) return NotFound();
        return View(category);
    }

    // Silme - POST
    [HttpPost]
    public IActionResult Delete(Category category)
    {
        _categoryService.Delete(category.Id);
        return RedirectToAction("Index");
    }

    // Silme (soft delete)
    public IActionResult Deactivate(int id)
    {
        _categoryService.Deactivate(id);
        return RedirectToAction("Index");
    }
    public IActionResult Activate(int id)
    {
        _categoryService.Activate(id);
        return RedirectToAction("Index");
    }
}