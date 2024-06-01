
using JunxtionTirana2.JunxtionTirana2.Models;

namespace JunxtionTirana2.Services.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(Message msg);
    }
}
