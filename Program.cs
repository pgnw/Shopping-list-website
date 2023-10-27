using Microsoft.EntityFrameworkCore;
using Shopping_list_website.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    //Sets how long the user can go withoput sending a wab requets bsfore the session data deletes. 
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    //Gives the session cookie a unique identifier as a name
    //options.Cookie.Name = "Test";
    options.Cookie.HttpOnly = true;
    //Sets the session cookie to only allow access from the same site
    options.Cookie.SameSite = SameSiteMode.Strict;
    //Sets the session cookie to always use the same connection type HTTP or HTTPS as
    //when returning a request
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
});

var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<ShoppingCartDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
