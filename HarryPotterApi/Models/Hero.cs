using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HarryPotterApi.Models
{
    public class Hero : Personne
    {
        [Required]
        public Epee Epee { get; set; }

        public Hero(): base() { }

        public Hero(int id, string nom, int pointsDeVie, Epee epee):
            base(id, nom, pointsDeVie)
        {
            this.Epee = epee;
        }

        public override void Attaquer(Personne cible)
        {
            base.Attaquer(cible);
        }

        public override void RecevoirDegats(Personne source)
        {
            Console.WriteLine("Je suis attaqué par " + source.Nom);
        }
    }
}