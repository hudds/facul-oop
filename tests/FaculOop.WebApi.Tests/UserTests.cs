using FaculOop.WebApi.Domain.UserAggregate;
using FaculOop.WebApi.Domain.UserAggregate.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FaculOop.WebApi.Tests
{
    public class UserTests
    {
        private const string DefaultUsername = "username";
        private const string DefaultPassword = "password";

        [Fact]
        public void DadoUmUsuarioDeveContruir()
        {
            User user = GetDefaultUser();
            user.Should().NotBeNull();
        }

        [Fact]
        public void DadoUmUsuarioQuandoSenhaForNulaNaoDeveContruir()
        {
            Username username = new Username("username");
            Action action = () =>{ 
                new User(username, null); 
            };
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void DadoUmUsuarioQuandoNomeDeUsuarioForNuloNaoDeveContruir()
        {
            Password password = new Password("password");
            Action action = () => { 
                new User(null, password); 
            };
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void DadoUmUsuarioQuandoSenhaENomeDeUsuarioForemNulosNaoDeveContruir()
        {
            Action action = () => { 
                new User(null, null); 
            };
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void DadoUmUsuarioQuandoNomeDeUsuarioForNuloNaoDevePreencher()
        {
            Action action = () =>
            {
                User user = GetDefaultUser();
                Password password = new Password("password2");
                user.Update(null, password);

            };
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void DadoUmUsuarioQuandoSenhaForNulaDevePreencherApenasNomeDeUsuario()
        {
            User user = GetDefaultUser();
            Username username = new Username("username2");
            Password password = user.Password;
            user.Update(username, null);
            user.Username.Should().Be(username);
            user.Password.Should().Be(password);
        }

        [Fact]
        public void DadoUmUsuarioDevePreencherNomeESenha()
        {
            User user = GetDefaultUser();
            Username username = new Username("username2");
            Password password = new Password("password2");
            user.Update(username, password);
            user.Username.Should().Be(username);
            user.Password.Should().Be(password);
        }

        private User GetDefaultUser()
        {
            Username username = new Username(DefaultUsername);
            Password password = new Password(DefaultPassword);
            return new User(username, password);
        }

    }
}
