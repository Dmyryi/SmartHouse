using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public interface ISensor
    {
        string Name { get; }
        int LastVal { get; }
        event EventHandler<SensorEventArgs> Triggered;
        void Check();
    }
}
