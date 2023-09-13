using CommunityToolkit.Maui.Views;
using ListaCompraApp.Helpers;
using ListaCompraApp.Models;

namespace ListaCompraApp.Views.Popups;

public partial class ChangeIdPopup : Popup
{
	public ChangeIdPopup()
	{
		InitializeComponent();
	}

    private void CambiarID(object sender, EventArgs e)
    {
        if (Guid.TryParse(NewIDEntry.Text, out Guid newId))
        {
            ActualUser.Id = newId;

            Close();
        }
    }
}