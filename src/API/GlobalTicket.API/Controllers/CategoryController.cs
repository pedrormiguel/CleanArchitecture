using Microsoft.AspNetCore.Mvc;
using MediatR;

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
        
        
    }
}