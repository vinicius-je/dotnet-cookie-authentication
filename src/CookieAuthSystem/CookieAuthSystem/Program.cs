using CookieAuthSystem.Application.Features.Cookie;
using CookieAuthSystem.Application.Features.Login;
using CookieAuthSystem.Domain.Interfaces;
using CookieAuthSystem.Infrastructure;
using CookieAuthSystem.Infrastructure.Context;
using CookieAuthSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Connection Configuration
builder.Services.ConfigureDabatase(builder.Configuration);

// Cookie Configuration
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "CookieAuthSystem";
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Strict;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
        options.SlidingExpiration = true;
        options.LoginPath = "/auth/login";
        options.AccessDeniedPath = "/auth/access-denied";
        // Hanlder the unauthorized access
        options.Events.OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = 401;
            return Task.CompletedTask;
        };
    });

// DI
builder.Services.AddScoped<IUserRespository, UserRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ICookieService, CookieService>();

var app = builder.Build();

CreateDataBase(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

void CreateDataBase(IHost app)
{
    var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated(); // Creates Database if does not exists
    dbContext.Database.Migrate(); // Execute migration
    // Initial Inserts
    string insertSql = File.ReadAllText("Infrastructure/Scripts/inserts.sql");
    dbContext.Database.ExecuteSqlRaw(insertSql);
}
