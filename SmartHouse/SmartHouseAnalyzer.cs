using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public class SmartHouseAnalyzer
    {
        public List<KeyValuePair<string, int>> GetHotSensors(IReadOnlyDictionary<string, int> sensorValues, int threshold)
        {
            List<KeyValuePair<string, int>> selectedValue = sensorValues.Where(s=>s.Value >= threshold).ToList();

            return selectedValue;
        }


        public List<string> GetLogsContaining(IReadOnlyCollection<string> logs,  string keyword)
        {
List<string> selectedLogs = logs.Where(log=>log.ToLower().Contains(keyword.ToLower())).ToList();

            return selectedLogs;
        }
       
    }
}
