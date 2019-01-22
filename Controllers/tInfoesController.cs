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
    public class tInfoesController : ApiController
    {
        private letnobookEntities db = new letnobookEntities();

        // GET: api/tInfoes
        public IQueryable<tInfo> GettInfoes()
        {
            return db.tInfoes;
        }

        // GET: api/tInfoes/5
        [ResponseType(typeof(tInfo))]
        public IHttpActionResult GettInfo(int id)
        {
            tInfo tInfo = db.tInfoes.Find(id);
            if (tInfo == null)
            {
                return NotFound();
            }

            return Ok(tInfo);
        }

        // PUT: api/tInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttInfo(int id, tInfo tInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tInfo.fInfoId)
            {
                return BadRequest();
            }

            db.Entry(tInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tInfoExists(id))
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

        // POST: api/tInfoes
        [ResponseType(typeof(tInfo))]
        public IHttpActionResult PosttInfo(tInfo tInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tInfoes.Add(tInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tInfo.fInfoId }, tInfo);
        }

        // DELETE: api/tInfoes/5
        [ResponseType(typeof(tInfo))]
        public IHttpActionResult DeletetInfo(int id)
        {
            tInfo tInfo = db.tInfoes.Find(id);
            if (tInfo == null)
            {
                return NotFound();
            }

            db.tInfoes.Remove(tInfo);
            db.SaveChanges();

            return Ok(tInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tInfoExists(int id)
        {
            return db.tInfoes.Count(e => e.fInfoId == id) > 0;
        }
    }
}