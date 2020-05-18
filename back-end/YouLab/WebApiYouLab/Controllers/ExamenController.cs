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
using WebApiYouLab.Models;

namespace WebApiYouLab.Controllers
{
    public class ExamenController : ApiController
    {
        private YouLabEntities db = new YouLabEntities();

        // GET: api/Examen
        public IQueryable<Examen> GetExamen()
        {
            return db.Examen;
        }

        // GET: api/Examen/5
        [ResponseType(typeof(Examen))]
        public IHttpActionResult GetExamen(int id)
        {
            Examen examen = db.Examen.Find(id);
            if (examen == null)
            {
                return NotFound();
            }

            return Ok(examen);
        }

        // PUT: api/Examen/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExamen(int id, Examen examen)
        {

            if (id != examen.ID_Exam)
            {
                return BadRequest();
            }

            db.Entry(examen).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamenExists(id))
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

        // POST: api/Examen
        [ResponseType(typeof(Examen))]
        public IHttpActionResult PostExamen(Examen examen)
        {
            using (YouLabEntities db = new YouLabEntities())
            {

                db.Examen.Add(examen);
                db.SaveChanges();

            }

            return CreatedAtRoute("DefaultApi", new { id = examen.ID_Exam }, examen);
        }

        // DELETE: api/Examen/5
        [ResponseType(typeof(Examen))]
        public IHttpActionResult DeleteExamen(int id)
        {
            Examen examen = db.Examen.Find(id);
            if (examen == null)
            {
                return NotFound();
            }

            db.Examen.Remove(examen);
            db.SaveChanges();

            return Ok(examen);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExamenExists(int id)
        {
            return db.Examen.Count(e => e.ID_Exam == id) > 0;
        }
    }
}