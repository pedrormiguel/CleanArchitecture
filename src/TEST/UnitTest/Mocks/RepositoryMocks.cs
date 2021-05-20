using System;
using System.Collections.Generic;
using System.Linq;
using Application.Contracts.Persistence;
using Domain.Entities;
using Moq;

namespace UnitTest.Mocks
{
    public static class RepositoryMocks
    {
        public static Mock<IAsyncRepository<Category>> GetCategoryRepository()
        {
            var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var playGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var conferenceGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            var categories = new List<Category>
            {
                new Category
                {
                    CategoryId = concertGuid,
                    Name = "Concerts"
                },
                new Category
                {
                    CategoryId = musicalGuid,
                    Name = "Musicals"
                },
                new Category
                {
                    CategoryId = conferenceGuid,
                    Name = "Conferences"
                },
                 new Category
                {
                    CategoryId = playGuid,
                    Name = "Plays"
                }
            };

            var mockCategoryRepository = new Mock<IAsyncRepository<Category>>();

            mockCategoryRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(categories);

            mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Category>()))
                                  .ReturnsAsync((Category category) =>
                       {
                           categories.Add(category);
                           return category;
                       });

            return mockCategoryRepository;
        }

        public static Mock<ICategoryRepository> GetCategoryWithEventsRepository()
        {
            var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var playGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var conferenceGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            var categories = new List<Category>
            {
                new Category
                {
                    CategoryId = concertGuid,
                    Name = "Concerts",
                    Events = new List<Event>()
                },
                new Category
                {
                    CategoryId = musicalGuid,
                    Name = "Musicals",
                    Events = new List<Event>()
                },
                new Category
                {
                    CategoryId = conferenceGuid,
                    Name = "Conferences",
                    Events = new List<Event>()
            },
                new Category
                {
                    CategoryId = playGuid,
                    Name = "Plays",
                    Events = new List<Event>()
                 }
            };

            var events = new List<Event>
            {
                new Event
                {
                    EventId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                    Name = "The State of Affairs: Michael Live!",
                    Price = 85,
                    Artist = "Michael Johnson",
                    Date = DateTime.Now.AddYears(-1),
                    Description =
                        "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/michael.jpg",
                    CategoryId = concertGuid
                },
                new Event
                {
                    EventId = Guid.Parse("{ADC42C09-08C1-4D2C-9F96-2D15BB1AF299}"),
                    Name = "To the Moon and Back",
                    Price = 135,
                    Artist = "Nick Sailor",
                    Date = DateTime.Now.AddMonths(8),
                    Description = "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/musical.jpg",
                    CategoryId = musicalGuid
                },
            };

            categories[2].Events = new List<Event> { events[0] };
            categories[1].Events = new List<Event> { events[1] };

            var mockRepository = new Mock<ICategoryRepository>();

            mockRepository.Setup(repo => repo.GetCategoriesWithEvents(true))
                          .ReturnsAsync(categories.Where(c => c.Events.Any(e => e.Date >= DateTime.Now)));

            mockRepository.Setup(repo => repo.GetCategoriesWithEvents(false))
                          .ReturnsAsync(categories);

            return mockRepository;
        }

        public static Mock<ICategoryRepository> GetCommandCategoryRepositoryAdd()
        {
            var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");

            var category = new Category
            {
                CategoryId = concertGuid,
                Name = "Concert"
            };

            var categoryDuplicate = new Category
            {
                Name = "TEST"
            };

            var listCategory = new List<Category>()
            {
                categoryDuplicate
            };

            var mockCategoryRepository = new Mock<ICategoryRepository>();

            mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Category>()))
                                  .ReturnsAsync(category);

            mockCategoryRepository.Setup(repo => repo.AddAsync(null))
                                  .ReturnsAsync(() => null);

            mockCategoryRepository.Setup(repo => repo.IsCategoryNameUnique(It.IsAny<string>()))
                                  .ReturnsAsync((string name) => listCategory.Any(c => c.Name == name));

            return mockCategoryRepository;
        }
 
    }
}