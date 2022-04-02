using contas_api.Interfaces;
using contas_api_model;
using contas_api_model.Entity;
using contas_api_model.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace contas_api_test.UnitTest
{
    public class ContaUnitTest
    {
        Contexto _contexto;
        ContaRepository _contaRepository;

        public ContaUnitTest()
        {
            var options = new DbContextOptionsBuilder<Contexto>()
            .UseInMemoryDatabase(databaseName: "contaDatabase")
            .Options;

            _contexto = new Contexto(options);

            _contaRepository = new ContaRepository(_contexto);
        }

        [Fact]
        public void Alterar_ValidaSeValorPagoNaoEZero_RetornaUmErro()
        {
            //Arrange
            Conta conta = new Conta {Id = 1, ValorTotal = 0, ValorRestante = 0, FormaPagamentoId = 1 };

            //Act
            Action act = () => _contaRepository.VerifyIfCanUpdate(null);

            //Assert
            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("Erro ao alterar conta!", exception.Message);
        }
    }
}
