using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using QLBH.Models;
using System.Data;
using System.Data.Entity;

namespace QLBH.Controllers
{
    public class loaihanghoaController : Controller
    {
        QLBHDBContext db = new QLBHDBContext();
        // GET: loaihanghoa
        public ActionResult IndexLHH()
        {
            ViewBag.lhh = db.loaihanghoas;
            return View();
        }

        [HttpGet]
        public ActionResult themLHH()
        {
            return View();
        }

        [HttpPost]
        public ActionResult themLHH(loaihanghoa l)
        {
            db.loaihanghoas.Add(l);
            db.SaveChanges();
            return RedirectToAction("IndexLHH");
        }

        [HttpGet]
        public ActionResult suaLHH(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            loaihanghoa lhh = db.loaihanghoas.Find(id);
            if (lhh == null)
                return HttpNotFound();
            ViewBag.lhh = lhh;
            return View(lhh);
        }
        [HttpPost]
        public ActionResult suaLHH()
        {
            string ma = Request["maloai"].ToString();
            loaihanghoa lhh = db.loaihanghoas.Find(ma);
            if (lhh == null)
                return HttpNotFound();
            lhh.tenloai = Request["tenloai"].ToString();
            db.Entry(lhh).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("IndexLHH");
        }

        public ActionResult xoaLHH(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loaihanghoa l = db.loaihanghoas.Find(id);
            if (l == null)
            {
                return HttpNotFound();
            }
            ViewBag.lhh = l;
            return View(l);
        }
        [HttpPost, ActionName("xoaLHH")]
        public ActionResult xoaLHH_Post(string id)
        {
            loaihanghoa l = db.loaihanghoas.Find(id);
            db.loaihanghoas.Remove(l);
            db.SaveChanges();
            return RedirectToAction("IndexLHH");
        }
    }
}