using GitAssessment.Domain.Context;
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

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("AppDbContext"));
});

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

app.Run();
