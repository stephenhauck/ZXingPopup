using System.ComponentModel;
using Xamarin.Forms;
using ZXingPopup.ViewModels;

namespace ZXingPopup.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
