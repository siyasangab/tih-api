using GitAssessment.Domain.Context;
using GitAssessment.Services.Caching;
using GitAssessment.Services.Domain.Words;
using GitAssessment.Services.Domain.WordTypes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services
builder.Services.AddScoped<IWordTypesService, WordTypeService>();
builder.Services.AddScoped<IWordsService, WordsService>();
builder.Services.AddScoped<ICacheService, CacheService>();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("AppDbContext"));
});


// Caching
builder.Services.AddResponseCaching();
builder.Services.AddDistributedMemoryCache();

var app = builder.Build();

await using var scope = app.Services.CreateAsyncScope();

using var db = scope.ServiceProvider.GetService<AppDbContext>();

await db.Database.MigrateAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x.AllowAnyMethod()
    .AllowAnyHeader()
    .WithOrigins("http://127.0.0.1:4200")
    .AllowCredentials());

app.UseResponseCaching();

app.Run();
