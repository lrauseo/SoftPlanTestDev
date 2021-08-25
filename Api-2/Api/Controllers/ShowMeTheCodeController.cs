using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    /// <summary>
    /// controler para exibir o endereço do projeto no github
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ShowMeTheCodeController :ControllerBase
    {
        private readonly IConfiguration _config;

        public ShowMeTheCodeController(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Método que exibe a url do github com o projeto
        /// </summary>
        /// <returns> url </returns>
        /// <response code="200">sucesso</response>
        [HttpGet]
        public IActionResult ShowTheCode()
        {
            return Ok(_config["Services:GitHubProj"]);
        }
    }
}
