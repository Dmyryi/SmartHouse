using System;
using System.Collections.Generic;
using System.Text.Json;
namespace SmartHouse
{
    public class SmartHouseSystem
    {
        private readonly Dictionary<string, int> _sensorValues = new();
        private readonly HashSet<string> _logMessages = new();

        private readonly ConsoleNotifier _notifier;

        public IReadOnlyDictionary<string, int> SensorValues => _sensorValues;
        public IReadOnlyCollection<string> LogMessages => _logMessages;

        public SmartHouseSystem(ConsoleNotifier notifier)
        {
            _notifier = notifier ?? throw new ArgumentNullException(nameof(notifier));
        }

        public void RegisterSensor(ISensor sensor)
        {
            if (sensor == null) return;

            if (!_sensorValues.ContainsKey(sensor.Name))
            {
                _sensorValues[sensor.Name] = sensor.LastVal;
                sensor.Triggered += _notifier.OnSensorTriggered;
            }
        }

        public void UpdateSensorValue(string name, int value)
        {
            if (_sensorValues.ContainsKey(name))
            {
                _sensorValues[name] = value;
            }
        }

        public void LogIfUniqueMessage(string fullMessage)
        {
            _logMessages.Add(fullMessage);
        }

        public void SaveState(string filePath)
        {
            SmartHouseData data = new SmartHouseData
            {
                SensorValues = new Dictionary<string, int>(_sensorValues),
                LogMessages = new List<string>(_logMessages)
            };

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error");
            }
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true});
            File.WriteAllText(filePath, json);
        }

        public void LoadState(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error");
            }
            string json = File.ReadAllText(filePath);
            SmartHouseData data =JsonSerializer.Deserialize<SmartHouseData>(json);
            if (data != null)
            {
                _sensorValues.Clear();
                foreach (var pair in data.SensorValues)
                    _sensorValues[pair.Key] = pair.Value;

                _logMessages.Clear();
                foreach (var msg in data.LogMessages)
                    _logMessages.Add(msg);
            }
        }

        public void PrintSummary()
        {
            Console.WriteLine("Sensor Values:");
            foreach (var pair in _sensorValues)
                Console.WriteLine($"{pair.Key}: {pair.Value}");

            Console.WriteLine("\nSensor Logs:");
            foreach (var msg in _logMessages)
                Console.WriteLine(msg);
        }
    }
}
