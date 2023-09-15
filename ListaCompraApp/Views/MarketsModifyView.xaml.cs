using ListaCompraApp.ViewModels;
using Microsoft.Maui.Controls;

namespace ListaCompraApp.Views;

public partial class MarketsModifyView : ContentPage
{
    private bool addButtonsShowed = false;

    public MarketsModifyView(MarketsModifyViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        (BindingContext as MarketsModifyViewModel).LoadMarkets();
    }

    private void ToggleAddButtons(object sender, EventArgs e)
    {
        (sender as ImageButton).RotateTo(addButtonsShowed ? 0 : 45);

        singleAddButton.TranslateTo(0, addButtonsShowed ? 0 : -100);
        multipleAddButton.TranslateTo(0, addButtonsShowed ? 0 : -175);

        Console.WriteLine(singleAddButton.Y);

        addButtonsShowed = !addButtonsShowed;
    }
}