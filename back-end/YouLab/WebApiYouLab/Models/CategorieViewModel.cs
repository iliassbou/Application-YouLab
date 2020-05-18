using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiYouLab.Models
{
    public class CategorieViewModel
    {
        public int ID_Cat { get; set; }
        public string Nom_Cat { get; set; }

        public List<ExamenViewModel> Examen { get; set; }
    }
}