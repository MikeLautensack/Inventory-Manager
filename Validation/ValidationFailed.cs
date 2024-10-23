using FluentValidation.Results;

namespace Inventory_Manager.Validation;

public record ValidationFailed(IEnumerable<ValidationFailure> Errors)
{
    public ValidationFailed(ValidationFailure error) : this(new[] { error })
    {
    }
}
