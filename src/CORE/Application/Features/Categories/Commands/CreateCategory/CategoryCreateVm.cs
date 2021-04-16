using System;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class CategoryCreateVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}