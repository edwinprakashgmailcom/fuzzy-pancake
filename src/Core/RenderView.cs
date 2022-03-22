namespace Core;

public class RenderView
{
    private readonly IRenderer _renderer;

    public RenderView (IRenderer renderer)
    {
        _renderer = renderer;
    }

    public string Render(string viewTemplate, string model)
    {
        return _renderer.RenderView(viewTemplate, model);
    }
}
