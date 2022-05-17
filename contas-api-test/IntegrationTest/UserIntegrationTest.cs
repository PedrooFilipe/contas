using contas_api_model.Entity;
using contas_api_model.Model;
using Microsoft.AspNetCore.Mvc.Testing;
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
    public class UserIntegrationTest : IClassFixture<CustomWebApplicationFactory<StartupTest>>
    {

        private readonly WebApplicationFactory<StartupTest> _factory;

        public UserIntegrationTest(CustomWebApplicationFactory<StartupTest> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Salvar_ContaCorreta_NaoDeveRetornarErros()
        {
            //Arrange
            User user = new User { Email = "test@gmail.com", Name = "Testing", Password = "password", IsActive = true};
            var client = _factory.CreateClient();
            var jsonContent = JsonConvert.SerializeObject(user);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //Act
            var response = await client.PostAsync("/users/save", contentString);
            var jsonString = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<RestResponse<User>>(jsonString.Replace("'\'", ""));

            //Assert
            Assert.Equal(200, data.ResponseCode);
        }

        [Fact]
        public async Task Login_CorrectUser_NaoDeveRetornarErros()
        {
            //Arrange
            User user = new User { Email = "test@gmail.com", Name = "Testing", Password = "password", IsActive = true };
            var client = _factory.CreateClient();
            var jsonContent = JsonConvert.SerializeObject(user);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //Act
            var response = await client.PostAsync("/users/login", contentString);
            var jsonString = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<RestResponse<User>>(jsonString.Replace("'\'", ""));

            //Assert
            Assert.Equal(200, data.ResponseCode);
        }

    }
}
