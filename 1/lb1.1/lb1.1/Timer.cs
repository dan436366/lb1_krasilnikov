using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lb1._1
{
    public delegate void TimerDelegate();

    public class Timer
    {
        private TimerDelegate method;
        private int interval;
        private bool isWorking;

        public Timer(TimerDelegate method, int interval)
        {
            this.method = method;
            this.interval = interval;
            isWorking = false;
        }

        private void Run()
        {
            while (isWorking)
            {
                method();
                Thread.Sleep(interval * 1000);
            }
        }

        public void Start()
        {
            if (!isWorking)
            {
                isWorking = true;
                Thread thread = new Thread(Run);
                thread.IsBackground = true;
                thread.Start();
            }
        }

        public void Stop()
        {
            isWorking = false;
        }
    }
}
