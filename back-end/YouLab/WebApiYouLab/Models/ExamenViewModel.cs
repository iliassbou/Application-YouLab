using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiYouLab.Models
{ 

    public class ExamenViewModel
    {
        public int ID_Exam { get; set; }
        public int LaborantinID_laboran { get; set; }
        public string Nom_Exam { get; set; }
        public string Valeur_Exam { get; set; }
        public string Unite_Exam { get; set; }
        public List<CategorieViewModel> Categorie { get; set; }

    }
}