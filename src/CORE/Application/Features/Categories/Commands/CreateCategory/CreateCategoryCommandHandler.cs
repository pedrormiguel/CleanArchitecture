using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler: IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _autoMapper;
        
        public CreateCategoryCommandHandler(IAsyncRepository<Category> categoryRepository, IMapper autoMapper)
        {
            _categoryRepository = categoryRepository;
            _autoMapper = autoMapper;
        }
        
        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
           var ifExistCategory = await _categoryRepository.GetByIdAsync(request.Id);

            if (ifExistCategory != null)
                throw new ApplicationException();

            var categoryToAdd = _autoMapper.Map<Category>(request);
            
            categoryToAdd = await _categoryRepository.AddAsync(categoryToAdd);

            return categoryToAdd.CategoryId;
        }
    }
}