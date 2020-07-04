using System.Threading.Tasks;

namespace Softplan.CalculaJuros.Api.Core.Interfaces
{
    public interface ICalculadoraJuros
    { 
        Task<double> ExecutaCalculoJuros(decimal valorInicial, int meses);
    }
}