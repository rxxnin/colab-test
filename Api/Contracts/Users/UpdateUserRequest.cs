using System.ComponentModel.DataAnnotations;

namespace Api.Contracts.Users;

    public record UpdateUserRequest(
        string Name,
        string Bio,
        string Skills);
