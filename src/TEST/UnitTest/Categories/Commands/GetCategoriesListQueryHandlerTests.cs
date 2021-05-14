using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Features.Categories.Queries.GetCategoriesList;
using Application.Profiles;
using AutoMapper;
using Domain.Entities;
using Moq;
using Shouldly;
using Xunit;

namespace UnitTest.Categories.Commands
{
    public class GetCategoriesListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepo;

        public GetCategoriesListQueryHandlerTests()
        {
            _mockCategoryRepo = RepositoryMocks.GetCategoryRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
               {
                   cfg.AddProfile<MappingProfile>();
               });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetCategoriesListTest()
        {
            var handler = new GetCategoryListQueryHandler(_mockCategoryRepo.Object, _mapper);

            var result = await handler.Handle(new GetCategoryListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CategoryListVm>>();

            result.Count.ShouldBe(4);
        }
    }
}
