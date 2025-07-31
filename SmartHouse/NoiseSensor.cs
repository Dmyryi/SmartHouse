using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public class NoiseSensor:ISensor
    {
        public string Name { get; } = "Noise Sensor";
        public int LastVal { get; private set; }

        public event EventHandler<SensorEventArgs> Triggered;

        private readonly SmartHouseSystem _smartSystem;
        private readonly List<INoiseAnalysisStrategy> _strategies = new();


        public NoiseSensor(SmartHouseSystem system)
        {
            _smartSystem = system ?? throw new ArgumentNullException(nameof(system));
        }
        public void AddStrategy(INoiseAnalysisStrategy strategy)
        {
            _strategies.Add(strategy);
        }

        public void Check()
        {
            Random rnd = new Random();
            int minVal = 20;
            int maxVal = 121;
            LastVal = rnd.Next(minVal, maxVal);

            foreach (var strategy in _strategies)
            {
                strategy.Analyze(Name, LastVal, _smartSystem);
            }

        }
    }
}
