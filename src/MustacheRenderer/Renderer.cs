using Core;
using Newtonsoft.Json;

namespace MustacheRenderer
{
    public class Renderer : IRenderer
    {
        public string RenderView(string viewTemplate, string model)
        {
            var jsonModel = JsonConvert.DeserializeObject(model);
            return Stubble.Core.StaticStubbleRenderer.Render(viewTemplate, jsonModel);
        }
    }
}