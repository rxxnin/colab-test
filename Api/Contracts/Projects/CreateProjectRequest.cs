using System.ComponentModel.DataAnnotations;

namespace Api.Contracts.Projects;

public record CreateProjectRequest(
    [Required] string Name,
    [Required] string Description,
    [Required] string RequiredSkills);