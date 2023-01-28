public class FileLogger : ILogger
{
    public async Task Log(string message)
    {
        await File.AppendAllLinesAsync("log.txt", new[] { $"[{DateTime.Now.ToString()}] {message}" });
    }
}