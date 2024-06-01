
using JunxtionTirana2.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunxtionTirana2.Application.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(Message msg);
    }
}
