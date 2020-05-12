using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace Lab07
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CodeQR : ContentPage
    {
        public CodeQR()
        {
            InitializeComponent();
        }

        private void OpenScanner(object sender, EventArgs e)
        {
            Scanner_open();
        }

        public async void Scanner_open()
        {

            var ScannerPage = new ZXingScannerPage();

            ScannerPage.OnScanResult += (result) => {
                // Parar de escanear
                ScannerPage.IsScanning = false;

                // Alert com o código escaneado
                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopAsync();
                    DisplayAlert("Código escaneado", result.Text, "OK");
                });
            };


            await Navigation.PushAsync(ScannerPage);

        }
    }
}