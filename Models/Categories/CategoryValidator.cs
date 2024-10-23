using FluentValidation;

namespace Inventory_Manager.Models.Categories;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.CreatedAt)
            .LessThanOrEqualTo(DateTime.UtcNow);
    }
}
