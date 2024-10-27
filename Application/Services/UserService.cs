using Domain.Common.Interfaces;
using Application.Interfaces.Auth;
using Domain.Entities;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;

        public UserService(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }
        
        public async Task<Guid> Register(string name, string email, string password, string bio, string skills)
        {
            var hashedPassword = _passwordHasher.Generate(password);
            
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                Bio = bio,
                Skills = skills,
                PasswordHash = hashedPassword
            };
            
            await _userRepository.Add(user);
            
            return user.Id;
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email) 
                       ?? throw new Exception("User not found.");

            if (!_passwordHasher.Verify(password, user.PasswordHash))
            {
                throw new Exception("Invalid password.");
            }

            var token = _jwtProvider.GenerateToken(user);

            return token;
        }
        
        public Task<Guid> Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }
        
        public async Task<User?> GetById(Guid id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _userRepository.GetByEmail(email);
        }

        public async Task<User> Update(Guid id, string name, string bio, string skills)
        {
            var user = new User
            {
                Name = name,
                Bio = bio,
                Skills = skills
            };
            
            return await _userRepository.Update(id, user);
        }

        public async Task Delete(Guid id)
        {
            await _userRepository.Delete(id);
        }
    }
}
