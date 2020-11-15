using System;
using FaculOop.WebApi.Domain.UserAggregate.ValueObjects;
using FluentAssertions;
using Xunit;

namespace FaculOop.WebApi.Tests
{
    public class UsernameTests
    {
        [Fact]
        public void DadoUmUsernameDevePoderConstruir()
        {
            var username = new Username("username");
            
            username.Should().NotBeNull();            
            username.Value.Should().Be("username");
        }

        [Fact]
        public void DadoUmUsernameQuandoForInvalidoDeveFalhar()
        {
            Func<Username> action = () => new Username(null);
            
            action.Should().Throw<ArgumentException>();
        }
    }
}
