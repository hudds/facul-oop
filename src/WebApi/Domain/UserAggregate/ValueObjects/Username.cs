namespace FaculOop.WebApi.Domain.UserAggregate.ValueObjects
{
    public class Username
    {
        private Username() {}
        public Username(string value) : this()
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new System.ArgumentException($"'{nameof(value)}' não pode ser nulo ou ter espaço em branco", nameof(value));
            }

            Value = value;
        }

        public string Value { get; }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            
            if (obj is string value) return Value == value;
            
            if (!(obj is Username username)) return false;
            
            return Value == username.Value;
        }
    }
}