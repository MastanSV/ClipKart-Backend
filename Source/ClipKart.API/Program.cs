using System.Text;
using Clipkart.Infrastructure.DbContexts;
using Clipkart.Infrastructure.Repository;
using ClipKart.API.Extensions;
using ClipKart.Core.Constants;
using ClipKart.Core.Helpers.UserLogin;
using ClipKart.Core.Interfaces.Products;
using ClipKart.Core.Interfaces.UserLogin;
using ClipKart.Core.Models;
using ClipKart.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterServices();

var jwtSettings = builder.Configuration.GetSection(AppConfigurationConstants.JWTSettingsSection);
var jwtSecretKey = Environment.GetEnvironmentVariable(EnvironementVariables.JWTSecretKey);

if (jwtSecretKey == null)
{
    throw new ArgumentNullException($"{nameof(jwtSecretKey)} is null. {nameof(jwtSecretKey)} has to be as a Env variable.");
}

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings[AppConfigurationConstants.JWTIssuer],
        ValidAudience = jwtSettings[AppConfigurationConstants.JWTAudience],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey))
    };
});


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
