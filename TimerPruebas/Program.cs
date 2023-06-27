using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TimerPruebas.Abstractions;
using TimerPruebas.Implementations;
//4 Probando ...por Ahmed Tarek

namespace TimerPruebas
{
    class Program
    {
        private static ILogger Logger;
        private static Autofac.IContainer Container;

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsolaLogger>().As<ILogger>();
            builder.RegisterType<IncomeTaxCalculator>().As<ITasaCalculator>();
            builder.RegisterType<VatTaxCalculator>().As<ITasaCalculator>();
            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                Logger = scope.Resolve<ILogger>();
                var taxCalculators = scope.Resolve<IEnumerable<ITasaCalculator>>();
                var monthlyIncome = 2000.0;
                var totalTax = 0.0;

                foreach (var taxCalculator in taxCalculators)
                {
                    taxCalculator.TaxCalculationReportReady += (sender, report) => LogTaxReport(report);
                    totalTax += taxCalculator.CalculateTaxPerMonth(monthlyIncome);
                }

                Logger.LogMessage($"Total Tax for Monthly Income: {monthlyIncome} equals {totalTax}");
            }

            Console.ReadLine();
        }

        private static void LogTaxReport(string report)
        {
            Logger.LogMessage(report);
        }
    }

}

//Lo que podemos notar aquí:

//El cambio principal aquí es suscribirse al TaxCalculationReportReadyevento
//    para cada ITaxCalculatorimplementación de interfaz.
//Y manejar esto en un LogTaxReportmétodo centralizado.
//Ahora, el conocimiento sobre la necesidad de los cálculos y registros de impuestos reside en el lugar correcto.
//Ahora podemos controlar fácilmente los diferentes módulos de la solución, recopilar toda la información requerida,
//tomar decisiones colectivas,...
//Simplemente, déjate llevar, puedes hacer lo que quieras.
//---------------------------------------------------------
//Entonces, ahora tenemos el mismo resultado pero con un diseño diferente y capacidades extendidas.

//Now, we can easily adapt the design to add new features as we wished for in the “What If” section above, easy and clean…

//-------------------------------------------------------------------
//At the end, I want to stress something — in the software world,
//    you keep growing day by day and you should always keep your eyes focused on what to learn next.
//    It is never too late to learn.<---- thanks por los animos!!!!!!!1

//Finally, hope you found reading this story as interesting as I found writing it.


//¿Cómo hacerlo bien?
//Con algunos cambios simples en el diseño, podemos hacerlo realidad. Entonces, profundicemos en el código.

////OTROS

//What we can notice here:

//This is the Program class. It is the main entry point to the whole application,
//    which is, by the way, a C# Console Application.
//We are using AutoFac IoC Container, so you will need to install it from the Nuget package manager.
//In the Main method, the first thing we are doing is that we are initializing the IoC container, 
//defining our abstractions-implementations pairs, and creating our IoC container scope.
//Inside the scope, we are resolving an instance of the ILogger,
//and a list of all available ITaxCalculator implementations.
//Then we are using all the Tax Calculators to get the sum of all combined Taxes.
//And finally logging a message.

//Autofac is an IoC container for Microsoft .NET. 
//    It manages the dependencies between classes 
//    so that applications stay easy to change as they grow in size and complexity.


//-----------------

//Great, the application is working as expected, we have defined our dependencies,
//    we are using DI, IoC, and IoC Containers… perfect.

//Ok, you might find this perfect and easy to read and understand. However,
//what if you have too many modules, too many loggers, too many calculators,…

//--------------------


//What If?
//you want to control the whole bandwidth of the logging process? The count of lines to be logged every one hour?
//you want to migrate your design to microservices?
//the logging service is down and you want to keep track of the missed logs
//you want to use something like a message bus?
//What if…

//We have a lot of “What ifs”, and don’t get me wrong, I understand that these were not a part of the requirements in the first place. So, I am not blaming you for not considering these into the design.

//However, what is concerning me here is:

//The design is not ready for these kinds of requirements.
//You would need to apply too many changes to adapt to the new needs.
//Even if you are not designing your logger and calculators to be separate isolated microservices,
//this doesn’t mean that a Tax Calculator should somehow depend on a Logger.
//A calculator can make use of a logger, but, it should also be able to do its job if a logger is not there.
//I hear someone saying that then we can modify the implementation and make the logger as optional, check if it is passed or null and so on,….
//Even if we apply this, besides the bad implementation and checking for nulls,…
//still the Calculator module/class knows about something called logger which is illogical.
//Also, using the current design, you can’t separate between doing the calculations and logging the messages.
//Besides, there is no one point of control that monitors the flow of messages coming from all the calculators.
//This makes you lose the edge of being able to do aggregations, applying thresholds,…
//Additionally, if someone new joins the team and starts looking into the code, he would end up looking into a huge web of illogical dependencies.

//-------------------------
//Nuevamente, sé que no debes aplicar diseños complicados basados ​​en sueños de lo que podría venir en los próximos 50 años o algo así. 
//    Sin embargo, a veces simplificamos demasiado las cosas cuando, en realidad, aplicar las mejores prácticas simples haría que todo el diseño fuera más sólido y confiable.

//¿Y que?
//Lo que puede hacer es simplemente cambiar la forma en que piensa acerca de las dependencias.

//Sí, sabemos que una dependencia va unida a una implementación, no a una abstracción. 
//Pero aún así, ¿crees que la implementación IncomeTaxCalculatordebería depender de un registrador?

//Puedo entender que una SQLDatabaseRepositoryimplementación de clase, que implementa IRepositoryla interfaz,
//dependería, por definición, de algún módulo que abre y cierra una conexión de base de datos SQL. 
//Esto es algo que puede decir fácilmente con plena confianza.
//Sin embargo, no se puede decir fácilmente, con el mismo nivel de confianza, que la SQLDatabaseRepositoryimplementación de la misma clase depende de un módulo registrador, ¿verdad?




