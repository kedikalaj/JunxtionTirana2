using JunxtionTirana2.Model.ApplicationUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunxtionTirana2.Services.Models.ProjectViewModels
{
    public class CreateProjectViewModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int TeamSize { get; set; }
        public List<string> Interests { get; set; }
        public List<CreateUserViewModel> Members { get; set; }
    }
    public class CreateUserViewModel
    {
        public string Username { get; set; }
        public int AvatarId { get; set; }
        public string Education { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public List<string> Skills { get; set; }
    }
    public class UserProjectInterestViewModel
    {
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
        public bool IsInterested { get; set; }
    }
    public class GetUserProjectInterestViewModel
    {
        public Guid UserId { get; set; }
        public bool IsInterested { get; set; }
    }
}
