using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using ListaCompraApp.Services;
using ListaCompraApp.Models;
using Mopups.Services;
using ListaCompraApp.Views.Popups;
using CommunityToolkit.Maui.Views;

namespace ListaCompraApp.ViewModels
{
    public partial class MarketsModifyViewModel : BaseViewModel
    {
        private readonly FirebaseService firebaseService;

        public ObservableCollection<Market> Markets { get; set; }

        public MarketsModifyViewModel(FirebaseService firebaseService)
        {
            this.firebaseService = firebaseService;

            Title = "Supermercados";

            Markets = new ObservableCollection<Market>();

            LoadMarkets();
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
        async Task AddItem()
        {
            if (IsBusy) return;

            IsBusy = true;

            //TODO Terminar popup y esta función
            await Shell.Current.ShowPopupAsync(new NewMarketPopupView(Markets));

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

            firebaseService.Put(Markets);

            IsBusy = false;
        }
    }
}
