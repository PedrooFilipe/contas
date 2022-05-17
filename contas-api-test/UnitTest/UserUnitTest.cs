using contas_api.Interfaces;
using contas_api_model;
using contas_api_model.Entity;
using contas_api_model.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using Xunit;

namespace contas_api_test.UnitTest
{
    public class UserUnitTest
    {
        Contexto _contexto;
        ContaRepository _contaRepository;

        public UserUnitTest()
        {
            var options = new DbContextOptionsBuilder<Contexto>()
            .UseInMemoryDatabase(databaseName: "contaDatabase")
            .Options;

            _contexto = new Contexto(options);

            _contaRepository = new ContaRepository(_contexto);
        }

        [Fact]
        public void Salvar_ValidaSeQuantidadeDeParcelasEstaZerada_DeveRetornarUmErro()
        {
            //Arrange
            User user = new User { Email = "test@gmail.com", Name = "Testing", Password = "password", IsActive = true };

            //Act
            Action act = () => _contaRepository.Login(user);

            //Assert
            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("User not found or inactive!", exception.Message);
        }
    }
}
