using JunxtionTirana2.Data.Model.Projects;
using JunxtionTirana2.Model.ApplicationUsers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunxtionTirana2.Data.Model
{
    public interface IApplicationDBContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<UserProjectInterest> UserProjectInterests { get; set; }

    }
}
