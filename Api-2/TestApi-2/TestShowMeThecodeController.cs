

using Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Xunit;

namespace TestApi_2
{
    public class TestShowMeThecodeController
    {
        IConfiguration _config;

        /// <summary>
        /// Criação das instancias necessarias para os testes
        /// </summary>
        public TestShowMeThecodeController()
        {
            var myAppSettings = new Dictionary<string, string>
                {
                    {"Services:GitHubProj", "https://github.com/lrauseo/SoftPlanTestDev"}
                };

            _config = new ConfigurationBuilder()
                .AddInMemoryCollection(myAppSettings)
                .Build();
        }

        [Fact]

        public void TestShowMeTheCodeStatusCode200()
        {
            var controller = new ShowMeTheCodeController(_config);
            ObjectResult result  = (ObjectResult)controller.ShowTheCode();
            Assert.True(result.StatusCode == 200, "Erro no retorno");            
        }
        [Fact]
        public void TestShowMeTheCodeUrl()
        {
            var controller = new ShowMeTheCodeController(_config);
            ObjectResult result = (ObjectResult)controller.ShowTheCode();            
            var resultado = (string)result.Value;
            Assert.True(resultado.ToLower().Contains("github"), "Nâo retornou uma url do github");

        }
    }
}
