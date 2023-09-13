using ListaCompraApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaCompraApp.Helpers
{
    public static class ActualUserHelper
    {
        /// <summary>
        /// Crea una nueva id y la guarda en SecureStorage
        /// </summary>
        /// <returns>Id creada</returns>
        public static Guid CreateUser()
        {
            try
            {
                Guid id = Guid.NewGuid();

                SecureStorage.SetAsync(Constants.UserId, id.ToString()).Wait();
                return id;
            }
            catch
            {
                Console.WriteLine("Failed creating user");
                return Guid.Empty;
            }
        }

        /// <summary>
        /// Guarda en SecureStorage el <paramref name="id"/>
        /// </summary>
        /// <param name="id">nueva id</param>
        /// <returns>Id actualizada correctamente</returns>
        public static bool UpdateUser(Guid id)
        {
            try
            {
                SecureStorage.SetAsync(Constants.UserId, id.ToString()).Wait();

                return true;
            }
            catch
            {
                Console.WriteLine("Failed updating user");
                return false;
            }
        }

        /// <summary>
        /// Saca de SecureStorage el id del usuario guardado.
        /// </summary>
        /// <returns>Id del usuario guardado</returns>
        public static Guid GetUser()
        {
            try
            {
                string id = SecureStorage.GetAsync(Constants.UserId).Result;

                return Guid.Parse(id);
            }
            catch
            {
                Console.WriteLine("Failed getting user");
                return Guid.Empty;
            }
        }
    }
}
