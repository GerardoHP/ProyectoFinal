using System.Collections.Generic;
using System.Linq;

namespace ServicioFaindMi.Repositorio
{
    using Common.Models;
    using System;

    public class UsrsRepositorio : IRepositorioBase<Usr>, IDisposable
    {
        #region Campos

        private faindmiService_dbEntities _db;

        #endregion

        #region Constructores

        public UsrsRepositorio()
        {
            this._db = new faindmiService_dbEntities();
        }

        #endregion

        #region Métodos Públicos

        public void ActualizarObjeto(string id, Usr objeto)
        {
            var objetoViejo = this.ObtenerObjeto(id);
            objetoViejo.Mail = objeto.Mail;
            objetoViejo.Pass = objeto.Pass;
            objetoViejo.Verified = objeto.Verified;
            this._db.SaveChanges();
        }

        public void AgregarObjeto(ref Usr objeto)
        {
            this._db.Usrs.Add(objeto);
            this._db.SaveChanges();
        }

        public void EliminarObjeto(string id)
        {
            var objetoViejo = this.ObtenerObjeto(id);
            this._db.Usrs.Remove(objetoViejo);
            this._db.SaveChanges();
        }

        public List<Usr> ObtenerObjeto()
        {
            return this._db.Usrs.ToList();
        }

        public Usr ObtenerObjeto(string id)
        {
            var idInt = int.Parse(id);
            return this._db.Usrs.Single(x => x.UserId == idInt);
        }

        public void Dispose()
        {
            this._db.Dispose();
        }

        #endregion
    }
} 