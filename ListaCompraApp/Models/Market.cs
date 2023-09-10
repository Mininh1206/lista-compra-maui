using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaCompraApp.Models
{
    public partial class Market : ObservableObject
    {
        public Market()
        {
            Name = string.Empty;
            List = new();
        }

        public Market(string name)
        {
            Name = name;
            List = new();
        }

        public Market(string name, ObservableCollection<Item> list)
        {
            Name = name;
            
            List = list;
        }

        [ObservableProperty]
        string name;

        public ObservableCollection<Item> List { get; set; }
    }
}
