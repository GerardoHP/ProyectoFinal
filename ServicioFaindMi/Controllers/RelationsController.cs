using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ServicioFaindMi.Controllers
{
    using AutoMapper;
    using Common.DataModels;
    using Common.Models;
    using CommonPortable.Models;
    using ServicioFaindMi.Models;
    using ServicioFaindMi.Repositorio;

    public class RelationsController : ApiController
    {
        private RelationRepositorio _repo = new RelationRepositorio();

        // GET: api/Relations
        public List<RelationDTO> GetRelations()
        {
            var listado = _repo.ObtenerObjeto();
            return AutoMapper.Mapper.Map<List<Relation>, List<RelationDTO>>(listado);
        }

        // GET: api/Relations/5
        [ResponseType(typeof(List<RelationDTO>))]
        public IHttpActionResult GetRelation(string id)
        {
            var relation = _repo.ObtenerObjeto(id);
            if (relation == null)
            {
                return NotFound();
            }

            return Ok(AutoMapper.Mapper.Map<Relation, RelationDTO>(relation));
        }

        // PUT: api/Relation/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRelation(string id, RelationDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.RelationId.ToString())
            {
                return BadRequest();
            }

            try
            {
                this._repo.ActualizarObjeto(id, Mapper.Map<RelationDTO, Relation>(request));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Relations
        [ResponseType(typeof(Relation))]
        public IHttpActionResult PostRelation(RelationDTO relationDto)
        {
            var relation = Mapper.Map<RelationDTO, Relation>(relationDto);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this._repo.AgregarObjeto(ref relation);
            relationDto.RelationId = relation.RelationId;

            return CreatedAtRoute("DefaultApi", new { id = relationDto.RelationId }, relationDto);
        }

        // DELETE: api/Relations/5
        [ResponseType(typeof(Relation))]
        public IHttpActionResult DeleteRelation(string id)
        {
            var relation = Mapper.Map<Relation, RelationDTO>(this._repo.ObtenerObjeto(id));
            if (relation == null)
            {
                return NotFound();
            }

            this._repo.EliminarObjeto(id);
            return Ok(relation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RelationExists(string id)
        {
            return this._repo.ObtenerObjeto(id) != null;
        }
    }
}