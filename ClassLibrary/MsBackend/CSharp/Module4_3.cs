public class Module4_3
{
    public static async Task PerformLongOperationAsync()
    {
        try
        {
            Console.WriteLine("PerformLongOperationAsync: Started");
            await Task.Delay(3000);
            Console.WriteLine("PerformLongOperationAsync: Complete");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception occured: {ex.Message}");
        }
        
    }

    public static async Task PerformLongOperationExAsync()
    {
        try
        {
            Console.WriteLine("PerformLongOperationAsync: Started");
            await Task.Delay(3000);
            throw new Exception("Test exception");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception occured: {ex.Message}");
        }
        
    }

    public static void Main()
    {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");

        Task.Run(async() => await PerformLongOperationAsync()).Wait();
        Console.WriteLine("Good bye!");
    }
}

