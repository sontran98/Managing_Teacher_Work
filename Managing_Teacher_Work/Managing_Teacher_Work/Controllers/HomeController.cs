using Managing_Teacher_Work.DAO;
using Managing_Teacher_Work.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Managing_Teacher_Work.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        MTWDbContext db = new MTWDbContext();
        public ActionResult Index()
        {
            List<Science> listSciense = db.Science.ToList();
            ViewBag.listSciense = listSciense;
          
            return View();
        }
        public PartialViewResult DanhSachMenu()
        {
            List<Menu> listMenu = db.Menu.ToList();
            ViewBag.listMenu = listMenu;
            return PartialView();
        }
    }
}