using System;
using System.Threading.Tasks;

public class Module4
{
    public async Task DownloadDataAsync()
    {
        Console.WriteLine("DownloadDataAsync is started");
        await Task.Delay(1000);
        Console.WriteLine("DownloadDataAsync is completed");

        try 
        {
            await Task.Delay(500);
            throw new InvalidOperationException("Simulate error");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    public async Task DownloadDataAsync2()
    {
        Console.WriteLine("DownloadDataAsync2 is started");
        await Task.Delay(2000);
        Console.WriteLine("DownloadDataAsync2 is completed");
    }

    public static async Task Main(string[] args)
    {
        var program = new Module4();

        var task1 = program.DownloadDataAsync();
        var task2 = program.DownloadDataAsync2();
        await Task.WhenAll(task1, task2);
    }
}