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
    public class CategoriesController : ApiController
    {
        private YouLabEntities db = new YouLabEntities();

        // GET: api/Categories
        public List<CategorieViewModel> GetCategorie()
        {
            List<CategorieViewModel> lct = new List<CategorieViewModel>();
            List<Categorie> ct = new List<Categorie>();
            ct = db.Categorie.ToList();

            foreach(var c in ct)
            {
                CategorieViewModel cvm = new CategorieViewModel();

                cvm.ID_Cat = c.ID_Cat;
                cvm.Nom_Cat = c.Nom_Cat;

                lct.Add(cvm);
            }

            return lct;
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Categorie))]
        public IHttpActionResult GetCategorie(int id)
        {
            Categorie categorie = db.Categorie.Find(id);
            if (categorie == null)
            {
                return NotFound();
            }

                CategorieViewModel cvm = new CategorieViewModel();

                cvm.ID_Cat = categorie.ID_Cat;
                cvm.Nom_Cat = categorie.Nom_Cat;


            List<ExamenViewModel> levm = new List<ExamenViewModel>();
            List<Examen> et = new List<Examen>();
            et = categorie.Examen.ToList();

            foreach (var e in et)
            {
                ExamenViewModel exvm = new ExamenViewModel();
                exvm.ID_Exam = e.ID_Exam;
                exvm.Nom_Exam = e.Nom_Exam;
                exvm.Valeur_Exam = e.Valeur_Exam;
                exvm.Unite_Exam = e.Unite_Exam;
                

                levm.Add(exvm);

            }

            cvm.Examen = levm;

            return Ok(cvm);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategorie(int id, Categorie categorie)
        {

            if (id != categorie.ID_Cat)
            {
                return BadRequest();
            }

            db.Entry(categorie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieExists(id))
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

        // POST: api/Categories
        [ResponseType(typeof(Categorie))]
        public IHttpActionResult PostCategorie(Categorie categorie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (YouLabEntities db = new YouLabEntities())
            {

                db.Categorie.Add(categorie);
                db.SaveChanges();

            }


            return CreatedAtRoute("DefaultApi", new { id = categorie.ID_Cat }, categorie);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Categorie))]
        public IHttpActionResult DeleteCategorie(int id)
        {
            Categorie categorie = db.Categorie.Find(id);
            if (categorie == null)
            {
                return NotFound();
            }

            db.Categorie.Remove(categorie);
            db.SaveChanges();

            return Ok(categorie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategorieExists(int id)
        {
            return db.Categorie.Count(e => e.ID_Cat == id) > 0;
        }
    }
}