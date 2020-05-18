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
    public class PatientsController : ApiController
    {
        private YouLabEntities db = new YouLabEntities();

        // GET: api/Patients
        // Liste des patients pour secraitaire (page acceuil)
        public List<PatientViewModel> GetPatient()
        {

            List<PatientViewModel> lpvm = new List<PatientViewModel>();
            List<Patient> lp = new List<Patient>();
            lp = db.Patient.ToList();
            foreach(var p in lp)
            {
                PatientViewModel pvm = new PatientViewModel();
                pvm.ID_P = p.ID_P;
                pvm.Nom_P = p.Nom_P;
                pvm.Prenom_P = p.Prenom_P;
                pvm.CIN = p.CIN;
                pvm.Telephone = p.Telephone;
                lpvm.Add(pvm);
            }


            return lpvm;
        }

        // GET: api/Patients/5
        [ResponseType(typeof(Patient))]
        public IHttpActionResult GetPatient(int id)
        {
            Patient patient = db.Patient.Find(id);
            if (patient == null)
            {
                return NotFound();
            }

            PatientViewModel pvm = new PatientViewModel();
            pvm.ID_P = patient.ID_P;
            pvm.Nom_P = patient.Nom_P;
            pvm.Prenom_P = patient.Prenom_P;
            pvm.CIN = patient.CIN;
            pvm.Telephone = patient.Telephone;

            List<ConsultationVIewModel> lcvm = new List<ConsultationVIewModel>();
            List<Consultation> lc = new List<Consultation>();
            lc = patient.Consultation.ToList();
            

            foreach (var c in lc)
            {
                ConsultationVIewModel cvm = new ConsultationVIewModel();
                cvm.ID_Consult = c.ID_Consult;
                cvm.Date_consult = c.Date_consult;

                lcvm.Add(cvm);
            }
            pvm.Consultation = lcvm;
            return Ok(pvm);
        }

        // PUT: api/Patients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPatient(int id, Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patient.ID_P)
            {
                return BadRequest();
            }

            db.Entry(patient).State = EntityState.Modified;
           

            foreach (var c in patient.Consultation)
            {
                 db.Entry(c).State = EntityState.Modified;
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
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

        // POST: api/Patients
        [ResponseType(typeof(Patient))]
        public IHttpActionResult PostPatient(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (YouLabEntities db = new YouLabEntities())
            {
                db.Patient.Add(patient);
                db.SaveChanges();
            }


            return CreatedAtRoute("DefaultApi", new { id = patient.ID_P }, patient);
        }

        // DELETE: api/Patients/5
        [ResponseType(typeof(Patient))]
        public IHttpActionResult DeletePatient(int id)
        {
            Patient patient = db.Patient.Find(id);
            if (patient == null)
            {
                return NotFound();
            }

            db.Patient.Remove(patient);
            db.SaveChanges();

            return Ok(patient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientExists(int id)
        {
            return db.Patient.Count(e => e.ID_P == id) > 0;
        }
    }
}