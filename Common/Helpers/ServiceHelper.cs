using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Helpers
{
    using RestSharp;

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

        public Task<T> ExecuteAsync<T>(RestRequest request, Dictionary<string, string> parametros) where T : new()
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

            client.ExecuteAsync<T>(request, (response) => taskCompletionSource.SetResult(response.Data));
            return taskCompletionSource.Task;
        }

        #endregion
    }
}
