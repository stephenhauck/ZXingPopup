using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ZXingPopup.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private bool _scaningBarcode;

        public bool ScanningBarcode
        {
            get => _scaningBarcode;
            set => SetProperty(ref _scaningBarcode, value);
        }


        public ICommand OpenWebCommand { get; }
        public ICommand ScanBarcodeCommand { get; }


        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            ScanBarcodeCommand = new Command(async () => await ScanBarcode());
        }

        private async Task ScanBarcode()
        {
            try
            {
                ScanningBarcode = true;
                //var popup = new 
                //object retcode = Shell.Current.Navigation.ShowPopupAsync();
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"An error occurred {exception.Message}");
            }
            finally
            {
                ScanningBarcode = false;
            }
        }
    }
}
