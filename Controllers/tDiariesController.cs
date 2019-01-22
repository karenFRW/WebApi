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
    public class tDiariesController : ApiController
    {
        private letnobookEntities db = new letnobookEntities();

        // GET: api/tDiaries
        public IQueryable<tDiary> GettDiaries()
        {
            return db.tDiaries;
        }

        // GET: api/tDiaries/5
        [ResponseType(typeof(tDiary))]
        public IHttpActionResult GettDiary(int id)
        {
            tDiary tDiary = db.tDiaries.Find(id);
            if (tDiary == null)
            {
                return NotFound();
            }

            return Ok(tDiary);
        }

        // PUT: api/tDiaries/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttDiary(int id, tDiary tDiary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tDiary.f日誌編號)
            {
                return BadRequest();
            }

            db.Entry(tDiary).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tDiaryExists(id))
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

        // POST: api/tDiaries
        [ResponseType(typeof(tDiary))]
        public IHttpActionResult PosttDiary(tDiary tDiary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tDiaries.Add(tDiary);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tDiary.f日誌編號 }, tDiary);
        }

        // DELETE: api/tDiaries/5
        [ResponseType(typeof(tDiary))]
        public IHttpActionResult DeletetDiary(int id)
        {
            tDiary tDiary = db.tDiaries.Find(id);
            if (tDiary == null)
            {
                return NotFound();
            }

            db.tDiaries.Remove(tDiary);
            db.SaveChanges();

            return Ok(tDiary);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tDiaryExists(int id)
        {
            return db.tDiaries.Count(e => e.f日誌編號 == id) > 0;
        }
    }
}