using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Business.Services.Concrete;
using MiniECommerce.Business.Services.Interfaces;
using MiniECommerce.Entity.Entities;

public class UserController : Controller
{
    private readonly IUserService _userService;

}