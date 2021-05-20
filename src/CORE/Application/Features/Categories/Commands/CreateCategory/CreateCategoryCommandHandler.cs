using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _autoMapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper autoMapper)
        {
            _categoryRepository = categoryRepository;
            _autoMapper = autoMapper;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryResponse = new CreateCategoryCommandResponse();
            var validator = new CreateCategoryCommandValidator(_categoryRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                categoryResponse.Success = false;
                categoryResponse.ValidationErrors = new List<string>();

                foreach (var errors in validationResult.Errors)
                {
                    categoryResponse.ValidationErrors.Add(errors.ErrorMessage);
                }
            }

            if (categoryResponse.Success)
            {
                var categoryToAdd = _autoMapper.Map<Category>(request);
                var category = await _categoryRepository.AddAsync(categoryToAdd);

                categoryResponse.CategoryCreateVm = _autoMapper.Map<CategoryCreateVm>(category);
            }

            return categoryResponse;
        }
    }
}