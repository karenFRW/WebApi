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
    public class tTeachersController : ApiController
    {
        private letnobookEntities db = new letnobookEntities();

        // GET: api/tTeachers
        public IQueryable<tTeacher> GettTeachers()
        {
            return db.tTeachers;
        }

        // GET: api/tTeachers/5
        [ResponseType(typeof(tTeacher))]
        public IHttpActionResult GettTeacher(int id)
        {
            tTeacher tTeacher = db.tTeachers.Find(id);
            if (tTeacher == null)
            {
                return NotFound();
            }

            return Ok(tTeacher);
        }

        // PUT: api/tTeachers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttTeacher(int id, tTeacher tTeacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tTeacher.f老師編號)
            {
                return BadRequest();
            }

            db.Entry(tTeacher).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tTeacherExists(id))
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

        // POST: api/tTeachers
        [ResponseType(typeof(tTeacher))]
        public IHttpActionResult PosttTeacher(tTeacher tTeacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tTeachers.Add(tTeacher);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tTeacher.f老師編號 }, tTeacher);
        }

        // DELETE: api/tTeachers/5
        [ResponseType(typeof(tTeacher))]
        public IHttpActionResult DeletetTeacher(int id)
        {
            tTeacher tTeacher = db.tTeachers.Find(id);
            if (tTeacher == null)
            {
                return NotFound();
            }

            db.tTeachers.Remove(tTeacher);
            db.SaveChanges();

            return Ok(tTeacher);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tTeacherExists(int id)
        {
            return db.tTeachers.Count(e => e.f老師編號 == id) > 0;
        }
    }
}