using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HarryPotterApi.Models
{
    public class Epee: Arme
    {
        [Required]
        public int Portee { get; set; }

        [Required]
        public int Longueur { get; set; }

        public Epee(): base() { }

        public Epee(int id, string nom, int degats, int portee, int longueur)
        : base(id, nom, degats)
        {
            this.Longueur = longueur;
            this.Portee = portee;
        }

        public Epee(string nom, int degats, int portee, int longueur)
        : base(nom, degats)
        {
            this.Longueur = longueur;
            this.Portee = portee;
        }
    }
}