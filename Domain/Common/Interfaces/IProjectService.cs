using Domain.Entities;

namespace Domain.Common.Interfaces;

public interface IProjectService
{
    Task<List<Project>> GetAll();
    Task<Project?> GetById(Guid id);
    Task<User> AddMember(Guid projectId, Guid userId);
    Task<Project> Add(Guid creatorId, string name, string description, string requiredSkills);
    Task Update(Guid id, Project project);
    Task Delete(Guid id);
}