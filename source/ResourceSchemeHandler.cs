using System;
using System.IO;
using System.Reflection;
using CefSharp;

namespace GoogleMapsWpf
{
    public class ResourceSchemeHandler : ResourceHandler
    {
        private Assembly _ass;
        private string _resourcePath;
        private string _file;
        private string _url;

        public override bool ProcessRequestAsync(IRequest request, ICallback callback)
        {
            this._url = request.Url;
            var u = new Uri(request.Url);
            this._file = u.Authority + u.AbsolutePath;

            this._ass = Assembly.GetExecutingAssembly();
            this._resourcePath = this._ass.GetName().Name + "." + this._file.Replace("/", "");

            if (this._ass.GetManifestResourceInfo(this._resourcePath) == null)
            {
                return false;
            }

            callback.Continue();
            return true;
        }

        public override Stream GetResponse(IResponse response, out long responseLength, out string redirectUrl)
        {
            switch (Path.GetExtension(this._resourcePath))
            {
                case ".html":
                    response.MimeType = "text/html";
                    break;
                case ".js":
                    response.MimeType = "text/javascript";
                    break;
                case ".png":
                    response.MimeType = "image/png";
                    break;
                case ".appcache":
                case ".manifest":
                    response.MimeType = "text/cache-manifest";
                    break;
                default:
                    response.MimeType = "application/octet-stream";
                    break;
            }
            var ret = this._ass.GetManifestResourceStream(this._resourcePath);

            responseLength = ret.Length;
            redirectUrl = string.Empty;

            return ret;
        }
    }
}
