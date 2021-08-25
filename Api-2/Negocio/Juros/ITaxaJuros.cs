using System.Threading.Tasks;

namespace Negocio.Juros
{
    public interface ITaxaJuros
    {
        Task<string> CalcularJurosAsync(decimal valor, int meses);
    }
}