using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ListaCompraApp.Helpers;
using ListaCompraApp.Models;
using ListaCompraApp.Views;
using ListaCompraApp.Views.Popups;
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
        async Task ChangeIdByQR()
        {
            if (IsBusy) return;

            IsBusy = true;

            await Shell.Current.GoToAsync(nameof(SettingsQRScannerView));

            UpdateUserId();

            IsBusy = false;
        }

        [RelayCommand]
        async Task ChangeId()
        {
            if (IsBusy) return;

            IsBusy = true;

            await Shell.Current.ShowPopupAsync(new ChangeIdPopup());

            UpdateUserId();

            IsBusy = false;
        }

        [RelayCommand]
        async Task CopyIdToClipboard()
        {
            if (IsBusy) return;

            IsBusy = true;

            await Clipboard.Default.SetTextAsync(Id);

            await Toast.Make("ID copiado al portapapeles").Show();

            IsBusy = false;
        }

        public void UpdateUserId()
        {
            Id = ActualUser.Id.ToString();
        }
    }
}
