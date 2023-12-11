using Singleton;

Console.Title = "Singleton pattern";

// var test = new Logger(); - Will not work as it is protected 

var instanceOne = Logger.Instance;
var instanceTwo = Logger.Instance;

if (instanceOne == instanceTwo && instanceTwo == Logger.Instance)
{
    Console.WriteLine("Instances are the same!");
}

instanceOne.Log($"Message from {nameof(instanceOne)}");
instanceOne.Log($"Message from {nameof(instanceTwo)}");
Logger.Instance.Log($"Message from {nameof(Logger.Instance)}");

Console.ReadLine();