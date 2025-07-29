using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public interface INotifier
    {
        

        void Notify(object sender, SensorEventArgs args);
    }
}
