﻿using System;

namespace Application.Features.Events
{
    public class EventListVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
    }
}