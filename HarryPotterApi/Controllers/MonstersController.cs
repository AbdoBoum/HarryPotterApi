using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HarryPotterApi.Data;
using HarryPotterApi.Models;

namespace HarryPotterApi.Controllers
{
    public class MonstersController : ApiController
    {
        private HarryPotterApiContext db = new HarryPotterApiContext();

        // GET: api/Monsters
        public IQueryable<Monster> GetMonsters()
        {
            return db.Monsters;
        }

        // GET: api/Monsters/5
        [ResponseType(typeof(Monster))]
        public async Task<IHttpActionResult> GetMonster(int id)
        {
            Monster monster = await db.Monsters.FindAsync(id);
            if (monster == null)
            {
                return NotFound();
            }

            return Ok(monster);
        }

        // PUT: api/Monsters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMonster(int id, Monster monster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monster.Id)
            {
                return BadRequest();
            }

            db.Entry(monster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonsterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Monsters
        [ResponseType(typeof(Monster))]
        public async Task<IHttpActionResult> PostMonster(Monster monster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Monsters.Add(monster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = monster.Id }, monster);
        }

        // DELETE: api/Monsters/5
        [ResponseType(typeof(Monster))]
        public async Task<IHttpActionResult> DeleteMonster(int id)
        {
            Monster monster = await db.Monsters.FindAsync(id);
            if (monster == null)
            {
                return NotFound();
            }

            db.Monsters.Remove(monster);
            await db.SaveChangesAsync();

            return Ok(monster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MonsterExists(int id)
        {
            return db.Monsters.Count(e => e.Id == id) > 0;
        }
    }
}