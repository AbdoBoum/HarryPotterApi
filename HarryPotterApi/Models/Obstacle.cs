using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HarryPotterApi.Models
{
    public class Obstacle
    {
        [Required]
        public int Id { get; set; }

        public int PositionY { get; private set; }

        public int PositionX { get; private set; }

        public Obstacle()
        {
        }

        public Obstacle(int id, int positionY, int positionX)
        {
            Id = id;
            PositionY = positionY;
            PositionX = positionX;
        }
    }
}