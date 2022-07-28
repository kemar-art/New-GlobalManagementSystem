using GlobalManagementSystem.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GlobalManagementSystem.Web.Configuration;
using GlobalManagementSystem.Web.Contracts;
using GlobalManagementSystem.Web.Repositoriesy;
using GlobalManagementSystem.Web.Repositories;
using Microsoft.AspNetCore.Identity.UI.Services;
using GlobalManagementSystem.Web.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<Employee>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddTransient<IEmailSender>(s => new EmailSender("localhost", 25, "no-reply@globalmanagementsystem"));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IMakeRepository, MakeRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IModelRepository, ModelRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
builder.Services.AddScoped<IRestockRepository, RestockRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();


builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Host.UseSerilog((ctx, lc) =>
    lc.WriteTo.Console()
    .ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
