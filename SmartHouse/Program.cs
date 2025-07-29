using SmartHouse;

public class Program
{
    public static void Main(string[] args)
    {
        TemperatureSensor tmpSensor = new TemperatureSensor();
        MotionSensor motSenson = new MotionSensor();
        ConsoleNotifier notifier = new ConsoleNotifier();

        motSenson.Triggered += notifier.OnSensorTriggered;
        tmpSensor.Triggered += notifier.OnSensorTriggered;
        motSenson.Check();
        tmpSensor.Check();
        motSenson.Check();
        tmpSensor.Check();
        motSenson.Check();
        tmpSensor.Check();

    }
}