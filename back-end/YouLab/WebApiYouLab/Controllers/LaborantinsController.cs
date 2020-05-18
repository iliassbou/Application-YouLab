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
    public class LaborantinsController : ApiController
    {
        private YouLabEntities db = new YouLabEntities();

        // GET: api/Laborantins
        public List<LaborantinViewModel> GetLaborantin()
        {
            
            List<LaborantinViewModel> lilb= new List<LaborantinViewModel>();
            List<Laborantin> lb = new List<Laborantin>();
            lb = db.Laborantin.ToList();
            foreach (var b in lb)
            {
                LaborantinViewModel lbo = new LaborantinViewModel();
                lbo.ID_laboran = b.ID_laboran;
                lbo.Nom_laboran = b.Nom_laboran;
                lbo.Prenom = b.Prenom;
                lbo.Username = b.Username;

                lilb.Add(lbo);
            }

            return lilb;

        }

        // GET: api/Laborantins/5
        [ResponseType(typeof(Laborantin))]
        public IHttpActionResult GetLaborantin(int id)
        {
            Laborantin laborantin = db.Laborantin.Find(id);
            if (laborantin == null)
            {
                return NotFound();
            }

                LaborantinViewModel lbo = new LaborantinViewModel();
                lbo.ID_laboran = laborantin.ID_laboran;
                lbo.Nom_laboran = laborantin.Nom_laboran;
                lbo.Prenom = laborantin.Prenom;
                lbo.Username = laborantin.Username;

            //List<ExamenViewModel> levm = new List<ExamenViewModel>();
            //List<Examen> et = new List<Examen>();
            //et = laborantin.Examen.ToList();
            
            //foreach (var e in et)
            //{
            //    ExamenViewModel exvm = new ExamenViewModel();
                
            //    exvm.ID_Exam = e.ID_Exam;
            //    exvm.Nom_Exam = e.Nom_Exam;
            //    exvm.Valeur_Exam = e.Valeur_Exam;
            //    exvm.Unite_Exam = e.Unite_Exam;


            //    levm.Add(exvm);

            //}
            //lbo.Examen = levm;

            return Ok(lbo);
        }

        // PUT: api/Laborantins/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLaborantin(int id, Laborantin laborantin)
        {

            if (id != laborantin.ID_laboran)
            {
                return BadRequest();
            }

            db.Entry(laborantin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaborantinExists(id))
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

        // POST: api/Laborantins
        [ResponseType(typeof(Laborantin))]
        public IHttpActionResult PostLaborantin(Laborantin laborantin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (YouLabEntities db = new YouLabEntities())
            {

                db.Laborantin.Add(laborantin);
                db.SaveChanges();

            }

            return CreatedAtRoute("DefaultApi", new { id = laborantin.ID_laboran }, laborantin);
        }

        // DELETE: api/Laborantins/5
        [ResponseType(typeof(Laborantin))]
        public IHttpActionResult DeleteLaborantin(int id)
        {
            Laborantin laborantin = db.Laborantin.Find(id);
            if (laborantin == null)
            {
                return NotFound();
            }

            db.Laborantin.Remove(laborantin);
            db.SaveChanges();

            return Ok(laborantin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LaborantinExists(int id)
        {
            return db.Laborantin.Count(e => e.ID_laboran == id) > 0;
        }
    }
}