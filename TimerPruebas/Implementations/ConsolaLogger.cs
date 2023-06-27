using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerPruebas.Abstractions;

namespace TimerPruebas.Implementations
{
    public class ConsolaLogger : ILogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}

//Esta es una ConsoleLogger clase que implementa ILogger.
//Envuelve System.Consolela clase y la usa para escribir en la Consola. 
//    Esta no es la implementación perfecta, pero sería suficiente
//    por ahora para centrar su atención en el alcance actual.
//If you like to know more about a better design and implementation,
//you can check this story: How to Fully Cover .NET C# Console Application With Unit Tests.