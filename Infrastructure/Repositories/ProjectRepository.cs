using Domain.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly ApplicationDbContext _context;

    public ProjectRepository(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }
    
    public async Task<List<Project>> GetAll()
    {
        return await _context.Projects
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Project?> GetById(Guid id)
    {
        var project = await _context.Projects
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
        
        if (project == null)
        {
            throw new KeyNotFoundException($"Project with ID {id} was not found.");
        }
        
        return project;
    }

    public async Task<User> AddMember(Guid projectId, Guid userId)
    {
        var project = await _context.Projects
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == projectId);
        
        var user = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == userId);

        if (project != null && user != null)
        {
            project.Members.Add(user);
            user.JoinedProjects.Add(project);
        }
        
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<Project> Add(Project project)
    {
        await _context.AddAsync(project);
        await _context.SaveChangesAsync();
        
        return project;
    }

    public async Task<Project> Update(Project project)
    {
        await _context.Projects
            .Where(p => p.Id == project.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Name, project.Name)
                .SetProperty(c => c.Description, project.Description)
                .SetProperty(c => c.RequiredSkills, project.RequiredSkills));
    
        return project;
    }

    public async Task Delete(Guid id)
    {
        await _context.Projects
            .Where(p => p.Id == id)
            .ExecuteDeleteAsync();
    }
}