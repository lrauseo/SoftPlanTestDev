using Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Negocio.Juros;
using Repository.TaxaJuros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestApi_2
{
    public class TestCalculoJuros
    {
        IConfiguration _config;
        ILogger<CalculaJurosController> _logger;
        ITaxaJuros _taxaJuros;
        ITaxaJurosRepositorio repository;

        /// <summary>
        /// Criação das instancias necessarias para os testes
        /// </summary>
        public TestCalculoJuros()
        {
            var myAppSettings = new Dictionary<string, string>
                {
                    {"Services:TaxaJuros", "http://localhost:8080/TaxaJuros"}

                };

            _config = new ConfigurationBuilder()
                .AddInMemoryCollection(myAppSettings)
                .Build();

            var mock = new Mock<ILogger<CalculaJurosController>>();
            ILogger<CalculaJurosController> logger = mock.Object;

            //or use this short equivalent 
            _logger = Mock.Of<ILogger<CalculaJurosController>>();
            repository = new TaxaJurosRepositorio(_config);
            _taxaJuros = new TaxaJurosComposto(repository);
        }

        [Fact]
        public async Task TesteCalculoJurosConexaoWSAsync()
        {

            var controller = new CalculaJurosController(_logger, _taxaJuros);
            ObjectResult result = (ObjectResult)await controller.CalculoJurosAsync(100, 5);
            Assert.NotNull(result);


        }

        [Fact]
        public async Task TesteCalculoJuroMaiorZero()
        {
            var controller = new CalculaJurosController(_logger, _taxaJuros);
            ObjectResult result = (ObjectResult)await controller.CalculoJurosAsync(100, 5);
            double resultado = double.Parse((string)result.Value);
            Assert.True(resultado > 0, "Calculo não retornou maior que zero");
        }
    }
}
