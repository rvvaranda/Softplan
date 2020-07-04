using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Polly;
using Softplan.CalculaJuros.Api.Core.Interfaces;
using Softplan.CalculaJuros.Api.Core.Model;

namespace Softplan.CalculaJuros.Api.Core
{
    public class TaxaJuros: ITaxaJuros
    {
        public async Task<TaxaJurosResponse> RetornaTaxaDeJuros()
        {
            try
            {
                var httpClient = new HttpClient();

                var url = "http://taxajurosapi:5000/taxaJuros";

                var response = await Policy
                    .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                    .Or<TimeoutException>()
                    .WaitAndRetryAsync(4, retryAttempt =>
                        TimeSpan.FromSeconds(5))
                    .ExecuteAsync(() =>
                        httpClient.GetAsync(new Uri(url)));

                var taxaJurosResponse = new TaxaJurosResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    taxaJurosResponse = JsonConvert.DeserializeObject<TaxaJurosResponse>(json);

                    return taxaJurosResponse;

                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}