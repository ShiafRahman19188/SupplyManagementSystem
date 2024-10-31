using Microsoft.EntityFrameworkCore;
using SupplyChainManagement.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SCMDbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("con")));
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
