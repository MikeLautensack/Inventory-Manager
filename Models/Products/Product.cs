using System.ComponentModel.DataAnnotations;

namespace Inventory_Manager.Models.Products;

public class Product {
    [Key]
    public required Guid Id { get; init; }
    public required string Name { get; set; }  
    public required decimal Price { get; set; }
    public required Guid CategoryId { get; init; }
    public required Guid SupplierId { get; init; }
    public required int StockQuantity { get; set; }
    public required DateTime CreatedAt { get; set; }
}