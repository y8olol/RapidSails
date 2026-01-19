using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using RapidSails.BytesEngine;
using RapidSails.Content;
using RapidSails.Views;
using RapidSails.VM;

namespace RapidSails
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private ImageLoader _imageLoader;
        public MainWindow()
        {
            InitializeComponent();
            _imageLoader = new ImageLoader();
            LoadImagesAndSwitchWindow();
            SettingsManager.LoadSettings(); 


        }
        private async void LoadImagesAndSwitchWindow()
        {

            await _imageLoader.LoadAllImagesAsync();

            await Dispatcher.InvokeAsync(async () =>
            {

                Hide();

                try
                {
                    PakManagerVM pakManagerVM = new PakManagerVM(_imageLoader);
                    PakManagerWindow pakManagerWindow = new PakManagerWindow(pakManagerVM);
                    pakManagerWindow.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            });

        }
    }
}