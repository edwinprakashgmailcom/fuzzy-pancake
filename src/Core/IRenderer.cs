namespace Core;

public interface IRenderer
{
    string RenderView(string viewTemplate, string model);
}
