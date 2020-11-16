using FaculOop.WebApi.Domain.UserAggregate.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FaculOop.WebApi.Tests
{
    public class PasswordTests
    {
        [Fact]
        public void DadoUmaSenhaValidaDeveConstruir()
        {
            Password password = new Password("password");
            password.Should().NotBeNull();
        }

        [Fact]
        public void DadoUmaSenhaInvalidaNaoDeveConstruir()
        {
            Action action = () => { Password password = new Password(null); };
            action.Should().Throw<ArgumentException>();
            action = () => { Password password = new Password(""); };
            action.Should().Throw<ArgumentException>();
            action = () => { Password password = new Password(" "); };
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void DadoUmaSenhaDeveRetornarStringCorreta()
        {
            Password password = new Password("password");
            password.ToString().Should().Be("password");
        }

        [Fact]
        public void DadoDuasSenhasIguaisDeveRetornarVerdadeiro()
        {
            Password password = new Password("password");
            Password password2 = new Password("password");
            password.Equals(password2).Should().BeTrue();
        }

        [Fact]
        public void DadoDuasSenhasDiferentesDeveRetornarFalso()
        {
            Password password = new Password("password");
            Password password2 = new Password("password2");
            password.Equals(password2).Should().BeFalse();
        }

        [Fact]
        public void DadoDuasSenhasIguaisOsHashCodesDevemSerIguais()
        {
            Password password = new Password("password");
            Password password2 = new Password("password");
            password.GetHashCode().Should().Be(password2.GetHashCode());
        }

        [Fact]
        public void DadoDuasSenhasDiferentesOsHashCodesDevemSerDiferentes()
        {
            Password password = new Password("password");
            Password password2 = new Password("password2");
            password.GetHashCode().Should().NotBe(password2.GetHashCode());
        }

    }
}
