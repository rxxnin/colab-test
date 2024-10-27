using Domain.Entities;

namespace Domain.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User?> GetById(Guid id);
        Task<User?> GetByEmail(string email);
        Task<User> Add(User user);
        Task<User> Update(Guid id, User user);
        Task Delete(Guid id);
    }
}
