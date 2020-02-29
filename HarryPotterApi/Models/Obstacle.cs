using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarryPotterApi.Models
{
    public class Obstacle
    {
        public int Id { get; set; }

        public int PositionY { get; private set; }

        public int PositionX { get; private set; }

    }
}