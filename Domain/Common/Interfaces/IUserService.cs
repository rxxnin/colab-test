using Domain.Entities;

namespace Domain.Common.Interfaces
{
    public interface IUserService
    {
        Task<Guid> Register(string name, string email, string password, string bio, string skills);
        Task<string> Login(string email, string password);
        Task<Guid> Logout();
        Task<List<User>> GetAll();
        Task<User?> GetById(Guid id);
        Task<User?> GetByEmail(string email);
        Task<User> Update(Guid id, string name, string bio, string skills);
        Task Delete(Guid id);
    }
}
