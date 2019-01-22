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
    public class tCommunicationsController : ApiController
    {
        private letnobookEntities db = new letnobookEntities();

        // GET: api/tCommunications
        public IQueryable<tCommunication> GettCommunications()
        {
            return db.tCommunications;
        }

        // GET: api/tCommunications/5
        [ResponseType(typeof(tCommunication))]
        public IHttpActionResult GettCommunication(int id)
        {
            tCommunication tCommunication = db.tCommunications.Find(id);
            if (tCommunication == null)
            {
                return NotFound();
            }

            return Ok(tCommunication);
        }

        // PUT: api/tCommunications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttCommunication(int id, tCommunication tCommunication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tCommunication.f交流編號)
            {
                return BadRequest();
            }

            db.Entry(tCommunication).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tCommunicationExists(id))
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

        // POST: api/tCommunications
        [ResponseType(typeof(tCommunication))]
        public IHttpActionResult PosttCommunication(tCommunication tCommunication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tCommunications.Add(tCommunication);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tCommunication.f交流編號 }, tCommunication);
        }

        // DELETE: api/tCommunications/5
        [ResponseType(typeof(tCommunication))]
        public IHttpActionResult DeletetCommunication(int id)
        {
            tCommunication tCommunication = db.tCommunications.Find(id);
            if (tCommunication == null)
            {
                return NotFound();
            }

            db.tCommunications.Remove(tCommunication);
            db.SaveChanges();

            return Ok(tCommunication);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tCommunicationExists(int id)
        {
            return db.tCommunications.Count(e => e.f交流編號 == id) > 0;
        }
    }
}