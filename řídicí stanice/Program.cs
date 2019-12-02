using System;
using System.Threading;

namespace řídicí_stanice
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    class TimeOfTick : EventArgs
    {
        public bool Rain { get; set; }
        public bool Night { get; set; }
        public bool Slunecno { get;set; }
    }
    class Car
    {
        public float Speed { get; set; }
        public bool Lights { get; set; }
        public int RouteLength { get; set; }
    }
    class RidiciCentrum
    {
        public void Subscribe(MeterologickaStanice w)
        {
            w.WS += new MeterologickaStanice.TickHandler(HeardIt);
        }

        private void HeardIt(MeterologickaStanice w, TimeOfTick e)
        {
            Console.WriteLine("{0}", e.Rain);
        }
    }
    class MeterologickaStanice
    {
        public delegate void TickHandler(MeterologickaStanice w, TimeOfTick e);
        public event TickHandler WS;
        Random rn = new Random();
        bool rain;

        public void Rain()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(2000);
                if (rn.Next(2) == 0)
                {
                    rain = false;
                }
                else
                {
                    rain = true;
                }

                if (WS != null)
                {
                    TimeOfTick tot = new TimeOfTick();
                    tot.Rain = rain;
                    WS(this, tot);
                    
                }
            }
        }


    }
}