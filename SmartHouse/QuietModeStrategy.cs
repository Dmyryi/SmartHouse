using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
   public class QuietModeStrategy:INoiseAnalysisStrategy
    {
        public void Analyze(string sensorName, int value, SmartHouseSystem system)
        {
            int noiseMin = 40;
            if (value < noiseMin)
            {
                system.UpdateSensorValue(sensorName, value);
                system.LogIfUniqueMessage($"[Log {DateTime.Now}] Quiet Noise: {value}");
            }
        }

    }
}
