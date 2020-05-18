using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiYouLab.Models
{
    public class SecretairesViewModel
    {

        public int ID_sec { get; set; }
        public string Nom_sec { get; set; }
        public string Prenom_sec { get; set; }
        public string Username { get; set; }
        public string password { get; set; }

    }
}