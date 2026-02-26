using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Business.Services.Interfaces;
public class OrderController : Controller
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    // Listeleme - GET
    public IActionResult Index()
    {
        var orders = _orderService.GetAll();
        return View(orders);
    }

    // Detay - GET
    public IActionResult Details(int id)
    {
        var order = _orderService.GetByIdWithDetails(id);
        if (order == null) return NotFound();
        return View(order);
    }

    // Durum Güncelleme - GET
    public IActionResult UpdateStatus(int id)
    {
        var order = _orderService.GetById(id);
        if (order == null) return NotFound();
        return View(order);
    }

    // Durum Güncelleme - POST
    [HttpPost]
    public IActionResult UpdateStatus(int id, string status)
    {
        _orderService.UpdateStatus(id, status);
        return RedirectToAction("Index");
    }
}