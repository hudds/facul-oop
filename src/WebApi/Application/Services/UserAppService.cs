using System.Collections.Generic;
using FaculOop.WebApi.Application.Contracts;
using FaculOop.WebApi.Domain.UserAggregate;
using FaculOop.WebApi.Domain.UserAggregate.Repositories;
using FaculOop.WebApi.Domain.UserAggregate.ValueObjects;

namespace FaculOop.WebApi.Application.Services
{
    public class UserAppService
    {
        private readonly IUserRepository _userRepository;

        public UserAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new System.ArgumentNullException(nameof(userRepository));
        }

        public int Create(CreateUserDTO createUser)
        {
            var user = new User(new Username(createUser.Username), new Password(createUser.Password));
            return _userRepository.Create(user);
        }

        public void Update(int userId, UpdateUserDTO updateUser)
        {
            var user = _userRepository.GetById(userId);
            user.Update(new Username(updateUser.Username), new Password(updateUser.Password));
            _userRepository.Update(user);
        }

        public void RemoveById(int userId)
        {
            var user = _userRepository.GetById(userId);
            _userRepository.Remove(user);
        }

        public User GetById(int userId)
        {
            return _userRepository.GetById(userId);
        }

        public IReadOnlyCollection<User> GetAll()
        {
            return _userRepository.GetAll();            
        }
    }
}