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
    public class tClassesController : ApiController
    {
        private letnobookEntities db = new letnobookEntities();

        // GET: api/tClasses
        public IQueryable<tClass> GettClasses()
        {
            return db.tClasses;
        }

        // GET: api/tClasses/5
        [ResponseType(typeof(tClass))]
        public IHttpActionResult GettClass(int id)
        {
            tClass tClass = db.tClasses.Find(id);
            if (tClass == null)
            {
                return NotFound();
            }

            return Ok(tClass);
        }

        // PUT: api/tClasses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttClass(int id, tClass tClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tClass.fClassId)
            {
                return BadRequest();
            }

            db.Entry(tClass).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tClassExists(id))
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

        // POST: api/tClasses
        [ResponseType(typeof(tClass))]
        public IHttpActionResult PosttClass(tClass tClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tClasses.Add(tClass);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tClass.fClassId }, tClass);
        }

        // DELETE: api/tClasses/5
        [ResponseType(typeof(tClass))]
        public IHttpActionResult DeletetClass(int id)
        {
            tClass tClass = db.tClasses.Find(id);
            if (tClass == null)
            {
                return NotFound();
            }

            db.tClasses.Remove(tClass);
            db.SaveChanges();

            return Ok(tClass);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tClassExists(int id)
        {
            return db.tClasses.Count(e => e.fClassId == id) > 0;
        }
    }
}