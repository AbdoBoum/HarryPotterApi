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
    public class EpeesController : ApiController
    {
        private HarryPotterApiContext db = new HarryPotterApiContext();

        // GET: api/Epees
        public object GetEpees()
        {
            return new { epees = db.Epees.ToList() };
        }

        // GET: api/Epees/5
        [ResponseType(typeof(Epee))]
        public async Task<IHttpActionResult> GetEpee(int id)
        {
            Epee epee = await db.Epees.FindAsync(id);
            if (epee == null)
            {
                return NotFound();
            }

            return Ok(epee);
        }

        // PUT: api/Epees/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEpee(int id, Epee epee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != epee.Id)
            {
                return BadRequest();
            }

            db.Entry(epee).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EpeeExists(id))
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

        // POST: api/Epees
        [ResponseType(typeof(Epee))]
        public async Task<IHttpActionResult> PostEpee(Epee epee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Epees.Add(epee);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = epee.Id }, epee);
        }

        // DELETE: api/Epees/5
        [ResponseType(typeof(Epee))]
        public async Task<IHttpActionResult> DeleteEpee(int id)
        {
            Epee epee = await db.Epees.FindAsync(id);
            if (epee == null)
            {
                return NotFound();
            }

            db.Epees.Remove(epee);
            await db.SaveChangesAsync();

            return Ok(epee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EpeeExists(int id)
        {
            return db.Epees.Count(e => e.Id == id) > 0;
        }
    }
}