namespace Negocio.TaxaJuros
{
    public class TaxaJurosSimples : ITaxaJuros
    {
        public decimal TaxaJurosAtual()
        {
            return 1.00M/100;
        }
    }
}