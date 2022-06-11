using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagicProject.Controllers
{
    public class Parms
    {
        public string prf { get; set; }
        public string occ { get; set; }
        public string frm { get; set; }
        public string pos { get; set; }
        public string user { get; set; }
    }
    public class MagicController : Controller
    {

        Models.ApplicationDbContext ity_context = new Models.ApplicationDbContext();
        Models.ContextDB db = new Models.ContextDB();
        // GET: Magic
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.IsAuth = this.HttpContext.User.Identity.IsAuthenticated;
            ViewBag.UserName = this.HttpContext.User.Identity.Name;
            ViewBag.IsAdmin = this.HttpContext.User.IsInRole("Administrator");
            ViewBag.IsEmployer = this.HttpContext.User.IsInRole("Employer");
            return View();
        }
        [Authorize(Roles = "Administrator, Employer")]
        public ActionResult PRF()
        {
            List<Models.Profes> l = new List<Models.Profes>();
            l.AddRange(db.Profeses.ToList<Models.Profes>());
            ViewBag.Profeses = l;
            return View();

        }
        [Authorize(Roles = "Administrator, Employer")]
        public ActionResult OCC(Parms parms)
        {
            List<Models.Zaynit> l = new List<Models.Zaynit>();
            l.AddRange(db.Zaynits.ToList<Models.Zaynit>());
            ViewBag.Zaynits = l;
            return View(parms);
        }
        [Authorize(Roles = "Administrator, Employer")]
        public ActionResult FRM(Parms parms)
        {
            List<Models.Form> l = new List<Models.Form>();
            l.AddRange(db.Forms.ToList<Models.Form>());
            ViewBag.Forms = l;
            return View(parms);

        }
        [Authorize(Roles = "Administrator, Employer")]
        public ActionResult POS(Parms parms)
        {
            List<Models.Position> l = new List<Models.Position>();
            l.AddRange(db.Positions.ToList<Models.Position>());
            ViewBag.Positions = l;
            return View(parms);

        }
        [Authorize(Roles = "Administrator, Employer")]
        public ActionResult SURV(Parms parms)
        {

            return View(parms);
        }
        public ActionResult Save(Parms parms)
        {
            db.OrderUsers.Add(new Models.OrderUser
            {
                prf = parms.prf,
                user = this.HttpContext.User.Identity.Name,
                occ = parms.occ,
                frm = parms.frm,
                pos = parms.pos,
            });
            db.SaveChanges();
            return Redirect("Index");
        }
        public ActionResult Del()
        {
            Models.OrderUser[] s = db.OrderUsers.ToArray<Models.OrderUser>();
            ViewBag.OrderUsers = s;
            return View();
        }
        public ActionResult DelConfirm(int? ID)
        {
            if (ID != null)
            {
                Models.OrderUser s = db.OrderUsers.Find((int)ID);
                if (s != null)
                {
                    db.OrderUsers.Remove(s);
                    db.SaveChanges();
                }
                else return RedirectToAction("Del");

            }
            else return RedirectToAction("Del");
            return RedirectToAction("Index");
        }
    }
}