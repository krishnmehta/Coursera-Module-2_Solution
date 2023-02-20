using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Enter the URL to download from:");
        string url = Console.ReadLine();

        Console.WriteLine("Downloading...");
        string content = await DownloadContentAsync(url);

        Console.WriteLine("Enter the filename to save to:");
        string filename = Console.ReadLine();

        await WriteContentToFileAsync(filename, content);

        Console.WriteLine("Done!");
    }

    static async Task<string> DownloadContentAsync(string url)
    {
        using (var client = new WebClient())
        {
            return await client.DownloadStringTaskAsync(url);
        }
    }

    static async Task WriteContentToFileAsync(string filename, string content)
    {
        using (var writer = new StreamWriter(filename))
        {
            await writer.WriteAsync(content);
        }
    }
}
