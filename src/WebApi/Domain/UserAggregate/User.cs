using FaculOop.WebApi.Domain.UserAggregate.ValueObjects;

namespace FaculOop.WebApi.Domain.UserAggregate
{
    public class User
    {
        public User(Username username, Password password)
        {
            Username = username ?? throw new System.ArgumentNullException(nameof(username));
            Password = password ?? throw new System.ArgumentNullException(nameof(password));
        }

        public int Id { get; }
        public Username Username { get; private set; }
        public Password Password { get; private set; }

        public void Update(Username username, Password password)
        {
            Username = username ?? throw new System.ArgumentNullException(nameof(username));
            Password = password ?? Password;
        }
    }
}