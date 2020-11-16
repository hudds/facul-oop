using FaculOop.WebApi.Domain.UserAggregate.ValueObjects;
using FluentAssertions;
using System;
using Xunit;

namespace FaculOop.WebApi.Tests
{
    public class UsernameTests
    {
        [Fact]
        public void DadoUmNomeDeUsuarioValidoDeveConstruir()
        {
            Username username = new Username("username");
            username.Should().NotBeNull();
        }

        [Fact]
        public void DadoUmNomeDeUsuarioInvalidoNaoDeveConstruir()
        {
            Action action = () => { Username username = new Username(null); };
            action.Should().Throw<ArgumentException>();

            action = () => { Username username = new Username(""); };
            action.Should().Throw<ArgumentException>();

            action = () => { Username username = new Username(" "); };
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void DadoUmNomeDeUsuarioDeveRetornarStringCorreta()
        {
            Username username = new Username("username");
            username.ToString().Should().Be("username");
        }

        [Fact]
        public void DadoDoisNomesDeUsuarioIguaisDeveRetornarVerdadeiro()
        {
            Username username = new Username("username");
            Username username2 = new Username("username");
            username.Equals(username2).Should().Be(true);
        }

        [Fact]
        public void DadoDoisNomesDeUsuarioDiferentesDeveRetornarFalso()
        {
            Username username = new Username("username");
            Username username2 = new Username("username2");
            username.Equals(username2).Should().Be(false);
        }

        [Fact]
        public void DadoDoisNomesDeUsuarioIguaisOsHashCodesDevemSerIguais()
        {
            Username username = new Username("username");
            Username username2 = new Username("username");
            username.GetHashCode().Equals(username2.GetHashCode()).Should().Be(true);
        }

        [Fact]
        public void DadoDoisNomesDeUsuarioDiferentesOsHashCodesDevemSerDiferentes()
        {
            Username username = new Username("username");
            Username username2 = new Username("username2");
            username.GetHashCode().Equals(username2.GetHashCode()).Should().Be(false);
        }

    }
}
