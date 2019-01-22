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
    public class tStudentsController : ApiController
    {
        private letnobookEntities db = new letnobookEntities();

        // GET: api/tStudents
        public IQueryable<tStudent> GettStudents()
        {
            return db.tStudents;
        }

        // GET: api/tStudents/5
        [ResponseType(typeof(tStudent))]
        public IHttpActionResult GettStudent(int id)
        {
            tStudent tStudent = db.tStudents.Find(id);
            if (tStudent == null)
            {
                return NotFound();
            }

            return Ok(tStudent);
        }

        // PUT: api/tStudents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttStudent(int id, tStudent tStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tStudent.f學生編號)
            {
                return BadRequest();
            }

            db.Entry(tStudent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tStudentExists(id))
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

        // POST: api/tStudents
        [ResponseType(typeof(tStudent))]
        public IHttpActionResult PosttStudent(tStudent tStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tStudents.Add(tStudent);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tStudent.f學生編號 }, tStudent);
        }

        // DELETE: api/tStudents/5
        [ResponseType(typeof(tStudent))]
        public IHttpActionResult DeletetStudent(int id)
        {
            tStudent tStudent = db.tStudents.Find(id);
            if (tStudent == null)
            {
                return NotFound();
            }

            db.tStudents.Remove(tStudent);
            db.SaveChanges();

            return Ok(tStudent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tStudentExists(int id)
        {
            return db.tStudents.Count(e => e.f學生編號 == id) > 0;
        }
    }
}