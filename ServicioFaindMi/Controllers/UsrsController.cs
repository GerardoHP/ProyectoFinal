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

    public class UsrsController : ApiController
    {
        private UsrsRepositorio _repo = new UsrsRepositorio();

        // GET: api/Usrs
        public List<UsrDTO> GetUsrs()
        {
            var listado = this._repo.ObtenerObjeto();
            return Mapper.Map<List<Usr>, List<UsrDTO>>(listado);
        }

        // GET: api/Usrs/5
        [ResponseType(typeof(UsrDTO))]
        public IHttpActionResult GetUsr(string id)
        {
            Usr usr = this._repo.ObtenerObjeto(id);
            if (usr == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Usr, UsrDTO>(usr));
        }

        // PUT: api/Usr/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsr(string id, UsrDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.UserId.ToString())
            {
                return BadRequest();
            }

            try
            {
                this._repo.ActualizarObjeto(id, Mapper.Map<UsrDTO, Usr>(request));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsrExists(id))
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

        // POST: api/Usrs
        [ResponseType(typeof(UsrDTO))]
        public IHttpActionResult PostUsr(UsrDTO usrDto)
        {
            var usr = Mapper.Map<UsrDTO, Usr>(usrDto);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this._repo.AgregarObjeto(ref usr);
            usrDto.UserId = usr.UserId;

            return CreatedAtRoute("DefaultApi", new { id = usrDto.UserId }, usrDto);
        }

        // DELETE: api/Usrs/5
        [ResponseType(typeof(Usr))]
        public IHttpActionResult DeleteUsr(string id)
        {
            var usr = Mapper.Map<Usr, UsrDTO>(this._repo.ObtenerObjeto(id));
            if (usr == null)
            {
                return NotFound();
            }

            this._repo.EliminarObjeto(id);
            return Ok(usr);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._repo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsrExists(string id)
        {
            return this._repo.ObtenerObjeto(id) != null;
        }
    }
}