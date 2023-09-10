using Firebase.Database;
using Firebase.Database.Query;
using ListaCompraApp.Helpers;
using ListaCompraApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaCompraApp.Services
{
    public class FirebaseService
    {
        private readonly FirebaseClient fbc = null;

        public FirebaseService()
        {
            fbc = new FirebaseClient(Constants.FirebaseURLDatabase);
        }

        public ChildQuery GetChild(string child)
        {
            return fbc.Child(child);
        }

        public ChildQuery GetActualUserChild()
        {
            return fbc.Child(ActualUser.Id.ToString());
        }

        public async void Put<T>(T data)
        {
            await fbc.Child(ActualUser.Id.ToString()).PutAsync(data);
        }

        public async void PutInChild<T>(string child, T data)
        {
            await fbc.Child(ActualUser.Id.ToString()).Child(child).PutAsync(data);
        }

        public async void RemoveChild(string child)
        {
            await fbc.Child(ActualUser.Id.ToString()).Child(child).DeleteAsync();
        }
    }
}
