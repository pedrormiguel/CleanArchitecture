using System.Collections.Generic;

namespace Application.Responses
{
    public class BaseResponse
    {
        BaseResponse()
        {
            Succes = true;
        }

        BaseResponse(string message = null)
        {
            Succes = true;
            Message = message;
        }
        
        BaseResponse(string message, bool succes)
        {
            Succes = succes;
            Message = message;
        }

        public bool Succes { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}