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
                default:
                    throw new ArgumentException($"Sensor type '{type}' is not supported.");
            }
        }
    }

}
