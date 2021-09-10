using System;
using System.Collections.Generic;
using ZXingPopup.ViewModels;
using ZXingPopup.Views;
using Xamarin.Forms;

namespace ZXingPopup
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(ScanBarcodePopupView), typeof(ScanBarcodePopupView));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
