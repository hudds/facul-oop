using System.Collections.Generic;
using System.Linq;
using FaculOop.WebApi.Domain.Shared.Exceptions;
using FaculOop.WebApi.Domain.UserAggregate;
using FaculOop.WebApi.Domain.UserAggregate.Repositories;
using FaculOop.WebApi.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace FaculOop.WebApi.Infrastructure.UserAggregate.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> _users;
        private readonly EFContext _context;

        public UserRepository(EFContext context)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
            _users = context.Set<User>();
        }

        public int Create(User user)
        {
            _users.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public IReadOnlyCollection<User> GetAll()
        {
            return _users.ToList();
        }

        public User GetById(int userId)
        {
            var user = _users.Find(userId);
            if (user == null) throw new NotFoundException("O usuário não foi encontrado.");
            return user;
        }

        public void Remove(User user)
        {
            _users.Remove(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _users.Update(user);
            _context.SaveChanges();
        }
    }
}