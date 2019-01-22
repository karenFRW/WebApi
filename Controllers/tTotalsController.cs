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
using WebApi.Models;

namespace WebApi.Controllers
{
    public class tTotalsController : ApiController
    {
        private letnobookEntities db = new letnobookEntities();

        // GET: api/tTotals
        public IQueryable<tTotal> GettTotals()
        {
            return db.tTotals;
        }

        // GET: api/tTotals/5
        [ResponseType(typeof(tTotal))]
        public IHttpActionResult GettTotal(string id)
        {
            tTotal tTotal = db.tTotals.Find(id);
            if (tTotal == null)
            {
                return NotFound();
            }

            return Ok(tTotal);
        }

        // PUT: api/tTotals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttTotal(string id, tTotal tTotal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tTotal.f身份區分)
            {
                return BadRequest();
            }

            db.Entry(tTotal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tTotalExists(id))
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

        // POST: api/tTotals
        [ResponseType(typeof(tTotal))]
        public IHttpActionResult PosttTotal(tTotal tTotal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tTotals.Add(tTotal);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tTotalExists(tTotal.f身份區分))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tTotal.f身份區分 }, tTotal);
        }

        // DELETE: api/tTotals/5
        [ResponseType(typeof(tTotal))]
        public IHttpActionResult DeletetTotal(string id)
        {
            tTotal tTotal = db.tTotals.Find(id);
            if (tTotal == null)
            {
                return NotFound();
            }

            db.tTotals.Remove(tTotal);
            db.SaveChanges();

            return Ok(tTotal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tTotalExists(string id)
        {
            return db.tTotals.Count(e => e.f身份區分 == id) > 0;
        }
    }
}