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
using HarryPotterApi.Services;

namespace HarryPotterApi.Controllers
{
    public class GameController : ApiController
    {
        
        private HarryPotterApiContext db = new HarryPotterApiContext();
        static List<Monster> monsterList = new List<Monster>();
        static List<Gourdin> gourdinList = new List<Gourdin>();
        static Hero myHero;
        static Epee myEpee;
        static List<Obstacle> obstacleList = new List<Obstacle>();
       

       



        // GET api/<controller>
        public object Get()
        {
            return new
            {
                hero = myHero,
                epee = myEpee,
                monsters = monsterList,
                gourdins = gourdinList,
                obstacles = obstacleList
            };


        }


        
        

        // POST api/<controller>
        public async Task<IHttpActionResult> Post(JObject request)
        {
            int id = request["id"].ToObject<int>();       
            myHero = await db.Heroes.FindAsync(id);
            myEpee = await db.Epees.FindAsync(myHero.EpeeId);


            if (myHero == null)
            {
                return BadRequest();
            }
            monsterList = db.Monsters.ToList();

            foreach(Monster m in monsterList)
            {
                gourdinList.Add(await db.Gourdins.FindAsync(m.GourdinId));

            }
            obstacleList = db.Obstacle.ToList();
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
            
            int xHero = request["hero"]["x"].ToObject<int>();

            int yHero = request["hero"]["y"].ToObject<int>();

            int xAttack = request["attack"]["x"].ToObject<int>();

            int yAttack = request["attack"]["y"].ToObject<int>();

            Tuple<int, int> heroLastPosition = new Tuple<int, int>(xHero, yHero);

            Tuple<int, int> attackPosition = new Tuple<int, int>(xAttack, yAttack);

            //x.x;
            GameLogic.processTour(myHero,myEpee, monsterList,gourdinList, obstacleList, heroLastPosition, attackPosition);

            return new { gameLog = GameLogic.sb.ToString() };
        }

       

    }
}