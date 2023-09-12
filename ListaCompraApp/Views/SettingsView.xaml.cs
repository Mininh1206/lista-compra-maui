using CommunityToolkit.Maui.Alerts;
using ListaCompraApp.ViewModels;

namespace ListaCompraApp.Views;

public partial class SettingsView : ContentPage
{
	public SettingsView(SettingsViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

		(BindingContext as SettingsViewModel).UpdateUserId();
    }
}