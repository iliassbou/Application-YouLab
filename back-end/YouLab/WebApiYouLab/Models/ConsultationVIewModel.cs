using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiYouLab.Models
{
    public class ConsultationVIewModel
    {
        public int ID_Consult { get; set; }
        public int PatientID_P { get; set; }
        public int MedecinID_Med { get; set; }
        public Nullable<System.DateTime> Date_consult { get; set; }
        //public virtual Medecin Medecin { get; set; }
        public Patient Patient { get; set; }
        public List<ResultatViewModel> Resultat { get; set; }
    }
}