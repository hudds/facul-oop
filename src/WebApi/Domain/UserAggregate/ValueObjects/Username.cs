using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaculOop.WebApi.Domain.UserAggregate.ValueObjects
{
    public class Username
    {
        public string Value { get; }

        public Username(string username)
        {
            Validate(username);
            Value = username;
        }

        private void Validate(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException($"'{nameof(username)}' não pode ser nulo ou ter espaço em branco", nameof(username));
            }
        }


        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object obj)
        {
            return obj is Username username &&
                   Value == username.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
