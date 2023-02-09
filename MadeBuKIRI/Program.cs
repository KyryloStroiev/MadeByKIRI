using KIRI.Domen.Repository;
using MadeByKIRI.Interfaces;
using MadeByKIRI.Value;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
BasePath = builder.Environment.WebRootPath;
builder.Logging.SetMinimumLevel(LogLevel.Debug);
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IAllGoods, GoodsRepository>();
builder.Services.AddTransient<IAllOrders, OrdersRepository>();
//builder.Services.AddTransient<IGoodsCategory, CategoryRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => ShopCart.GetCart(sp));
builder.Services.AddDbContext<NewDbContext>(options =>
options.UseSqlServer(Setting.ConnectionString));
builder.Services.AddScoped<GoodsRepository>();
builder.Services
    .AddAuthentication(optional => optional.DefaultScheme
= CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();
builder.Services.AddMvc();
builder.Services.AddMemoryCache();
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromSeconds(300);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});
var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/home/error";
        await next();
    }
});
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}/{id?}");

app.Run();

