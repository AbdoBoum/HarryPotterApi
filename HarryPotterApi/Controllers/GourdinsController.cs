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
    public class GourdinsController : ApiController
    {
        private HarryPotterApiContext db = new HarryPotterApiContext();

        // GET: api/Gourdins
        public IQueryable<Gourdin> GetGourdins()
        {
            return db.Gourdins;
        }

        // GET: api/Gourdins/5
        [ResponseType(typeof(Gourdin))]
        public async Task<IHttpActionResult> GetGourdin(int id)
        {
            Gourdin gourdin = await db.Gourdins.FindAsync(id);
            if (gourdin == null)
            {
                return NotFound();
            }

            return Ok(gourdin);
        }

        // PUT: api/Gourdins/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGourdin(int id, Gourdin gourdin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gourdin.Id)
            {
                return BadRequest();
            }

            db.Entry(gourdin).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GourdinExists(id))
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

        // POST: api/Gourdins
        [ResponseType(typeof(Gourdin))]
        public async Task<IHttpActionResult> PostGourdin(Gourdin gourdin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gourdins.Add(gourdin);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = gourdin.Id }, gourdin);
        }

        // DELETE: api/Gourdins/5
        [ResponseType(typeof(Gourdin))]
        public async Task<IHttpActionResult> DeleteGourdin(int id)
        {
            Gourdin gourdin = await db.Gourdins.FindAsync(id);
            if (gourdin == null)
            {
                return NotFound();
            }

            db.Gourdins.Remove(gourdin);
            await db.SaveChangesAsync();

            return Ok(gourdin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GourdinExists(int id)
        {
            return db.Gourdins.Count(e => e.Id == id) > 0;
        }
    }
}