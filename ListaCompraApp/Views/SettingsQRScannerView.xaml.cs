using ListaCompraApp.Models;
using ZXing.Net.Maui;

namespace ListaCompraApp.Views;

public partial class SettingsQRScannerView : ContentPage
{
	public SettingsQRScannerView()
	{
		InitializeComponent();

        cameraBarcodeReaderView.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.All,
            AutoRotate = true,
            Multiple = true
        };
    }

    private void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        Dispatcher.Dispatch(async () =>
        {
            try
            {
                Guid id = Guid.Parse(e.Results[0].Value);

                ActualUser.Id = id;

                await Shell.Current.GoToAsync("..");
            }
            catch
            {
                await Shell.Current.DisplayAlert("Error", "No es un QR valido", "OK");
            }
        });
        
    }
}