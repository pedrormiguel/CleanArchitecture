using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, List<CategoryListVm>>
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _autoMapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryRepository"></param>
        /// <param name="autoMapper"></param>
        public GetCategoryListQueryHandler(IAsyncRepository<Category> categoryRepository, IMapper autoMapper)
        {
            _categoryRepository = categoryRepository;
            _autoMapper = autoMapper;
        }


        public async Task<List<CategoryListVm>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categoryList = (await _categoryRepository.ListAllAsync())
                                                        .OrderBy(x => x.Name);

            return _autoMapper.Map<List<CategoryListVm>>(categoryList);
        }
    }
}