using ETrade.Business.Abstract;
using ETrade.Business.Concrete;
using ETrade.Core.CrossCuttingConcerns.Caching.Redis;
using ETrade.DataAccess.Abstract;
using ETrade.DataAccess.Concrete.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//Configuration for Redis !
IConfiguration configuration = builder.Configuration;
var multiplexer = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);

//TODO : Maybe I should use ServiceRegistration !
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Database integrated for application.
//builder.Services.AddDbContext<AppDbContext>
//    (options =>
//    {
//        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlDbCon"));
//    });

//Baðýmlýlýklarýmýzý ekliyoruz 

//For RedisCache
builder.Services.AddSingleton<ICacheService, RedisCacheManager>();

//For Product
builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<IProductService, ProductManager>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
