using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HarryPotterApi.Models
{
    public class Monster : Personne
    { 
        [Required]
        public int Niveau { get; set; }

        [Required]
        public Gourdin Gourdin { get; set; }

        public Monster() : base() { }

        public Monster(int id, string nom, int pointsDeVie, Gourdin gourdin) :
            base(id, nom, pointsDeVie)
        {
            this.Gourdin = gourdin;
        }

        public override void Attaquer(Personne cible)
    {
        base.Attaquer(cible);
    }

    public override void RecevoirDegats(Personne source)
        {
            throw new NotImplementedException();
        }
    }
}