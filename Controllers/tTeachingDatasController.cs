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
    public class tTeachingDatasController : ApiController
    {
        private letnobookEntities db = new letnobookEntities();

        // GET: api/tTeachingDatas
        public IQueryable<tTeachingData> GettTeachingDatas()
        {
            return db.tTeachingDatas;
        }

        // GET: api/tTeachingDatas/5
        [ResponseType(typeof(tTeachingData))]
        public IHttpActionResult GettTeachingData(int id)
        {
            tTeachingData tTeachingData = db.tTeachingDatas.Find(id);
            if (tTeachingData == null)
            {
                return NotFound();
            }

            return Ok(tTeachingData);
        }

        // PUT: api/tTeachingDatas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttTeachingData(int id, tTeachingData tTeachingData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tTeachingData.SID)
            {
                return BadRequest();
            }

            db.Entry(tTeachingData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tTeachingDataExists(id))
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

        // POST: api/tTeachingDatas
        [ResponseType(typeof(tTeachingData))]
        public IHttpActionResult PosttTeachingData(tTeachingData tTeachingData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tTeachingDatas.Add(tTeachingData);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tTeachingDataExists(tTeachingData.SID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tTeachingData.SID }, tTeachingData);
        }

        // DELETE: api/tTeachingDatas/5
        [ResponseType(typeof(tTeachingData))]
        public IHttpActionResult DeletetTeachingData(int id)
        {
            tTeachingData tTeachingData = db.tTeachingDatas.Find(id);
            if (tTeachingData == null)
            {
                return NotFound();
            }

            db.tTeachingDatas.Remove(tTeachingData);
            db.SaveChanges();

            return Ok(tTeachingData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tTeachingDataExists(int id)
        {
            return db.tTeachingDatas.Count(e => e.SID == id) > 0;
        }
    }
}