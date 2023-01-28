public interface IView
{
    string GetHtml(object model, string user, string cultureInfo);
}