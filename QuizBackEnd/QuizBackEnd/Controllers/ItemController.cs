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
    public class ItemController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Item
        public IQueryable<ItemModel> GetItems()
        {
            return db.Items;
        }

        // GET: api/Item/5
        [ResponseType(typeof(ItemModel))]
        public IHttpActionResult GetItemModel(int id)
        {
            ItemModel itemModel = db.Items.Find(id);
            if (itemModel == null)
            {
                return NotFound();
            }

            return Ok(itemModel);
        }

        // PUT: api/Item/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItemModel(int id, ItemModel itemModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemModel.ID)
            {
                return BadRequest();
            }

            db.Entry(itemModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemModelExists(id))
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

        // POST: api/Item
        [ResponseType(typeof(ItemModel))]
        public IHttpActionResult PostItemModel(ItemModel itemModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Items.Add(itemModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = itemModel.ID }, itemModel);
        }

        // DELETE: api/Item/5
        [ResponseType(typeof(ItemModel))]
        public IHttpActionResult DeleteItemModel(int id)
        {
            ItemModel itemModel = db.Items.Find(id);
            if (itemModel == null)
            {
                return NotFound();
            }

            db.Items.Remove(itemModel);
            db.SaveChanges();

            return Ok(itemModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemModelExists(int id)
        {
            return db.Items.Count(e => e.ID == id) > 0;
        }
    }
}