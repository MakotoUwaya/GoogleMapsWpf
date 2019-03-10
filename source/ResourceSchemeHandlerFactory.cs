using CefSharp;

namespace GoogleMapsWpf
{
    public class ResourceSchemeHandlerFactory : ISchemeHandlerFactory
    {
        public IResourceHandler Create(IBrowser browser, IFrame frame, string schemeName, IRequest request)
        {
            return new ResourceSchemeHandler();
        }
        public static string SchemeName => "resource";
    }
}
