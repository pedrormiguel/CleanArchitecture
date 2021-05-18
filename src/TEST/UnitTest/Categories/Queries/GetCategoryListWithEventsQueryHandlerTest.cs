using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using Application.Profiles;
using AutoMapper;
using Moq;
using Shouldly;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Categories.Queries
{
    public class GetCategoryListWithEventsQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;

        public GetCategoryListWithEventsQueryHandlerTest()
        {
            var configurationProvider = new MapperConfiguration(
                cfg => cfg.AddProfile<MappingProfile>());
            _mapper = configurationProvider.CreateMapper();

            _categoryRepositoryMock = RepositoryMocks.GetCategoryWithEventsRepository();

        }

        [Fact]
        public async Task GetCategoriesListWithEventsTest_ShouldReturnAllWithEvents()
        {
            var handler = new GetCategoryListWithEventsQueryHandler(_categoryRepositoryMock.Object, _mapper);

            var result = await handler.Handle(new GetCategoryListWithEventsQuery { IncludeHistory = true }, CancellationToken.None);

            result.ShouldBeOfType<List<CategoryListWithEventsVm>>();
            result.Count.ShouldBe(1);
        }

        [Fact]
        public async Task GetCategoriesListWithEventsTest_ShouldReturnAll()
        {
            var handler = new GetCategoryListWithEventsQueryHandler(_categoryRepositoryMock.Object, _mapper);

            var result = await handler.Handle(new GetCategoryListWithEventsQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CategoryListWithEventsVm>>();
            result.Count.ShouldBe(4);
        }
    }
}