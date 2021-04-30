using System.Collections.Generic;
using MediatR;

namespace Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class GetCategoryListWithEventsQuery : IRequest<List<CategoryListWithEventsVm>>
    {
        public bool IncludeHistory;
    }
}