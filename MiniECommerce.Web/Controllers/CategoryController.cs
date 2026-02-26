using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Business.Services.Concrete;
using MiniECommerce.Business.Services.Interfaces;
using MiniECommerce.Entity.Entities;

public class OrderItemController : Controller
{
    private readonly IOrderItemService _orderItemService;

    public OrderItemController(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }

    // Listeleme
    public IActionResult Index()
    {
        var orderItem = _orderItemService.GetAll();
        return View(orderItem);
    }

    // Ekleme - GET
    public IActionResult Create() => View();

    // Ekleme - POST
    [HttpPost]
    public IActionResult Create(OrderItem orderItem)
    {
        _orderItemService.Add(orderItem);
        return RedirectToAction("Index");
    }

    // Güncelleme - GET
    public IActionResult Edit(int id)
    {
        var orderItem = _orderItemService.GetById(id);
        if (orderItem == null) return NotFound();
        return View(orderItem);
    }

    // Güncelleme - POST
    [HttpPost]
    public IActionResult Edit(OrderItem orderItem)
    {
        _orderItemService.Update(orderItem);
        return RedirectToAction("Index");
    }

    // Silme - GET
    public IActionResult Delete(int id)
    {
        var orderItem = _orderItemService.GetById(id);
        if (orderItem == null) return NotFound();
        return View(orderItem);
    }

    // Silme - POST
    [HttpPost]
    public IActionResult Delete(OrderItem orderItem)
    {
        _orderItemService.Delete(orderItem.Id);
        return RedirectToAction("Index");
    }
}