﻿using System;

namespace SmartHouse
{
    public class MotionSensor : ISensor
    {
        public string Name { get; } = "Motion Sensor";
        public int LastVal { get; private set; }
        public event EventHandler<SensorEventArgs> Triggered;

        private readonly SmartHouseSystem _smartSystem;

        public MotionSensor(SmartHouseSystem system)
        {
            _smartSystem = system ?? throw new ArgumentNullException(nameof(system));
        }

        public void Check()
        {
            Random rand = new Random();
            LastVal = rand.Next(0, 2);
            _smartSystem.UpdateSensorValue(Name, LastVal);

            if (LastVal == 1)
            {
                Triggered?.Invoke(this, new SensorEventArgs
                {
                    SensorName = "[Motion Sensor]",
                    Message = "Motion detected!"
                });

                _smartSystem.LogIfUniqueMessage($"[Log {DateTime.Now}] {Name}: {LastVal}");
            }
        }
    }
}
