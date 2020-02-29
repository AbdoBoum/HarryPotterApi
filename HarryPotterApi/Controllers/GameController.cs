using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HarryPotterApi.Models;
using HarryPotterApi.Data;
using System.Web.Http.Description;
using System.Threading.Tasks;
using System.Web.Http.Tracing;
using Newtonsoft.Json.Linq;

namespace HarryPotterApi.Controllers
{
    public class GameController : ApiController
    {
        
        private HarryPotterApiContext db = new HarryPotterApiContext();
        static List<Monster> monsterList = new List<Monster>();
         static Models.Hero myHero;
        static List<Obstacle> obstacleList = new List<Obstacle>();

       



        // GET api/<controller>
        public object Get()
        {
            return new
            {
                monsters = monsterList,
                hero = myHero
               
            };
           
            
        }


        
        

        // POST api/<controller>
        public async Task<IHttpActionResult> Post(JObject request)
        {
            int id = request["id"].ToObject<int>();       
            myHero = await db.Heroes.FindAsync(id);
            if (myHero == null)
            {
                return BadRequest();
            }
            monsterList = db.Monsters.ToList();
            return Ok(myHero);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
        [Route("api/game/fintour")]
        public object PostFinTour(JObject request)
        {
            
            
            
            
            
            return null;
        }

       

    }
}