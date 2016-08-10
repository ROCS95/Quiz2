using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using QuizBackEnd.Models;

namespace QuizBackEnd.Controllers
{
    public class PokemonController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Pokemon
        public IQueryable<PokemonModel> GetPokemon()
        {
            return db.Pokemon;
        }

        // GET: api/Pokemon/5
        [ResponseType(typeof(PokemonModel))]
        public IHttpActionResult GetPokemonModel(int id)
        {
            PokemonModel pokemonModel = db.Pokemon.Find(id);
            if (pokemonModel == null)
            {
                return NotFound();
            }

            return Ok(pokemonModel);
        }

        // PUT: api/Pokemon/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPokemonModel(int id, PokemonModel pokemonModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pokemonModel.ID)
            {
                return BadRequest();
            }

            db.Entry(pokemonModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PokemonModelExists(id))
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

        // POST: api/Pokemon
        [ResponseType(typeof(PokemonModel))]
        public IHttpActionResult PostPokemonModel(PokemonModel pokemonModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pokemon.Add(pokemonModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pokemonModel.ID }, pokemonModel);
        }

        // DELETE: api/Pokemon/5
        [ResponseType(typeof(PokemonModel))]
        public IHttpActionResult DeletePokemonModel(int id)
        {
            PokemonModel pokemonModel = db.Pokemon.Find(id);
            if (pokemonModel == null)
            {
                return NotFound();
            }

            db.Pokemon.Remove(pokemonModel);
            db.SaveChanges();

            return Ok(pokemonModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PokemonModelExists(int id)
        {
            return db.Pokemon.Count(e => e.ID == id) > 0;
        }
    }
}