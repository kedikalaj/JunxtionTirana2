using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunxtionTirana2.Services.Models.LoginViewModel
{
    public class RegisterViewModel
    {
        public string? Username { get; set; }
        public int AvatarId { get; set; }
        public string? Education { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? Description { get; set; }
        public List<string>? Skills { get; set; }
    }
    public class LoginViewModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
