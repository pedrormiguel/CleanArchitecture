using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.Categories.Queries.GetCategoriesList;
using Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Http;
using Application.Features.Categories.Commands.CreateCategory;

namespace GlobalTicket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public CategoryController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet("all", Name = "GetAllCategories")]
        public async Task<ActionResult<List<CategoryListVm>>> Get()
        {
            var dto = await _mediatR.Send(new GetCategoryListQuery());

            return Ok(dto);
        }

        [HttpGet("allWithEvents", Name = "GetAllCategoriesWithEvents")]
        //[HttpGet("{includeHistory}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListWithEventsVm>>> GetCategoryEvents([FromQuery] bool includeHistory)
        {
            var output = await _mediatR.Send(new GetCategoryListWithEventsQuery() { IncludeHistory = includeHistory });

            return Ok(output);
        }

        [HttpPost("Add", Name = "AddCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CreateCategoryCommandResponse>> AddCategory([FromBody] CategoryCreateVm category)
        {
            var dto = await _mediatR.Send(new CreateCategoryCommand() { Name = category.Name });

            return Ok(dto);
        }
    }
}