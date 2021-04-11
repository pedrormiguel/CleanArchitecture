using System.Collections.Generic;
using MediatR;

namespace Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoryListQuery : IRequest<List<CategoryListVm>>
    {
        
    }
}