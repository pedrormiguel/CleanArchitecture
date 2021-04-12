using System;
using MediatR;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand: CategoryCreateVm, IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}