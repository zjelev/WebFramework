using System.Runtime.CompilerServices;

public abstract class Controller
{
    public HttpRequest Request { get; set; }

    protected HttpResponse View<T>(T viewModel = null, [CallerMemberName] string viewName = null)
        where T : class
    {
        var typeName = this.GetType().Name/*.Replace("Controller", string.Empty)*/;
        var controllerName = typeName.Substring(0, typeName.Length - 10);
        var viewPath = "Views/" + controllerName + "/" + viewName + ".html";
        return this.ViewByName<T>(viewPath, viewModel);
    }

    protected HttpResponse View([CallerMemberName] string viewName = null)
        => this.View<object>(null, viewName);

    protected HttpResponse Error(string error)
        => this.ViewByName<ErrorViewModel>("Views/Shared/Error.html", new ErrorViewModel { Error = error });

    protected HttpResponse Redirect(string url)
        => new RedirectResponse(url);

    protected HttpResponse NotFound()
        => new StatusCodeResponse(HttpResponseCode.NotFound);
    
    private HttpResponse ViewByName<T>(string viewPath, object viewModel)
    {
        IViewEngine viewEngine = new ViewEngine();
        var html = File.ReadAllText(viewPath);
        html = viewEngine.GetHtml(html, viewModel, this.User);

        var layout = File.ReadAllText("Views/Shared/_Layout.html");
        var bodyWithLayout = layout.Replace("@RenderBody()", html);
        bodyWithLayout = viewEngine.GetHtml(bodyWithLayout, viewModel, this.User);
        return new HtmlResponse(bodyWithLayout);
    }

    protected bool IsUserLoggedIn()
        => this.User != null;

    protected void SignIn(string userId)
    {
        this.Request.SessionData["UserId"] = userId;
    }

    protected void SignOut()
    {
        this.Request.SessionData["UserId"] = null;
    }

    public string User =>
        this.Request.SessionData.ContainsKey("UserId") ? this.Request.SessionData["UserId"] : null;
}