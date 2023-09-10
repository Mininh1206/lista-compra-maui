using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ListaCompraApp.Models;
using ListaCompraApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaCompraApp.ViewModels
{
    [QueryProperty(nameof(Name), "name")]
    public partial class MarketViewModel : BaseViewModel
    {
        private readonly FirebaseService firebaseService;

        [ObservableProperty]
        Market actualMarket;

        public string Key { get; set; }
        public string Name { get; set; }

        public MarketViewModel(FirebaseService firebaseService)
        {
            this.firebaseService = firebaseService;

            LoadMarket();
        }

        public async void LoadMarket()
        {
            if (IsBusy) return;

            IsBusy = true;

            var temp = await firebaseService.GetActualUserChild().OnceAsListAsync<Market>();

            temp.ToList().ForEach(e =>
            {
                if (e.Object != null && e.Object.Name == Name)
                {
                    Key = e.Key;
                    ActualMarket = new Market(e.Object.Name, e.Object.List);
                }
            });

            IsBusy = false;
        }

        [RelayCommand]
        void RefreshMarket()
        {
            ActualMarket = new Market();

            LoadMarket();
        }

        [RelayCommand]
        void PutInCar(Item item)
        {
            if (IsBusy) return;

            IsBusy = true;

#if __MOBILE__
            item.InCar = !item.InCar;
#endif

            firebaseService.PutInChild(Key, ActualMarket);

            IsBusy = false;
        }

        [RelayCommand]
        async Task Save()
        {
            if (IsBusy) return;

            IsBusy = true;

            List<Item> itemsToRemove = ActualMarket.List.Where(e => e.InCar).ToList();

            itemsToRemove.ForEach(e =>
            {
                ActualMarket.List.Remove(e);
            });

            if (ActualMarket.List.Count == 0)
            {
                firebaseService.RemoveChild(Key);
            }
            else
            {
                firebaseService.PutInChild(Key, ActualMarket);
            }

            await Shell.Current.GoToAsync("..");

            IsBusy = false;
        }
    }
}
