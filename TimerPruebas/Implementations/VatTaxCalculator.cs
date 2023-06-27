using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerPruebas.Abstractions;

namespace TimerPruebas.Implementations
{
    public class VatTaxCalculator : TaxCalculatorBase // ITasaCalculator
    {
        private readonly ILogger m_Logger;

     

        public VatTaxCalculator(ILogger logger)
        {
            m_Logger = logger;
        }

        public override  double CalculateTaxPerMonth(double monthlyIncome) //+override
        {
            var tax = 0.0;

            // Do some complex calculations on more than one step

            // Step1
            tax += monthlyIncome * 0.0012;
            m_Logger.LogMessage($"VAT Calculation Step 1, Factor: {monthlyIncome * 0.0012}, Total: {tax}");

            // Step2
            tax += monthlyIncome * 0.003;
            m_Logger.LogMessage($"VAT Calculation Step 2, Factor: {monthlyIncome * 0.003}, Total: {tax}");

            // Step3
            tax += monthlyIncome * 0.00005;
            m_Logger.LogMessage($"VAT Calculation Step 3, Factor: {monthlyIncome * 0.00005}, Total: {tax}");

            // Don't forget to log the final message
            m_Logger.LogMessage($"Calculated Vat Tax per month for Monthly Income: {monthlyIncome} equals {tax}");

            return tax;
        }
    }
}
//Lo que podemos notar aquí:

//Esta es una clase de VatTaxCalculator que implementa ITaxCalculator.
//Depende de ILogger poder registrar algunos mensajes importantes sobre los cálculos.
//Es por eso que el ILogger se inyecta en el constructor.
//En la implementación del método CalculateTaxPerMonth,
//solo hacemos los cálculos y registramos el mensaje usando el ILogger inyectado.
//La diferencia aquí es que los cálculos son más complejos,
//se necesitan 3 pasos para completar los cálculos y para cada paso necesitamos registrar información importante.


//El mismo tipo de cambios que en IncomeTaxCalculatorclase.