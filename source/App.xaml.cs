using System;
using System.IO;
using System.Windows;
using CefSharp;
using CefSharp.Wpf;

namespace GoogleMapsWpf
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var settings = new CefSettings
            {
                //By default CefSharp will use an in-memory cache, you need to specify a Cache Folder to persist data
                CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache")
            };

            var customScheme = new CefCustomScheme
            {
                SchemeName = ResourceSchemeHandlerFactory.SchemeName,
                SchemeHandlerFactory = new ResourceSchemeHandlerFactory()
            };
            settings.RegisterScheme(customScheme);

            //Perform dependency check to make sure all relevant resources are in our output directory.
            Cef.Initialize(settings, true, browserProcessHandler: null);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            Cef.Shutdown();
        }
    }
}
