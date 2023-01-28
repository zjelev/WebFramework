public class ConsoleLogger : ILogger
{
    public async Task Log(string message)
    {
        await Console.Out.WriteLineAsync($"[{DateTime.Now.ToString()}] {message}");
    }
}