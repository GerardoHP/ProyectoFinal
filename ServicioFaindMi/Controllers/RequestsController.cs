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

    public class RequestsController : ApiController
    {
        private RequestRepositorio _repo = new RequestRepositorio();

        // GET: api/Requests
        public List<RequestDTO> GetRequests()
        {
            var listado = AutoMapper.Mapper.Map<List<Request>, List<RequestDTO>>(this._repo.ObtenerObjeto());
            return listado;
        }

        // GET: api/Requests/5
        [ResponseType(typeof(RequestDTO))]
        public IHttpActionResult GetRequest(string id)
        {
            var request = Mapper.Map<Request, RequestDTO>(this._repo.ObtenerObjeto(id));
            if (request == null)
            {
                return NotFound();
            }

            return Ok(request);
        }

        // PUT: api/Requests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRequest(string id, RequestDTO request)
        {
            var idRelation = Guid.Parse(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.RequestId)
            {
                return BadRequest();
            }

            try
            {
                this._repo.ActualizarObjeto(id, Mapper.Map<RequestDTO, Request>(request));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(idRelation))
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

        // POST: api/Requests
        [ResponseType(typeof(RequestDTO))]
        public IHttpActionResult PostRequest(RequestDTO requestDto)
        {
            var request = AutoMapper.Mapper.Map<RequestDTO, Request>(requestDto);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                this._repo.AgregarObjeto(ref request);
                requestDto.RequestId = request.RequestId.ToString();
            }
            catch (DbUpdateException)
            {
                if (RequestExists(request.RequestId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = requestDto.RequestId }, requestDto);
        }

        // DELETE: api/Requests/5
        [ResponseType(typeof(RequestDTO))]
        public IHttpActionResult DeleteRequest(string id)
        {
            var request = Mapper.Map<Request, RequestDTO>(this._repo.ObtenerObjeto(id));
            if (request == null)
            {
                return NotFound();
            }

            this._repo.EliminarObjeto(id);

            return Ok(request);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._repo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestExists(Guid id)
        {
            return this._repo.ObtenerObjeto(id.ToString()) != null;
        }
    }
}