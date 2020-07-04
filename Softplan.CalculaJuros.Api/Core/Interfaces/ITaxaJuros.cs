using System.Threading.Tasks;
using Softplan.CalculaJuros.Api.Core.Model;

namespace Softplan.CalculaJuros.Api.Core.Interfaces
{
    public interface ITaxaJuros
    {
        Task<TaxaJurosResponse> RetornaTaxaDeJuros();
    }
}