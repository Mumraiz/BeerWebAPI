using BeerApplication.DataAccess.AutoMapperProfiles;
using BeerApplication.DataAccess.Data;
using BeerApplication.Repositories;
using BeerApplication.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseInMemoryDatabase("InMemoryDb");
});

builder.Services.AddScoped<IBeerRepository, BeerRepository>();
builder.Services.AddScoped<IBeerService, BeerService>();
builder.Services.AddAutoMapper(typeof(BeerProfile));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
