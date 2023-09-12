using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Reflection;

namespace ListaCompraApp.Views.Popups;

public partial class ConfirmationPopup : Popup
{
    public ConfirmationPopup(string messaje)
	{
		InitializeComponent();

		MessajeEntry.Text = messaje;
	}

    private void ReturnYes(object sender, EventArgs e)
    {
        Close(true);
    }

    private void ReturnNo(object sender, EventArgs e)
    {
        Close(false);
    }
}