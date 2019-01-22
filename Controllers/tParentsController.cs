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
    public class tParentsController : ApiController
    {
        private letnobookEntities db = new letnobookEntities();

        // GET: api/tParents
        public IQueryable<tParent> GettParents()
        {
            return db.tParents;
        }

        // GET: api/tParents/5
        [ResponseType(typeof(tParent))]
        public IHttpActionResult GettParent(int id)
        {
            tParent tParent = db.tParents.Find(id);
            if (tParent == null)
            {
                return NotFound();
            }

            return Ok(tParent);
        }

        // PUT: api/tParents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttParent(int id, tParent tParent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tParent.f家庭編號)
            {
                return BadRequest();
            }

            db.Entry(tParent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tParentExists(id))
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

        // POST: api/tParents
        [ResponseType(typeof(tParent))]
        public IHttpActionResult PosttParent(tParent tParent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tParents.Add(tParent);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tParent.f家庭編號 }, tParent);
        }

        // DELETE: api/tParents/5
        [ResponseType(typeof(tParent))]
        public IHttpActionResult DeletetParent(int id)
        {
            tParent tParent = db.tParents.Find(id);
            if (tParent == null)
            {
                return NotFound();
            }

            db.tParents.Remove(tParent);
            db.SaveChanges();

            return Ok(tParent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tParentExists(int id)
        {
            return db.tParents.Count(e => e.f家庭編號 == id) > 0;
        }
    }
}