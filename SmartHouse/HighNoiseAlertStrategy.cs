using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartHouse
{
    public class HighNoiseAlertStrategy:INoiseAnalysisStrategy
    {
        public void Analyze(string sensorName, int value, SmartHouseSystem system)
        {
            int noiseMax = 100;
            if (value > noiseMax)
            {
                system.UpdateSensorValue(sensorName, value);
                system.LogIfUniqueMessage($"[Log {DateTime.Now}] High Noise: {value}");
            }
        }
    }
}
