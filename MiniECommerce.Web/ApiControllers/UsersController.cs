using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Business.Interfaces;

namespace MiniECommerce.Web.ApiControllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
    }
}