using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaindMiApp.Common
{
    public static class Utilidades
    {
        #region Métodos Públicos

        /// <summary>
        /// Se encarga de obtener un valor del IsolatedStorageSettings.
        /// </summary>
        /// <typeparam name="T">Tipo a devolver.</typeparam>
        /// <param name="clave">Clave con la cual fue almacenado el valor.</param>
        /// <param name="valor">Valor a guardar,</param>
        /// <returns>Indica si se pudo obtener el valor.</returns>
        public static bool ObtenerSetting<T>(string clave, out T valor)
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains(clave))
            {
                valor = (T)IsolatedStorageSettings.ApplicationSettings[clave];
                return true;
            }
            else
            {
                valor = default(T);
                return false;
            }
        }

        /// <summary>
        /// Guarda un valor en el IsolatedStorageSettings.
        /// </summary>
        /// <param name="clave">Clave con la cual se desea guardar.</param>
        /// <param name="valor"></param>
        public void GuardarSetting(string clave, object valor)
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains(clave))
            {
                IsolatedStorageSettings.ApplicationSettings[clave] = valor;
                return;
            }

            IsolatedStorageSettings.ApplicationSettings.Add(clave, valor);
        }

        #endregion
    }
}
