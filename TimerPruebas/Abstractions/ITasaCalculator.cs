using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerPruebas.Abstractions
{

    //public interface ITaxCalculator
    //{
    //    double CalculateTaxPerMonth(double monthlyIncome);
    //}//Lo que podemos notar aquí:

    //Esta es la interfaz ITaxCalculator.
    //Representa todas las calculadoras de impuestos que podríamos tener en la solución.
    //Define solo un método con el encabezado double CalculateTaxPerMonth(double monthlyIncome);.
    //-----------
    public delegate void TaxCalculationReportReadyEventHandler(object sender, string report);

    public interface ITasaCalculator
    {
        event TaxCalculationReportReadyEventHandler TaxCalculationReportReady;
        double CalculateTaxPerMonth(double monthlyIncome);
    }


}

//Lo que podemos notar aquí:

//Aplicamos un cambio a la ITaxCalculatorinterfaz.
//Definimos un delegado de tipo TaxCalculationReportReadyEventHandler.
//Definimos un nuevo miembro en la interfaz como un evento de tipo TaxCalculationReportReadyEventHandler.
//Este evento se usaría para enviar mensajes
//    a cualquier suscriptor cada vez que un mensaje de registro esté listo desde cualquier Calculadora de impuestos.
