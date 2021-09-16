using System;
using System.IO;
using System.Reflection;
using ZXing;
using System.Windows.Input;
using MvvmHelpers.Commands;
using Plugin.SimpleAudioPlayer;
using Command = Xamarin.Forms.Command;
using System.Threading.Tasks;

namespace ZXingPopup.ViewModels
{
    public class ScanBarcodePopupViewModel :  BaseViewModel
    {
        private Result _result;
        private bool _isAnalyzing;
        private bool _isScanning;
        private bool _torchOn;
        private readonly ISimpleAudioPlayer _simpleAudioPlayer;

       

        public Result Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }

        public bool IsAnalyzing
        {
            get => _isAnalyzing;
            set => SetProperty(ref _isAnalyzing, value);
        }
        public bool IsScanning
        {
            get => _isScanning;
            set => SetProperty(ref _isScanning, value);
        }

        public bool TorchOn
        {
            get => _torchOn;
            set => SetProperty(ref _torchOn, value);
        }


        public ICommand TorchButtonCommand { get; }
        public ICommand ScanResultCommand { get; }


        public ScanBarcodePopupViewModel()
        {
            //Create the audio player and load the embedded sound resource
            _simpleAudioPlayer = CrossSimpleAudioPlayer.Current;
            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream audioStream = assembly.GetManifestResourceStream("ZXingPopup.Sounds." + "scanbeep.mp3");
            _simpleAudioPlayer.Load(audioStream);
            TorchButtonCommand = new AsyncCommand(async () => TorchButton());
            ScanResultCommand = new AsyncCommand(async () => ScanResult());
            IsAnalyzing = true;
        }

        private async Task TorchButton()
        {
            TorchOn = !TorchOn;
        }

        private async Task ScanResult()
        {
            _simpleAudioPlayer.Play();
        }
    }
}
