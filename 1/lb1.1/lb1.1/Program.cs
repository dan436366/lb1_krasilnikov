using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lb1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Timer timer1 = new Timer(PrintPes, 2); 
            Timer timer2 = new Timer(PrintKit, 3); 

            timer1.Start();
            timer2.Start();

            Thread.Sleep(12000);

            timer1.Stop();
            timer2.Stop();
            Console.WriteLine("\nTimers stopped!");
        }

        static void PrintPes()
        {
            Console.WriteLine("Pes Patron!");
        }

        static void PrintKit()
        {
            Console.WriteLine("Kit Patron!");
        }
    }
}
