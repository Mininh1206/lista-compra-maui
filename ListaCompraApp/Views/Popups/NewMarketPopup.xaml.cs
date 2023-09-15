using CommunityToolkit.Maui.Views;
using ListaCompraApp.Models;
using System.Collections.ObjectModel;

namespace ListaCompraApp.Views.Popups;

public partial class NewMarketPopup : Popup
{
    ObservableCollection<Market> Markets { get; set; }

    public NewMarketPopup(ObservableCollection<Market> markets)
	{
		InitializeComponent();

        Markets = markets;
	}

    private void AddItemToMarket(object sender, EventArgs e)
    {
        string marketName = (string)(MarketPicker.SelectedItem ?? "");
        string newItem = ItemEntry.Text;

        if (string.IsNullOrEmpty(marketName) || string.IsNullOrEmpty(newItem) )
        {

        }
        else
        {
            if (Markets.Any(x => x.Name == marketName))
            {
                Markets.First(x => x.Name == marketName).List.Add(new Item(newItem));
            }
            else
            {
                Market newMarket = new (marketName);
                newMarket.List.Add(new Item(newItem));

                Markets.Add(newMarket);
            }

            Close();
        }
    }
}