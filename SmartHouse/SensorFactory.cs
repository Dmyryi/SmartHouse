using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public class SensorFactory
    {
        public ISensor CreateSensor(string type, SmartHouseSystem system)
        {
            switch (type.ToLower())
            {
                case "temperature":
                    return new TemperatureSensor(system);
                case "motion":
                    return new MotionSensor(system);
                case "noise":
                    return new NoiseSensor(system);
                default:
                    throw new NotSupportedException($"Sensor type '{type}' is not supported.");
            }
        }
    }

}
