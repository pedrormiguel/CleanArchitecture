<<<<<<< HEAD
﻿using Application.Features.Categories.Queries.GetCategoriesList;
using Application.Features.Categories.Queries.GetCategoriesListWithEvents;
=======
﻿using Application.Features.Events;
using Application.Features.Events.Commands.CreateEvent;
>>>>>>> Feature-CreateEvent
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
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, EventCreateVm>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryListWithEventsVm>();
        }
    }
}