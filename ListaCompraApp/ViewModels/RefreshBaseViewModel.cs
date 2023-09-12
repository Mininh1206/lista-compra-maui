using CommunityToolkit.Mvvm.Input;
using ListaCompraApp.Models;
using ListaCompraApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaCompraApp.ViewModels
{
    public partial class RefreshBaseViewModel : BaseViewModel
    {

        protected readonly FirebaseService firebaseService;

        public ObservableCollection<Market> Markets { get; set; }

        public RefreshBaseViewModel(FirebaseService firebaseService)
        {
            this.firebaseService = firebaseService;

            Markets = new ObservableCollection<Market>();

            LoadMarkets();
        }

        public async void LoadMarkets()
        {
            if (IsBusy) return;

            IsBusy = true;

            Markets.Clear();

            var listaTemp = await firebaseService.GetActualUserChild().OnceAsListAsync<Market>();

            listaTemp.ToList().ForEach(e =>
            {
                Markets.Add(e.Object);
            });

            IsBusy = false;
        }

        [RelayCommand]
        void RefreshMarkets()
        {
            LoadMarkets();
        }
    }
}
