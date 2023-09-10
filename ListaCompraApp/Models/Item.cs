using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaCompraApp.Models
{
    public partial class Item : ObservableObject
    {
        public Item(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            InCar = false;
        }

        public Guid Id { get; set; }

        [ObservableProperty]
        string name;

        [ObservableProperty]
        bool inCar;
    }
}
