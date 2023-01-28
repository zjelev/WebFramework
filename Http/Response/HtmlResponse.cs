using System.Text;

/// <summary>
/// Represents an HTML Response with properties for the <c>Response Status Line</c>, <c>Response Headers</c> and <c>Response Body</c>.
/// </summary>
public class HtmlResponse : HttpResponse
{
    public HtmlResponse(string html)
    {
        this.StatusCode = HttpResponseCode.Ok;
        byte[] byteData = Encoding.UTF8.GetBytes(html);
        this.Body = byteData;
        this.Headers.Add(new Header("Content-Type", "text/html"));
        this.Headers.Add(new Header("Content-Length", this.Body.Length.ToString()));
    }
}