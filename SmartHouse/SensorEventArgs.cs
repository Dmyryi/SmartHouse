using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public class SensorEventArgs : EventArgs
    {

        public string SensorName { get; set; }
        public string Message { get; set; }
    }
}
