using API_CompanyTest.Middleware;
using API_CompanyTest.Repositories;
using API_CompanyTest.Services;
using BE_CompanyTest.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CompanyTestContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Dependency Injection for Repositories and Services

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAutoMapper(typeof(Program));

// Middleware custom declaration
builder.Services.AddTransient<MiddlewareLogger>();

var app = builder.Build();

// Middleware custom using
app.UseMiddleware<MiddlewareLogger>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
