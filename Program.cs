using System;
using System.IO;
using System.Threading.Tasks;

public class BackgroundOperation
{
    public async Task WriteToFileAsync(string message)
    {
        await Task.Delay(3000);
        await File.WriteAllTextAsync("tmp.txt", message);
    }
}

public class KioskSystem
{
    private readonly BackgroundOperation _backgroundOperation;

    public KioskSystem()
    {
        _backgroundOperation = new BackgroundOperation();
    }

    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Write \"Hello World\"");
            Console.WriteLine("2. Write Current Date");
            Console.WriteLine("3. Write OS Version");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    await _backgroundOperation.WriteToFileAsync("Hello World");
                    Console.WriteLine("Done writing to file.");
                    break;
                case "2":
                    await _backgroundOperation.WriteToFileAsync(DateTime.Now.ToString());
                    Console.WriteLine("Done writing to file.");
                    break;
                case "3":
                    await _backgroundOperation.WriteToFileAsync(Environment.OSVersion.VersionString);
                    Console.WriteLine("Done writing to file.");
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }
    }
}

public class Program
{
    public static async Task Main(string[] args)
    {
        var kioskSystem = new KioskSystem();
        await kioskSystem.RunAsync();
    }
}
