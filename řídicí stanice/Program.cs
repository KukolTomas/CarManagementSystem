using System;
using System.Threading;

namespace řídicí_stanice
{
    class TimeOfTick : EventArgs
    {
        public bool Rain { get; set; }
        public bool Night { get; set; }
    }
    class Car
    {
        public float Speed { get; set; }
        public bool Lights { get; set; }
        public int RouteLength { get; set; }
    }
    class Headquater
    {
        public void Subscribe(WeatherStation w)
        {
            w.WS += new WeatherStation.WeatherStatus(HeardIt);
        }

        private void HeardIt(WeatherStation w, TimeOfTick e)
        {
            Console.WriteLine("{0}", e.Rain);
        }
    }
    class WeatherStation
    {
        public delegate void WeatherStatus(WeatherStation w, TimeOfTick e);
        public event WeatherStatus WS;

    }
    class Road
    {

    }
}