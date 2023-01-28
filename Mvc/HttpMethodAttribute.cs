[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public abstract class HttpMethodAttribute : Attribute
{
    protected HttpMethodAttribute()
    {
    }

    protected HttpMethodAttribute(string url)
    {
        this.Url = url;
    }

    public string Url { get; }

    public abstract HttpMethodType Type { get; }
}