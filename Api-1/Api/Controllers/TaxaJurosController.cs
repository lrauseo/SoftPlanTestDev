using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Negocio.TaxaJuros;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    /// <summary>
    /// API para consulta da taxa de juros
    /// </summary>
    public class TaxaJurosController : ControllerBase
    {
        private readonly ILogger<TaxaJurosController> _logger;
        private readonly ITaxaJuros _taxaJuros;

        public TaxaJurosController(ILogger<TaxaJurosController> logger, ITaxaJuros taxaJuros)
        {
            _logger = logger;
            _taxaJuros = taxaJuros;
        }

        /// <summary>
        /// Método de busca da taxa de juros atual
        /// </summary>
        /// <returns>Valor Decimal do percentual de juros</returns>
        /// <response code="200">Requisicao Ok</response>        
        [HttpGet]
        public IActionResult BuscarTaxaJurosAtual(){
            return Ok(this._taxaJuros.TaxaJurosAtual());
        }
    }
}
