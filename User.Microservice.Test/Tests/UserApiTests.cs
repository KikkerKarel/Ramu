using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using User.Microservice.Repository;
using User.Microservice.Test.Stubs;
using Xunit;

namespace User.Microservice.Test.Tests
{
    public class UserApiTests : WebApplicationFactory<Program>
    {
        UserDALStub stub = new UserDALStub();
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IUserDAL, UserDALStub>();
            });

            return base.CreateHost(builder);
        }

        [Fact]
        public async void GetUsers_Passed()
        {
            // Arrange
            var webAppFactory = new UserApiTests();
            HttpClient httpClient = webAppFactory.CreateClient();
            stub.testValue = true;

            // Act
            var response = await httpClient.GetAsync("/users");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async void GetUserById_Passed()
        {
            // Arrange
            //UserModel user = new UserModel(;
            //user.Id = 6;
            var webAppFactory = new UserApiTests();
            HttpClient httpClient = webAppFactory.CreateClient();
            stub.testValue = true;

            //string json = "{ }";

            //StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            //Act
            var response = await httpClient.GetAsync("/user/6");

            //Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
