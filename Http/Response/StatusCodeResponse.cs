public class StatusCodeResponse : HttpResponse
{
    public StatusCodeResponse(HttpResponseCode code)
    {
        this.StatusCode = code;
    }
}