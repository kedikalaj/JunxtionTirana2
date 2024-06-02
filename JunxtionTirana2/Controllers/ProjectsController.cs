using JunxtionTirana2.Data.Model.Projects;
using JunxtionTirana2.Services.Interfaces;
using JunxtionTirana2.Services.Models.ProjectViewModels;
using Microsoft.AspNetCore.Mvc;

[Route("[Controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
    {
        var projects = await _projectService.GetProjectsAsync();
        return Ok(projects);
    }


    [HttpGet("GetProject/{id}")]
    public async Task<ActionResult<Project>> GetProject([FromQuery] Guid id)
    {
        var project = await _projectService.GetProjectByIdAsync(id);
        if (project == null)
        {
            return NotFound();
        }

        return Ok(project);
    }

    [HttpPost("CreateProject")]
    public async Task<ActionResult<Project>> CreateProject(CreateProjectViewModel viewModel)
    {
        var createdProject = await _projectService.CreateProjectAsync(viewModel);
        return CreatedAtAction(nameof(GetProject), new { id = createdProject.Id }, createdProject);

    }

    [HttpPost("AddUserInteresProject")]
    public async Task<ActionResult<UserProjectInterest>> AddUserProjectInterest(UserProjectInterestViewModel viewModel)
    {
        var createdInterest = await _projectService.AddUserProjectInterestAsync(viewModel);
        return CreatedAtAction(nameof(GetUserPreferredProjects), new { userId = createdInterest.UserId }, createdInterest);
    }

    [HttpGet("GetPreferedProject{userId}")]
    public async Task<ActionResult<IEnumerable<Project>>> GetUserPreferredProjects([FromQuery] GetUserProjectInterestViewModel model)
    {
        var preferredProjects = await _projectService.GetUserPreferredProjectsAsync(model);
        return Ok(preferredProjects);
    }
}
