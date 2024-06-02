using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunxtionTirana2.Data.Model.Projects
{
    public class UserProjectInterest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
        public bool IsInterested { get; set; }

        public Project Project { get; set; }
    }
}
