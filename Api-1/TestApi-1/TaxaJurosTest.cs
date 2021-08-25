using Negocio.TaxaJuros;
using System;
using Xunit;

namespace TestApi_1
{
    public class TaxaJurosTest
    {
        [Fact]
        public void TestTaxaJurosAtualReturnTrue()
        {
            ITaxaJuros taxaJuros = new TaxaJurosSimples();
            decimal resultado = taxaJuros.TaxaJurosAtual();
            Assert.True(resultado > 0, "Taxa juros deve ser maior do Que Zero(resultado > 0)");
        }        
    }
}
