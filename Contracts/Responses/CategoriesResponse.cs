namespace Inventory_Manager.Contracts.Responses;

public class CategoriesResponse
{
    public required IEnumerable<CategoryResponse> Items { get; init; } = Enumerable.Empty<CategoryResponse>();
}