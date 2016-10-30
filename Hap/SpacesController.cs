using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hap.Models.Entities;

namespace Hap
{
    public class SpacesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Spaces
        public async Task<ActionResult> Index()
        {
            return View(await db.Spaces.ToListAsync());
        }

        // GET: Spaces/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Space space = await db.Spaces.FindAsync(id);
            if (space == null)
            {
                return HttpNotFound();
            }
            return View(space);
        }

        // GET: Spaces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Spaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,ShortDescription,LongDescription,Street,PostCode,PricePerHourPoundsSterling,MaxCapacityPersons,AreaMetresSquared,WebLink,AddedUtc,UpdatedUtc,DeletedUtc")] Space space)
        {
            if (ModelState.IsValid)
            {
                space.ID = Guid.NewGuid();
                db.Spaces.Add(space);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(space);
        }

        // GET: Spaces/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Space space = await db.Spaces.FindAsync(id);
            if (space == null)
            {
                return HttpNotFound();
            }
            return View(space);
        }

        // POST: Spaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,ShortDescription,LongDescription,Street,PostCode,PricePerHourPoundsSterling,MaxCapacityPersons,AreaMetresSquared,WebLink,AddedUtc,UpdatedUtc,DeletedUtc")] Space space)
        {
            if (ModelState.IsValid)
            {
                db.Entry(space).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(space);
        }

        // GET: Spaces/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Space space = await db.Spaces.FindAsync(id);
            if (space == null)
            {
                return HttpNotFound();
            }
            return View(space);
        }

        // POST: Spaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Space space = await db.Spaces.FindAsync(id);
            db.Spaces.Remove(space);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
