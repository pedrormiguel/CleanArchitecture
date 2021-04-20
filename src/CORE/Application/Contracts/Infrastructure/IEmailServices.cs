using System.Threading.Tasks;
using Application.Models.Mail;

namespace Application.Contracts.Infrastructure
{
    public interface IEmailServices
    {
        Task<bool> SendEmail(Email email);
    }
}