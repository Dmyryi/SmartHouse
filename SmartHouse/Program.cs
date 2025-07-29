using System;
using SmartHouse;

public class Program
{
    public static void Main(string[] args)
    {
        var notifier = new ConsoleNotifier();
        var smartSystem = new SmartHouseSystem(notifier);

        var tempSensor = new TemperatureSensor(smartSystem);
        var motionSensor = new MotionSensor(smartSystem);

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
