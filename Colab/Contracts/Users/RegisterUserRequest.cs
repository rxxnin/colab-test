using System.ComponentModel.DataAnnotations;

namespace Api.Contracts.Users;
    public record RegisterUserRequest(
        [Required] string Name,
        [Required] string Email,
        [Required] string Password,
        [Required] string Bio,
        [Required] string Skills);