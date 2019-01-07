using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlannerMSQL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PlannerMSQL.Controllers
{
    public class MeetingModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MeetingModels
        public async Task<ActionResult> Index()
        {
            return View(await db.MeetingModels.ToListAsync());
        }

        // GET: MeetingModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingModel meetingModel = await db.MeetingModels.FindAsync(id);
            if (meetingModel == null)
            {
                return HttpNotFound();
            }
            return View(meetingModel);
        }

        // GET: MeetingModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MeetingModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MeetingId,Name,Description")] MeetingModel meetingModel)
        {
            if (ModelState.IsValid)
            {
                if (this.User.Identity.GetUserId() != null)
                {
                    IOwinContext context = this.HttpContext.GetOwinContext();
                    var UserManager = context.GetUserManager<ApplicationUserManager>();
                    ApplicationUser currentUser = UserManager.FindById(User.Identity.GetUserId());
                    //System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                    meetingModel.Owner = currentUser;
                    
                }
                else
                {
                    throw new System.Exception("Nie JEsteś zalogowany");
                }

                db.MeetingModels.Add(meetingModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(meetingModel);
        }

        // GET: MeetingModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingModel meetingModel = await db.MeetingModels.FindAsync(id);
            if (meetingModel == null)
            {
                return HttpNotFound();
            }
            return View(meetingModel);
        }

        // POST: MeetingModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MeetingId,Name,Description")] MeetingModel meetingModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meetingModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(meetingModel);
        }

        // GET: MeetingModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingModel meetingModel = await db.MeetingModels.FindAsync(id);
            if (meetingModel == null)
            {
                return HttpNotFound();
            }
            return View(meetingModel);
        }

        // POST: MeetingModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MeetingModel meetingModel = await db.MeetingModels.FindAsync(id);
            db.MeetingModels.Remove(meetingModel);
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
