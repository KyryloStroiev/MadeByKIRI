using MadeByKIRI.Value;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
BasePath = builder.Environment.WebRootPath;
builder.Logging.SetMinimumLevel(LogLevel.Debug);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<NewDbContext>(options =>
options.UseSqlServer(Setting.ConnectionString));
builder.Services.AddScoped<GoodsRepository>();
builder.Services
    .AddAuthentication(optional => optional.DefaultScheme
= CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();
var app = builder.Build();
app.UseDeveloperExceptionPage();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}/{id?}");

app.Run();

