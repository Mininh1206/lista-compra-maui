using CommunityToolkit.Maui.Views;
using ListaCompraApp.Models;
using System.Collections.ObjectModel;

namespace ListaCompraApp.Views.Popups;

public partial class NewMarketsPopup : Popup
{
    ObservableCollection<Market> Markets { get; set; }

    public NewMarketsPopup(ObservableCollection<Market> markets)
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
            if (Markets.Any(x => x.Name == marketName))
            {
                Market marketSelected = Markets.First(x => x.Name == marketName);

                newItems.ForEach(e => marketSelected.List.Add(new Item(e)));
            }
            else
            {
                Market newMarket = new(marketName);

                newItems.ForEach(e => newMarket.List.Add(new Item(e)));

                Markets.Add(newMarket);
            }

            Close();
        }
    }
}