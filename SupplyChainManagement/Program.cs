using Microsoft.EntityFrameworkCore;
using SupplyChainManagement.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SCMDbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddScoped<DBService>();
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
    pattern: "{controller=PurchaseRequisition}/{action=Index}/{id?}");

app.Run();
