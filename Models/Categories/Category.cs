using System.ComponentModel.DataAnnotations;

namespace Inventory_Manager.Models.Categories;

public class Category
{
    [Key]
    public required Guid Id { get; init; }

    public required string Name { get; set; }
    public required DateTime CreatedAt { get; set; }
}