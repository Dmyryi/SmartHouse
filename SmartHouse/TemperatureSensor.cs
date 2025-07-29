using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    class TemperatureSensor:ISensor
    {
        public string Name {  get; private set; }

        public event EventHandler<SensorEventArgs> Triggered;

        public void Check()
        {
            Random rand = new Random();

            int minTemp = 65;
            int maxTemp = 85;

          int val = rand.Next(minTemp, maxTemp);
            if(val > 70)
            {
                Triggered?.Invoke(this, new SensorEventArgs
                {
                    SensorName = "[Temperature Sensor]",
                    Message = $"Temperature exceeded: {val}°C"
                });

            }
        }

     
    }
}
