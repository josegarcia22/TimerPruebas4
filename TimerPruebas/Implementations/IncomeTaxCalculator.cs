using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerPruebas.Abstractions;

namespace TimerPruebas.Implementations
{
    public class IncomeTaxCalculator : TaxCalculatorBase
    {
        private readonly ILogger m_Logger;

        public IncomeTaxCalculator(ILogger logger)
        {
            m_Logger = logger;
        }

        public override double CalculateTaxPerMonth(double monthlyIncome)//antes sin override porque la clase no era abstract (TaxCalculatorBase )
        {
            // Do some interesting calculations
            var tax = monthlyIncome * 0.5;

            // Don't forget to log the message
            m_Logger.LogMessage($"Calculated Income Tax per month for Monthly Income: {monthlyIncome} equals {tax}");

            return tax;
        }

    }
}

//Lo que podemos notar aquí:

//Ahora la IncomeTaxCalculator clase extiende la TaxCalculatorBase clase en lugar de la ITaxCalculatorinterfaz.
//Ya no depende de la ILoggerinterfaz como solía ser en la implementación anterior.
//Ahora, cada vez que necesita informar un mensaje, 
//activa el TaxCalculationReportReadyevento en lugar de utilizar directamente una instancia de la ILoggerinterfaz.


//This is an IncomeTaxCalculator class implementing ITaxCalculator.
//It depends on the ILogger to be able to log some important messages about the calculations.
//That’s why the ILogger is injected into the constructor.
//In the CalculateTaxPerMonth method implementation, we just do the calculations and log the message using the injected ILogger.