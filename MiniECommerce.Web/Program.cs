using Microsoft.EntityFrameworkCore;
using MiniECommerce.Business.Concrete;
using MiniECommerce.Business.Interfaces;
using MiniECommerce.Business.Mapping;
using MiniECommerce.DataAccess.Context;
using MiniECommerce.DataAccess.Repositories.Concrete;
using MiniECommerce.DataAccess.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Controllerda API kullanımı için yapılandırma
builder.Services.AddHttpClient("ApiClient", client => client.BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseUrl"]));

builder.Services.AddControllersWithViews();

// API Controllers
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EĞER AUTOMAPPER KULLANILACAKSA
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<CategoryProfile>();
    config.AddProfile<OrderItemProfile>();
    config.AddProfile<OrderProfile>();
    config.AddProfile<ProductProfile>();
    config.AddProfile<UserProfile>();
});
// SATIRI EKLENMELİ

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();

// Services
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IOrderItemService, OrderItemManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    // Swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
