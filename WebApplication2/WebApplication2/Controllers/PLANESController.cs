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
    public class PLANESController : ApiController
    {
        private Data db = new Data();

        // GET: api/PLANES
        public IQueryable<PLANES> GetPLANES()
        {
            return db.PLANES;
        }

        // GET: api/PLANES/5
        [ResponseType(typeof(PLANES))]
        public IHttpActionResult GetPLANES(int id)
        {
            PLANES pLANES = db.PLANES.Find(id);
            if (pLANES == null)
            {
                return NotFound();
            }

            return Ok(pLANES);
        }

        // PUT: api/PLANES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPLANES(int id, PLANES pLANES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pLANES.IDPLAN)
            {
                return BadRequest();
            }

            db.Entry(pLANES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PLANESExists(id))
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

        // POST: api/PLANES
        [ResponseType(typeof(PLANES))]
        public IHttpActionResult PostPLANES(PLANES pLANES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PLANES.Add(pLANES);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PLANESExists(pLANES.IDPLAN))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pLANES.IDPLAN }, pLANES);
        }

        // DELETE: api/PLANES/5
        [ResponseType(typeof(PLANES))]
        public IHttpActionResult DeletePLANES(int id)
        {
            PLANES pLANES = db.PLANES.Find(id);
            if (pLANES == null)
            {
                return NotFound();
            }

            db.PLANES.Remove(pLANES);
            db.SaveChanges();

            return Ok(pLANES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PLANESExists(int id)
        {
            return db.PLANES.Count(e => e.IDPLAN == id) > 0;
        }
    }
}