using JunxtionTirana2.Data.Model.Projects;
using JunxtionTirana2.Services.Models.ProjectViewModels;


namespace JunxtionTirana2.Services.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetProjectsAsync();
        Task<Project> GetProjectByIdAsync(Guid id);
        Task<Project> CreateProjectAsync(CreateProjectViewModel viewModel);
        Task<UserProjectInterest> AddUserProjectInterestAsync(UserProjectInterestViewModel viewModel);
        Task<IEnumerable<Project>> GetUserPreferredProjectsAsync(GetUserProjectInterestViewModel model);

    }

}
