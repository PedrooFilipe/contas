using contas_api_model.Entity;
using contas_api_model.Model;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace contas_api_test.IntegrationTest
{
    public class ContaIntegrationTest : IClassFixture<CustomWebApplicationFactory<StartupTest>>
    {
        private readonly WebApplicationFactory<StartupTest> _factory;

        public ContaIntegrationTest(CustomWebApplicationFactory<StartupTest> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Salvar_ContaCorreta_NaoDeveRetornarErros()
        {
            //Arrange
            Conta conta = new Conta { Id = 1, ValorTotal = 0, ValorRestante = 0, FormaPagamentoId = 1 };
            var client = _factory.CreateClient();
            var jsonContent = JsonConvert.SerializeObject(conta);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //contentString.Headers.Add("Session-Token", session_token);

            //Act
            var response = await client.PostAsync("/contas/salvar", contentString);
            var jsonString = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<RestResponse<Conta>>(jsonString.Replace("'\'", ""));

            //Assert
            Assert.Equal(200, data.ResponseCode);
        }
    }   
}
