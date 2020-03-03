using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HarryPotterApi.Models
{
    public class GameResult
    {
        [Required]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int Rounds { get;  set; }

        public int HeroId { get; set; }

        public int State { get; set; }
        public GameResult()
        {
        }
        public GameResult( DateTime date, int rounds, int heroId, int state)
        {
            Date = date;
            Rounds = rounds;
            HeroId = heroId;
            State = state;
        }


    }
}