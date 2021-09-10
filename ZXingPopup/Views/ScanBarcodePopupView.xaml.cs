using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.CommunityToolkit.UI.Views;
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
            InitializeComponent();
            BindingContext = new ScanBarcodePopupViewModel();
            //Set some defaults ... 
            ((ScanBarcodePopupViewModel)BindingContext).IsScanning = true;
            ((ScanBarcodePopupViewModel)BindingContext).TorchOn = true;
        }

        private void ZXingScannerView_OnOnScanResult(Result result)
        {
            Debug.WriteLine($"Dismissing and passing back scan result {JsonConvert.SerializeObject(result)}");
            Dismiss(result);
        }


        private void Button_OnClicked(object sender, EventArgs e)
        {
            Debug.WriteLine($"Dismissing and passing back null");
           Dismiss(null);
        }
    }
}
