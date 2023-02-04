using contas_api_model;
using contas_api_model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using contas_api_model.Repository;
using Xunit;
using contas_api_model.Interfaces.Service;
using Moq;
using contas_api_model.Interfaces;
using contas_api_model.Services;

namespace contas_api_test.UnitTest
{
    public class ContaUnitTest
    {

        private BillService _billService;
        private Mock<IBillRepository> _billRepository;

        public ContaUnitTest()
        {
            _billService = new BillService(_billRepository.Object);
        }

        [Fact]
        public void Salvar_ValidaSeQuantidadeDeParcelasEstaZerada_DeveRetornarUmErro()
        {
            ////Arrange
            //Bill conta = new Bill {Id = 1, TotalAmount = 150, RemainingAmount = 150, TypePaymentId = 2 };
            

            ////Act
            //Action act = () => _billService.VerificaSeNumeroDeParcelasEstaZerado(conta);

            ////Assert
            //Exception exception = Assert.Throws<Exception>(act);
            //Assert.Equal("Não é possível salvar uma conta parcelada com o número de parcelas zerado!", exception.Message);
        }

        [Fact]
        public void Salvar_ValidaSeDataDeVencimentoEMaiorQueDataAtual_DeveRetornarUmErro()
        {
            ////Arrange
            //DateTime dataDeValidade = DateTime.UtcNow.AddDays(5);
            //Bill conta = new Bill { Id = 1, ValorTotal = 150, ValorRestante = 150, DataValidade = dataDeValidade, FormaPagamentoId = 2 };

            ////Act
            //Action act = () => _billRepository.VerificaDataDeValidade(conta);

            ////Assert
            //Exception exception = Assert.Throws<Exception>(act);
            //Assert.Equal("Não é possível salvar uma conta com a data de vencimento maior que a data de hoje!", exception.Message);
        }
    }
}
