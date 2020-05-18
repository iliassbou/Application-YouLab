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
    public class ConsultationsController : ApiController
    {
        private YouLabEntities db = new YouLabEntities();

        //// GET: api/Consultations
        //public IQueryable<Consultation> GetConsultation()
        //{
        //    return db.Consultation;
        //}

        //// GET: api/Consultations/5
        //[ResponseType(typeof(Consultation))]
        //public IHttpActionResult GetConsultation(int id)
        //{
        //    Consultation consultation = db.Consultation.Find(id);
        //    if (consultation == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(consultation);
        //}

        // PUT: api/Consultations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConsultation(int id, Consultation consultation)
        {

            if (id != consultation.ID_Consult)
            {
                return BadRequest();
            }

            db.Entry(consultation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultationExists(id))
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

        // POST: api/Consultations
        [ResponseType(typeof(Consultation))]
        public IHttpActionResult PostConsultation(Consultation consultation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (YouLabEntities db = new YouLabEntities())
            {
                consultation.Date_consult = DateTime.Now;
                db.Consultation.Add(consultation);
                db.SaveChanges();

            }

            return CreatedAtRoute("DefaultApi", new { id = consultation.ID_Consult }, consultation);
        }

        // DELETE: api/Consultations/5
        [ResponseType(typeof(Consultation))]
        public IHttpActionResult DeleteConsultation(int id)
        {
            Consultation consultation = db.Consultation.Find(id);
            if (consultation == null)
            {
                return NotFound();
            }

            db.Consultation.Remove(consultation);
            db.SaveChanges();

            return Ok(consultation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConsultationExists(int id)
        {
            return db.Consultation.Count(e => e.ID_Consult == id) > 0;
        }
    }
}