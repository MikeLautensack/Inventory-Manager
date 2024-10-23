using Microsoft.AspNetCore.Http.HttpResults;

namespace Inventory_Manager.Contracts.Responses;

public class CategoryResponse
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required DateTime CreatedAt { get; init; }
}