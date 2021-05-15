using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class GetCategoryListWithEventsQueryHandler : IRequestHandler<GetCategoryListWithEventsQuery, List<CategoryListWithEventsVm>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _autoMapper;

        public GetCategoryListWithEventsQueryHandler(ICategoryRepository categoryRepository, IMapper autoMapper)
        {
            _categoryRepository = categoryRepository;
            _autoMapper = autoMapper;
        }

        public async Task<List<CategoryListWithEventsVm>> Handle(GetCategoryListWithEventsQuery request, CancellationToken cancellationToken)
        {
            var categoriesWithEvents = 
                    (await _categoryRepository.GetCategoriesWithEvents(request.IncludeHistory));

            return _autoMapper.Map<List<CategoryListWithEventsVm>>(categoriesWithEvents); 
        }
    }
}