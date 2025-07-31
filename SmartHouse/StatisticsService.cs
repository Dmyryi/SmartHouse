using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public class StatisticsService
    {
        public Dictionary<string, List<string>> GetLogsGroupedbySensor(IEnumerable<string> logs)
        {
    


            var groupedResult = logs.GroupBy(log =>
            {
                int start = log.IndexOf("] ") + 2;
                int end = log.LastIndexOf(":");
                return log.Substring(start, end - start);
            });



            return groupedResult.ToDictionary(g => g.Key, g => g.ToList());

        }

        public List<KeyValuePair<string, int>> GetOrderedSensors(IReadOnlyDictionary<string, int> sensors)
        {
            var sensorDictionary = sensors.OrderByDescending(s => s.Value).ThenBy(s=>s.Key).ToList();

           


            return sensorDictionary;
        }

        public double GetAverageSensorValue(IEnumerable<int> sensors) {

            double accSensors = sensors.Aggregate((acc,x)=>acc+x)/sensors.Count();
            return accSensors;
        
        }

        public bool HasCriticalTemperature(IEnumerable<string> logs) {

            bool anyLog = logs.Any(l=>l.Contains("Temperature") && ExtractValue(l)>80);

            return anyLog;
        }

        public int ExtractValue(string log)
        {
            int colonIndex = log.LastIndexOf(':');
            if (colonIndex == -1)
                throw new FormatException("Log format is invalid: ':' not found");

            string part = log.Substring(colonIndex + 1).Replace("°C", "").Trim();
            return int.Parse(part);
        }


    }
}
