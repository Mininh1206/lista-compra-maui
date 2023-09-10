using ListaCompraApp.ViewModels;

namespace ListaCompraApp.Views;

public partial class MarketsModifyView : ContentPage
{
	public MarketsModifyView(MarketsModifyViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
    }
}