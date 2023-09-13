using ListaCompraApp.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaCompraApp.Models
{
    public static class ActualUser
    {
        private static Guid id = Guid.Empty;

        /// <summary>
        /// Coge o cambia la Id con ayuda de ActualUserHelper
        /// </summary>
        public static Guid Id
        {
            get
            {
                if (id.Equals(Guid.Empty))
                {
                    id = ActualUserHelper.GetUser();

                    if (id.Equals(Guid.Empty))
                    {
                        id = ActualUserHelper.CreateUser();
                    }
                }

                return id;
            }

            set
            {
                id = value;

                ActualUserHelper.UpdateUser(id);
            }
        }
    }
}
