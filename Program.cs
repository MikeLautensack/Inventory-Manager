using Microsoft.EntityFrameworkCore;
using Inventory_Manager.Database;
using Inventory_Manager.Models.Categories;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("inventory"));
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "Inventory Manager";
    config.Title = "Inventory Manager v1";
    config.Version = "v1";
});

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "Inventory Manager";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}

app.MapGet("/", () => "Hello World!");

app.MapCategoryEndpoints();

app.Run();
