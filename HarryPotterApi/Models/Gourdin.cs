using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HarryPotterApi.Models
{
    public class Gourdin: Arme
    {
        [Required]
        public int Poid { get; set; }

        public Gourdin(): base() { }

        public Gourdin(int id, string nom, int degats, int poid)
        : base(id, nom, degats)
        {
            this.Poid = poid;
        }

        public Gourdin(string nom, int degats, int poid)
        : base(nom, degats)
        {
            this.Poid = poid;
        }
    }
}