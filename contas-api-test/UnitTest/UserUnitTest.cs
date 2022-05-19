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
            Conta conta = new Conta {Id = 1, ValorTotal = 150, ValorRestante = 150, FormaPagamentoId = 2 };

            //Act
            Action act = () => _contaRepository.VerificaSeNumeroDeParcelasEstaZerado(conta);

            //Assert
            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("Não é possível salvar uma conta parcelada com o número de parcelas zerado!", exception.Message);
        }
        
    }
}
