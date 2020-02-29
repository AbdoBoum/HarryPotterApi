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

        public override bool RecevoirDegats(Arme source)
        {
            Console.WriteLine("Je suis attaqué. J'ai pris " + source.Degats);
            this.PointsDeVie -= source.Degats;
            if (this.PointsDeVie <= 0)
            {
                return false;
            }
            return true;
        }
    }
}