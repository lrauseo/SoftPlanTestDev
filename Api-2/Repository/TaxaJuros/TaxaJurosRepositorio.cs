using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Repository.TaxaJuros
{
    public class TaxaJurosRepositorio : ITaxaJurosRepositorio
    {
        private readonly IConfiguration _config;

        public TaxaJurosRepositorio(IConfiguration config)
        {
            _config = config;
        }
        

        public async Task<decimal> BuscaTaxaJurosAsync()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            var client = new HttpClient(handler);
            var response = await client.GetAsync(_config["Services:TaxaJuros"]);
            return JsonConvert.DeserializeObject<decimal>( await response.Content.ReadAsStringAsync());
            
        }
    }
}