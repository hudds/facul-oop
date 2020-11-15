using System;
using FaculOop.WebApi.Domain.UserAggregate.ValueObjects;
using FluentAssertions;
using Xunit;

namespace FaculOop.WebApi.Tests
{
    public class PasswordTests
    {
        [Fact]
        public void DadoUmaSenhaDevePoderConstruir()
        {
            var password = new Password("password");
            
            password.Should().NotBeNull();            
            password.Value.Should().Be("password");
        }

        [Fact]
        public void DadoUmaSenhaQuandoForInvalidoDeveFalhar()
        {
            Func<Password> action = () => new Password(null);
            
            action.Should().Throw<ArgumentException>();
        }
    }
}
