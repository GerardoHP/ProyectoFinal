using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicioFaindMi.Repositorio
{
    using Common.Models;

    public class RelationRepositorio : IRepositorioBase<Relation>, IDisposable
    {
        #region Campos

        private faindmiService_dbEntities _db;

        #endregion

        #region Constructores

        public RelationRepositorio()
        {
            this._db = new faindmiService_dbEntities();
        }

        #endregion

        #region Métodos Públicos

        public void ActualizarObjeto(string id, Relation objeto)
        {
            throw new Exception("No se puede actualizar una relación.");
        }

        public void AgregarObjeto(ref Relation objeto)
        {
            this._db.Relations.Add(objeto);
            this._db.SaveChanges();
        }

        public void EliminarObjeto(string id)
        {
            var objeto = this.ObtenerObjeto(id);
            this._db.Relations.Remove(objeto);
            this._db.SaveChanges();
        }

        public List<Relation> ObtenerObjeto()
        {
            return this._db.Relations.ToList();
        }

        public Relation ObtenerObjeto(string id)
        {
            var idInt = int.Parse(id);
            return this._db.Relations.Single(x => x.RelationId == idInt);
        }

        public void Dispose()
        {
            this._db.Dispose();
        }

        #endregion

    }
}