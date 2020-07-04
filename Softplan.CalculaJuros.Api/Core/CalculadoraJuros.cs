using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Softplan.CalculaJuros.Api.Core.Interfaces;

namespace Softplan.CalculaJuros.Api.Core
{
    public class CalculadoraJuros : ICalculadoraJuros
    {
        private readonly ITaxaJuros _taxaJuros;
        
        public CalculadoraJuros(ITaxaJuros taxaJuros)
        {
            _taxaJuros = taxaJuros;
        }
        
        public async Task<double> ExecutaCalculoJuros(decimal valorInicial, int meses)
        {
            try
            {
                var taxaJuros = await _taxaJuros.RetornaTaxaDeJuros();

                if (taxaJuros == null) return 0.00f;

                var taxa = 1 + Convert.ToDouble(taxaJuros.Taxa);
                var valor = Math.Truncate((Convert.ToDouble(valorInicial) * Math.Pow(taxa, meses)) * 100);

                return (valor / 100);
            }
            catch (Exception ex)
            {
                return 0.00f;
            }
        }
    }
}