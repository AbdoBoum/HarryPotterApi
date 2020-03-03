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
        static int nbTour;
        static int etat; //0 en cours, 1 victoire, -1 défaite
       

       



        // GET api/<controller>
        public object Get()
        {
            return new
            {
                hero = myHero,
                epee = myEpee,
                monsters = monsterList,
                gourdins = gourdinList,
                obstacles = obstacleList,
                tour = nbTour,
                status = etat

            };


        }


        
        
        //When this method is called, it signals the start of the game
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
            nbTour = 1;
            etat = 0;
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

       
        [Route("api/game/saveToDb")]
        public async Task<IHttpActionResult> Post()
        {
            db.GameResult.Add(new GameResult(DateTime.Now, nbTour, myHero.Id, etat));
            await db.SaveChangesAsync();
            return Ok();
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
            etat = GameLogic.processTour(myHero,myEpee, monsterList,gourdinList, obstacleList, heroLastPosition, attackPosition);


            if (etat == 0) nbTour++;
            
            return new { gameLog = GameLogic.sb.ToString() };


        }

       

    }
}