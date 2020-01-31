using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HarryPotterApi.Models
{
    public abstract class Personne
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        public String Avatar { get; set; }

        [Required]
        public int PositionY { get; private set; }

        [Required]
        public int PositionX { get; private set; }

        [Required]
        public int PointsDeVie { get; private set; }

        public Personne() { }

        public Personne(int id, string nom, int pointsDeVie)
        {
            this.Id = id;
            this.Nom = nom;
            this.PointsDeVie = pointsDeVie;
        }


        public void SePositionner(int positionX, int positionY)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
        }

        public virtual void Attaquer(Personne cible)
        {
            cible.RecevoirDegats(this);
        }

        public abstract void RecevoirDegats(Personne source);
    }
}