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
    public partial class MarketsViewModel : BaseViewModel
    {
        private readonly FirebaseService firebaseService;

        public ObservableCollection<Market> Markets { get; set; }

        public MarketsViewModel(FirebaseService firebaseService)
        {
            this.firebaseService = firebaseService;

            Title = "Supermercados";

            Markets = new();
        }

        public void LoadMarkets()
        {
            if (IsBusy) return;

            IsBusy = true;

            Markets.Clear();

            firebaseService.GetActualUserChild()
                .AsObservable<Market>()
                .Subscribe(x =>
                {
                    if (x.Object != null)
                    {
                        if (x.EventType == Firebase.Database.Streaming.FirebaseEventType.InsertOrUpdate)
                        {
                            if (!Markets.Contains(Markets.FirstOrDefault(e => e.Name == x.Object.Name)))
                            {
                                Markets.Add(x.Object);
                            }
                        }
                        else
                        {
                            Markets.Remove(Markets.FirstOrDefault(e => e.Name == x.Object.Name));
                        }
                    }
                });

            IsBusy = false;
        }

        [RelayCommand]
        void RefreshMarkets()
        {
            LoadMarkets();
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
