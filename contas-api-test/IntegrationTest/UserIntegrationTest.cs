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
using contas_api_model.DTO;
using Xunit;

namespace contas_api_test.IntegrationTest
{
    public class UserIntegrationTest : IClassFixture<CustomWebApplicationFactory<StartupTest>>
    {

        private readonly WebApplicationFactory<StartupTest> _factory;
        private HttpClient _client;

        public UserIntegrationTest(CustomWebApplicationFactory<StartupTest> factory)
        {
            _factory = factory;
            // _client = _factory.CreateClient();
        }
        
        [Fact]
        public async Task Login_CorrectUser_NaoDeveRetornarErros()
        {
            //Arrange
            User user = new User { Email = "test@gmail.com", Name = "Testing", Password = "password", IsActive = true };
            var contentString = HelperTest.CreateContentString(user);

            //Act
            var response = await _client.PostAsync("/users/login", contentString);
            var data = await HelperTest.DeserializeObject<User>(response);

            //Assert
            Assert.Equal(200, data.ResponseCode);
        }

        [Fact]
        public async Task Save_UserWithoutRequiredFields_MustReturnOneValidationError()
        {
            //Arrange
            SaveUserDTO user = new SaveUserDTO{ Email = "test@gmail.com", Name = "Testing", Password = "password"};
            var client = _factory.CreateClient();
            var contentString = HelperTest.CreateContentString(user);

            //Act
            var response = await client.PostAsync("/users/save", contentString);
            var data = await HelperTest.DeserializeObject<User>(response);
            
            //Assert
            Assert.Equal(420, data.ResponseCode);
        }
    }
}
