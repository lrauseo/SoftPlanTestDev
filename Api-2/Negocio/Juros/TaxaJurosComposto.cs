using Microsoft.Extensions.Configuration;
using Repository.TaxaJuros;
using System;
using System.Threading.Tasks;

namespace Negocio.Juros
{
    public class TaxaJurosComposto : ITaxaJuros
    {

        private readonly ITaxaJurosRepositorio _taxaJurosRepositorio;

        public TaxaJurosComposto(ITaxaJurosRepositorio taxaJurosRepositorio)
        {
            //_config = config;
            _taxaJurosRepositorio = taxaJurosRepositorio;
        }
        public async Task<string> CalcularJurosAsync(decimal valor, int meses)
        {

            double percentual = Decimal.ToDouble(await _taxaJurosRepositorio.BuscaTaxaJurosAsync()) + 1;
            double valorInicial = Decimal.ToDouble(valor);
            double valorFinal = (valorInicial * Math.Pow(percentual, meses));
            valorFinal = Math.Truncate(valorFinal * 100) / 100;
            return valorFinal.ToString("N2");
            
        }
    }
}