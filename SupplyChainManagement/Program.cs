using MailKit;
using Microsoft.EntityFrameworkCore;
using SupplyChainManagement.Db;
using SupplyChainManagement.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SCMDbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddScoped<DBService>();
builder.Services.AddScoped<MailServices>();
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
    pattern: "{controller=YarnBooking}/{action=Index}/{id?}");

app.Run();
