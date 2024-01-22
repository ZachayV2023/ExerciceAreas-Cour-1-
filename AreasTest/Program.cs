using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AreasTest.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AreasTestContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AreasTestContext") ?? throw new InvalidOperationException("Connection string 'AreasTestContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Ajouter les services pour Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//--Route For Admins--//
app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

//--Route For Normal Users--//
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
