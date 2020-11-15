using System;
using FaculOop.WebApi.Domain.UserAggregate;
using FaculOop.WebApi.Domain.UserAggregate.ValueObjects;
using FluentAssertions;
using Xunit;

namespace FaculOop.WebApi.Tests
{
    public class UserTests
    {
        [Fact]
        public void DadoUmUsuarioDevePoderConstruir()
        {
            var user = new User(new Username("username"), new Password("password"));
            user.Should().NotBeNull();
        }

        [Fact]
        public void DadoUmUsuarioQuandoNomeForInvalidoDeveFalhar()
        {
            Func<User> action = () => new User(null, new Password("password"));
            
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void DadoUmUsuarioQuandoAtualizarOsDadosDevePreencherNomeESenha()
        {
            var user = new User(new Username("username"), new Password("password"));

            user.Update(new Username("username_2"), new Password("password_2"));

            user.Username.Should().Be("username_2");
            user.Password.Should().Be("password_2");
        }

        [Fact]
        public void DadoUmUsuarioQuandoAtualizarOsDadosEONomeForInvalidoDeveFalhar()
        {
            var user = new User(new Username("username"), new Password("password"));

            Action action = () => user.Update(null, new Password("password_2"));

            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void DadoUmUsuarioQuandoAtualizarOsDadosEASenhaForNulaDeveManterASenhaAtual()
        {
            var user = new User(new Username("username"), new Password("password"));

            user.Update(new Username("username_2"), null);

            user.Username.Should().Be("username_2");
            user.Password.Should().Be("password");
        }
    }
}
