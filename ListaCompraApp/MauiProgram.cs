using CommunityToolkit.Maui;
using ListaCompraApp.Services;
using ListaCompraApp.ViewModels;
using ListaCompraApp.Views;
using ZXing.Net.Maui.Controls;

namespace ListaCompraApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseBarcodeReader()
            .UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<FirebaseService>();

		builder.Services.AddTransient<MarketsView>();
        builder.Services.AddTransient<MarketView>();
        builder.Services.AddTransient<MarketsModifyView>();
        builder.Services.AddTransient<SettingsView>();
        builder.Services.AddTransient<SettingsQRScannerView>();

        builder.Services.AddTransient<MarketsViewModel>();
		builder.Services.AddTransient<MarketViewModel>();
		builder.Services.AddTransient<MarketsModifyViewModel>();
        builder.Services.AddTransient<SettingsViewModel>();

        return builder.Build();
	}
}
