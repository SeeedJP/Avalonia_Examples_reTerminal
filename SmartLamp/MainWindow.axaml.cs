using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;

namespace SmartLamp
{
    public partial class MainWindow : Window
    {
        private IHardwareService HardwareService = null!;

        private Bitmap LampOnBitmap = null!;
        private Bitmap LampOffBitmap = null!;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            this.LampImage = this.FindControl<Image>("LampImage");

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                this.HardwareService = new DummyHardwareService();
            else
                this.HardwareService = new RasPiHardwareService();

            this.LampOnBitmap = new Bitmap(AssetLoader.Open(new Uri("avares://SmartLamp/Assets/LampOn.png")));
            this.LampOffBitmap = new Bitmap(AssetLoader.Open(new Uri("avares://SmartLamp/Assets/LampOff.png")));

            this.HardwareService.SetLamp(false);
            this.LampImage!.Source = this.LampOffBitmap;
        }

        private void TurnOnButtonClick(object sender, RoutedEventArgs e)
        {
            this.HardwareService.SetLamp(true);
            this.LampImage.Source = this.LampOnBitmap;
        }

        private void TurnOffButtonClick(object sender, RoutedEventArgs e)
        {
            this.HardwareService.SetLamp(false);
            this.LampImage.Source = this.LampOffBitmap;
        }
    }
}
