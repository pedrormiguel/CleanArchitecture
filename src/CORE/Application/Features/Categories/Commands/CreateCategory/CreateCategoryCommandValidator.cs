using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(ca => ca.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsCategoryNameUnique).WithMessage("{PropertyName} must to be unique");
        }

        private async Task<bool> IsCategoryNameUnique(string category, CancellationToken token)
        {
            return !(await _categoryRepository.IsCategoryNameUnique(category));
        }
    }
}