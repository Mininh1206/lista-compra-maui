using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Database.Query;
using ListaCompraApp.Models;
using ListaCompraApp.Services;
using ListaCompraApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaCompraApp.ViewModels
{
    public partial class MarketsViewModel : RefreshBaseViewModel
    {
        public MarketsViewModel(FirebaseService firebaseService) : base(firebaseService)
        {
            Title = "Supermercados";
        }


        [RelayCommand]
        async Task GoToMarket(Market market)
        {
            if (IsBusy) return;

            IsBusy = true;

            if (market is not null)
            {
                await Shell.Current.GoToAsync($"{nameof(MarketView)}?name={market.Name}");
            }

            IsBusy = false;
        }
    }
}
