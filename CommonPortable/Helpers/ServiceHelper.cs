using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Helpers
{
    using RestSharp;
    using RestSharp.Portable;

    public class ServiceHelper
    {
        #region Campos

        private Uri BaseUrl;

        #endregion

        #region Constructores

        public  ServiceHelper(string servicio = null)
        {
            this.BaseUrl = string.IsNullOrEmpty(servicio) ? new Uri("http://serviciofaindmi.azurewebsites.net") : new Uri(servicio);
        }

        #endregion

        #region Métodos Publicos

        public Task<IRestResponse< T>> ExecuteAsync<T>(RestRequest request, Dictionary<string, string> parametros) where T : new()
        {
            var client = new RestClient();
            var taskCompletionSource = new TaskCompletionSource<T>();
            client.BaseUrl = this.BaseUrl;
            if (parametros != null)
            {
                foreach (var parametro in parametros)
                {
                    request.AddParameter(parametro.Key, parametro.Value);
                }
            }

            return client.Execute<T>(request); // (request, (response) => taskCompletionSource.SetResult(response.Data));
        }

        #endregion
    }
}
