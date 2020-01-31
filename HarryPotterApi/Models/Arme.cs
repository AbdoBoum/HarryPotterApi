using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HarryPotterApi.Models
{
    public abstract class Arme
    {
        public int Id { get; set; }

        [Required]
        public String Nom { get; set; }

        [Required]
        public int Degats { get; set; }

        public Arme() { }

        public Arme(int id, string nom, int degats)
        {
            this.Id = id;
            this.Nom = nom;
            this.Degats = degats;
        }

        public Arme(string nom, int degats)
        {
            this.Nom = nom;
            this.Degats = degats;
        }

    }
}