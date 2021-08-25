
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Negocio.Juros;
using System.Threading.Tasks;

namespace Api.Controllers
{
    /// <summary>
    /// Controller para calculo de juros compostos
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : ControllerBase
    {                
        private readonly ILogger<CalculaJurosController> _logger;
        private readonly ITaxaJuros _taxaJuros;

        
        public CalculaJurosController(ILogger<CalculaJurosController> logger, ITaxaJuros taxaJuros)
        {
            _logger = logger;
            _taxaJuros = taxaJuros;
        }

        /// <summary>
        /// Método que calcula os juros compostos
        /// </summary>
        /// <param name="valor">Valor inicial a ser calculado</param>
        /// <param name="meses">quantidade de meses a calcular</param>
        /// <returns>valor total com o juros</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        public async Task<IActionResult> CalculoJurosAsync(decimal valor, int meses){
            return Ok(await _taxaJuros.CalcularJurosAsync(valor, meses));
        }

    }
}