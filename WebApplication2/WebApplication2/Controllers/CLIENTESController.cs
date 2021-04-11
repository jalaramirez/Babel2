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
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CLIENTESController : ApiController
    {
        private Data db = new Data();

        // GET: api/CLIENTES
        public IQueryable<CLIENTES> GetCLIENTES()
        {
            return db.CLIENTES;
        }

        // GET: api/CLIENTES/5
        [ResponseType(typeof(CLIENTES))]
        public IHttpActionResult GetCLIENTES(int id)
        {
            CLIENTES cLIENTES = db.CLIENTES.Find(id);
            if (cLIENTES == null)
            {
                return NotFound();
            }

            return Ok(cLIENTES);
        }

        // PUT: api/CLIENTES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCLIENTES(int id, CLIENTES cLIENTES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cLIENTES.IDCLIENTE)
            {
                return BadRequest();
            }

            db.Entry(cLIENTES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CLIENTESExists(id))
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

        // POST: api/CLIENTES
        [ResponseType(typeof(CLIENTES))]
        public IHttpActionResult PostCLIENTES(CLIENTES cLIENTES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CLIENTES.Add(cLIENTES);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CLIENTESExists(cLIENTES.IDCLIENTE))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cLIENTES.IDCLIENTE }, cLIENTES);
        }

        // DELETE: api/CLIENTES/5
        [ResponseType(typeof(CLIENTES))]
        public IHttpActionResult DeleteCLIENTES(int id)
        {
            CLIENTES cLIENTES = db.CLIENTES.Find(id);
            if (cLIENTES == null)
            {
                return NotFound();
            }

            db.CLIENTES.Remove(cLIENTES);
            db.SaveChanges();

            return Ok(cLIENTES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CLIENTESExists(int id)
        {
            return db.CLIENTES.Count(e => e.IDCLIENTE == id) > 0;
        }
    }
}