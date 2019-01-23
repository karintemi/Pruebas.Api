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
using Pruebas.Common.Models;
using Pruebas.Domain.Models;

namespace Pruebas.Api.Controllers
{
    public class CategoriasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Categorias
        public IQueryable<Categoria> GetCategoria()
        {
            return db.Categoria;
        }

        // GET: api/Categorias/5
        [ResponseType(typeof(Categoria))]
        public async Task<IHttpActionResult> GetCategoria(int id)
        {
            Categoria categoria = await db.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        // PUT: api/Categorias/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoria.IdCategoria)
            {
                return BadRequest();
            }

            db.Entry(categoria).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
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

        // POST: api/Categorias
        [ResponseType(typeof(Categoria))]
        public async Task<IHttpActionResult> PostCategoria(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categoria.Add(categoria);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = categoria.IdCategoria }, categoria);
        }

        // DELETE: api/Categorias/5
        [ResponseType(typeof(Categoria))]
        public async Task<IHttpActionResult> DeleteCategoria(int id)
        {
            Categoria categoria = await db.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            db.Categoria.Remove(categoria);
            await db.SaveChangesAsync();

            return Ok(categoria);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoriaExists(int id)
        {
            return db.Categoria.Count(e => e.IdCategoria == id) > 0;
        }
    }
}