using Domain.Entities;

namespace Domain.Common.Interfaces;

public interface IProjectRepository
{
    Task<List<Project>> GetAll();
    Task<Project?> GetById(Guid id);
    Task<User> AddMember(Guid projectId, Guid userId);
    Task<Project> Add(Project project);
    Task<Project> Update(Project project);
    Task Delete(Guid id);
}