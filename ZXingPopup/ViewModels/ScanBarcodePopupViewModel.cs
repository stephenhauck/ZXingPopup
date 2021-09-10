using System;
using ZXing;
using System.Windows.Input;
using Xamarin.Forms;
namespace ZXingPopup.ViewModels
{
    public class ScanBarcodePopupViewModel :  BaseViewModel
    {
        public ICommand ScanCommand
        {
            get
            {
                return new Command(() =>
                {
                    throw new NotImplementedException();
                });
            }
        }

        public Result Result { get; set; }

        public bool IsAnalyzing { get; set; }

        public bool IsScanning { get; set; }

        public ScanBarcodePopupViewModel()
        {

        }
    }
}
