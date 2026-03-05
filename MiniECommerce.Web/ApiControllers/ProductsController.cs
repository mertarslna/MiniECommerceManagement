using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Business.Concrete;
using MiniECommerce.Business.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Web.ApiControllers
{
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
    }
}