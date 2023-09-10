using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaCompraApp.Helpers
{
    public static class ActualUserHelper
    {
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
