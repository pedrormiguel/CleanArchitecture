using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class CategoryListWithEventsVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}