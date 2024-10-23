namespace Inventory_Manager.Contracts.Requests;

public class CreateCategoryRequest
{
    public required string Name { get; init; }
    public required DateTime CreatedAt { get; init; }
}