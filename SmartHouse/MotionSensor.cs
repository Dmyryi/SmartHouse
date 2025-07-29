using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public class MotionSensor: ISensor
    {
      public string Name { get;private set; }
        public event EventHandler<SensorEventArgs> Triggered;
        public void Check()
        {
            Random rand = new Random();

            int minVal = 0;
            int maxVal = 1;
            int val = rand.Next(minVal,maxVal);

            if (val == 1)
            {
                Triggered?.Invoke(this, new SensorEventArgs
                {
                    SensorName = "[Motion Sensor]",
                    Message = "Motion detected!"
                });
            }

        }
    }
}
