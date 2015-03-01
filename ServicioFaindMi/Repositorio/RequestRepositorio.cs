using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioFaindMi.Repositorio
{
    using Common.Models;
    using CommonPortable.Models;

    public class RequestRepositorio : IRepositorioBase<Request>, IDisposable
    {
        #region Campos

        private faindmiService_dbEntities _db;

        #endregion

        #region Constructores

        public RequestRepositorio()
        {
            this._db = new faindmiService_dbEntities();
        }

        #endregion

        #region Métodos Públicos

        public void ActualizarObjeto(string id, Request objeto)
        {
            var objetoViejo = this.ObtenerObjeto(id);
            objetoViejo.Accepted = objeto.Accepted;
            objetoViejo.Finished = objeto.Finished;
            objetoViejo.LatFirstUser = objetoViejo.LatFirstUser;
            objetoViejo.LatSecondUser = objetoViejo.LatSecondUser;
            objetoViejo.LngFirstUser = objetoViejo.LngFirstUser;
            objetoViejo.LngSecondUser = objetoViejo.LngSecondUser;
            this._db.SaveChanges();
        }

        public void AgregarObjeto(ref Request objeto)
        {
            this._db.Requests.Add(objeto);
            this._db.SaveChanges();
        }

        public void EliminarObjeto(string id)
        {
            var objeto = this.ObtenerObjeto(id);
            this._db.Requests.Remove(objeto);
            this._db.SaveChanges();
        }

        public List<Request> ObtenerObjeto()
        {
            return this._db.Requests.ToList();
        }

        public Request ObtenerObjeto(string id)
        {
            var idGuid = Guid.Parse(id);
            return this._db.Requests.Single(x => x.RequestId == idGuid);
        }

        public void Dispose()
        {
            this._db.Dispose();
        }

        #endregion
    }
}