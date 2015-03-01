using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Pruebas
{
    using Common.DataModels;
    using Common.Helpers;
    using RestSharp.Portable;

    class Program
    {
        static void Main(string[] args)
        {
            PruebaServicio();
            Console.ReadKey();
        }

        private static async void PruebaServicio()
        {
            var servicio = new ServiceHelper();
            
            var request = new RestRequest("Usrs/2", HttpMethod.Get);
            var parametros = new Dictionary<string, string>();
            //parametros.Add("lat", latitud);
            //parametros.Add("lng", longitud);
            //parametros.Add("username", "gerardohp");

            var ubicacion = await servicio.ExecuteAsync<UsrDTO>(request, parametros);
            Console.WriteLine(ubicacion);
        }
    }
}
