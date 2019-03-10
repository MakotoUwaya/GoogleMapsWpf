using System.Windows;

namespace GoogleMapsWpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.Browser.Address = "resource:google_map.html";
        }


        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            // Using debug
            //this.Browser.ShowDevTools();
        }
    }
}
