using JunxtionTirana2.Data.Model.Projects;
using JunxtionTirana2.Model;
using JunxtionTirana2.Model.ApplicationUsers;
using JunxtionTirana2.Services.Interfaces;
using JunxtionTirana2.Services.Models.ProjectViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunxtionTirana2.Services.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDBContext _context;

        public ProjectService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await _context.Projects
                .Include(p => p.Members)
                .ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(Guid id)
        {
            return await _context.Projects
                .Include(p => p.Members)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Project> CreateProjectAsync(CreateProjectViewModel viewModel)
        {
            var project = new Project
            {
                Name = viewModel.Name,
                Date = viewModel.Date,
                Description = viewModel.Description,
                TeamSize = viewModel.TeamSize,
                Preferences = viewModel.Interests,
                Members = viewModel.Members.Select(m => new User
                {
                    UserName = m.Username,
                    AvatarId = m.AvatarId,
                    Education = m.Education,
                    Email = m.Email,
                    Description = m.Description,
                    Skills = m.Skills
                }).ToList(),
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }
        public async Task<UserProjectInterest> AddUserProjectInterestAsync(UserProjectInterestViewModel viewModel)
        {
            var userProjectInterest = new UserProjectInterest
            {
                UserId = viewModel.UserId,
                ProjectId = viewModel.ProjectId,
                IsInterested = viewModel.IsInterested
            };

            _context.UserProjectInterests.Add(userProjectInterest);
            await _context.SaveChangesAsync();
            return userProjectInterest;
        }

        public async Task<IEnumerable<Project>> GetUserPreferredProjectsAsync(GetUserProjectInterestViewModel model)
        {
            var preferredProjectIds = await _context.UserProjectInterests.Include(x => x.Project)
                .Where(upi => upi.UserId == model.UserId && upi.IsInterested == model.IsInterested)
                .Select(upi => upi.ProjectId)
                .ToListAsync();

            return await _context.Projects
                .Where(p => preferredProjectIds.Contains(p.Id))
                .ToListAsync();
        }
    }

}
