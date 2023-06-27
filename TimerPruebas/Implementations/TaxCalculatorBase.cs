using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerPruebas.Abstractions;

namespace TimerPruebas.Implementations
{

    public abstract class TaxCalculatorBase : ITasaCalculator
    {
        public event TaxCalculationReportReadyEventHandler TaxCalculationReportReady;

        public abstract double CalculateTaxPerMonth(double monthlyIncome);

        protected void OnTaxCalculationReportReady(string report)
        {
            TaxCalculationReportReady?.Invoke(this, report);
        }
    }
}
//Lo que podemos notar aquí:

//Definimos la nueva clase base TaxCalculatorBasepara todas ITaxCalculatorslas implementaciones.
//Esta clase proporcionaría una implementación común del OnTaxCalculationReportReadymétodo 
//    protegido que es responsable de la activación interna del TaxCalculationReportReadyevento. Esta es una de las mejores prácticas recomendadas por Microsoft.