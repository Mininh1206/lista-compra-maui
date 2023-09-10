using ListaCompraApp.ViewModels;

namespace ListaCompraApp.Views;

public partial class MarketView : ContentPage
{
	public MarketView(MarketViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}