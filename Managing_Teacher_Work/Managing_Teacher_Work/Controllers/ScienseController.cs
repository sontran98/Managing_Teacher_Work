using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Managing_Teacher_Work.Models;
using Managing_Teacher_Work.DAO;
using Newtonsoft.Json;
using System.Globalization;

namespace Managing_Teacher_Work.Controllers
{
    [ValidateInput(false)]
    public class ScienseController : Controller
    {
        // GET: Sciense
        MTWDbContext db = new MTWDbContext();
        public bool isThemMoi;
        public ActionResult Index()
        {
            List<Science> listSciense = db.Science.ToList();
            ViewBag.listSciense = listSciense;
          
            return View();
        }
        public ActionResult getList(int id)
        {
           
                 JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var hs = db.Science.SingleOrDefault(x => x.ID == id);
            var result = JsonConvert.SerializeObject(hs, Formatting.Indented, jss);
            return this.Json(result, JsonRequestBehavior.AllowGet);
          
          
           
        }
      
        public ActionResult Add(Science model, string submit)
        {
            if (submit == "Thêm")
            {
                
                
                isThemMoi = true;
                if (model != null)
                {
                    model.Name = model.Name.ToString();
                    model.Address = model.Address.ToString();
                    model.Description = model.Description.ToString();
                    model.Founding = model.Founding;
                    model.CreatedDate = model.CreatedDate.GetValueOrDefault(System.DateTime.Now);   

                    db.Science.Add(model);
                    db.SaveChanges();
                    model = null;
                }
              
                return RedirectToAction("Index");
            }
            else if (submit == "Cập Nhật")
            {
                isThemMoi = false;
                if (model != null)
                {
                    var list = db.Science.SingleOrDefault(x => x.ID == model.ID);
                    list.Name = model.Name;
                    list.Address = model.Address.ToString();
                    list.Description = model.Description.ToString();
                    list.Founding = model.Founding;
                    list.ModifiedDate = model.CreatedDate.GetValueOrDefault(System.DateTime.Now);
                    db.SaveChanges();
                    model = null;
                }
                
                return RedirectToAction("Index");
            }
            else if (submit == "Tìm")
            {
                if (!string.IsNullOrEmpty(model.Name))
                {
                    List<Science> list = GetData().Where(s => s.Name.Contains(model.Name)).ToList();
                    return View("Index", list);
                }
                else
                {
                    List<Science> list = GetData();
                    return View("Index", list);
                }
            }
            else
            {
                List<Science> list = GetData().OrderBy(s => s.Name).ToList();
                return View("Index", list);
            }
        }
        public List<Science> GetData()
        {
            return db.Science.ToList();


        }
        public ActionResult Delete(int id)
        {
            new ScienseDao().Delete(id);
            return RedirectToAction("Index");
        }
      
    }
}