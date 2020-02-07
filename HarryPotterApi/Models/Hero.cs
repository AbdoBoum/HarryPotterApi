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
        public int EpeeId { get; set; }

        public Hero(): base() { }

        public Hero(int id, string nom, String avatar, int pointsDeVie, int epeeId):
            base(id, nom, avatar, pointsDeVie)
        {
            this.EpeeId = epeeId;
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