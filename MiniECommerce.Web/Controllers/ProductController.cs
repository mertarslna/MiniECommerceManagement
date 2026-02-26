using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Business.Services.Concrete;
using MiniECommerce.Business.Services.Interfaces;
using MiniECommerce.Entity.Entities;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    public IActionResult Index()
    {
        var products = _productService.GetAllWithCategories();
        return View(products);
    }

    // Ekleme - GET
    public IActionResult Create()
    {
        ViewBag.Categories = _categoryService.GetActiveCategories();
        return View();
    }

    // Ekleme - POST
    [HttpPost]
    public IActionResult Create(Product product)
    {
        _productService.Add(product);
        return RedirectToAction("Index");
    }

    // Güncelleme - GET
    public IActionResult Edit(int id)
    {
        var product = _productService.GetById(id);
        if (product == null) return NotFound();
        ViewBag.Categories = _categoryService.GetActiveCategories();
        return View(product);
    }

    // Güncelleme - POST
    [HttpPost]
    public IActionResult Edit(Product product)
    {
        _productService.Update(product);
        return RedirectToAction("Index");
    }

    // Silme - GET
    public IActionResult Delete(int id)
    {
        var product = _productService.GetById(id);
        if (product == null) return NotFound();
        return View(product);
    }

    // Silme - POST
    [HttpPost]
    public IActionResult Delete(Product product)
    {
        _productService.Delete(product.Id);
        return RedirectToAction("Index");
    }

    // Silme (soft delete) - GET
    public IActionResult Deactivate(int id)
    {
        _productService.Deactivate(id);
        return RedirectToAction("Index");
    }
    public IActionResult Activate(int id)
    {
        _productService.Activate(id);
        return RedirectToAction("Index");
    }
}