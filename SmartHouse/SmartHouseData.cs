using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public class SmartHouseData
    {
        public Dictionary<string, int> SensorValues { get; set; }
        public List<string> LogMessages { get; set; }

    }
}
