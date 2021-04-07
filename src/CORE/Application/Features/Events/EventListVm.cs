﻿using System;
namespace Application.Features.Events
{
    //Class that serve as DTO
    //It's just show the informacion that I want.
    public class EventListVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
    }
}