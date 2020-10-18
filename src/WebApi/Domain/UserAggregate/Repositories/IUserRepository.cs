using System.Collections.Generic;

namespace FaculOop.WebApi.Domain.UserAggregate.Repositories
{
    public interface IUserRepository
    {
        int Create(User user);
        void Update(User user);
        void Remove(User user);
        User GetById(int userId);
        IReadOnlyCollection<User> GetAll();
    }
}