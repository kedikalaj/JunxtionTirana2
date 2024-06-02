using JunxtionTirana2.Model.ApplicationUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunxtionTirana2.Data.Model.Projects
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int TeamSize { get; set; }
        public List<string> Preferences { get; set; }
        public List<User> Members { get; set; }

    }
}
