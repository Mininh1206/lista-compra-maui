using ListaCompraApp.ViewModels;

namespace ListaCompraApp.Views;

public partial class MarketsView : ContentPage
{
	public MarketsView(MarketsViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        (BindingContext as MarketsViewModel).LoadMarkets();
    }
}