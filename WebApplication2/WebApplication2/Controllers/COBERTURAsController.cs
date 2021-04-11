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
    public class COBERTURAsController : ApiController
    {
        private Data db = new Data();

        // GET: api/COBERTURAs
        public IQueryable<COBERTURA> GetCOBERTURA()
        {
            return db.COBERTURA;
        }

        // GET: api/COBERTURAs/5
        [ResponseType(typeof(COBERTURA))]
        public IHttpActionResult GetCOBERTURA(int id)
        {
            COBERTURA cOBERTURA = db.COBERTURA.Find(id);
            if (cOBERTURA == null)
            {
                return NotFound();
            }

            return Ok(cOBERTURA);
        }

        // PUT: api/COBERTURAs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCOBERTURA(int id, COBERTURA cOBERTURA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cOBERTURA.IDCOBERTURA)
            {
                return BadRequest();
            }

            db.Entry(cOBERTURA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!COBERTURAExists(id))
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

        // POST: api/COBERTURAs
        [ResponseType(typeof(COBERTURA))]
        public IHttpActionResult PostCOBERTURA(COBERTURA cOBERTURA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.COBERTURA.Add(cOBERTURA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (COBERTURAExists(cOBERTURA.IDCOBERTURA))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cOBERTURA.IDCOBERTURA }, cOBERTURA);
        }

        // DELETE: api/COBERTURAs/5
        [ResponseType(typeof(COBERTURA))]
        public IHttpActionResult DeleteCOBERTURA(int id)
        {
            COBERTURA cOBERTURA = db.COBERTURA.Find(id);
            if (cOBERTURA == null)
            {
                return NotFound();
            }

            db.COBERTURA.Remove(cOBERTURA);
            db.SaveChanges();

            return Ok(cOBERTURA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool COBERTURAExists(int id)
        {
            return db.COBERTURA.Count(e => e.IDCOBERTURA == id) > 0;
        }
    }
}