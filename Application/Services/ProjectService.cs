using Domain.Common.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository, IUserRepository userRepository)
    {
        _projectRepository = projectRepository;
    }

    public Task<List<Project>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Project?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<User> AddMember(Guid projectId, Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<Project> Add(Guid creatorId, string name, string description, string requiredSkills)
    {
        throw new NotImplementedException();
    }

    public Task Update(Guid id, Project project)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}