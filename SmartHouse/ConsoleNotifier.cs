using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public class ConsoleNotifier
    {
        public void OnSensorTriggered(object sender, SensorEventArgs e)
        {
            Console.WriteLine($"{e.SensorName}  {e.Message}");
        }
    }
}
