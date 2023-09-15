using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using ListaCompraApp.Services;
using ListaCompraApp.Models;
using ListaCompraApp.Views.Popups;
using CommunityToolkit.Maui.Views;

namespace ListaCompraApp.ViewModels
{
    public partial class MarketsModifyViewModel : RefreshBaseViewModel
    {
        public MarketsModifyViewModel(FirebaseService firebaseService) : base(firebaseService)
        {
            Title = "Supermercados";
        }

        [RelayCommand]
        async Task AddSingleItem()
        {
            if (IsBusy) return;

            IsBusy = true;

            await Shell.Current.ShowPopupAsync(new NewMarketPopup(Markets));

            firebaseService.Put(Markets);

            IsBusy = false;
        }

        [RelayCommand]
        async Task AddMultipleItem()
        {
            if (IsBusy) return;

            IsBusy = true;

            await Shell.Current.ShowPopupAsync(new NewMarketsPopup(Markets));

            firebaseService.Put(Markets);

            IsBusy = false;
        }

        [RelayCommand]
        void RemoveItem(Guid id)
        {
            if (IsBusy) return;

            IsBusy = true;

            Market market = Markets.First(e => e.List.Select(x => x.Id).Contains(id));

            market.List.Remove(market.List.First(e => e.Id == id));

            if (market.List.Count == 0)
            {
                firebaseService.RemoveChildByName(market.Name);
            }
            else
            {
                firebaseService.Put(Markets);
            }

            firebaseService.Put(Markets);

            IsBusy = false;
        }
    }
}
