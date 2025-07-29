using System;

namespace SmartHouse
{
    public class TemperatureSensor : ISensor
    {
        public string Name { get; } = "Temperature Sensor";
        public int LastVal { get; private set; }

        public event EventHandler<SensorEventArgs> Triggered;

        private readonly SmartHouseSystem _smartSystem;

        public TemperatureSensor(SmartHouseSystem system)
        {
            _smartSystem = system ?? throw new ArgumentNullException(nameof(system));
        }

        public void Check()
        {
            Random rand = new Random();
            LastVal = rand.Next(65, 85);

            _smartSystem.UpdateSensorValue(Name, LastVal);

            if (LastVal > 70)
            {
                Triggered?.Invoke(this, new SensorEventArgs
                {
                    SensorName = "[Temperature Sensor]",
                    Message = $"Temperature exceeded: {LastVal}°C"
                });

                _smartSystem.LogIfUniqueMessage($"[Log {DateTime.Now}] {Name}: {LastVal}°C");
            }
        }
    }
}
