using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiYouLab.Models
{
    public class PatientViewModel
    {
        public int ID_P { get; set; }
        public string Nom_P { get; set; }
        public string Prenom_P { get; set; }
        public string Adresse { get; set; }
        public Nullable<int> Telephone { get; set; }
        public Nullable<System.DateTime> Date_Naiss { get; set; }
        public string CIN { get; set; }
        public string Securite_social { get; set; }
        public string Email { get; set; }
        public string Sexe { get; set; }
        public string Groupe_sanguin { get; set; }
        public List<ConsultationVIewModel> Consultation { get; set; }
    }
}