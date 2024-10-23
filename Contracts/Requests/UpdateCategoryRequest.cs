namespace Inventory_Manager.Contracts.Requests;

public class UpdateCategoryRequest
{
    public required string Name { get; init; }
    public required DateTime CreatedAt { get; init; }
}