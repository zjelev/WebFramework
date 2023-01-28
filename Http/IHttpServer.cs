public interface IHttpServer
{
    Task StartAsync();
    Task ResetAsync();
    void Stop();
}