using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiYouLab.Models
{
    public class LaborantinViewModel
    {
        public int ID_laboran { get; set; }
        public string Nom_laboran { get; set; }
        public string Prenom { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<ExamenViewModel> Examen { get; set; }

    }
}