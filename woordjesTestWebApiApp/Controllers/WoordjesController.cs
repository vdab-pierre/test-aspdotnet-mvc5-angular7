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
using woordjesTestWebApiApp.Models;

namespace woordjesTestWebApiApp.Controllers
{
    public class WoordjesController : ApiController
    {
        private woordjesTestService db = new woordjesTestService();

        // GET: api/Woordjes
        public IQueryable<Woordje> GetWoordjes()
        {
            return db.Woordjes;
        }

        // GET: api/Woordjes/5
        [ResponseType(typeof(Woordje))]
        public async Task<IHttpActionResult> GetWoordje(int id)
        {
            Woordje woordje = await db.Woordjes.FindAsync(id);
            if (woordje == null)
            {
                return NotFound();
            }

            return Ok(woordje);
        }

        // PUT: api/Woordjes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWoordje(int id, Woordje woordje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != woordje.Id)
            {
                return BadRequest();
            }

            db.Entry(woordje).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WoordjeExists(id))
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

        // POST: api/Woordjes
        [ResponseType(typeof(Woordje))]
        public async Task<IHttpActionResult> PostWoordje(Woordje woordje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Woordjes.Add(woordje);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = woordje.Id }, woordje);
        }

        // DELETE: api/Woordjes/5
        [ResponseType(typeof(Woordje))]
        public async Task<IHttpActionResult> DeleteWoordje(int id)
        {
            Woordje woordje = await db.Woordjes.FindAsync(id);
            if (woordje == null)
            {
                return NotFound();
            }

            db.Woordjes.Remove(woordje);
            await db.SaveChangesAsync();

            return Ok(woordje);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WoordjeExists(int id)
        {
            return db.Woordjes.Count(e => e.Id == id) > 0;
        }
    }
}