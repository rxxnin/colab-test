using System.ComponentModel.DataAnnotations;

namespace Api.Contracts.Users;

public record LoginUserRequest(
    [Required] string Email,
    [Required] string Password);