using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Web.Models;
using System.Net.Http.Json;

namespace MiniECommerce.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
                return View(login);

            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.PostAsJsonAsync("auth/login", login);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<TokenResponse>();

                if (result != null && !string.IsNullOrEmpty(result.Token))
                {
                    HttpContext.Response.Cookies.Append("JwtToken", result.Token, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = Request.IsHttps,
                        SameSite = SameSiteMode.Lax,
                        Expires = DateTimeOffset.UtcNow.AddHours(1),
                        Path = "/"
                    });

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "E-posta veya şifre hatalı.");
            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
                return View(register);

            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.PostAsJsonAsync("auth/register", register);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", "Kayıt işlemi sırasında bir hata oluştu.");
            return View(register);
        }

        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("JwtToken");
            return RedirectToAction("Login", "Auth");
        }
    }

    public class TokenResponse { public string Token { get; set; } }
}