using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace MiniECommerce.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IHttpClientFactory _httpClientFactory;

        protected BaseController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        protected HttpClient GetHttpClient()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            // Cookie'den token'ı al
            if (Request.Cookies.TryGetValue("JwtToken", out var token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return client;
        }
    }
}
