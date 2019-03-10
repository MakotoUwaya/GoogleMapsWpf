using System;
using System.Windows;
using System.Windows.Interactivity;
using CefSharp;
using CefSharp.Wpf;

namespace GoogleMapsWpf.Behaviours
{
    public class HoverLinkBehaviour : Behavior<ChromiumWebBrowser>
    {
        // Using a DependencyProperty as the backing store for HoverLink. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HoverLinkProperty = DependencyProperty.Register("HoverLink", typeof(string), typeof(HoverLinkBehaviour), new PropertyMetadata(string.Empty));

        public string HoverLink
        {
            get { return (string)this.GetValue(HoverLinkProperty); }
            set { this.SetValue(HoverLinkProperty, value); }
        }

        protected override void OnAttached()
        {
            this.AssociatedObject.StatusMessage += this.OnStatusMessageChanged;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.StatusMessage -= this.OnStatusMessageChanged;
        }
        
        private void OnStatusMessageChanged(object sender, StatusMessageEventArgs e)
        {
            var chromiumWebBrowser = sender as ChromiumWebBrowser;
            chromiumWebBrowser.Dispatcher.BeginInvoke((Action)(() => this.HoverLink = e.Value));
        }
    }
}
