using CommunityToolkit.Maui.Views;
using ListaCompraApp.Models;
using System.Collections.ObjectModel;

namespace ListaCompraApp.Views.Popups;

public partial class AddItemsToMarketPopup : Popup
{
    ObservableCollection<Market> Markets { get; set; }

    public AddItemsToMarketPopup(ObservableCollection<Market> markets)
    {
        InitializeComponent();

        Markets = markets;
    }

    private void AddItemsToMarket(object sender, EventArgs e)
    {
        string marketName = (string)(MarketPicker.SelectedItem ?? "");
        List<string> newItems = ItemEditor.Text.Split("\n").ToList();

        if (string.IsNullOrEmpty(marketName) || newItems.Count == 0)
        {

        }
        else
        {
            Market selectedMarket = Markets.FirstOrDefault(x => x.Name == marketName) ?? new(marketName);

            if (!Markets.Any(x => x.Name == marketName))
            {
                Markets.Add(selectedMarket);
            }

            newItems.ForEach(e =>
            {
                if (!string.IsNullOrEmpty(e))
                {
                    selectedMarket.List.Add(new Item(e));
                }
            });

            Close();
        }
    }
}