using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiYouLab.Models
{
    public class ResultatViewModel
    {
        public int ID_Res { get; set; }
        public Nullable<float> Float_Valeur { get; set; }
        public int ExamenID_Exam { get; set; }
        //public int ConsultationID_Consult { get; set; }
        public string Nom_Exam { get; set; }
        public string Valeur_Exam { get; set; }
        public string Unite_Exam { get; set; }
        //public virtual Consultation Consultation { get; set; }
        //public ExamenViewModel Examen { get; set; }
    }
}