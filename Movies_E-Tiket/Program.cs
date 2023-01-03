using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Movies_E_Tiket.Data;
using Movies_E_Tiket.Data.Cart;
using Movies_E_Tiket.Data.Services;
using Movies_E_Tiket.Models;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//DbContext configuration
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
//Service Configuration
builder.Services.AddScoped<IActorsService, ActorsService>();
builder.Services.AddScoped<IMoviesService, MoviesService>();
builder.Services.AddScoped<IProducersService, ProducersService>();
builder.Services.AddScoped<IMoviesService, MoviesService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

//Authentication and authorization
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});



//Multiple Language 

builder.Services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
builder.Services.Configure<RequestLocalizationOptions>(opt =>

{
    var supportedCultures = new List<CultureInfo>
    {
     new CultureInfo("en"),
     new CultureInfo("fr"),
     new CultureInfo("tr"),
    };
    opt.DefaultRequestCulture = new RequestCulture("en");
    opt.SupportedCultures= supportedCultures;   
    opt.SupportedUICultures= supportedCultures; 
});
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

//Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.UseRequestLocalization(((IApplicationBuilder)app).ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

/*var supportedCultures = new[] { "en", "fr", "tr" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);*/

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

//Seed Database
AppDb›nitialiazer.Seed(app);
AppDb›nitialiazer.SeedUsersAndRolesAsync(app).Wait();

app.Run();
