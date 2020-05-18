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
    public class SecretairesController : ApiController
    {
        private YouLabEntities db = new YouLabEntities();

        // GET: api/Secretaires
        public List<SecretairesViewModel> GetSecretaire()
        {
            List<SecretairesViewModel> lsvm = new List<SecretairesViewModel>();
            List<Secretaire> ls = new List<Secretaire>();
            ls = db.Secretaire.ToList();
            foreach (var s in ls)
            {
                SecretairesViewModel svm = new SecretairesViewModel();
                svm.ID_sec = s.ID_sec;
                svm.Nom_sec = s.Nom_sec;
                svm.Prenom_sec = s.Prenom_sec;
                svm.Username = s.Username;
                svm.password = s.password;
                lsvm.Add(svm);
            }

            return lsvm;
        }

        // GET: api/Secretaires/5
        [ResponseType(typeof(Secretaire))]
        public IHttpActionResult GetSecretaire(int id)
        {
            Secretaire secretaire = db.Secretaire.Find(id);
            if (secretaire == null)
            {
                return NotFound();
            }

            SecretairesViewModel svm = new SecretairesViewModel();
            svm.ID_sec = secretaire.ID_sec;
            svm.Nom_sec = secretaire.Nom_sec;
            svm.Prenom_sec = secretaire.Prenom_sec;
            svm.Username = secretaire.Username;
            svm.password = secretaire.password;

            return Ok(svm);
        }

        // PUT: api/Secretaires/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSecretaire(int id, Secretaire secretaire)
        {

            if (id != secretaire.ID_sec)
            {
                return BadRequest();
            }

            db.Entry(secretaire).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SecretaireExists(id))
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

        // POST: api/Secretaires
        [ResponseType(typeof(Secretaire))]
        public IHttpActionResult PostSecretaire(Secretaire secretaire)
        {
            using (YouLabEntities db = new YouLabEntities())
            {

                db.Secretaire.Add(secretaire);
                db.SaveChanges();
            }


            return CreatedAtRoute("DefaultApi", new { id = secretaire.ID_sec }, secretaire);
        }

        // DELETE: api/Secretaires/5
        [ResponseType(typeof(Secretaire))]
        public IHttpActionResult DeleteSecretaire(int id)
        {
            Secretaire secretaire = db.Secretaire.Find(id);
            if (secretaire == null)
            {
                return NotFound();
            }

            db.Secretaire.Remove(secretaire);
            db.SaveChanges();

            return Ok(secretaire);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SecretaireExists(int id)
        {
            return db.Secretaire.Count(e => e.ID_sec == id) > 0;
        }
    }
}