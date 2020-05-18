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
    public class ResultatsController : ApiController
    {
        private YouLabEntities db = new YouLabEntities();

        // GET: api/Resultats
        public List<ResultatViewModel> GetResultat()
        {
            List<ResultatViewModel> lrvm = new List<ResultatViewModel>();
            List<Resultat> lr = new List<Resultat>();
            lr = db.Resultat.ToList();
            

            foreach (var r in lr)
            {
                ResultatViewModel rvm = new ResultatViewModel();

                rvm.ID_Res = r.ID_Res;
                rvm.Float_Valeur = r.Float_Valeur;
                rvm.ExamenID_Exam = r.ExamenID_Exam;
                rvm.Nom_Exam = r.Examen.Nom_Exam;
                rvm.Valeur_Exam = r.Examen.Valeur_Exam;
                rvm.Unite_Exam = r.Examen.Unite_Exam;

                lrvm.Add(rvm);
            }
            return lrvm;
        }

        // GET: api/Resultats/5
        [ResponseType(typeof(Resultat))]
        public IHttpActionResult GetResultat(int id)
        {
            Resultat resultat = db.Resultat.Find(id);
            if (resultat == null)
            {
                return NotFound();
            }

            ResultatViewModel rvm = new ResultatViewModel();

            rvm.ID_Res = resultat.ID_Res;
            rvm.Float_Valeur = resultat.Float_Valeur;
            rvm.ExamenID_Exam = resultat.ExamenID_Exam;
            rvm.Nom_Exam = resultat.Examen.Nom_Exam;
            rvm.Valeur_Exam = resultat.Examen.Valeur_Exam;
            rvm.Unite_Exam = resultat.Examen.Unite_Exam;

            PrintingManager pm = new PrintingManager();
            pm.Printing("Microsoft Print to PDF");
            return Ok(rvm);
        }

        // PUT: api/Resultats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResultat(int id, Resultat resultat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != resultat.ID_Res)
            {
                return BadRequest();
            }

            db.Entry(resultat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultatExists(id))
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

        // POST: api/Resultats
        [ResponseType(typeof(Resultat))]
        public IHttpActionResult PostResultat(Resultat resultat)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (YouLabEntities db = new YouLabEntities())
            {

                db.Resultat.Add(resultat);
                db.SaveChanges();

            }

            return CreatedAtRoute("DefaultApi", new { id = resultat.ID_Res }, resultat);
        }

        // DELETE: api/Resultats/5
        [ResponseType(typeof(Resultat))]
        public IHttpActionResult DeleteResultat(int id)
        {
            Resultat resultat = db.Resultat.Find(id);
            if (resultat == null)
            {
                return NotFound();
            }

            db.Resultat.Remove(resultat);
            db.SaveChanges();

            return Ok(resultat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResultatExists(int id)
        {
            return db.Resultat.Count(e => e.ID_Res == id) > 0;
        }
    }
}