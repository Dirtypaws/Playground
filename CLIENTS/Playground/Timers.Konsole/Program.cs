using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Timers.Konsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var timer = new Timer(timer_Elapsed, null, 2000, 2000);
            Thread.Sleep(11000);
            timer.Change(1000, 1000);
            Console.ReadKey();
        }

        static void timer_Elapsed(object e)
        {
            Console.WriteLine("timer called");
            
        }
    }
}
