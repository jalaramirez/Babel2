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
    public class REL_CLIENTE_PLANController : ApiController
    {
        private Data db = new Data();

        // GET: api/REL_CLIENTE_PLAN
        public IQueryable<REL_CLIENTE_PLAN> GetREL_CLIENTE_PLAN()
        {
            
            var aux = db.REL_CLIENTE_PLAN;

            
            return aux;
        }

        // GET: api/REL_CLIENTE_PLAN/5
        [ResponseType(typeof(REL_CLIENTE_PLAN))]
        public IHttpActionResult GetREL_CLIENTE_PLAN(int id)
        {
            REL_CLIENTE_PLAN rEL_CLIENTE_PLAN = db.REL_CLIENTE_PLAN.Find(id);
            if (rEL_CLIENTE_PLAN == null)
            {
                return NotFound();
            }

            return Ok(rEL_CLIENTE_PLAN);
        }

        // PUT: api/REL_CLIENTE_PLAN/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutREL_CLIENTE_PLAN(int id, REL_CLIENTE_PLAN rEL_CLIENTE_PLAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rEL_CLIENTE_PLAN.IDCP)
            {
                return BadRequest();
            }

            db.Entry(rEL_CLIENTE_PLAN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!REL_CLIENTE_PLANExists(id))
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

        // POST: api/REL_CLIENTE_PLAN
        [ResponseType(typeof(REL_CLIENTE_PLAN))]
        public IHttpActionResult PostREL_CLIENTE_PLAN(REL_CLIENTE_PLAN rEL_CLIENTE_PLAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.REL_CLIENTE_PLAN.Add(rEL_CLIENTE_PLAN);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (REL_CLIENTE_PLANExists(rEL_CLIENTE_PLAN.IDCP))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rEL_CLIENTE_PLAN.IDCP }, rEL_CLIENTE_PLAN);
        }

        // DELETE: api/REL_CLIENTE_PLAN/5
        [ResponseType(typeof(REL_CLIENTE_PLAN))]
        public IHttpActionResult DeleteREL_CLIENTE_PLAN(int id)
        {
            REL_CLIENTE_PLAN rEL_CLIENTE_PLAN = db.REL_CLIENTE_PLAN.Find(id);
            if (rEL_CLIENTE_PLAN == null)
            {
                return NotFound();
            }

            db.REL_CLIENTE_PLAN.Remove(rEL_CLIENTE_PLAN);
            db.SaveChanges();

            return Ok(rEL_CLIENTE_PLAN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool REL_CLIENTE_PLANExists(int id)
        {
            return db.REL_CLIENTE_PLAN.Count(e => e.IDCP == id) > 0;
        }
    }
}