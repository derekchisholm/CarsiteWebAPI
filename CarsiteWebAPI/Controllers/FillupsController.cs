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
using CarsiteWebAPI.Models;
using System.Web.Http.Cors;

namespace CarsiteWebAPI.Controllers
{
    [EnableCors(origins: "http://www.carsite.com", headers: "*", methods: "*", SupportsCredentials = true)]
    public class FillupsController : ApiController
    {
        private CarsiteContext db = new CarsiteContext();

        // GET: api/Fillups
        [System.Web.Http.Authorize]
        public IQueryable<Fillup> GetFillups()
        {
            return db.Fillups;
        }

        // GET: api/Fillups/5
        [ResponseType(typeof(Fillup))]
        public IHttpActionResult GetFillup(int id)
        {
            Fillup fillup = db.Fillups.Find(id);
            if (fillup == null)
            {
                return NotFound();
            }

            return Ok(fillup);
        }

        // PUT: api/Fillups/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFillup(int id, Fillup fillup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fillup.id)
            {
                return BadRequest();
            }

            db.Entry(fillup).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FillupExists(id))
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

        // POST: api/Fillups
        [ResponseType(typeof(Fillup))]
        public IHttpActionResult PostFillup(Fillup fillup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fillups.Add(fillup);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fillup.id }, fillup);
        }

        // DELETE: api/Fillups/5
        [ResponseType(typeof(Fillup))]
        public IHttpActionResult DeleteFillup(int id)
        {
            Fillup fillup = db.Fillups.Find(id);
            if (fillup == null)
            {
                return NotFound();
            }

            db.Fillups.Remove(fillup);
            db.SaveChanges();

            return Ok(fillup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FillupExists(int id)
        {
            return db.Fillups.Count(e => e.id == id) > 0;
        }
    }
}