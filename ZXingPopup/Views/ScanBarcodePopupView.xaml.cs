using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZXing;
using ZXingPopup.ViewModels;

namespace ZXingPopup.Views
{
    /// <summary>
    /// I know this is an MVVM app but sometimes a little code in the code behind makes life much simpler
    /// </summary>
    public partial class ScanBarcodePopupView : Popup
    {
        public ScanBarcodePopupView()
        {
            try
            {
                InitializeComponent();
                BindingContext = new ScanBarcodePopupViewModel();
                //Set some defaults ... 
                ((ScanBarcodePopupViewModel)BindingContext).IsScanning = true;
                ((ScanBarcodePopupViewModel)BindingContext).TorchOn = true;
            }
            catch (Exception exception)
            {
                if (Debugger.IsAttached) Debugger.Break();
                Debug.WriteLine(exception.Message);
            }
           
        }

        private void ZXingScannerView_OnOnScanResult(Result result)
        {
            try
            {
                ((ScanBarcodePopupViewModel)BindingContext).IsScanning = false;
                ((ScanBarcodePopupViewModel)BindingContext).TorchOn = false;
                ((ScanBarcodePopupViewModel)BindingContext).IsAnalyzing = false;
                Debug.WriteLine($"Dismissing and passing back scan result {JsonConvert.SerializeObject(result)}");
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Dismiss(result);
                });


            }
            catch (Exception exception)
            {
                if (Debugger.IsAttached) Debugger.Break();
                Debug.WriteLine(exception.Message);
            }
           
        }


        private void Button_OnClicked(object sender, EventArgs e)
        {
            try
            {
                ((ScanBarcodePopupViewModel)BindingContext).IsScanning = false;
                ((ScanBarcodePopupViewModel)BindingContext).TorchOn = false;
                ((ScanBarcodePopupViewModel)BindingContext).IsAnalyzing = false;
                Debug.WriteLine($"Dismissing and passing back null");
                Dismiss(null);
            }
            catch (Exception exception)
            {
                if (Debugger.IsAttached) Debugger.Break();
                Debug.WriteLine(exception.Message);
            }
            
        }
    }
}
