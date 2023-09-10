using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ListaCompraApp.Models;
using ListaCompraApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaCompraApp.ViewModels
{
    public partial class SettingsViewModel : BaseViewModel
    {
        [ObservableProperty]
        string id;

        public SettingsViewModel()
        {
            Title = "Settings";
        }

        [RelayCommand]
        async Task ChangeId()
        {
            if (IsBusy) return;

            IsBusy = true;

            await Shell.Current.GoToAsync(nameof(SettingsQRScannerView));

            IsBusy = false;
        }

        public void OnAppearing()
        {
            Id = ActualUser.Id.ToString();
        }
    }
}
