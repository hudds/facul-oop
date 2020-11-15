namespace FaculOop.WebApi.Domain.UserAggregate
{
    public class User
    {
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public int Id { get; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public void Update(string username, string password)
        {
            Username = username;
            Password = password ?? Password;
        }
    }
}