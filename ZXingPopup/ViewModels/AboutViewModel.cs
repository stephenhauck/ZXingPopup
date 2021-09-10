using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;
using ZXingPopup.Views;

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

        /// <summary>
        /// Show the barcode popup and wait for the result ..
        /// </summary>
        /// <returns></returns>
        private async Task ScanBarcode()
        {
            try
            {
                if(ScanningBarcode) return;
                ScanningBarcode = true;
                var popup = new ScanBarcodePopupView();
                object popupResult = await Shell.Current.Navigation.ShowPopupAsync(popup);
                if(popupResult != null)
                {
                    Result scanResult = (Result)popupResult;
                    UserDialogs.Instance.Alert($"The scanned value was {scanResult.Text} with a barcode symbology of {scanResult.BarcodeFormat}","Barcode result");
                }
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
