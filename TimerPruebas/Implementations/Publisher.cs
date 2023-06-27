using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TimerPruebas.Implementations
{
    public class Publisher : IPublisher
    {

        private readonly Timer m_Timer;
        private readonly IConsola m_Console; // IConsola---> void WriteLine(object value);//?
        public Publisher(IConsola consola)
        {
            m_Timer = new Timer();
            m_Timer.Enabled = true;
            m_Timer.Interval = 1000;
            m_Timer.Elapsed += Handler;

            m_Console = consola;
        }
        public void StartPublishing()
        {
            m_Timer.Start();
        }

        //public void StartPublishing(object value)
        //{
        //    throw new NotImplementedException();
        //}

        public void StopPublishing()
        {
            m_Timer.Stop();
        }

        private void Handler(object sender, ElapsedEventArgs args)
        {
            m_Console.WriteLine(args.SignalTime);
        }

    }
}
