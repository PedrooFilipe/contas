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
using contas_api_model;
using contas_api_model.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace contas_api_test.IntegrationTest
{
    public class SessionIntegrationTest : IClassFixture<CustomWebApplicationFactory<StartupTest>>
    {

        private readonly WebApplicationFactory<StartupTest> _factory;
        private HttpClient _client;

        public SessionIntegrationTest(CustomWebApplicationFactory<StartupTest> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }
        
        [Fact]
        public async Task Login_CorrectUser_MustPassWithoutThrowExceptions()
        {
            //Arrange
            var context = _factory.Server.Services.GetService<Contexto>();

            User user = new User { Email = "test@gmail.com", Name = "Testing", Password = "password", IsActive = true };
            
            var test = await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            
            var contentString = HelperTest.CreateContentString(user);

            //Act
            var response = await _client.PostAsync("/session/login", contentString);
            var data = await HelperTest.DeserializeObject<User>(response);

            //Assert
            Assert.Equal(200, data.ResponseCode);
        }
    }
}
