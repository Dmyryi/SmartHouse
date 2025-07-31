using System;
using SmartHouse;

public class Program
{
    public static void Main(string[] args)
    {
        ConsoleNotifier notifier = new ConsoleNotifier();
        SmartHouseSystem smartSystem = new SmartHouseSystem(notifier);
        SmartHouseAnalyzer smartHouseAnalyzer = new SmartHouseAnalyzer();
        SensorFactory factory = new SensorFactory();
        ISensor tempSensor = factory.CreateSensor("temperature", smartSystem);
        ISensor motionSensor = factory.CreateSensor("motion", smartSystem);
       
        StatisticsService statistic = new StatisticsService();
        smartSystem.RegisterSensor(tempSensor);
        smartSystem.RegisterSensor(motionSensor);

        const string filePath = "smarthouse_data.json";

        while (true)
        {
            Console.WriteLine("\n=== SmartHouse Control Panel ===");
            Console.WriteLine("1. Check all sensors");
            Console.WriteLine("2. Show current status");
            Console.WriteLine("3. Save system state");
            Console.WriteLine("4. Load system state");
            Console.WriteLine("5. Analyze data (hot sensors and logs)");
            Console.WriteLine("6. Logs by themes");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    tempSensor.Check();
                    motionSensor.Check();
                    Console.WriteLine("Sensors checked.");
                    break;

                case "2":
                    smartSystem.PrintSummary();
                    break;

                case "3":
                    smartSystem.SaveState(filePath);
                    Console.WriteLine("✅ State saved.");
                    break;

                case "4":
                    smartSystem.LoadState(filePath);
                    Console.WriteLine("✅ State loaded.");
                    break;

                case "5":
                    int threshold = 75;
                    List<KeyValuePair<string, int>> selectedSensors = smartHouseAnalyzer.GetHotSensors(smartSystem.SensorValues, threshold);
                    List<string> selectedLogs =  smartHouseAnalyzer.GetLogsContaining(smartSystem.LogMessages, "temperature");
                    
                    foreach (var sens in selectedSensors)
                    {
                        Console.WriteLine(sens);
                    }
                    foreach (var log in selectedLogs)
                    {
                        Console.WriteLine(log);
                    }
                    break;
                case "6":
                    Console.WriteLine("=== Sensor Logs by Type ===");
                    var keyValue = statistic.GetLogsGroupedbySensor(smartSystem.LogMessages);

                    foreach (var pair in keyValue)
                    {
                        Console.WriteLine($"📦 Sensor: {pair.Key}");
                        foreach (var log in pair.Value)
                        {
                            Console.WriteLine($"   • {log}");
                        }
                        Console.WriteLine(new string('-', 40));
                    }

                    Console.WriteLine("============= Ordered Sensors ===========");
                    var orderedSensors = statistic.GetOrderedSensors(smartSystem.SensorValues);
                    foreach (var sensor in orderedSensors)
                    {
                        Console.WriteLine($"{sensor.Key}: {sensor.Value}°C");
                    }
                    Console.WriteLine(new string('-', 40));

                    double avg = statistic.GetAverageSensorValue(smartSystem.SensorValues.Values);
                    Console.WriteLine($"📈 Average sensor value: {avg}");

                    bool critical = statistic.HasCriticalTemperature(smartSystem.LogMessages);
                    Console.WriteLine($"🔥 Critical temperature detected: {(critical ? "YES" : "NO")}");

                    break;

                case "0":
                    Console.WriteLine("Shutting down SmartHouse... 🏠");
                    return;

                default:
                    Console.WriteLine("⚠️ Unknown command. Please try again.");
                    break;
            }
        }
    }
}
