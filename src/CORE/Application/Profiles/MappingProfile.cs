using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Queries.GetCategoriesList;
using Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using Application.Features.Events.Commands.CreateEvent;
using Application.Features.Events.Queries.GetEventDetail;
using Application.Features.Events.Queries.GetEventList;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>();
            CreateMap<Event, EventDetailVm>();
            CreateMap<Event, EventCreateVm>();
            CreateMap<Event, CategoryEventDto>();

            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryListWithEventsVm>();

            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<Category, CategoryCreateVm>();

            CreateMap<Category, CategoryDto>();


        }
    }
}