using System.Threading.Tasks;

namespace Repository.TaxaJuros
{
    public interface ITaxaJurosRepositorio
    {
        Task<decimal> BuscaTaxaJurosAsync();
    }
}