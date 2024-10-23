using Inventory_Manager.Models.Categories;
using Inventory_Manager.Contracts.Requests;
using Inventory_Manager.Contracts.Responses;
using FluentValidation.Results;
using Inventory_Manager.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Inventory_Manager.Contracts;

public static class ContractMapping
{
    public static Category MapToCategory(this CreateCategoryRequest request)
    {
        return new Category
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            CreatedAt = request.CreatedAt,
        };
    }

    public static Category MapToCategory(this UpdateCategoryRequest request, Guid id)
    {
        return new Category
        {
            Id = id,
            Name = request.Name,
            CreatedAt = request.CreatedAt,
        };
    }

    public static CategoryResponse MapToResponse(this Category category)
    {
        return new CategoryResponse
        {
            Id = category.Id,
            Name = category.Name,
            CreatedAt = category.CreatedAt,
        };
    }

    public static CategoriesResponse MapToResponse(this IEnumerable<Category> categories)
    {
        return new CategoriesResponse
        {
            Items = categories.Select(MapToResponse)
        };
    }

    public static ValidationFailureResponse MapToResponse(this IEnumerable<ValidationFailure> validationFailures)
    {
        return new ValidationFailureResponse
        {
            Errors = validationFailures.Select(x => new ValidationResponse
            {
                PropertyName = x.PropertyName,
                Message = x.ErrorMessage
            })
        };
    }

    public static ValidationFailureResponse MapToResponse(this ValidationFailed failed)
    {
        return new ValidationFailureResponse
        {
            Errors = failed.Errors.Select(x => new ValidationResponse
            {
                PropertyName = x.PropertyName,
                Message = x.ErrorMessage,
            })
        };
    }
}