using CommunityToolkit.Mvvm.Input;
using ListaCompraApp.Helpers;
using ListaCompraApp.Views;
using System.Windows.Input;

namespace ListaCompraApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
        InitializeComponent();

        Routing.RegisterRoute(nameof(MarketsView), typeof(MarketsView));
        Routing.RegisterRoute(nameof(MarketView), typeof(MarketView));
        Routing.RegisterRoute(nameof(MarketsModifyView), typeof(MarketsModifyView));
        Routing.RegisterRoute(nameof(SettingsView), typeof(SettingsView));
        Routing.RegisterRoute(nameof(SettingsQRScannerView), typeof(SettingsQRScannerView));
    }
}
