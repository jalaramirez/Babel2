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
    public class REL_PLAN_COBERController : ApiController
    {
        private Data db = new Data();

        // GET: api/REL_PLAN_COBER
        public IQueryable<REL_PLAN_COBER> GetREL_PLAN_COBER()
        {
            return db.REL_PLAN_COBER;
        }

        // GET: api/REL_PLAN_COBER/5
        [ResponseType(typeof(REL_PLAN_COBER))]
        public IHttpActionResult GetREL_PLAN_COBER(int id)
        {
            REL_PLAN_COBER rEL_PLAN_COBER = db.REL_PLAN_COBER.Find(id);
            if (rEL_PLAN_COBER == null)
            {
                return NotFound();
            }

            return Ok(rEL_PLAN_COBER);
        }

        // PUT: api/REL_PLAN_COBER/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutREL_PLAN_COBER(int id, REL_PLAN_COBER rEL_PLAN_COBER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rEL_PLAN_COBER.IDpc)
            {
                return BadRequest();
            }

            db.Entry(rEL_PLAN_COBER).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!REL_PLAN_COBERExists(id))
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

        // POST: api/REL_PLAN_COBER
        [ResponseType(typeof(REL_PLAN_COBER))]
        public IHttpActionResult PostREL_PLAN_COBER(REL_PLAN_COBER rEL_PLAN_COBER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.REL_PLAN_COBER.Add(rEL_PLAN_COBER);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (REL_PLAN_COBERExists(rEL_PLAN_COBER.IDpc))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rEL_PLAN_COBER.IDpc }, rEL_PLAN_COBER);
        }

        // DELETE: api/REL_PLAN_COBER/5
        [ResponseType(typeof(REL_PLAN_COBER))]
        public IHttpActionResult DeleteREL_PLAN_COBER(int id)
        {
            REL_PLAN_COBER rEL_PLAN_COBER = db.REL_PLAN_COBER.Find(id);
            if (rEL_PLAN_COBER == null)
            {
                return NotFound();
            }

            db.REL_PLAN_COBER.Remove(rEL_PLAN_COBER);
            db.SaveChanges();

            return Ok(rEL_PLAN_COBER);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool REL_PLAN_COBERExists(int id)
        {
            return db.REL_PLAN_COBER.Count(e => e.IDpc == id) > 0;
        }
    }
}