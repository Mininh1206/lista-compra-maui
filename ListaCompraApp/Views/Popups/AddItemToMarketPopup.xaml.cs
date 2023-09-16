using CommunityToolkit.Maui.Views;
using ListaCompraApp.Models;
using System.Collections.ObjectModel;

namespace ListaCompraApp.Views.Popups;

public partial class AddItemToMarketPopup : Popup
{
    ObservableCollection<Market> Markets { get; set; }

    string marketName;

    public AddItemToMarketPopup(ObservableCollection<Market> markets)
	{
		InitializeComponent();

        Markets = markets;
	}

    public AddItemToMarketPopup(ObservableCollection<Market> markets, string marketName)
    {
        InitializeComponent();

        MarketPickerContainer.IsVisible = false;

        Markets = markets;

        this.marketName = marketName;
    }

    private void AddItemToMarket(object sender, EventArgs e)
    {
        marketName ??= (string)(MarketPicker.SelectedItem ?? "");
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