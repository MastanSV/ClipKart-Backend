using Clipkart.Infrastructure.DbContexts;
using Clipkart.Infrastructure.Repository;
using ClipKart.Core.Helpers.UserLogin;
using ClipKart.Core.Interfaces.Products;
using ClipKart.Core.Interfaces.UserLogin;
using ClipKart.Core.Models;
using ClipKart.Core.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUserLoginCrendentialValidator, UserLoginCredentialsValidator>();
builder.Services.AddSingleton<IUserLoginService, UserLoginService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("ClipKart.API")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowClipKartApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173") 
              .AllowAnyMethod()                    
              .AllowAnyHeader()                    
              .AllowCredentials();                 
    });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowClipKartApp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
