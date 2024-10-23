using FluentValidation;
using Inventory_Manager.Database;
using Inventory_Manager.Validation;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Manager.Models.Products;

public class ProductService : IProductService {
private readonly IValidator<Product> _validator;
    private readonly AppDbContext _dbContext;

    public ProductService(IValidator<Product> validator, AppDbContext dbContext) {
        _validator = validator;
        _dbContext = dbContext;
    }
}

public interface IProductService {
Task<Result<Product, ValidationFailed>> Create(Product product);

    Task<Product?> GetById(Guid id);

    Task<IEnumerable<Product>> GetAll();

    Task<Result<Product?, ValidationFailed>> Update(Product product);

    Task<bool> DeleteById(Guid id);
}