using Application.Responses;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreateCategoryCommandResponse() : base()
        {
            
        }

        public CategoryCreateVm CategoryCreateVm { get; set; }
    }
}