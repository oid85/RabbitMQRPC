internal class Program
{
    private static async Task Main(string[] args)
    {
        await InvokeAsync("hi there!");

        Console.ReadLine();
    }

    private static async Task InvokeAsync(string input)
    {
        var cts = new CancellationTokenSource();
        var cancellationToken = cts.Token;

        using var rpcClient = new RpcClient();

        // Помещаем вызов в Task
        _ = Task.Run(async () => await rpcClient.CallAsync(input, cancellationToken));

        // Спустя таймаут отменяем
        await Task.Delay(1_000, cancellationToken);
        
        try
        {
            cts.Cancel();
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}