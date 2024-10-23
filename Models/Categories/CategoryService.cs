using FluentValidation;
using Inventory_Manager.Database;
using Inventory_Manager.Validation;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Manager.Models.Categories;

public class CategoryService : ICategoryService
{
    private readonly IValidator<Category> _validator;
    private readonly AppDbContext _dbContext;

    public CategoryService(IValidator<Category> validator, AppDbContext dbContext)
    {
        _validator = validator;
        _dbContext = dbContext;
    }

    public async Task<Result<Category, ValidationFailed>> Create(Category category)
    {
        var validationResult = await _validator.ValidateAsync(category);
        if (!validationResult.IsValid)
        {
            return new ValidationFailed(validationResult.Errors);
        }

        _dbContext.Categories.Add(category);
        await _dbContext.SaveChangesAsync();

        return category;
    }

    public async Task<Category?> GetById(Guid id)
    {
        return await _dbContext.Categories.FindAsync(id);
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _dbContext.Categories.ToListAsync();
    }

    public async Task<Result<Category?, ValidationFailed>> Update(Category category)
    {
        var validationResult = await _validator.ValidateAsync(category);
        if (!validationResult.IsValid)
        {
            return new ValidationFailed(validationResult.Errors);
        }
        _dbContext.Categories.Update(category);
        var result = await _dbContext.SaveChangesAsync();
        return result > 0 ? category : default;
    }

    public async Task<bool> DeleteById(Guid id)
    {
        var result = await _dbContext.Categories.Where(c => c.Id == id).ExecuteDeleteAsync();
        return result > 0;
    }
}

public interface ICategoryService
{
    Task<Result<Category, ValidationFailed>> Create(Category category);

    Task<Category?> GetById(Guid id);

    Task<IEnumerable<Category>> GetAll();

    Task<Result<Category?, ValidationFailed>> Update(Category category);

    Task<bool> DeleteById(Guid id);
}