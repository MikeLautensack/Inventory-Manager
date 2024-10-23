using Inventory_Manager.Contracts;
using Inventory_Manager.Contracts.Requests;

namespace Inventory_Manager.Models.Categories;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("categories");

        group.MapPost("/", async (ICategoryService categoryService, CreateCategoryRequest request) =>
        {
            var category = request.MapToCategory();
            var result = await categoryService.Create(category);
            return result.Match<IResult>(
                _ => Results.CreatedAtRoute("GetCategory", new { id = category.Id }, category.MapToResponse()),
                failed => Results.BadRequest(failed.MapToResponse())
            );
        });

        group.MapGet("/{id:guid}", async (ICategoryService categoryService, Guid id) =>
        {
            var result = await categoryService.GetById(id);
            return result is not null ? Results.Ok(result.MapToResponse()) : Results.NotFound();
        }).WithName("GetCategory");

        group.MapGet("/", async (ICategoryService categoryService) =>
        {
            var categories = await categoryService.GetAll();
            var categoriesResponse = categories.MapToResponse();
            return Results.Ok(categoriesResponse);
        });

        group.MapPut("/{id:guid}", async (ICategoryService categoryService, Guid id, UpdateCategoryRequest request) =>
        {
            var category = request.MapToCategory(id);
            var result = await categoryService.Update(category);

            return result.Match<IResult>(
                m => m is not null ? Results.Ok(m.MapToResponse()) : Results.NotFound(),
                failed => Results.BadRequest(failed.MapToResponse())
            );
        });

        group.MapDelete("/{id:guid}", async (ICategoryService categoryService, Guid id) =>
        {
            var deleted = await categoryService.DeleteById(id);
            return deleted ? Results.Ok() : Results.NotFound();
        });
    }
}