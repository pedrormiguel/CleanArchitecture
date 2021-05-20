using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Features.Categories.Commands.CreateCategory;
using Application.Profiles;
using AutoMapper;
using Moq;
using Shouldly;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Categories.Commands
{
    public class CreateCategoryCommandHandlerTest
    {
        private readonly Mock<ICategoryRepository> _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandlerTest()
        {
            var configurationProvider = new MapperConfiguration(mp => mp.AddProfile<MappingProfile>());

            _mapper = configurationProvider.CreateMapper();

            _categoryRepository = RepositoryMocks.GetCommandCategoryRepositoryAdd();
        }

        [Theory]
        [InlineData("Concert", "B0788D2F-8003-43C1-92A4-EDC76A7C5DDE")]
        public async Task CreateCategoryCommand_ShouldReturnCategoryResponseSuccesfull(string name, string guid)
        {
            var handler = new CreateCategoryCommandHandler(_categoryRepository.Object, _mapper);

            var response = await handler.Handle(new CreateCategoryCommand() { Name = name }, CancellationToken.None);


            response.ShouldBeOfType<CreateCategoryCommandResponse>();
            response.Success.ShouldBe(true, "The state of success must to be True");
            response.ValidationErrors.ShouldBeNull();

            response.CategoryCreateVm.Name.ShouldBe(name);
            response.CategoryCreateVm.CategoryId.ShouldBe(Guid.Parse(guid));
        }

        [Fact]
        public async Task CreateCategoryCommand_ShouldReturnCategoryResponseFailure_WithEmptyName()
        {
            var handler = new CreateCategoryCommandHandler(_categoryRepository.Object, _mapper);

            var response = await handler.Handle(new CreateCategoryCommand(), CancellationToken.None);

            response.ShouldBeOfType<CreateCategoryCommandResponse>();
            response.Success.ShouldBe(false, "The state of success must to be False");
            response.ValidationErrors.Count.ShouldBe(2);
            response.ValidationErrors.ElementAt(0).ShouldBe("Name is required.");
            response.ValidationErrors.ElementAt(1).ShouldBe("'Name' must not be empty.");

            response.CategoryCreateVm.ShouldBeNull();
        }

        [Theory]
        [InlineData("TEST")]
        public async Task CreateCategoryCommandHandler_ShouldReturnCategoryResponseFailer_WithDuplicateName(string name)
        {
            var handler = new CreateCategoryCommandHandler(_categoryRepository.Object, _mapper);

            var response = await handler.Handle(new CreateCategoryCommand() { Name = name }, CancellationToken.None);

            response.ShouldBeOfType<CreateCategoryCommandResponse>();
            response.Success.ShouldBe(false, "The state of success must to be False");
            response.ValidationErrors.Count.ShouldBeGreaterThan(0);
            response.CategoryCreateVm.ShouldBeNull();
        }
    }
}
