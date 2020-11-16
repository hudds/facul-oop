using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaculOop.WebApi.Domain.UserAggregate.ValueObjects
{
    public class Password
    {

        public string Value { get; }

        public Password(string password)
        {
            ValidateValue(password);

            this.Value = password;
        }

        private void ValidateValue(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException($"'{nameof(password)}' não pode ser nulo ou ter espaço em branco", nameof(password));
            }
        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object obj)
        {
            return obj is Password password &&
                   Value == password.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
}
